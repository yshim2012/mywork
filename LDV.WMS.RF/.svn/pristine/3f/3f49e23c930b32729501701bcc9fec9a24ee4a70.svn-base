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
    public partial class WarehouseMoveConfirm : Form
    {

        private int _planId, _planDetailId, _locId, _targetlocId, _partId, _stockId;

        public int DetailId
        {
            get;
            set;
        }

        public WarehouseMoveConfirm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// /构造函数
        /// </summary>
        /// <param name="planDetailId"></param>
        /// <param name="partName"></param>
        /// <param name="partCode"></param>
        public WarehouseMoveConfirm(int planId,int detailId,int locId,int targetId,int stockId)
        {
            InitializeComponent();
            _planId = planId;
            _planDetailId = detailId;
            _locId = locId;
            _targetlocId = targetId;
            _stockId = stockId;
        }

        /// <summary>
        /// /返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.txtActualLoc.Text.Trim() == string.Empty)
            {
                this.lbMessage.Text = "请扫描目的库位！";
                this.lbMessage.Visible = true;
                return;
            }

            if (this.lbMessage.Text == "移库成功！")
            {
                WarehouseMoveScan wms = (WarehouseMoveScan)this.Owner;
                wms.MovePlanRemove(DetailId);
               // wms.BindData(dtPlanList, 0);
                this.Close();
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WarehouseMoveConfirm_Load(object sender, EventArgs e)
        {
            this.txtActualLoc.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtActualLoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Cursor.Current = Cursors.WaitCursor;

                if (MoveLoc())
                {
                    this.btnConfirm.Focus();
                    this.lbMessage.Text = "移库成功！";

                    WarehouseMoveScan wms=(WarehouseMoveScan)this.Owner;
                    ///确认扫描

                    Cursor.Current = Cursors.Default;
                }

                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// 移库
        /// </summary>
        /// <returns></returns>
        private bool MoveLoc()
        {          
            string mess;
            string Errms;

            bool flg = CC.Singleton().service().ConfirmPlanMove(_planId, _planDetailId, _stockId, _locId, _targetlocId, Convert.ToInt32(txtActualQty.Text.Trim()),
                mainForm._logUser.LOGIN_NAME, mainForm._logUser.EXTEND_COLUMN_0, out mess, out Errms, Int32.Parse(mainForm._logUser.ID.ToString()));
            if (flg)
            {
                return flg;
            }
            else
            {
                lbMessage.Text = mess;
                return flg;
            }
        }
    }
}