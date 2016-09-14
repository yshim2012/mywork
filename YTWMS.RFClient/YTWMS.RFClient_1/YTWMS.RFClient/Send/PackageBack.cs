using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTWMS.RFClient
{
    public partial class PackageBack : Form
    {
        public PackageBack()
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
            if (this.cmbTruckNo.SelectedValue.ToString() == string.Empty)
            {
                MessageBox.Show("请选择卡车！");
                return;
            }

            if (this.cmbSupplier.SelectedValue.ToString() == string.Empty)
            {
                MessageBox.Show("请选择供应商！");
                return;
            }

            PackageBackSupplierDetail back = new PackageBackSupplierDetail();
            back.SupplierId = Convert.ToInt32(this.cmbSupplier.SelectedValue.ToString());
            back.Mobile = this.tbxMobile.Text.Trim();
            back.Drver = this.tbxDriver.Text.Trim();
            back.TruckNo = this.cmbTruckNo.SelectedValue.ToString();
            back.Owner = this;

            back.ShowDialog();
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
        private void PackageBack_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                BindingSource bs = new BindingSource();
                bs.DataSource = BaseInfo.SupplierList;
                this.cmbSupplier.DataSource = bs;
                this.cmbSupplier.ValueMember = "Value";
                this.cmbSupplier.DisplayMember = "Key";

                BindingSource bsTruck = new BindingSource();
                bsTruck.DataSource = BaseInfo.truckList;
                this.cmbTruckNo.DataSource = bsTruck;
                this.cmbTruckNo.ValueMember = "Value";
                this.cmbTruckNo.DisplayMember = "Key";
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化错误:" + ex.Message);
            }
        }
    }
}