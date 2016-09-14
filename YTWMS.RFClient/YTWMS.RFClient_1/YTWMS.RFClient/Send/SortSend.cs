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

namespace YTWMS.RFClient
{
    public partial class SortSend : Form
    {

        LoginInfo logonInfo = LoginInfo.GetInstance();
        public DataTable dtMenory; //记录排序零件

        public string SortNo = string.Empty;

        public int CurrentSeqNo = 1;

        public SortSend()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 排序完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (SortNo == string.Empty)
            {
                this.lbMessage.Text = "没有完成的排序单号！";
                return;
            }

            SendInfo info = new SendInfo();
            info.SortNo = this.SortNo.Substring(0, SortNo.Length - 1);
            info.Owner = this;
            info.ShowDialog();
        }

        /// <summary>
        /// 排序单号焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortSend_Load(object sender, EventArgs e)
        {
            try
            {
                Sys.Initilize(); //硬件初始化
                Scanner.Initilize();
                Thread.Sleep(500);

                this.txtSortOrder.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message.ToString());
                return;
            }
        }

        /// <summary>
        /// 创建空的内存表格数据
        /// </summary>
        private void CreateEmptyMenoryTable()
        {
            this.dtMenory = new DataTable();
            DataColumn dcPartCode = new DataColumn("PART_CODE");
            DataColumn dcPartNmae = new DataColumn("PART_NAME");
            DataColumn dcSeq = new DataColumn("SEQNO");
            DataColumn dcPullQty = new DataColumn("PULL_QTY");
            DataColumn dcDock = new DataColumn("DELIVER_DOCK");
            DataColumn dcOrderNo = new DataColumn("PULL_ORDER_NO");
            DataColumn dcPartId = new DataColumn("PART_ID");
            DataColumn dcSupplierId = new DataColumn("SUPPLIER_ID");
            DataColumn dcProId = new DataColumn("PROJECT_ID");
            DataColumn dcProItemId = new DataColumn("PROJECT_ITEM_ID");
            DataColumn dcID = new DataColumn("ID");

            dtMenory.Columns.Add(dcPartCode);
            dtMenory.Columns.Add(dcPartNmae);
            dtMenory.Columns.Add(dcSeq);
            dtMenory.Columns.Add(dcPullQty);
            dtMenory.Columns.Add(dcDock);
            dtMenory.Columns.Add(dcOrderNo);
            dtMenory.Columns.Add(dcPartId);
            dtMenory.Columns.Add(dcSupplierId);
            dtMenory.Columns.Add(dcProId);
            dtMenory.Columns.Add(dcProItemId);
            dtMenory.Columns.Add(dcID);
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortSend_Closing(object sender, CancelEventArgs e)
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

        /// <summary>
        /// 扫描订单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSortOrder_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                LoginInfo info = LoginInfo.GetInstance();

                if (e.KeyValue == 131)
                {
                    this.txtSortOrder.Text = string.Empty;
                    //二维头(UTF8码制请改成UTF-8,OENCP码制请改成GB2312。。。)
                    string strPart = Scanner.StartScanDim2(ScanType.MotorSound, Encoding.UTF8);
                    strPart = ExceService.FilterByte(strPart);
                    if (strPart == string.Empty)
                    {
                        this.txtSortOrder.Focus();
                        this.lbMessage.Text = "请先扫描排序号！";
                        return;
                    }

                    if (ExceService.IsPartFormart(strPart))
                    {
                        this.txtSortOrder.Focus();
                        return;
                    }

                    this.txtSortOrder.Text = strPart;

                    DataTable dt = ExceService.GetSortParts(this.txtSortOrder.Text.Trim(), info.LoginUser.WAREHOUSE_ID);
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        this.lbMessage.Text = "排序单号已完成或不存在！";
                        this.txtSortOrder.Text = string.Empty;
                        this.txtSortOrder.Focus();
                        return;
                    }
                    else
                    {
                        this.dgSorting.DataSource = dt;
                        this.txtPartNo.Focus();

                        this.lbMessage.Text = "当前序号:" + CurrentSeqNo.ToString();
                    }
                }
                else if (e.KeyValue == 13)
                {
                    if (this.txtSortOrder.Text.Trim() == string.Empty)
                    {
                        this.lbMessage.Text = "请先扫描排序号！";
                        this.txtSortOrder.Text = string.Empty;
                        this.txtSortOrder.Focus();
                        return;
                    }

                    DataTable dt = ExceService.GetSortParts(this.txtSortOrder.Text.Trim(), info.LoginUser.WAREHOUSE_ID);
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        this.lbMessage.Text = "排序单号已完成或不存在！";
                        this.txtSortOrder.Text = string.Empty;
                        this.txtSortOrder.Focus();
                        return;
                    }
                    else
                    {
                        this.dgSorting.DataSource = dt;
                        this.txtPartNo.Focus();

                        this.lbMessage.Text = "当前序号:" + CurrentSeqNo.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                if (!ExceService.CheckService())
                {
                    this.lbMessage.Text = "无法连接到服务器";
                }
                else
                    MessageBox.Show("Error:" + ex.Message.ToString());
            }
        }

        /// <summary>
        /// 扫描零件二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPartNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 131)
                {

                    if (this.txtSortOrder.Text == string.Empty)
                    {
                        MessageBox.Show("请先扫描排序单号!");
                        return;
                    }

                    //二维头(UTF8码制请改成UTF-8,OENCP码制请改成GB2312。。。)
                    //string strPart = Scanner.StartScanDim2(ScanType.MotorSound);
                    string strPart = Scanner.StartScanDim2(ScanType.MotorSound, Encoding.GetEncoding("GB2312"));
                    if (strPart.Length <= 0)
                        return;

                    if (strPart.Length < 20)
                    {
                        ////一维码不存在零件号，条码第3,4,5,6 为零件号的后四位，特殊处理；
                        string str = strPart.Substring(2, 4);
                        if ("9016650".IndexOf(str) > 0)
                        {
                            this.txtPartNo.Text = "9016650";
                        }
                        else if ("9016651".IndexOf(str) > 0)
                        {
                            this.txtPartNo.Text = "9016651";
                        }
                        else if ("9039093".IndexOf(str) > 0)
                        {
                            this.txtPartNo.Text = "9039093";
                        }
                        else if ("9040274".IndexOf(str) > 0)
                        {
                            this.txtPartNo.Text = "9040274";
                        }
                        else if ("24103001".IndexOf(str) > 0)
                        {
                            this.txtPartNo.Text = "24103001";
                        }
                    }
                    else
                    {
                        string strCode = ExceService.FilterByte(strPart);
                        if (!ExceService.IsPartFormart(strCode))
                        {
                            this.txtPartNo.Focus();
                            return;
                        }
                        this.txtPartNo.Text = strCode.Split(' ')[3].Substring(1).ToString(); ;
                    }

                    CheckPart();
                }
                else if (e.KeyValue == 13)
                {
                    CheckPart();
                }
            }
            catch (Exception ex)
            {
                if (!ExceService.CheckService())
                {
                    this.lbMessage.Text = "无法连接到服务器";
                }
                else
                    MessageBox.Show("Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 检查零件
        /// </summary>
        protected void CheckPart()
        {
            try
            {
                if (this.txtPartNo.Text == string.Empty)
                {
                    this.lbMessage.Text = "请扫描零件号!";
                    this.txtPartNo.Focus();
                    return;
                }
                DataTable dt = (DataTable)dgSorting.DataSource;
                if (CurrentSeqNo > dt.Rows.Count)
                    return;

                if (txtPartNo.Text.Trim() == dt.Rows[CurrentSeqNo - 1]["PART_CODE"].ToString())
                {
                    this.txtPartNo.Text = string.Empty;
                    CurrentSeqNo += 1;
                    this.lbMessage.Text = "当前序号:" + CurrentSeqNo.ToString();
                    this.txtPartNo.Text = string.Empty;
                    this.txtPartNo.Focus();
                }
                else
                {
                    this.lbMessage.Text = string.Empty;
                    this.lbMessage.Text = "序号:" + CurrentSeqNo.ToString() + " 错误!";
                    this.txtPartNo.Text = string.Empty;
                    this.txtPartNo.Focus();
                    return;
                }

                if (CurrentSeqNo > dt.Rows.Count && this.txtSortOrder.Text.Trim() != string.Empty)
                {
                    if (SortNo.IndexOf(txtSortOrder.Text.Trim()) < 0)
                        SortNo += txtSortOrder.Text.Trim() + ",";
                    //this.txtSortOrder.Text = string.Empty;
                    this.CurrentSeqNo = 1;
                    this.lbMessage.Text = string.Empty;
                    this.txtSortOrder.Focus();
                    MessageBox.Show("当前排序完成!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message.ToString());
                return;
            }
        }
    }
}