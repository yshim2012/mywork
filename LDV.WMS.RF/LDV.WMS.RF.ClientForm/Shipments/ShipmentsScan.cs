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
    public partial class ShipmentsScan : Form
    {
        DataTable Order;
        double PackId;
        bool IsNew;
        public ShipmentsScan(DataTable _Order,string PackgeOrder,string PackgeId,string OrderNumber,string CustName,bool _IsNew)
        {
            InitializeComponent();

            Order = _Order;
            IsNew = _IsNew;
            PackId = double.Parse(PackgeId);
            
            txtPackgeNumber.Text = PackgeOrder;
            txtOrderNumber.Text = OrderNumber;
            txtCustomerName.Text = CustName;
            //lblCount.Text = Order.Select("SHIP_QTY< PICKED_QTY").Length.ToString();//显示物料数
            try
            {
                lblCount.Text =  CC.Singleton().service().PackgeCount(OrderNumber, PackgeOrder, PackId).ToString();
            }
            catch (Exception ex)
            {
                lblCount.Text = "物料数加载失败!";
                return;
            }
            txtPartNumber.Focus();
            Cursor.Current = Cursors.Default;
            
        }

        //返回
        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    CC.Singleton().service().UpdateUserState(double.Parse(mainForm._logUser.ID.ToString()), "", "");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("网络错误:" + ex.Message);
                    this.Close();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            btnReturn_Click(null, null);
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
            //出库

            double ShipCount = 0;//出库输入数量

            #region 数据检查
            if (txtPartNumber.Text.Trim()==string.Empty)
            {
                lblMessage.Text = "请输入零件编码!";
                txtPartNumber.Focus();
                return;
            }
            if(Order.Select("ITEM_CODE='" + txtPartNumber.Text.Trim()+"'").Length<1)
            {
                lblMessage.Text = "零件数据错误!请退出核料重新查询!";
                return;
            }
            if (txtShipmentsCount.Text.Trim() == string.Empty)
            {
                lblMessage.Text = "请输入核料数量!";
                txtShipmentsCount.Focus();
                return;
            }
            
            try
            {
                ShipCount = Convert.ToDouble(txtShipmentsCount.Text.Trim());
            }
            catch (Exception ex)
            {
                lblMessage.Text = "输入的必须是数字!";
                txtShipmentsCount.SelectAll();
                return;
            }
            #endregion

            DataRow Tm = Order.Select("ITEM_CODE='" + txtPartNumber.Text.Trim() + "'")[0];

                
                if (ShipCount < 1)
                {
                    lblMessage.Text = "核料数量必须大于0!";
                    return;
                }
                double PickQTY = double.Parse(Tm["PICKED_QTY"].ToString());
                double OrdeQty = double.Parse(Tm["ORDER_QTY"].ToString());
                double ShipQty = double.Parse(Tm["SHIP_QTY"].ToString());
                if (PickQTY > OrdeQty)
                {
                    lblMessage.Text = "拣货数量大于订单数量,此零件不能被出库!";
                    txtPartNumber.Text = string.Empty;
                    txtShipmentsCount.Text = string.Empty;
                    txtPartNumber.Focus();
                    return;
                }
                if (ShipCount > (PickQTY - ShipQty))
                {
                    lblMessage.Text = "核料数不能大于拣货数!拣货:" + PickQTY.ToString() + ",已出库:" + ShipQty.ToString();
                    txtShipmentsCount.SelectAll();
                    return;
                }

                try
                {
                        
                    Cursor.Current = Cursors.WaitCursor;
                    string Mesg;
                    bool flag = CC.Singleton().service().OutShipment(
                        PackId,
                        mainForm._logUser.ID.Value,
                        double.Parse(Tm["ITEM_ID"].ToString()),
                        ShipCount,
                        IsNew,
                        out Mesg,
                        double.Parse(Tm["WHSE_ID"].ToString()),
                        Tm["WHSE_NAME"].ToString(),
                        txtOrderNumber.Text.Trim()
                        );
                    if (flag)
                     {
                        
                        lblMessage.Text = txtPartNumber.Text + "核料成功!";
                        //Tm["SHIP_QTY"] = double.Parse(Tm["SHIP_QTY"].ToString()) + ShipCount;//重新查询
                        try
                        {
                            Order.Clear();
                            Order = CC.Singleton().service().LoadShipOrder(txtOrderNumber.Text.Trim(), mainForm._logUser.ID.ToString(), out Mesg);

                            lblCount.Text = CC.Singleton().service().PackgeCount(txtOrderNumber.Text, txtPackgeNumber.Text, PackId).ToString();//刷新物料数
                        }
                        catch (Exception ex)
                        {
                            lblCount.Text = "数据刷新失败!";
                            return;
                        }              
                        
                        //if (double.Parse(Tm["SHIP_QTY"].ToString()) == double.Parse(Tm["ORDER_QTY"].ToString()))
                        //{
                        //    lblCount.Text = (double.Parse(lblCount.Text) - 1).ToString();
                        //}                        
                        
                    }
                    else
                    {
                        lblMessage.Text = Mesg;
                        Cursor.Current = Cursors.Default;
                        return;
                    }
                    
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "网络错误," + ex.Message.Replace("服务器无法处理请求。 --->","");
                    Cursor.Current = Cursors.Default;
                    return;
                }


                try
                {
                    #region 验证出库全部完成
                    double PickQTYs = double.Parse(Order.Compute("SUM(PICKED_QTY)", "PICKED_QTY>0").ToString());
                    double OrdeQtys = double.Parse(Order.Compute("SUM(ORDER_QTY)", "PICKED_QTY>0").ToString());
                    double ShipQtys = double.Parse(Order.Compute("SUM(SHIP_QTY)", "PICKED_QTY>0").ToString());
                    if (PickQTYs == OrdeQtys && PickQTYs == ShipQtys)
                    {
                        int BOX_COUNT = CC.Singleton().service().PackgeCountByPickTickCode(txtOrderNumber.Text.Trim());//根据出库单号查询总箱数
                        if (MessageBox.Show("核料完成，共" + BOX_COUNT + "箱。是否打印单据?", " 提示", MessageBoxButtons.OKCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                        {
                            bool b = CC.Singleton().service().SaveOrderAutoPrintInfo(txtOrderNumber.Text.Trim(), mainForm._logUser.ID.ToString());
                            if (b == false)
                            {
                                lblMessage.Text = "打印单据保存失败！";
                            }
                            else
                            {
                                lblMessage.Text = "出库全部完成,请返回主界面重新选择单据!";
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }
                        else
                        {
                            //MessageBox.Show("出库全部完成,请返回主界面重新选择单据!");
                            lblMessage.Text = "出库全部完成,请返回主界面重新选择单据!";
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    #endregion 
                    txtPartNumber.Text = string.Empty;
                    txtShipmentsCount.Text = string.Empty;

                    txtPartNumber.Focus();
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Cursor.Current = Cursors.Default;
                }
        }

        private void txtPartNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)    //Enter
            {
                lblMessage.Text = string.Empty;
                DataTable MRow = Order.Clone();
                foreach (DataRow item in Order.Select("ITEM_CODE='" + txtPartNumber.Text.Trim() + "'"))
                {
                    MRow.Rows.Add(item.ItemArray);
                }
                if (MRow.Rows.Count < 1)
                {
                    lblMessage.Text = "该物料号不在拣货单内,请重新输入!";
                    txtPartNumber.SelectAll();
                    return;
                }

                if (float.Parse(MRow.Compute("SUM(SHIP_QTY)", "ORDER_QTY>0").ToString()) >=
                    float.Parse(MRow.Compute("SUM(ORDER_QTY)", "ORDER_QTY>0").ToString()))
                {
                    lblMessage.Text = "该物料已出库,请重新输入!";
                    txtPartNumber.SelectAll();
                    return;
                }
                txtShipmentsCount.SelectAll();
                txtShipmentsCount.Focus();
            }
        }

        private void txtShipmentsCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)    //Enter
            {
                try
                {
                    if(int.Parse(txtShipmentsCount.Text.Trim())<1)
                    {
                        lblMessage.Text = "出库数量必须是大于0的数字!";
                        txtShipmentsCount.SelectAll();
                        return;
                    }
                }
                catch (FormatException ex)
                {
                    lblMessage.Text = "出库数量必须是大于0的数字!";
                    txtShipmentsCount.SelectAll();
                    return;
                }
                btnOut_Click(null, null);
            }
        }

        private void txtPartNumber_LostFocus(object sender, EventArgs e)
        {
            //lblMessage.Text = string.Empty;
            //if (txtPartNumber.Text.Trim() == string.Empty)
            //{
            //    lblMessage.Text = "请输入物料号!";
            //    txtPartNumber.Focus();
            //    return;
            //}
            //if (Order.Select("ITEM_CODE='" + txtPartNumber.Text.Trim() + "'").Length < 1)
            //{
            //    lblMessage.Text = "该物料号不在拣货单内,请重新输入!";
            //    txtPartNumber.SelectAll();
            //    return;
            //}
        }
    }
}