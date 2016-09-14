using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LDV.WMS.RF.ClientForm
{
    public partial class InventoryMain : Form
    {
        public InventoryMain()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProgramCheckList checkList = new ProgramCheckList();
            checkList.ShowDialog();
        }

        private void menuBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            CycleCountScanner scanner = new CycleCountScanner();
            scanner.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 库内移位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBankShift_Click(object sender, EventArgs e)
        {
            WarehouseMove frm = new WarehouseMove();
            frm.ShowDialog();
        }

        /// <summary>
        /// 计划移库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlanMove_Click(object sender, EventArgs e)
        {
            WarehouseMoveNew wmn = new WarehouseMoveNew();
            wmn.ShowDialog();
        }
    }
}