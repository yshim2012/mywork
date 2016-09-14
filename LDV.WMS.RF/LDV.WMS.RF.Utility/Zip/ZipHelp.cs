using System;
using System.Collections.Generic;
using System.IO;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;


namespace LDV.WMS.RF.Utility
{
   public class ZipHelp
    {
        #region 压缩
        /// <summary>  
        ///  压缩多个文件  
        /// </summary>  
        /// <param name="files">文件名</param>  
        /// <param name="ZipedFileName">压缩包文件名</param>  
        /// <param name="Password">解压码</param>  
        /// <returns></returns>  
        public static void Zip(List<string> files, string ZipedFileName, string Password)
        {
            foreach (string f in files)
            {
                if (!File.Exists(f))
                    throw new FileNotFoundException("未找到指定的文件夹");
            }

            //files = files.Where(f => File.Exists(f)).ToArray();   
            //if (files.Length == 0) throw new FileNotFoundException("未找到指定打包的文件");  
            ZipOutputStream s = new ZipOutputStream(File.Create(ZipedFileName));
            s.SetLevel(6);
            //if (!string.IsNullOrEmpty(Password.Trim())) 
            //    s.Password = Password.Trim();  
            ZipFileDictory(files, s);
            s.Finish();
            s.Close();
        }

        /// <summary>  
        ///  压缩多个文件  
        /// </summary>  
        /// <param name="files">文件名</param>  
        /// <param name="ZipedFileName">压缩包文件名</param>  
        /// <returns></returns>  
        public static void Zip(List<string> files, string ZipedFileName)
        {
            Zip(files, ZipedFileName, string.Empty);
        }

        private static void ZipFileDictory(List<string> files, ZipOutputStream s)
        {
            ZipEntry entry = null;
            FileStream fs = null;
            Crc32 crc = new Crc32();
            try
            {
                ////创建当前文件夹  
                entry = new ZipEntry("/");  //加上 “/” 才会当成是文件夹创建  
                s.PutNextEntry(entry);
                s.Flush();
                foreach (string file in files)
                {
                    //打开压缩文件  
                    fs = File.OpenRead(file);

                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    entry = new ZipEntry(Path.GetFileName(file));
                    entry.DateTime = DateTime.Now;
                    entry.Size = fs.Length;
                    entry.IsUnicodeText = true;
                    fs.Close();
                    crc.Reset();
                    crc.Update(buffer);
                    entry.Crc = crc.Value;
                    s.PutNextEntry(entry);
                    s.Write(buffer, 0, buffer.Length);
                }
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs = null;
                }
                if (entry != null)
                    entry = null;
                GC.Collect();
            }
        }
        #endregion

        #region 解压缩
        /// <summary>
        /// 功能：解压zip格式的文件。
        /// </summary>
        /// <param name="zipFilePath">压缩文件路径</param>
        /// <param name="unZipDir">解压文件存放路径,为空时默认与压缩文件同一级目录下，跟压缩文件同名的文件夹</param>
        /// <param name="err">出错信息</param>
        /// <returns>解压是否成功</returns>
        public static void UnZip(string zipFilePath, string unZipDir)
        {
            if (zipFilePath == string.Empty)
            {
                throw new Exception("压缩文件不能为空！");
            }
            if (!File.Exists(zipFilePath))
            {
                throw new System.IO.FileNotFoundException("压缩文件不存在！");
            }
            //解压文件夹为空时默认与压缩文件同一级目录下，跟压缩文件同名的文件夹
            if (unZipDir == string.Empty)
                unZipDir = zipFilePath.Replace(Path.GetFileName(zipFilePath), Path.GetFileNameWithoutExtension(zipFilePath));
            if (!unZipDir.EndsWith("\\"))
                unZipDir += "\\";
            if (!Directory.Exists(unZipDir))
                Directory.CreateDirectory(unZipDir);

            using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipFilePath)))
            {

                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string directoryName = Path.GetDirectoryName(theEntry.Name);
                    string fileName = Path.GetFileName(theEntry.Name);
                    if (directoryName.Length > 0)
                    {
                        Directory.CreateDirectory(unZipDir + directoryName);
                    }
                    if (!directoryName.EndsWith("\\"))
                        directoryName += "\\";
                    if (fileName != String.Empty)
                    {
                        using (FileStream streamWriter = File.Create(unZipDir + theEntry.Name))
                        {

                            int size = 2048;
                            byte[] data = new byte[2048];
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    streamWriter.Write(data, 0, size);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
