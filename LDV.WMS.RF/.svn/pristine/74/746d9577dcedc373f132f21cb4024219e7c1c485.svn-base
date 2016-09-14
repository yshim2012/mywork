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
    public partial class NewReceivingAP : Form
    {
        DataTable data;
        public NewReceivingAP()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            this.dataGrid1.DataSource = null;
            data = CC.Singleton().service().LoadMainDocByStatus("AP",mainForm._logUser.ID.Value.ToString());

            data.TableName = "OrderList";
            this.dataGrid1.DataSource = data;
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

        }

        private void btnStartReceiving_Click(object sender, EventArgs e)
        {
            //显示窗口
            ReceivingScan Scan = new ReceivingScan(data, this);
            Scan.ShowDialog();
            BindData();
            Cursor.Current = Cursors.Default;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGrid1_Click(object sender, EventArgs e)
        {

        }

       
    }
}