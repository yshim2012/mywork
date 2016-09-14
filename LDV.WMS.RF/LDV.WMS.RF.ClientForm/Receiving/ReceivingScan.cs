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
    public partial class ReceivingScan : Form
    {
        DataTable OrderList;
        string OrderNumber;
        DataTable orderInfoList;

        Receiving.NewReceivingAP RdFm;
        public ReceivingScan(DataTable _OrderList, Receiving.NewReceivingAP _RdFm)
        {
            InitializeComponent();
            this.OrderList = _OrderList;
            this.RdFm = _RdFm;



            // txtReceivingNumber.Text = OrderNumber;
            Cursor.Current = Cursors.Default;
            txtPartNumber.Focus();

            //获取订单状态
            // BindDataAgain("all");
            //  orderInfoList = CC.Singleton().service().SelectOrderPartInfo();//所有订单信息



        }

        private void BindDataAgain(string Status)
        {
            //if (Status == "all")
            //{
            //    OrderList = CC.Singleton().service().LoadMainDocByStatus("AP", mainForm._logUser.ID.Value.ToString());//获取所有订单总和信息
            //    orderInfoList = CC.Singleton().service().SelectOrderPartInfo(int.Parse(mainForm._logUser.ID.Value.ToString()),string.Empty);//所有订单信息
            //}
            //if (Status == "item")
            //{
            //    OrderList = CC.Singleton().service().LoadMainDocByStatus("ITEM_" + txtPartNumber.Text.Trim(), mainForm._logUser.ID.Value.ToString());//获取所有订单总和信息---item_code
            //    orderInfoList = CC.Singleton().service().SelectOrderPartInfo(int.Parse(mainForm._logUser.ID.Value.ToString()), txtPartNumber.Text.Trim().ToUpper());//所有订单信息
            //}

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            try
            {
                GC.Collect();

                lblMessage.Text = string.Empty;

                CheckLocWithComment();//提交当前
            }
            catch (Exception ex)
            {
                // throw ex;
                lblMessage.Text = ex.ToString();
            }


        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            //返回
            //清除用户状态
            try
            {
                CC.Singleton().service().UpdateUserState(double.Parse(mainForm._logUser.ID.ToString()), "", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
            this.Close();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            //返回
            btnReturn_Click(null, null);
        }

        private void txtPartNumber_KeyPress(object sender, KeyPressEventArgs e)
        {

            lblMessage.Text = string.Empty;
            //if (e.KeyChar == ' ')
            //{
            //    e.Handled = true;
            //}
            if (e.KeyChar == 0x20)  //禁止空格键  
            {
                e.Handled = true;
            }
            //判断零件是否在收货单内
            if (e.KeyChar == 13)    //Enter
            {
                Cursor.Current = Cursors.WaitCursor;
                CheckPartNumber();
                return;

            }
        }

        private void CheckLocWithComment()
        {
            //验证用户
            try
            {
                if (!CC.Singleton().service().IsUserLoginOtherDevice(mainForm._logUser.LOGIN_NAME, mainForm._logUser.EXTEND_COLUMN_0))
                {
                    lblMessage.Text = "该账号已经在别处登陆!请重新登陆!";
                    Cursor.Current = Cursors.Default; return;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "验证用户出现异常,请检查网络后重试!";
                return;
            }

            //检查默认库位并提交
            try
            {
                #region 判断该零件是否已经预收货和包装

                if (txtInArea.Text.Trim() == string.Empty)
                {
                    lblMessage.Text = "入库库位不能为空!";
                    txtInArea.Focus();
                    return;
                }
                if (txtInCount.Text.Trim() == string.Empty)
                {
                    lblMessage.Text = "入库数量不能为空!";
                    txtInCount.Focus();
                    return;
                }
                if (txtLoc.Text == string.Empty)
                {
                    lblMessage.Text = "默认库位为空!";
                    txtPartNumber.SelectAll();
                    return;
                }
                try
                {
                    double cont = Convert.ToDouble(txtInCount.Text.Trim());
                    if (cont < 1)
                    {
                        lblMessage.Text = "入库数量必须是整数!";
                        txtInCount.SelectAll();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "入库数量必须是数字!";
                    txtInCount.SelectAll();
                    return;
                }

                string ISLOC = "false";
                if (!txtInArea.Text.Trim().Equals(txtLoc.Text))
                {
                    //不是推荐库位
                    DialogResult rst = MessageBox.Show(
                        "当前使用扫描的库位不是系统推荐库位,是否继续?", "",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (rst == DialogResult.No)
                    {
                        txtInArea.Focus();
                        txtInArea.SelectAll();

                        return;
                    }
                    if (rst == DialogResult.Yes)
                    {
                        if (CC.Singleton().service().IsUserWhse(txtInArea.Text.Trim(), mainForm._logUser.ID.Value.ToString()))
                        {
                            ISLOC = "true";
                        }
                        else
                        {
                            lblMessage.Text = "入库库位必须是当前用户对应仓库下的库位!";
                            txtInArea.Focus();
                            txtInArea.SelectAll();
                            return;
                        }


                    }
                }
                string outmsg = string.Empty;
                Cursor.Current = Cursors.WaitCursor;
                if (CC.Singleton().service().SaveAddedDetail(
                    txtPartNumber.Text,
                    double.Parse(txtInCount.Text),
                     txtInArea.Text,
                     ISLOC,
                     mainForm._logUser.ID.Value.ToString(),
                     out outmsg
                    ))
                {
                    lblMessage.Text = "上架成功!";
                    txtPartNumber.Text = string.Empty;
                    txtLoc.Text = string.Empty;
                    txtInArea.Text = string.Empty;
                    txtInCount.Text = string.Empty;
                    txtPartNumber.Focus();
                }
                else
                {
                    lblMessage.Text = "上架失败!";
                }

                #endregion

                GC.Collect();
                #region 原代码
                //int CurrIndex =int.Parse(OrderList.Compute("COUNT(RID)", "EXTEND_COLUMN_2='AP'").ToString());
                //if (CurrIndex == OrderList.Rows.Count)
                //{
                //    string Mid="";
                //    foreach (DataRow item in OrderList.Rows)
                //    {
                //        if (item["EXTEND_COLUMN_2"].ToString() == "AP")
                //        {

                //            Mid=item["RID"].ToString();
                //        }
                //    }
                //    if (Mid.Length > 1)
                //    {
                //        Mid.Remove(Mid.Length - 1, 1);
                //        OrderList.TableName = "SednMain";
                //        if (CC.Singleton().service().SaveOrderMain(Mid.ToString()))
                //        {
                //            RdFm.lblMessage.Text = "单据" + OrderNumber + "已收货完毕!";
                //            this.Close();
                //            RdFm.Activate();
                //        }

                //    }
                //}
                #endregion
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString().Replace("服务器无法处理请求。 ---> ", "");
                lblMessage.Text = error;
                MessageBox.Show(error);
                Cursor.Current = Cursors.Default;
            }

        }


        #region 界面验证

        private void txtInCount_GotFocus(object sender, EventArgs e)
        {
            //lblMessage.Text = string.Empty;
            //if (txtPartNumber.Text == string.Empty)
            //{
            //    lblMessage.Text = "零件号不能为空!";
            //    txtPartNumber.Focus();
            //    return;
            //}
            Cursor.Current = Cursors.WaitCursor;
            CheckPartNumber();

        }

        private void txtInCount_KeyPress(object sender, KeyPressEventArgs e)
        {

            //入库数量入库验证
            lblMessage.Text = string.Empty;
            e.Handled = true;
            if (e.KeyChar >= '0' && e.KeyChar <= '9')  //禁止空格键  
            {
                e.Handled = false;
            }
            if (e.KeyChar == 0x08)
            {
                e.Handled = false;
                return;
            }
            if (e.KeyChar == 13)    //Enter
            {
                if (txtInCount.Text.Trim() == string.Empty)
                {
                    lblMessage.Text = "入库数量不能为空!";
                    txtInCount.Focus();
                    return;
                }

                try
                {
                    double cont = Convert.ToDouble(txtInCount.Text.Trim());
                    if (cont < 1)
                    {
                        lblMessage.Text = "入库数量必须是整数!";
                        txtInCount.SelectAll();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "入库数量必须是数字!";
                    txtInCount.SelectAll();
                    return;
                }
                //txtInArea.Text = txtLoc.Text;
                txtInArea.SelectAll();
                txtInArea.Focus();
            }
        }


        private void txtInArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            //库位提交
            lblMessage.Text = string.Empty;
            if (e.KeyChar == 13)    //Enter
            {
                CheckLocWithComment();

            }
        }



        private void CheckPartNumber()
        {

            //检查零件
            if (txtPartNumber.Text == string.Empty)
            {
                lblMessage.Text = "零件号不能为空!";
                txtPartNumber.Focus();
                Cursor.Current = Cursors.Default;
                return;
            }
            string Item_LOC = txtPartNumber.Text.ToString();
            if (txtLoc.Text == string.Empty || txtLoc.Text == "")
            {
                txtLoc.Text = CC.Singleton().service().GetInfoByPartCode(txtPartNumber.Text.Trim(), mainForm._logUser.ID.Value.ToString());
                txtMloc.Text = CC.Singleton().service().GetInfoByPartCodeMloc(txtPartNumber.Text.Trim(), mainForm._logUser.ID.Value.ToString());
            }
            //判断零件是否存在，存在则获取推荐库位
            //string Item_LOC = CC.Singleton().service().GetInfoByPartCode(txtPartNumber.Text.Trim(), mainForm._logUser.ID.Value.ToString());
            if (Item_LOC == "NotFoundIItem")
            {
                lblMessage.Text = "零件编码" + txtPartNumber.Text.Trim() + "不在上架订单中!";
                // txtPartNumber.Focus(); 
                txtPartNumber.SelectAll();
                Cursor.Current = Cursors.Default;
                GC.Collect();
                return;
            }
            else
            {
                //txtLoc.Text = Item_LOC;
                txtInCount.Focus();
            }
            Cursor.Current = Cursors.Default;
        }


        private void txtInArea_GotFocus(object sender, EventArgs e)
        {

            lblMessage.Text = string.Empty;
            Cursor.Current = Cursors.Default;
            GC.Collect();
            if (txtPartNumber.Text.Trim() == string.Empty)
            {
                txtPartNumber.Focus();
                lblMessage.Text = "零件号不能为空!";
                return;
            }

            if (txtInCount.Text.Trim().Replace(" ", "") == string.Empty)
            {
                txtInCount.Focus();
                lblMessage.Text = "零件数量不能为空!";
                return;
            }
            try
            {
                Convert.ToDouble(txtInCount.Text.Trim());
            }
            catch (Exception ex)
            {
                lblMessage.Text = "入库数量必须是数字!";
                txtInCount.SelectAll();
                return;
            }

            if (txtInArea.Text.Trim() == string.Empty)
            {
                txtInArea.Focus();
                lblMessage.Text = "入库库位不能为空!";
                return;
            }
        }
        #endregion

        private void txtInCount_LostFocus(object sender, EventArgs e)
        {

        }

        //private void txtPartNumber_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    lblMessage.Text = string.Empty;
        //    if (e.KeyChar == 0x20)  //禁止空格键  
        //    {
        //        e.Handled = true;
        //    }
        //    //判断零件是否在收货单内
        //    if (e.KeyChar == 13)    //Enter
        //    {
        //        CheckPartNumber();
        //    }
        //}
    }
}
