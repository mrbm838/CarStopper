using Cognex.VisionPro;
using ReadAndWriteConfigSystem;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cowain
{
    public class ImageClass
    {
        public Object image1;
        public string fullPath1;
        /// <summary>
        /// 拍照的指令
        /// </summary>
        public string cmd;
        public ImageClass(Object image, string fullPath, string cmd1)
        {
            image1 = image;
            fullPath1 = fullPath;
            cmd = cmd1;
        }
    }
    public class SaveImage
    {
        public static ConcurrentQueue<ImageClass> CMDQueue = new ConcurrentQueue<ImageClass>();
        private static SaveImage instace;
        private Thread thread;
        public static Dictionary<string, string[]> cmdSaveImages = new Dictionary<string, string[]>();
        public SaveImage()
        {
            thread = new Thread(autoSaveImage);
            thread.IsBackground = true;
            thread.Priority = ThreadPriority.Lowest;
            thread.Start();
            getCMDSaveImageDictionary();
        }
        public static void getCMDSaveImageDictionary()
        {
            cmdSaveImages.Clear();
            List<string> lists = ConfigHelperSystem.GetAllKey("SaveImageSet");
            for (int i = 0; i < lists.Count; i++)
            {
                string cmd = ConfigHelperSystem.GetAppConfig("SaveImageSet", lists[i], "CMD");
                string saveBMP = ConfigHelperSystem.GetAppConfig("SaveImageSet", lists[i], "SaveBMP");
                string saveJPG = ConfigHelperSystem.GetAppConfig("SaveImageSet", lists[i], "SaveJPG");
                cmdSaveImages.Add(cmd, new string[] { saveBMP, saveJPG });
            }
        }
        public static void getCMDSaveImage(string cmd, ref bool b_SaveBMPImage, ref bool b_SaveJPGImage)
        {
            if (cmdSaveImages.Keys.Contains(cmd))
            {
                b_SaveBMPImage = cmdSaveImages[cmd][0] == "1" ? true : false;
                b_SaveJPGImage = cmdSaveImages[cmd][1] == "1" ? true : false;
            }
            else
            {
                b_SaveBMPImage = true;
                b_SaveJPGImage = true;
            }
        }

        private void autoSaveImage()
        {
            while (true)
            {
                if (CMDQueue.IsEmpty != true)
                {
                    ImageClass image = dequeueCMD();
                    //判断是否保存
                    bool b_SaveBMP = false, b_SaveJPG = false, b_CMDSaveBMP = false, b_CMDSaveJPG = false;

                    b_SaveBMP = ConfigHelperSystem.GetAppConfig("Vision", "SaveBMPImage") == "1" ? true : false;
                    b_SaveJPG = ConfigHelperSystem.GetAppConfig("Vision", "SaveJPGImage") == "1" ? true : false;
                    getCMDSaveImage(image.cmd, ref b_CMDSaveBMP, ref b_CMDSaveJPG);
                    try
                    {
                        int index = image.fullPath1.LastIndexOf('\\');
                        string dirPath = image.fullPath1.Substring(0, index);
                        if (!Directory.Exists(dirPath))
                        {
                            Directory.CreateDirectory(dirPath);
                        }
                        if (image.image1 is CogImage8Grey)
                        {
                            if (b_SaveBMP && b_CMDSaveBMP)
                            {
                                Vision.Vision.saveRawImage(image.fullPath1, (CogImage8Grey)image.image1);
                            }
                        }
                        else if (image.image1 is Image)
                        {
                            if (b_SaveJPG && b_CMDSaveJPG)
                            {
                                Vision.Vision.saveJPGImage(image.fullPath1, (Image)image.image1);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        LogClass.addMSG("在存图时发生异常：" + e.ToString() + "\r\n存图路径：" + image.fullPath1, LogType.Error);
                    }
                }
                else
                {
                    Thread.Sleep(1);
                }
            }
        }
        public static SaveImage CreateInstance()
        {
            if (instace == null)
            {
                instace = new SaveImage();
            }
            return instace;
        }
        public static void addImage(ImageClass iamgeClass)
        {
            CMDQueue.Enqueue(iamgeClass);
        }
        public static ImageClass dequeueCMD()
        {
            ImageClass cmd = null;
            CMDQueue.TryDequeue(out cmd);
            return cmd;
        }
    }
}
