using System;
using System.Drawing;

namespace JJMC.Utility
{
    public class BarCode
    {
        /// <summary>
        /// 生成BARCODE，保存到指定文件
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="Path"></param>
        public void CreateImage(string Code, string Path, int Width, int Hight)
        {
            BARCODEXLib.CBarcodeXClass bc = new BARCODEXLib.CBarcodeXClass();
            bc.CreateBMP(Path, 8, Code, 1, Width, Hight, 1, "Arial", 14, 16777215, 0);
        }
    }
}
