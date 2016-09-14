/******************************************************
FileName: JsonSerializationHandler.cs
Copyright: L&T Tech.
Writer: 王峥
Create Date: 2013-10-29
******************************************************/

using System;
using System.IO;
using Newtonsoft.Json;

namespace LDV.WMS.RF.Utility
{
    /// <summary>
    /// Json序列化反序列化工具类
    /// </summary>
    public static class JsonSerializationHandler
    {
        /// <summary>  
        /// 序列化数据为Json格式的数据
        /// </summary>  
        /// <typeparam name="T">序列化对象的泛型类型</typeparam>
        /// <param name="t">数据对象</param>  
        /// <returns>Json格式的数据</returns>  
        public static string Serialize<T>(T t)
        {
            Type type = t.GetType();

            var json = new JsonSerializer();
            json.NullValueHandling = NullValueHandling.Include;
            json.ObjectCreationHandling = Newtonsoft.Json.ObjectCreationHandling.Replace;
            json.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;
            json.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            using(var stringWriter = new StringWriter())
            {
                using (var jsonWriter = new JsonTextWriter(stringWriter))
                {
                    jsonWriter.Formatting = Formatting.None;
                    jsonWriter.QuoteChar = '"';
                    json.Serialize(jsonWriter, t);

                    var jsonString = stringWriter.ToString();

                    return jsonString;
                }
            }
        }

        /// <summary>  
        /// 反序列化Json格式数据
        /// </summary>
        /// <typeparam name="T">反序列化对象的泛型类型</typeparam>
        /// <param name="jsonString">Json格式数据</param>  
        /// <returns>数据对象</returns>  
        public static T Deserialize<T>(string jsonString)
        {
            var json = new JsonSerializer();
            json.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include;
            json.ObjectCreationHandling = Newtonsoft.Json.ObjectCreationHandling.Replace;
            json.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;
            json.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            using (var stringReader = new StringReader(jsonString))
            {
                using (var jsonReader = new JsonTextReader(stringReader))
                {
                    T result = json.Deserialize<T>(jsonReader);
                    return result;
                }
            }
        }  
    }
}
