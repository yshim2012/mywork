using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SalesPoint.Device.Scan;
using SalesPoint.Device.Core;
using System.Threading;

namespace YTWMS.RFStart
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 131)
            {
                //二维头(UTF8码制请改成UTF-8,OENCP码制请改成GB2312。。。)
                //string strPart = Scanner.StartScanDim2(ScanType.MotorSound);
                //string strPart1 = Scanner.StartScanDim2(ScanType.MotorSound, Encoding.ASCII);
                //string strPart11 = Scanner.StartScanDim2(ScanType.MotorSound, Encoding.Unicode);
                //string strPart12 = Scanner.StartScanDim2(ScanType.MotorSound, Encoding.BigEndianUnicode);
                //string strPart2 = Scanner.StartScanDim2(ScanType.MotorSound, Encoding.UTF7);
                //string strPart3 = Scanner.StartScanDim2(ScanType.MotorSound, Encoding.UTF8);
                string strPart4 = Scanner.StartScanDim2(ScanType.MotorSound, Encoding.UTF8);
                //string strPart5 = Scanner.StartScanDim2(ScanType.MotorSound);


                byte[] b = System.Text.Encoding.UTF8.GetBytes(strPart4);

                //string strPart13331 = Scanner.StartScanDim2(ScanType.MotorSound);
               // this.textBox1.Text = strPart3.Substring(strPart3.IndexOf("XP") + 3, strPart3.IndexOf("12V") - strPart3.IndexOf("XP") - 2); 
                //this.textBox1.Text = strPart4.Substring(strPart4.IndexOf("XP") + 3, strPart4.IndexOf("12V") - strPart4.IndexOf("XP") - 2);
                //if (strPart4.Length <= 0)
                //    return;

                //if (strPart4.Length < 20)
                //{
                //    ////一维码不存在零件号，条码第3,4,5,6 为零件号的后四位，特殊处理；
                //    string str = strPart4.Substring(2, 4);
                //    if ("9016650".IndexOf(str) > 0)
                //    {
                //        this.textBox1.Text = "9016650";
                //    }
                //    else if ("9016651".IndexOf(str) > 0)
                //    {
                //        this.textBox1.Text = "9016651";
                //    }
                //    else if ("9039093".IndexOf(str) > 0)
                //    {
                //        this.textBox1.Text = "9039093";
                //    }
                //    else if ("9040274".IndexOf(str) > 0)
                //    {
                //        this.textBox1.Text = "9040274";
                //    }
                //    else if ("24103001".IndexOf(str) > 0)
                //    {
                //        this.textBox1.Text = "24103001";
                //    }
                //   ///this.textBox1.Text = string.Empty;
                }
                else
                {
                    //this.textBox1.Text = strPart4.Substring(strPart4.IndexOf("XP") + 3, 8);
                }
            }

        private void Form2_Closing(object sender, CancelEventArgs e)
        {
            try
            {
                Scanner.Deinitilize();//释放扫描头
                Thread.Sleep(500);
                Sys.Deinitilize();//释放硬件
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message.ToString());
                return;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Sys.Initilize(); //硬件初始化
            Scanner.Initilize();
            Thread.Sleep(500);
            //Scanner.Initilize();//扫描头初始化
            //Scanner.StartScanDim2(ScanType.MotorSound);
         
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            //二维头(UTF8码制请改成UTF-8,OENCP码制请改成GB2312。。。)
            string strPart = Scanner.StartScan(ScanType.MotorSound);
            if (strPart == string.Empty)
                return;

            this.textBox1.Text = strPart;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void tbxCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 131)
            {
             
                ////if(this.comboBox1.SelectedText=="UTF8")
                ////{
                ////    this.tbxCode.Text=Scanner.StartScanDim2(ScanType.MotorSound, Encoding.UTF8);
                ////}
                ////else if(this.comboBox1.SelectedText=="UTF7")
                ////{
                ////    this.tbxCode.Text=Scanner.StartScanDim2(ScanType.MotorSound, Encoding.UTF8);
                ////}
                ////二维头(UTF8码制请改成UTF-8,OENCP码制请改成GB2312。。。)
                ////string strPart = Scanner.StartScanDim2(ScanType.MotorSound);
                ////string strPart1 = Scanner.StartScanDim2(ScanType.MotorSound, Encoding.ASCII);
                ////string strPart11 = Scanner.StartScanDim2(ScanType.MotorSound, Encoding.Unicode);
                ////string strPart12 = Scanner.StartScanDim2(ScanType.MotorSound, Encoding.BigEndianUnicode);
                ////string strPart2 = Scanner.StartScanDim2(ScanType.MotorSound, Encoding.UTF7);
                ////string strPart3 = Scanner.StartScanDim2(ScanType.MotorSound, Encoding.UTF8);
                //string strPart4 = Scanner.StartScanDim2(ScanType.MotorSound, Encoding.GetEncoding("GB2312"));
                ////string strPart5 = Scanner.StartScanDim2(ScanType.MotorSound);


                ////string strPart13331 = Scanner.StartScanDim2(ScanType.MotorSound);
                //// this.textBox1.Text = strPart3.Substring(strPart3.IndexOf("XP") + 3, strPart3.IndexOf("12V") - strPart3.IndexOf("XP") - 2); 
                ////this.textBox1.Text = strPart4.Substring(strPart4.IndexOf("XP") + 3, strPart4.IndexOf("12V") - strPart4.IndexOf("XP") - 2);
               
                //}
                //else
                //{
                //    this.textBox1.Text = strPart4.Substring(strPart4.IndexOf("XP") + 3, 8);
                //}
            }
        }
    }
}