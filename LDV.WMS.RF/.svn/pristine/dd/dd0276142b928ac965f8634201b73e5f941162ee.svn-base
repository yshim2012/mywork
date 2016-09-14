using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClientForward;

namespace LDV.WMS.RF.ClientForm.Receiving
{
    public partial class ReceivingPQSelect : Form
    {
        DataTable data = new DataTable();
        public ReceivingPQSelect()
        {
            InitializeComponent();
            //-----huzhenfei------
            //this.txtReceivingNumber.Focus();
            //data = CC.Singleton().service().LoadMainDocByStatus("PQ");

            //data.TableName = "OrderList";
            //this.dataGrid1.DataSource = data;
            BindGrid();
           
        }
        private void BindGrid()
        {
            this.txtReceivingNumber.Focus();
            data = CC.Singleton().service().LoadMainDocByStatus("PQ", mainForm._logUser.ID.Value.ToString());

            data.TableName = "OrderList";
            this.dataGrid1.DataSource = data;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dataGrid1_MouseUp(object sender, MouseEventArgs e)
        {
            //if (dataGrid1.CurrentRowIndex > 0)
            //{
            //    dataGrid1.Select(dataGrid1.CurrentRowIndex);
            //}
            System.Drawing.Point pt = new Point(e.X, e.Y);
            DataGrid.HitTestInfo hti = dataGrid1.HitTest(e.X, e.Y);
            if (hti.Type == DataGrid.HitTestType.Cell)
            {
                dataGrid1.CurrentCell = new DataGridCell(hti.Row, hti.Column);
                dataGrid1.Select(hti.Row);
            }   
        }
        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            int rowIndex = this.dataGrid1.CurrentRowIndex;
            this.txtReceivingNumber.Text = dataGrid1[rowIndex, 1].ToString();
            this.txtReceivingNumber.Focus();
            this.txtReceivingNumber.SelectAll();
        }
        private void txtReceivingNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)    //Enter
            {
                btnStartReceiving_Click(null, null);
                return;
            }
        }

        private void btnStartReceiving_Click(object sender, EventArgs e)
        {
            #region 判断单号是否正确
            if (this.txtReceivingNumber.Text.Trim() == string.Empty)
            {
                lblMessage.Text = "包装单号不能为空！";
                Cursor.Current = Cursors.Default;
                return;
            }
            if (data.Select("DOC_CODE='" + txtReceivingNumber.Text.Trim() + "'").Length == 0)
            {
                lblMessage.Text = "包装单号不存在！";
                Cursor.Current = Cursors.Default;
                return;
            }
            #endregion

            // lblMessage.Text = "单号测试成功";
         
            ReceivingPQ pq = new ReceivingPQ(this.txtReceivingNumber.Text.Trim(), this);
            pq.ShowDialog();
            BindGrid();
            txtReceivingNumber.Text = string.Empty;
            txtReceivingNumber.Focus();
        }

        private void dataGrid1_Click(object sender, EventArgs e)
        {
            txtReceivingNumber.Focus();
        }
    }
}