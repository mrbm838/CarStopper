using NPOI.HSSF.UserModel;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cowain
{
    public enum DataType
    {
        TXT,
        CSV,
        XLS,
    }
    public class SaveData
    {
        /// <summary>
        /// 保存XLS和CSV类型时，存储数据的键值对
        /// </summary>
        public Dictionary<string, object> myDictionary;
        /// <summary>
        /// 保存数据的类型
        /// </summary>
        public DataType dataType;
        /// <summary>
        /// 添加键的事件
        /// </summary>
        public event Action addKeyevent;
        /// <summary>
        /// 文件夹的路径
        /// </summary>
        public string directoryPath;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataType1">保存数据的类型</param>
        /// <param name="directoryPath1">保存数据的文件夹</param>
        public SaveData(DataType dataType1, string directoryPath1)
        {
            dataType = dataType1;
            directoryPath = directoryPath1;
            myDictionary = new Dictionary<string, object>();
        }
        public void save()
        {
            if (dataType == DataType.XLS)
            {
                WriteDataToExcel(myDictionary);
            }
            else
            {
                string fileName = string.Format("{0}.csv", DateTime.Now.ToString("yyyy_MM_dd"));
                SaveCSV(fileName, myDictionary);
            }
            myDictionary.Clear();
            addKeyevent?.Invoke();
        }
        public void AddValue(string key, object value)
        {
            if (myDictionary.Keys.Count == 0)
            {
                addKeyevent?.Invoke();
            }
            foreach (KeyValuePair<string, object> kv in myDictionary)
            {
                if (kv.Key == key)
                {
                    myDictionary[kv.Key] = value;
                    return;
                }
            }
        }
        public void AddKey(string key, object value)
        {
           myDictionary.Add(key, value);
        }
        public void SaveLog(string SaveMSG)
        {
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                string fileName;
                fileName = string.Format("{0}.txt", DateTime.Now.ToString("yyyy_MM_dd"));
                string fullFileName = Path.Combine(directoryPath, fileName);
                System.IO.FileStream fs;
                StreamWriter sw;
                fs = new System.IO.FileStream(fullFileName, System.IO.FileMode.Append, System.IO.FileAccess.Write, FileShare.Read);
                sw = new StreamWriter(fs, System.Text.Encoding.Default);
                sw.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff") + "," + SaveMSG);
                sw.Close();
                fs.Close();
            }
            catch
            {
            }
        }
        public void SaveLog(string pathName, string SaveMSG)
        {
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                string fullFileName = Path.Combine(directoryPath, pathName);
                System.IO.FileStream fs;
                StreamWriter sw;
                fs = new System.IO.FileStream(fullFileName, System.IO.FileMode.Append, System.IO.FileAccess.Write, FileShare.Read);
                sw = new StreamWriter(fs, System.Text.Encoding.Default);
                sw.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff") + "," + SaveMSG);
                sw.Close();
                fs.Close();
            }
            catch
            {
            }
        }
        public void SaveCSV(string pathName, Dictionary<string, Object> saveData)
        {
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                string fullFileName = Path.Combine(directoryPath, pathName);
                string key_TXT = "";
                string value_TXT = "";
                foreach (KeyValuePair<string, object> item in myDictionary)
                {
                    key_TXT += item.Key + ",";
                    value_TXT += item.Value.ToString() + ",";
                }
                bool b_FileExist = File.Exists(fullFileName);
                System.IO.FileStream fs;
                StreamWriter sw;
                fs = new System.IO.FileStream(fullFileName, System.IO.FileMode.Append, System.IO.FileAccess.Write, FileShare.Read);
                sw = new StreamWriter(fs, System.Text.Encoding.Default);
                if (b_FileExist != true)//保存文件头
                {
                    sw.WriteLine(key_TXT);
                    sw.WriteLine(value_TXT);
                }
                else
                {
                    sw.WriteLine(value_TXT);
                }
                sw.Close();
                fs.Close();
            }
            catch
            {
            }
        }
        private void WriteDataToExcel(Dictionary<string, Object> saveData)
        {
            string fileName;
            fileName = string.Format("{0}.xls", DateTime.Now.ToString("yyyy_MM_dd"));
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            string excelPath = Path.Combine(directoryPath, fileName);
            try
            {
                if (!File.Exists(excelPath))
                {
                    IWorkbook objIWorkbook = new HSSFWorkbook();
                    ISheet objISheet = objIWorkbook.CreateSheet();
                    IRow row = objISheet.CreateRow(0);
                    int i = 0;
                    foreach (KeyValuePair<string, Object> kv in saveData)
                    {
                        row.CreateCell(i).SetCellValue(kv.Key);
                        i++;
                    }
                    using (FileStream fs = new FileStream(excelPath, FileMode.Append, FileAccess.Write))
                    {
                        objIWorkbook.Write(fs);
                    }
                }
            }
            catch
            { }
            try
            {
                using (FileStream fs = new FileStream(excelPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)) //读取流
                {
                    POIFSFileSystem ps = new POIFSFileSystem(fs);//需using NPOI.POIFS.FileSystem;
                    IWorkbook workbook = new HSSFWorkbook(ps);
                    ISheet sheet = workbook.GetSheetAt(0);//获取工作表
                    IRow row = sheet.GetRow(0); //得到表头
                    using (FileStream fout = new FileStream(excelPath, FileMode.Open, FileAccess.Write, FileShare.ReadWrite))//写入流
                    {
                        row = sheet.CreateRow((sheet.LastRowNum + 1));//在工作表中添加一行
                        int n = 0;
                        foreach (KeyValuePair<string, Object> kv in saveData)
                        {
                            string ss = kv.Value.GetType().Name;
                            if (kv.Value.GetType().Name == "String")
                            {
                                row.CreateCell(n).SetCellValue((string)kv.Value);
                            }

                            else if (kv.Value.GetType().Name == "Double")
                            {
                                row.CreateCell(n).SetCellValue((double)kv.Value);
                            }
                            else
                            {
                                row.CreateCell(n).SetCellValue((int)kv.Value);
                            }
                            n++;
                        }
                        fout.Flush();
                        workbook.Write(fout);//写入文件
                        workbook = null;
                        fout.Close();
                    }
                }
            }
            catch
            {

            }
        }
    }
}
