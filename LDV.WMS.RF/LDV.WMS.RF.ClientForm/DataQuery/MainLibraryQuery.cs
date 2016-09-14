using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClientForward;

namespace LDV.WMS.RF.ClientForm
{
    public partial class MainLibraryQuery : Form
    {
        public MainLibraryQuery()
        {
            InitializeComponent();
            this.txtPartCode.Focus();
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

        private void txtPartCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            labMessage.Text = string.Empty;
            if (e.KeyChar == 0x20)  //禁止空格键  
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)    //Enter
            {
                Cursor.Current = Cursors.WaitCursor;
                queryMainLoc();
            }
        }

        private void queryMainLoc()
        {
            //检查零件
            if (this.txtPartCode.Text == string.Empty)
            {
                txtPartCode.Focus();
                labMessage.Text = "零件号不能为空!";
                Cursor.Current = Cursors.Default;
                return;
            }
            DataTable dt = CC.Singleton().service().GetMainLocByPartCode(txtPartCode.Text.Trim(), mainForm._logUser.ID.Value.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                this.txtPartName.Text = dt.Rows[0]["item_name"].ToString();
                this.txtLoc.Text = dt.Rows[0]["LOC_CODE"].ToString();
            }
            else
            {
                this.txtPartName.Text = string.Empty;
                this.txtLoc.Text = string.Empty;
                labMessage.Text = "未找到主库位信息!";
                this.txtPartCode.Focus();
            }
            GC.Collect();
            Cursor.Current = Cursors.Default;
        }
    }
}