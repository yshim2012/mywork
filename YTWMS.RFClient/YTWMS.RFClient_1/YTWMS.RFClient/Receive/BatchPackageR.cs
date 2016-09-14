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
using CodeBetter.Json;

namespace YTWMS.RFClient
{
    public partial class BatchPackageR : Form
    {
        public BatchPackageR()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 收货确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReceive_Click(object sender, EventArgs e)
        {
            try
            {
                #region  验证
                if (this.tbxStartNo.Text == string.Empty)
                {
                    this.lbMessage.Text = "起始箱号不能为空!";
                    this.tbxStartNo.Focus();
                    return;
                }
                if (this.tbxEndNo.Text == string.Empty)
                {
                    this.lbMessage.Text = "结束箱号不能为空!";
                    this.tbxEndNo.Focus();
                    return;
                }
                if (this.tbxPartNo.Text == string.Empty)
                {
                    this.lbMessage.Text = "零件号不能为空!";
                    this.tbxPartNo.Focus();
                    return;
                }
                if (this.tboxQty.Text == string.Empty)
                {
                    this.lbMessage.Text = "数量不能为空!";
                    this.tboxQty.Focus();
                    return;
                }
                if (this.tbxBach.Text == string.Empty)
                {
                    this.lbMessage.Text = "批次不能为空!";
                    this.tbxBach.Focus();
                    return;
                }
                if (this.cmbProject.SelectedValue.ToString() == string.Empty)
                {
                    this.lbMessage.Text = "请选择项目!";
                    return;
                }
                #endregion

                LoginInfo info = LoginInfo.GetInstance();
                IList<BoxInfo> boxList = new List<BoxInfo>();
                BoxInfo box;
                decimal indexStart = Convert.ToDecimal(this.tbxStartNo.Text.Substring(2));
                decimal indexEnd = Convert.ToDecimal(this.tbxEndNo.Text.Substring(2));

                if (indexStart > indexEnd)
                {
                    this.lbMessage.Text = "结束箱号要大于箱号!";
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                for (decimal i = indexStart; i <= indexEnd; i++)
                {
                    box = new BoxInfo();
                    box.BATCH_NO = this.tbxBach.Text.Trim();
                    box.BOX_CODE = tbxStartNo.Text.Substring(0, 2) + i.ToString();
                    box.FURNACE_NO = string.Empty;
                    box.PART_CODE = this.tbxPartNo.Text.Trim();
                    box.PROJECT_ID = Convert.ToInt32(this.cmbProject.SelectedValue.ToString());
                    box.PROJECT_ITEM_ID = 0;
                    box.QTY = Convert.ToInt32(this.tboxQty.Text);

                    boxList.Add(box);
                }

                string boxJson = Converter.Serialize(boxList);

                string strMessage = ExceService.PackageReceive(this.tbxDocument.Text.Trim(), info.LoginUser.ID, boxJson, info.LoginUser.WAREHOUSE_ID);
                MessageInfo Message = Converter.Deserialize<MessageInfo>(strMessage);
                Cursor.Current = Cursors.Default;
                if (Message.ResultState == "Succes")
                {
                    this.tbxDocument.Text = string.Empty;
                    this.tbxStartNo.Text = string.Empty;
                    this.tbxEndNo.Text = string.Empty;
                    this.tbxPartNo.Text = string.Empty;
                    this.tboxQty.Text = string.Empty;
                    this.tbxPartNo.Text = string.Empty;
                    this.lbMessage.Text = string.Empty;
                    MessageBox.Show("收货成功！");
                }
                else
                {
                    this.lbMessage.Text = Message.Info;
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                if (!ExceService.CheckService())
                {
                    this.lbMessage.Text = "无法连接到服务器";
                }
                else
                    MessageBox.Show("Error:" + ex.ToString());
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BatchPackageR_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                BindingSource bs = new BindingSource();
                bs.DataSource = BaseInfo.ProjectList;
                this.cmbProject.DataSource = bs;
                this.cmbProject.ValueMember = "Value";
                this.cmbProject.DisplayMember = "Key";
                this.tbxBach.Text = DateTime.Now.ToString("yyyyMMdd").Substring(2);

                Sys.Initilize(); //硬件初始化
                Scanner.Initilize();
                Thread.Sleep(500);

                this.lbMessage.Text = string.Empty;
                this.tbxStartNo.Focus();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化错误:" + ex.Message);
            }
        }

        /// <summary>
        /// 起始箱号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxStartNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.KeyValue == 131)
                {
                    //二维头(UTF8码制请改成UTF-8,OENCP码制请改成GB2312。。。)
                    string strCode = Scanner.StartScanDim2(ScanType.MotorSound, Encoding.UTF8);
                    if (strCode == string.Empty)
                    {
                        Cursor.Current = Cursors.Default;
                        this.lbMessage.Text = "扫描有效箱号";
                        this.tbxStartNo.Text = string.Empty;
                        return;
                    }

                    strCode = ExceService.FilterByte(strCode);
                    //修改by mjy 2016-8-30 判断一维码
                    if (strCode.Split('-').Length == 3)
                    {
                        string strPart = strCode.Split('-')[0].ToString();
                        if (this.tbxPartNo.Text == string.Empty)
                        {
                            this.lbMessage.Text = string.Empty;
                            this.tbxPartNo.Text = strPart;
                        }
                        else if (this.tbxPartNo.Text != strPart)
                        {
                            Cursor.Current = Cursors.Default;
                            this.lbMessage.Text = "箱号零件不一致！";
                            this.tbxStartNo.Text = string.Empty;
                            this.tbxStartNo.Focus();
                            return;
                        }

                        string strQty = strCode.Split('-')[1].ToString();
                        if (this.tboxQty.Text == string.Empty)
                        {
                            this.lbMessage.Text = string.Empty;
                            this.tboxQty.Text = strQty;
                        }
                        else if (this.tboxQty.Text != strQty)
                        {
                            Cursor.Current = Cursors.Default;
                            this.lbMessage.Text = "箱号包装数量不一致！";
                            this.tbxStartNo.Text = string.Empty;
                            this.tbxStartNo.Focus();
                            return;
                        }

                        string strBox = strCode.Split('-')[2].ToString();
                        if (strBox == this.tbxEndNo.Text)
                        {
                            Cursor.Current = Cursors.Default;
                            this.lbMessage.Text = "起始/结束箱号不能相同！";
                            this.tbxStartNo.Text = string.Empty;
                            this.tbxStartNo.Focus();
                            return;
                        }
                        this.tbxStartNo.Text = strBox;

                    }
                    else
                    {
                        if (!ExceService.IsBoxFormart(strCode))
                        {
                            Cursor.Current = Cursors.Default;
                            this.tbxStartNo.Focus();
                            return;
                        }

                        if (strCode.Split(' ').Length > 5)
                        {
                            string strPart = strCode.Split(' ')[2].Substring(1).ToString();
                            if (this.tbxPartNo.Text == string.Empty)
                            {
                                this.lbMessage.Text = string.Empty;
                                this.tbxPartNo.Text = strPart;
                            }
                            else if (this.tbxPartNo.Text != strPart)
                            {
                                Cursor.Current = Cursors.Default;
                                this.lbMessage.Text = "箱号零件不一致！";
                                this.tbxStartNo.Text = string.Empty;
                                this.tbxStartNo.Focus();
                                return;
                            }

                            string strQty = strCode.Split(' ')[3].Substring(1).ToString();
                            if (this.tboxQty.Text == string.Empty)
                            {
                                this.lbMessage.Text = string.Empty;
                                this.tboxQty.Text = strQty;
                            }
                            else if (this.tboxQty.Text != strQty)
                            {
                                Cursor.Current = Cursors.Default;
                                this.lbMessage.Text = "箱号包装数量不一致！";
                                this.tbxStartNo.Text = string.Empty;
                                this.tbxStartNo.Focus();
                                return;
                            }

                            string strBox = strCode.Split(' ')[4].Substring(2).ToString();
                            if (strBox == this.tbxEndNo.Text)
                            {
                                Cursor.Current = Cursors.Default;
                                this.lbMessage.Text = "起始/结束箱号不能相同！";
                                this.tbxStartNo.Text = string.Empty;
                                this.tbxStartNo.Focus();
                                return;
                            }
                            this.tbxStartNo.Text = strBox;
                        }
                    }

                    this.tbxEndNo.Focus();
                }
                else if (e.KeyValue == 13)
                {
                    this.tbxEndNo.Focus();
                }
                Cursor.Current = Cursors.Default;
                this.lbMessage.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 结束箱号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxEndNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.KeyValue == 131)
                {
                    //二维头(UTF8码制请改成UTF-8,OENCP码制请改成GB2312。。。)
                    string strCode = Scanner.StartScanDim2(ScanType.MotorSound, Encoding.UTF8);
                    strCode = ExceService.FilterByte(strCode);
                    if (strCode == string.Empty)
                    {
                        this.lbMessage.Text = "扫描有效箱号！";
                        this.tbxEndNo.Text = string.Empty;
                        Cursor.Current = Cursors.Default;
                        this.tbxEndNo.Focus();
                        return;
                    }
                    //修改by mjy 2016-8-30 判断一维码
                    if (strCode.Split('-').Length == 3)
                    {
                        string strPart = strCode.Split('-')[0].ToString();
                        if (this.tbxPartNo.Text == string.Empty)
                        {
                            this.lbMessage.Text = string.Empty;
                            this.tbxPartNo.Text = strPart;
                        }
                        else if (this.tbxPartNo.Text != strPart)
                        {
                            Cursor.Current = Cursors.Default;
                            this.lbMessage.Text = "箱号零件不一致！";
                            this.tbxEndNo.Text = string.Empty;
                            this.tbxEndNo.Focus();
                            return;
                        }

                        string strQty = strCode.Split('-')[1].ToString();
                        if (this.tboxQty.Text == string.Empty)
                        {
                            this.lbMessage.Text = string.Empty;
                            this.tboxQty.Text = strQty;
                        }
                        else if (this.tboxQty.Text != strQty)
                        {
                            Cursor.Current = Cursors.Default;
                            this.lbMessage.Text = "箱号包装数量不一致！";
                            this.tbxEndNo.Text = string.Empty;
                            this.tbxEndNo.Focus();
                            return;
                        }

                        string strBox = strCode.Split('-')[2].ToString();
                        if (strBox == tbxStartNo.Text)
                        {
                            Cursor.Current = Cursors.Default;
                            this.lbMessage.Text = "起始/结束箱号不能相同！";
                            this.tbxEndNo.Text = string.Empty;
                            this.tbxEndNo.Focus();
                            return;
                        }
                        this.tbxEndNo.Text = strBox;

                    }
                    else
                    {
                        if (!ExceService.IsBoxFormart(strCode))
                        {
                            Cursor.Current = Cursors.Default;
                            this.tbxEndNo.Focus();
                            return;
                        }

                        if (strCode.Split(' ').Length > 5)
                        {
                            string strPart = strCode.Split(' ')[2].Substring(1).ToString();
                            if (this.tbxPartNo.Text == string.Empty)
                            {
                                this.lbMessage.Text = string.Empty;
                                this.tbxPartNo.Text = strPart;
                            }
                            else if (this.tbxPartNo.Text != strPart)
                            {
                                Cursor.Current = Cursors.Default;
                                this.lbMessage.Text = "箱号零件不一致！";
                                this.tbxEndNo.Text = string.Empty;
                                this.tbxEndNo.Focus();
                                return;
                            }

                            string strQty = strCode.Split(' ')[3].Substring(1).ToString();
                            if (this.tboxQty.Text == string.Empty)
                            {
                                this.lbMessage.Text = string.Empty;
                                this.tboxQty.Text = strQty;
                            }
                            else if (this.tboxQty.Text != strQty)
                            {
                                Cursor.Current = Cursors.Default;
                                this.lbMessage.Text = "箱号包装数量不一致！";
                                this.tbxEndNo.Text = string.Empty;
                                this.tbxEndNo.Focus();
                                return;
                            }

                            string strBox = strCode.Split(' ')[4].Substring(2).ToString();
                            if (strBox == tbxStartNo.Text)
                            {
                                Cursor.Current = Cursors.Default;
                                this.lbMessage.Text = "起始/结束箱号不能相同！";
                                this.tbxEndNo.Text = string.Empty;
                                this.tbxEndNo.Focus();
                                return;
                            }
                            this.tbxEndNo.Text = strBox;
                        }
                    }
                    this.tbxBach.Focus();
                }
                else if (e.KeyValue == 13)
                {
                    this.tbxPartNo.Focus();
                }
                Cursor.Current = Cursors.Default;
                this.lbMessage.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BatchPackageR_Closing(object sender, CancelEventArgs e)
        {
            try
            {
                Scanner.Deinitilize();//释放扫描头
                Thread.Sleep(500);
                Sys.Deinitilize();//释放硬件
            }
            catch (Exception ex)
            {
                MessageBox.Show("释放资源错误:" + ex.Message);
                return;
            }
        }

        /// <summary>
        /// 零件号一维码扫描
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxPartNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ///零件号一维码扫描
                Cursor.Current = Cursors.WaitCursor;

                if (e.KeyValue == 131)
                {
                    string strCode = Scanner.StartScanDim2(ScanType.MotorSound, Encoding.UTF8);
                    strCode = ExceService.FilterByte(strCode);
                    if (strCode == string.Empty || strCode.Split(' ').Length > 2 || strCode.Split('-').Length == 3)
                    {
                        Cursor.Current = Cursors.Default;
                        this.lbMessage.Text = "请扫描有效的零件号！";
                        this.tbxPartNo.Focus();
                        return;
                    }
                    this.tbxPartNo.Text = strCode;
                    this.tboxQty.Focus();
                }
                else if (e.KeyValue == 13)
                {
                    this.tboxQty.Focus();
                }
                Cursor.Current = Cursors.Default;
                this.lbMessage.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                this.lbMessage.Text = "Error:" + ex.Message.ToString();
            }
        }
    }
}