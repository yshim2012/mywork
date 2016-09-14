using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace JJMC.Utility.WebChart
{
    /// <summary>
    /// 绘制两种颜色的长方形
    /// </summary>
    public class TwoColorBox
    {
        public void Render(int Width, int Heigth, Color c1, Color c2, int Color1Length, Stream target)
        {
            float fwidth = Convert.ToSingle(Width);
            float fheigth = Convert.ToSingle(Heigth);
            float fColor1Length = Convert.ToSingle(Color1Length);
            if (fColor1Length > fwidth)
            {
                fColor1Length = fwidth;
            }
            else if (fColor1Length < 0)
            {
                fColor1Length = 0;
            }


            Bitmap bm = new Bitmap(Width, Heigth);//设置大小            
            Graphics g = Graphics.FromImage(bm);
            g.SmoothingMode = SmoothingMode.HighSpeed;

            g.Clear(c1);
            Pen p = new Pen(c1);
            g.DrawRectangle(p, 0, 0, fwidth, fheigth);

            SolidBrush Brush1 = new SolidBrush(c1);
            g.FillRectangle(Brush1, 0, 0, fwidth, fColor1Length);
            Brush1.Dispose();
            Brush1 = new SolidBrush(c2);
            g.FillRectangle(Brush1, fColor1Length, 0, fwidth - fColor1Length, fheigth);

            bm.Save(target, ImageFormat.Jpeg);
            bm.Dispose();
            g.Dispose();
        }

        public void Render(int Width, int Heigth, string color1, string color2, int Color1Length, Stream target)
        {
            RGB16 rgb = new RGB16();
            Color c1 = rgb.S16ToColor(color1);
            Color c2 = rgb.S16ToColor(color2);
            Render(Width, Heigth, c1, c2, Color1Length, target);
        }
    }
}
