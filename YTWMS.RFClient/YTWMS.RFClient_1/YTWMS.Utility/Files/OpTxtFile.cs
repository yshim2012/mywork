using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JJMC.Utility
{
    /// <summary>
    /// 文本文件操作类
    /// </summary>
    public class OpTxtFile
    {
        #region 属性
        private string _FileFullPath;
        /// <summary>
        /// 文件全路径
        /// </summary>
        public string FileFullPath
        {
            get { return _FileFullPath; }
            set { _FileFullPath = value; }
        }
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public OpTxtFile()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="FileFullPath"></param>
        public OpTxtFile(string FileFullPath)
        {
            this._FileFullPath = FileFullPath;
        }
        #endregion

        /// <summary>
        /// 得到所有的文件名
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllFileNames()
        {
            try
            {
                DirectoryInfo dicInfo = new DirectoryInfo(this._FileFullPath);
                FileInfo[] fils = dicInfo.GetFiles("*.*");

                List<string> FileNames = new List<string>();
                foreach (FileInfo f in fils)
                {
                    FileNames.Add(f.Name);
                }

                return FileNames;
            }
            catch (Exception ex)
            {
                throw new Exception("Read file names err:" + ex.Message);
            }
        }

        /// <summary>
        /// 得到所有的文件名
        /// </summary>
        /// <param name="FileType">文件类型</param>
        /// <returns></returns>
        public List<string> GetAllFileNames(string FileType)
        {
            try
            {
                DirectoryInfo dicInfo = new DirectoryInfo(this._FileFullPath);
                FileInfo[] fils = dicInfo.GetFiles("*." + FileType);

                List<string> FileNames = new List<string>();
                foreach (FileInfo f in fils)
                {
                    FileNames.Add(f.Name);
                }

                return FileNames;
            }
            catch (Exception ex)
            {
                throw new Exception("Read file names err:" + ex.Message);
            }
        }

        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="FileName">要移动文件的文件名</param>
        public void MoveFile(string FileName, string MoveToPath)
        {
            try
            {
                if (!Directory.Exists(MoveToPath))
                    Directory.CreateDirectory(MoveToPath);

                File.Move(this._FileFullPath + "\\" + FileName, MoveToPath + "\\" + FileName);
            }
            catch (Exception ex)
            {
                throw new Exception("Move file err:" + ex.Message);
            }
        }

        /// <summary>
        /// 按行读取数据
        /// </summary>
        /// <param name="FileName">文件名</param>
        /// <returns></returns>
        public List<string> GetDataByLine(string FileName)
        {
            try
            {
                StreamReader txtRead = new StreamReader(this._FileFullPath + "\\" + FileName);
                List<string> contents = new List<string>();

                while (!txtRead.EndOfStream)
                {
                    string sLine = txtRead.ReadLine();
                    if (!string.IsNullOrEmpty(sLine))
                        contents.Add(sLine);
                }
                txtRead.Close();

                return contents;
            }
            catch (Exception ex)
            {
                throw new Exception("Read file by line err:" + ex.Message);
            }
        }

        /// <summary>
        /// 生成文件
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <param name="FileName">文件名</param>
        /// <param name="contents">内容</param>
        public void CreateTxtFile(string FilePath, string FileName, List<string> contents)
        {
            if (string.IsNullOrEmpty(FilePath) || string.IsNullOrEmpty(FileName))
                throw new Exception("No FilePath or File Name");

            if (!Directory.Exists(FilePath))
                Directory.CreateDirectory(FilePath);

            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                fs = new FileStream(FilePath + "\\" + FileName, FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);

                foreach (string con in contents)
                {
                    sw.WriteLine(con);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sw != null)
                    sw.Close();
                if (fs != null)
                    fs.Close();
            }
        }

        /// <summary>
        /// 生成文件
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <param name="FileName">文件名</param>
        /// <param name="contents">内容</param>
        public static void CreateTxtFile(string FilePath, string FileName,string Content)
        {
            if (string.IsNullOrEmpty(FilePath) || string.IsNullOrEmpty(FileName))
                throw new Exception("No FilePath or File Name");

            if (!Directory.Exists(FilePath))
                Directory.CreateDirectory(FilePath);

            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                fs = new FileStream(FilePath + "\\" + FileName, FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);

                sw.Write(Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sw != null)
                    sw.Close();
                if (fs != null)
                    fs.Close();
            }
        }


        /// <summary>
        /// 追加内容
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="FileName"></param>
        /// <param name="contents"></param>
        public void AppendText(string FilePath, string FileName, string contents)
        {
            if (string.IsNullOrEmpty(FilePath) || string.IsNullOrEmpty(FileName))
                throw new Exception("No FilePath or File Name");

            string FullPath = FilePath + "\\" + FileName;
            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                if (!Directory.Exists(FilePath))
                    Directory.CreateDirectory(FilePath);

                fs = new FileStream(FullPath, FileMode.Append, FileAccess.Write);
                sw = new StreamWriter(fs);

                sw.WriteLine(contents);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sw != null)
                    sw.Close();
                if (fs != null)
                    fs.Close();
            }
        }

        /// <summary>
        /// 删除这个目录下的所有文件
        /// </summary>
        /// <param name="FilePath"></param>
        public void DeleteALLFile(string FilePath)
        {
            if (string.IsNullOrEmpty(FilePath))
                throw new Exception("No FilePath");

            try
            {
                if (Directory.Exists(FilePath))
                {
                    string[] fils = Directory.GetFiles(FilePath);
                    foreach (string fi in fils)
                    {
                        File.Delete(fi);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除指定路径的文件
        /// </summary>
        /// <param name="FilePath"></param>
        public void DeleteFile(string FilePath)
        {
            if(string.IsNullOrEmpty(FilePath))
                throw new Exception("No FilePath");
            try
            {
                if(File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 文件是否存在
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool IsFileExist(string FilePath, string FileName)
        {
            if (string.IsNullOrEmpty(FilePath))
                throw new Exception("No FilePath");

            return File.Exists(FilePath + "\\" + FileName);
        }
    }
}
