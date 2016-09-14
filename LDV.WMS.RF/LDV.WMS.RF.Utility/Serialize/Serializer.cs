using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace LDV.WMS.RF.Utility
{
    /// <summary>
    /// ���л�/�����л�������
    /// </summary>
    public static class Serializer
    {
        /// <summary>
        /// Binary��ʽ�����л�
        /// </summary>
        /// <param name="obj">��Ҫ���л��Ķ���</param>
        /// <returns>����ֵstring</returns>
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
        /// Binary��ʽ�ķ����л�
        /// </summary>
        /// <param name="returnString">��Ҫ�����л���stringֵ</param>
        /// <returns>����ֵ�����л���Ķ���</returns>
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
