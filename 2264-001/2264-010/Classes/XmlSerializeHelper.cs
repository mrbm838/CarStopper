using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace OP010
{
    public class XmlSerializeHelper<T> where T : class,new ()
    {
        /// <summary>
        /// 序列化文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="obj"></param>
        /// <exception cref="Exception"></exception>
        public static void SerializeToFile(string path,T obj)
        {
            try
            {
                FileInfo fi = new FileInfo(path);
                if (!Directory.Exists(fi.DirectoryName))
                {
                    Directory.CreateDirectory(fi.DirectoryName);
                }
                using (FileStream fs=new FileStream (path,FileMode.Create,FileAccess.ReadWrite,FileShare.ReadWrite))
                {
                    using (StreamWriter sw=new StreamWriter (fs))
                    {
                        XmlSerializer xs = new XmlSerializer(obj.GetType());
                        xs.Serialize(sw, obj);
                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.ToString());
            }
        }

        /// <summary>
        /// 反序列化文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T DeSerializeFronFile(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open,FileAccess.Read))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    return xs.Deserialize(fs) as T;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
