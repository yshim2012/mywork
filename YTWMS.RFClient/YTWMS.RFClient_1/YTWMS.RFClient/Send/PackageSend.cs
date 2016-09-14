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
    public partial class PackageSend : Form
    {
        #region 变量
        private bool IsOk = false;
        #endregion


        public PackageSend()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 下一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!IsOk)
            {
                MessageBox.Show("请输入有效的拉动单号！");
                return;
            }

            PackageSendDetail send = new PackageSendDetail();
            send.PullNo = this.tboxPullNo.Text.Trim();
            send.Truck = this.cmbTruckNo.SelectedValue.ToString();
            send.Mobile = this.tbxMobile.Text.Trim();
            send.Driver = this.tbxDriver.Text.Trim();
            send.Owner = this;
            send.ShowDialog();
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
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PackageSend_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                BindingSource bs = new BindingSource();
                bs.DataSource = BaseInfo.truckList;
                this.cmbTruckNo.DataSource = bs;
                this.cmbTruckNo.ValueMember = "Value";
                this.cmbTruckNo.DisplayMember = "Key";
                this.tboxPullNo.Text = string.Empty;

                this.lbMessage.Text = string.Empty;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化错误:" + ex.Message);
            }
        }

        /// <summary>
        /// 获取拉动单信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tboxPullNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                LoginInfo logonInfo = LoginInfo.GetInstance();
                if (e.KeyValue == 131)
                {
                    string strCode = Scanner.StartScanDim2(ScanType.MotorSound, Encoding.UTF8);
                    strCode = ExceService.FilterByte(strCode);
                    if (strCode.Split(' ').Length > 0 || strCode.Split('-').Length == 3)
                    {
                        Cursor.Current = Cursors.Default;
                        return;
                    }

                    this.tboxPullNo.Text = strCode;


                    DataTable dt = ExceService.getPlanInfo(this.tboxPullNo.Text.Trim(), logonInfo.LoginUser.WAREHOUSE_ID);
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        this.lbMessage.Text = "拉动单号已完成或不存在！";
                        this.tboxPullNo.Text = string.Empty;
                        this.tboxPullNo.Focus();
                        return;
                    }
                    else
                    {
                        this.lbMessage.Visible = false;
                        this.IsOk = true;
                    }
                }
                else if (e.KeyValue == 13)
                {
                    DataTable dt = ExceService.GetSortParts(this.tboxPullNo.Text.Trim(), logonInfo.LoginUser.WAREHOUSE_ID);
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        this.lbMessage.Text = "拉动单号已完成或不存在！";
                        this.tboxPullNo.Text = string.Empty;
                        this.tboxPullNo.Focus();
                        return;
                    }
                    else
                    {
                        this.lbMessage.Visible = false;
                        this.IsOk = true;
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Error:" + ex.ToString());
            }
        }
    }
}