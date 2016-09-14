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
    public partial class WarehouseMoveScan : Form
    {
        //string _planNo;
        DataTable dtPlanList;
        private int _planId, _planDetailId, _locId, _targetlocId, _partId, _actualQty, _stockId;

        public WarehouseMoveScan()
        {
            InitializeComponent();
        }

        public WarehouseMoveScan(DataTable _dtPlanList)
        {
            InitializeComponent();

            //_planNo = ScanNO;
            dtPlanList = _dtPlanList;
            MovePlan = _dtPlanList;
        }

        /// <summary>
        /// 移库计划
        /// </summary>
        public DataTable MovePlan
        {
            get;
            set;
        }

        /// <summary>
        /// 当前索引值
        /// </summary>
        public int CurrentIndex
        {
            get;
            set;
        }

        /// <summary>
        /// 当前明细ID
        /// </summary>
        public int CurrentDetailId
        {
            get;
            set;
        }

        /// <summary>
        /// 计划单据号
        /// </summary>
        public string ScanNo
        {
            get;
            set;
        }

        public string TargetLoc
        {
            get;
            set;
        }
        public bool GetDataNextIndex(int curIndex)
        {
                
                if (dtPlanList.Rows.Count > curIndex)
                {
                    if (!isMoveDetailID(dtPlanList.Rows[curIndex]["DETAIL_ID"].ToString()))
                    {
                        curIndex++;
                        return false;
                    }
                    else
                    {
                    return true;
                    }

                }
                else
                {
                    curIndex=0;
                    return false;
                }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void BindData(DataTable dtPlanList, int curIndex)
        {
            try
            {
                ///没有明细计划时，关闭扫描计划表
                if (MovePlan == null || MovePlan.Rows.Count == 0)
                {
                    //WarehouseMoveNew wmn = (WarehouseMoveNew)this.Owner;
                    //wmn.BindData();
                    DialogResult rst = MessageBox.Show(
                 "当前移库任务全部完成！！", "",
                 MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    this.Close();
                }
                //while (true)
                //{
                //    if (GetDataNextIndex(curIndex))
                //        break;
                //}

                this.txtMoveLoc.Text = "";
                this.txtActualQty.Text = "";
                this.txtMoveItem.Text = "";
                this.txtActualLoc.Text = "";
                //lbMessage.Text = "";
               
                this.txtItem.Text = dtPlanList.Rows[curIndex]["ITEM_CODE"].ToString();
                this.txtItemName.Text = dtPlanList.Rows[curIndex]["ITEM_NAME"].ToString();
                this.txtMoveQty.Text = dtPlanList.Rows[curIndex]["QTY"].ToString();
                this.txtLocName.Text = dtPlanList.Rows[curIndex]["LOC_CODE"].ToString();
                this.txtBatchNo.Text = dtPlanList.Rows[curIndex]["LOT"].ToString();
                this.txtTargetLoc.Text = dtPlanList.Rows[curIndex]["TARGET_LOC_CODE"].ToString();
                TargetLoc = dtPlanList.Rows[curIndex]["TARGET_LOC_CODE"].ToString();

                this.lbCount.Text = (curIndex + 1) + "/" + dtPlanList.Rows.Count.ToString();
                this.MovePlan = dtPlanList;

                _planId = Convert.ToInt32(dtPlanList.Rows[curIndex]["ID"].ToString());
                _planDetailId = Convert.ToInt32(dtPlanList.Rows[curIndex]["DETAIL_ID"].ToString());
                _locId = Convert.ToInt32(dtPlanList.Rows[curIndex]["LOC_ID"].ToString());
                _targetlocId = Convert.ToInt32(dtPlanList.Rows[curIndex]["MOVE_LOC_ID"].ToString());
                _stockId = Convert.ToInt32(dtPlanList.Rows[curIndex]["inv_detail_id"].ToString());
                //}
                //else
                //{
                //    this.txtItem.Text = MovePlan.Rows[curIndex]["ITEM_CODE"].ToString();
                //    this.txtItemName.Text = MovePlan.Rows[curIndex]["ITEM_NAME"].ToString();
                //    this.txtMoveQty.Text = MovePlan.Rows[curIndex]["QTY"].ToString();
                //    this.txtLocName.Text = MovePlan.Rows[curIndex]["LOC_CODE"].ToString();
                //    this.txtBatchNo.Text = MovePlan.Rows[curIndex]["LOT"].ToString();
                //    TargetLoc = MovePlan.Rows[curIndex]["TARGET_LOC_CODE"].ToString();

                //    this.lbCount.Text = (curIndex + 1) + "/" + MovePlan.Rows.Count.ToString();
                //    this.MovePlan = MovePlan;

                //    _planId = Convert.ToInt32(MovePlan.Rows[0]["ID"].ToString());
                //    _planDetailId = Convert.ToInt32(MovePlan.Rows[0]["DETAIL_ID"].ToString());
                //    _locId = Convert.ToInt32(MovePlan.Rows[0]["LOC_ID"].ToString());
                //    _targetlocId = Convert.ToInt32(MovePlan.Rows[0]["MOVE_LOC_ID"].ToString());
                //    _stockId = Convert.ToInt32(MovePlan.Rows[0]["inv_detail_id"].ToString());
                //}

                //DataTable dtDetail= CC.Singleton().service().QueryMovePlanDetail(1);

                //if (dtDetail == null || dtDetail.Rows.Count <= 0)
                //    return;
                //this.txtItem.Text = dtDetail.Rows[0]["ITEM_CODE"].ToString();
                //this.txtItemName.Text = dtDetail.Rows[0]["ITEM_NAME"].ToString();
                //this.txtItemName.Text = dtDetail.Rows[0]["ITEM_NAME"].ToString();
                //this.txtMoveQty.Text = dtDetail.Rows[0]["QTY"].ToString();
                //this.txtLocName.Text = dtDetail.Rows[0]["LOC_CODE"].ToString();
                //this.txtBatchNo.Text = dtDetail.Rows[0]["LOT"].ToString();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                lbMessage.Text = "网络错误:" + ex.Message;
                Cursor.Current = Cursors.Default;
                return;
            }

        }

        /// <summary>
        /// 初始窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WarehouseMoveScan_Load(object sender, EventArgs e)
        {
            BindData(dtPlanList, 0);
            Cursor.Current = Cursors.Default;
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
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (CurrentIndex + 1 < MovePlan.Rows.Count)
                CurrentIndex += 1;
            else
                CurrentIndex = 0;

            BindData(dtPlanList, CurrentIndex);
        }
        public bool isMoveDetailID(string detailId)
        {
            if (MovePlan != null && MovePlan.Rows.Count > 0)
            {
                foreach (DataRow dr in MovePlan.Rows)
                {
                    if (dr["DETAIL_ID"].ToString() == detailId)
                    {
                      
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 移出已经执行的计划
        /// </summary>
        public void MovePlanRemove(int detailId)
        {
            if (MovePlan != null && MovePlan.Rows.Count > 0)
            {
                foreach (DataRow dr in MovePlan.Rows)
                {
                    if (dr["DETAIL_ID"].ToString() == detailId.ToString())
                    {
                        MovePlan.Rows.Remove(dr);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMoveLoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

                if (this.txtMoveLoc.Text.Trim() != this.txtLocName.Text.Trim())
                {
                    this.lbMessage.Text = "移库库位与原库位不一致!";
                    this.lbMessage.Visible=true;
                    this.txtMoveLoc.Focus();
                    this.txtMoveLoc.SelectAll();
                    return;
                }

                this.lbMessage.Visible = false;
                this.txtMoveItem.Focus();
            }
        }

        /// <summary>
        /// 回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMoveItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.txtMoveItem.Text.Trim() != this.txtItem.Text.Trim())
                {
                    this.lbMessage.Text = "移库零件与计划移库零件不一致！";
                    this.lbMessage.Visible = true;
                    this.txtMoveItem.Focus();
                    this.txtMoveItem.SelectAll();
                    return;
                }

                this.lbMessage.Visible = false;
                this.txtActualQty.Focus();
            }
        }

        /// <summary>
        /// 回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtActualQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.txtMoveLoc.Text.Trim() == string.Empty)
                {
                    this.lbMessage.Text = "请扫描移库库位！";
                    this.txtMoveLoc.SelectAll();
                    return;
                }
                if (this.txtMoveItem.Text.Trim() == string.Empty)
                {
                    this.lbMessage.Text = "请扫描移库零件";
                    this.txtMoveItem.SelectAll();
                    return;
                }
                if (this.txtMoveLoc.Text.Trim() != this.txtLocName.Text.Trim())
                {
                    this.lbMessage.Text = "移库库位与原库位不一致!";
                    this.lbMessage.Visible = true;
                    this.txtMoveLoc.SelectAll();
                    return;
                }

                if (this.txtMoveItem.Text.Trim() != this.txtItem.Text.Trim())
                {
                    this.lbMessage.Text = "移库零件与计划移库零件不一致！";
                    this.lbMessage.Visible = true;
                    this.txtMoveItem.SelectAll();
                }
                try
                {
                    if (int.Parse(this.txtActualQty.Text.Trim()) < 1)
                    {
                        lbMessage.Text = "移库数量必须是大于0的数字!";
                        txtActualQty.SelectAll();
                        return;
                    }
                }
                catch (FormatException ex)
                {
                    lbMessage.Text = "移库数量必须是大于0的数字!";
                    txtActualQty.SelectAll();
                    return;
                }
                if (int.Parse(this.txtActualQty.Text.Trim()) > int.Parse(this.txtMoveQty.Text.Trim()))
                {
                    lbMessage.Text = "移库数量必须小于等于计划移库数量!";
                    txtActualQty.SelectAll();
                    return;
                }
                this.lbMessage.Visible = false;
                this.txtActualLoc.Focus();

                //WarehouseMoveConfirm confirm = new WarehouseMoveConfirm(_planId, _planDetailId, _locId, _targetlocId, _stockId);
                //confirm.Owner = this;
                //confirm.txtItem.Text = this.txtItem.Text.Trim();
                //confirm.txtItemName.Text = this.txtItemName.Text.Trim();
                //confirm.txtLocName.Text = this.txtMoveLoc.Text.Trim();
                //confirm.txtMoveQty.Text = this.txtMoveQty.Text.Trim();
                //confirm.txtBatchNO.Text = this.txtBatchNo.Text.Trim();
                //confirm.txtTargetLoc.Text = TargetLoc;
                //confirm.txtActualQty.Text = this.txtActualQty.Text.Trim();
                //confirm.ShowDialog();

                //confirm.lbCount.Text = this.lbCount.Text.Trim();
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
        private void txtActualLoc_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.txtTargetLoc.Text.Trim() != this.txtActualLoc.Text.Trim())
                {
                    this.lbMessage.Text = "目的库位与计划移库位不一致！";
                    this.lbMessage.Visible = true;
                    this.txtActualLoc.Focus();
                    this.txtActualLoc.SelectAll();
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                if (MoveLoc())
                {
                    if (this.txtActualLoc.Text.Trim() == string.Empty)
                    {
                        this.lbMessage.Text = "请扫描目的库位！";
                        this.lbMessage.Visible = true;
                        return;
                    }

                    //if (this.lbMessage.Text == "移库成功！")
                    //{
                        MovePlanRemove(_planDetailId);
                        BindData(dtPlanList, CurrentIndex+1);
                     //}
                    this.lbMessage.Text = "移库成功！！";

                    //WarehouseMoveScan wms = (WarehouseMoveScan)this.Owner;
                    ///确认扫描

                    Cursor.Current = Cursors.Default;
                }

                Cursor.Current = Cursors.Default;
            }
        }
    }
}