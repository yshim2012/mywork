using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace JJMC.Utility.WebChart
{
    /// <summary>
    /// RGB、16进制、Color互相转换类
    /// </summary>
    public class RGB16
    {
        /// <summary>
        /// 将16进制转换为Color
        /// </summary>
        /// <param name="S16"></param>
        /// <returns></returns>
        public Color S16ToColor(string S16)
        {
            try
            {
                int r = Convert.ToInt32("0x" + S16.Substring(1, 2), 16);
                int g = Convert.ToInt32("0x" + S16.Substring(3, 2), 16);
                int b = Convert.ToInt32("0x" + S16.Substring(5, 2), 16);

                return Color.FromArgb(r, g, b);
            }
            catch (Exception)
            {
                throw new Exception(S16 + "：不是有效的16进制字符串");
            }
        }
    }
}
