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
    public partial class ReceiveInfo : Form
    {
        public ReceiveInfo()
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
            try
            {
                PackageR package = new PackageR();
                package.DocumentNo = this.tbxDocumentNo.Text.Trim();
                package.Owner = this;

                package.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
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

        private void ReceiveInfo_Load(object sender, EventArgs e)
        {
            this.tbxDocumentNo.Focus();
        }
    }
}