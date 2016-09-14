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
    public partial class FreeLibraryQuery : Form
    {
        public FreeLibraryQuery()
        {
            InitializeComponent();
            txtWareHouse.Focus();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuQuery_Click(object sender, EventArgs e)
        {
            this.labMessage.Text = string.Empty;
            string LocCode=this.txtWareHouse.Text.Trim();
            if (LocCode == string.Empty)
            {
                this.labMessage.Text = "库位号不能为空!";
                return;
            }
            DataTable dt = CC.Singleton().service().SelectNullLoc(LocCode,Convert.ToDouble(mainForm._logUser.ID));
            dt.TableName = "NullLoc";
            this.dgList.DataSource = dt;
            if (dt.Rows.Count == 0)
            {
                this.labMessage.Text = "无"+LocCode+"这个空库位！";
            }
            txtWareHouse.SelectAll();
        }
        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtWareHouse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)    //Enter
            {
                menuQuery_Click(null, null);
            }
        }

        private void dgList_MouseUp(object sender, MouseEventArgs e)
        {
            System.Drawing.Point pt = new Point(e.X, e.Y);
            DataGrid.HitTestInfo hti = dgList.HitTest(e.X, e.Y);
            if (hti.Type == DataGrid.HitTestType.Cell)
            {
                dgList.CurrentCell = new DataGridCell(hti.Row, hti.Column);
                dgList.Select(hti.Row);
            }   
        }
        //查询
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.labMessage.Text = string.Empty;
                string LocCode = this.txtWareHouse.Text.Trim();
                if (LocCode == string.Empty)
                {
                    this.labMessage.Text = "库位号不能为空!";
                    return;
                }
                DataTable dt = CC.Singleton().service().SelectNullLoc(LocCode, Convert.ToDouble(mainForm._logUser.ID));
                dt.TableName = "NullLoc";
                this.dgList.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    this.labMessage.Text = "无" + LocCode + "这个空库位！";
                }
                txtWareHouse.SelectAll();
            }
            catch(Exception ex)
            {
                labMessage.Text = "服务器无法处理请求。 --->";
            }
        }
        //返回
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}