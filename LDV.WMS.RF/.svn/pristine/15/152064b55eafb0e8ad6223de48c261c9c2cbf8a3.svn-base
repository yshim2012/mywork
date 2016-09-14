using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace LDV.WMS.RF.Utility
{
    /// <summary>
    /// 序列化/反序列化工具类
    /// </summary>
    public static class Serializer
    {
        /// <summary>
        /// Binary格式的序列化
        /// </summary>
        /// <param name="obj">需要序列化的对象</param>
        /// <returns>返回值string</returns>
        public static string BinarySerialize(object obj)
        {
            Stream ms = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(ms, obj);

                byte[] b = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(b, 0, b.Length);

                string s = Convert.ToBase64String(b);
                return s;
            }
            catch (SerializationException e)
            {
                throw e;
            }
            finally
            {
                ms.Close();
            }

        }
       
        /// <summary>
        /// Binary格式的反序列化
        /// </summary>
        /// <param name="returnString">需要反序列化的string值</param>
        /// <returns>返回值，序列化后的对象</returns>
        public static object BinaryDeserialize(string returnString)
        {
            BinaryFormatter formatter;
            MemoryStream ms = null;
            try
            {
                formatter = new BinaryFormatter();

                byte[] b = Convert.FromBase64String(returnString);

                ms = new MemoryStream(b);

                object obj = formatter.Deserialize(ms);
                return obj;
            }
            catch (SerializationException e)
            {
                throw e;
            }
            finally
            {
                ms.Close();
            }
        }

    }
}
