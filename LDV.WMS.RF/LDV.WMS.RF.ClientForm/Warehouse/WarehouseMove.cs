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
    public partial class WarehouseMove : Form
    {
        public WarehouseMove()
        {
            InitializeComponent();
        }

        #region Buttons
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
        private void btnCommit_Click(object sender, EventArgs e)
        {
            if (this.cbox_lot.SelectedValue != null)
            {
                if (this.cbox_lot.SelectedValue.ToString() == string.Empty)
                {
                    lbMessage.Text = "请选择批号！";
                    return;
                }
            }
            else
            {
                lbMessage.Text = "请选择批号！";
                return;
            }

             #region 判断新老库位是否是正常库位
            //DataTable newwhdt=CC.Singleton().service().QueryByLocId(txtNewLoc.Text);
            //if (newwhdt.Rows.Count == 0)
            //{
            //    lbMessage.Text = "新库位不存在！";
            //    return;
            //}
            //else
            //{
            //    if (newwhdt.Rows[0]["TYPE"].ToString() != "RV")
            //    {
            //        lbMessage.Text = "新库位不是正常库位！";
            //        return;
            //    }
            //}
            //DataTable lodwhdt = CC.Singleton().service().QueryByLocId(txtOldLoc.Text);
            //if (lodwhdt.Rows.Count == 0)
            //{
            //    lbMessage.Text = "老库位不存在！";
            //    return;
            //}
            //else
            //{
            //    if (lodwhdt.Rows[0]["TYPE"].ToString() != "RV")
            //    {
            //        lbMessage.Text = "老库位不是正常库位！";
            //        return;
            //    }
            //}
              #endregion

            lbMessage.Text = string.Empty;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (MoveLoc())
                {
                    
                  
                    txtOldLoc.Text = string.Empty;
                    txtPartCode.Text = string.Empty;
                    txtMoveCount.Text = string.Empty;
                    txtNewLoc.Text = string.Empty;
                    Cursor.Current = Cursors.Default;
                    //添加批号 add by xhy 
                    this.cbox_lot.DataSource=string.Empty.Split(',');
                    txtOldLoc.Focus();
                    lbMessage.Text = "移库成功!";
                    return;
                }
            }
            catch (Exception ex)
            {
                lbMessage.Text = "网络错误:" + ex.Message;
                Cursor.Current = Cursors.Default;
                return;
            }
           
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

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuConfirmed_Click(object sender, EventArgs e)
        {
            btnCommit_Click(null, null);
        }

        #endregion

        private bool MoveLoc()
        {
            if (this.CheckInfo())
            { 
                string mess;
                string Errms;
                //bool flg = CC.Singleton().service().MovLoc(mainForm._logUser.LOGIN_NAME, mainForm._logUser.EXTEND_COLUMN_0, txtOldLoc.Text.Trim(),
                //    txtNewLoc.Text.Trim(), txtPartCode.Text.Trim(), int.Parse(txtMoveCount.Text.Trim()), out mess, out Errms);
                bool flg = CC.Singleton().service().MovLocWithLot(mainForm._logUser.LOGIN_NAME, mainForm._logUser.EXTEND_COLUMN_0, txtOldLoc.Text.Trim(),
                  txtNewLoc.Text.Trim(), txtPartCode.Text.Trim(), int.Parse(txtMoveCount.Text.Trim()), this.cbox_lot.SelectedValue.ToString(),
                      out mess, out Errms);
                if (flg)
                {
                    return flg;
                }
                else
                {
                    if (mess.Equals("录入的数量大于库存数量"))
                    {
                        txtMoveCount.SelectAll();
                    }
                    if (mess.Equals("新库位不存在")||mess.Equals("新库位被设为其它商品的主库位"))
                    {
                        txtNewLoc.SelectAll();
                    }
                    if (mess.Contains("中没有"))
                    {
                        txtPartCode.SelectAll();
                    }
                    lbMessage.Text = mess;
                    return flg;
                }
                
            }
            return false;  
        }

        private bool CheckInfo()
        {
            if (this.txtOldLoc.Text.Trim() == string.Empty)
            {
                this.txtOldLoc.Focus();
                this.lbMessage.Text = "请扫描旧库位";
                return false;
            }
            if (txtOldLoc.Text.Trim() == txtNewLoc.Text.Trim())
            {
                this.lbMessage.Text = "新库位与原库位一致!";
                //txtOldLoc.Text = string.Empty;
                //txtNewLoc.Text = string.Empty;
                txtNewLoc.SelectAll();
                return false;
            }
            if (this.txtPartCode.Text.Trim() == string.Empty)
            {
                this.txtPartCode.Focus();
                this.lbMessage.Text = "请扫描零件编码";
                return false;
            }

            if (this.txtMoveCount.Text.Trim() == string.Empty)
            {
                this.txtMoveCount.Focus();
                this.lbMessage.Text = "请录入移动数量";
                return false;
            }
            else
            {
                try
                {
                    int count = 0;
                    count = int.Parse(this.txtMoveCount.Text.Trim());
                    if (count <= 0)
                    {
                        this.txtMoveCount.SelectAll();
                        this.lbMessage.Text = "移动数量（只能是大于零的数字）";
                        return false;
                    }
                }
                catch (Exception)
                {
                    this.txtMoveCount.SelectAll();
                    this.lbMessage.Text = "移动数量（只能是大于零的数字）";
                    return false;
                }
            }

            if (this.txtNewLoc.Text.Trim() == string.Empty)
            {
                this.txtNewLoc.Focus();
                this.lbMessage.Text = "请扫描新库位";
                return false;
            }

            return true;
        }
        
        #region Enter
        /// <summary>
        /// 原库位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOldLoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)    //Enter
            {
                this.txtPartCode.SelectAll();
                this.txtPartCode.Focus();
            }
        }
        
        /// <summary>
        /// 零件编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPartCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.txtOldLoc.Text.Trim() == string.Empty)
                {
                    this.txtOldLoc.SelectAll();
                    this.txtOldLoc.Focus();
                    this.lbMessage.Text = "请扫描原库位";
                }
                else
                {
                    string strLots = CC.Singleton().service().GetLotByItemLoc(this.txtPartCode.Text.Trim(), this.txtOldLoc.Text.Trim());

                    if (strLots.Equals(string.Empty))
                    {
                        this.cbox_lot.DataSource = null;
                        this.lbMessage.Text = "未找到物料批号！";
                        return;
                    }
                    this.lbMessage.Text = string.Empty;
                    IList<string> lotList = strLots.Split(',');
                    this.cbox_lot.DataSource = lotList;

                    this.txtMoveCount.SelectAll();
                    this.txtMoveCount.Focus();
                }
            }
        }        

        /// <summary>
        /// 数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMoveCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == 13)
            {
                try
                {
                    int count = 0;
                    count = int.Parse(this.txtMoveCount.Text.Trim());
                    if (count <= 0)
                    {
                        this.txtMoveCount.SelectAll();
                        this.lbMessage.Text = "移动数量（只能是大于零的数字）";
                        return;
                    }
                }
                catch (Exception)
                {
                    this.txtMoveCount.SelectAll();
                    this.lbMessage.Text = "移动数量（只能是大于零的数字）";
                    return;
                }
                this.txtNewLoc.SelectAll();
                this.txtNewLoc.Focus();
            }
        }

        private void txtNewLoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.btnCommit_Click(null, null);
            }
        }
        #endregion
        
        private void cmbLot_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtMoveCount.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbox_lot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbox_lot.SelectedValue.ToString().Equals(string.Empty))
                this.lbMessage.Text = "请选择批号！";
            else
                this.lbMessage.Text = string.Empty;
        }

        private void txtPartCode_LostFocus(object sender, EventArgs e)
        {
            if (this.txtOldLoc.Text.Trim() == string.Empty)
            {
                this.txtOldLoc.SelectAll();
                this.txtOldLoc.Focus();
                this.lbMessage.Text = "请扫描原库位";
            }
            else
            {
                string strLots = CC.Singleton().service().GetLotByItemLoc(this.txtPartCode.Text.Trim(), this.txtOldLoc.Text.Trim());

                if (strLots.Equals(string.Empty))
                {
                    this.cbox_lot.DataSource = null;
                    this.lbMessage.Text = "未找到物料批号！";
                    return;
                }
                this.lbMessage.Text = string.Empty;
                IList<string> lotList = strLots.Split(',');
                this.cbox_lot.DataSource = lotList;

                this.txtMoveCount.SelectAll();
                this.txtMoveCount.Focus();
            }
        }

        private void label5_ParentChanged(object sender, EventArgs e)
        {

        }

        private void label3_ParentChanged(object sender, EventArgs e)
        {

        }

        private void label2_ParentChanged(object sender, EventArgs e)
        {

        }

        private void label4_ParentChanged(object sender, EventArgs e)
        {

        }

        private void label1_ParentChanged(object sender, EventArgs e)
        {

        }
    }
}