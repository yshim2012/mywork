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
    public partial class ReceivingPQDetail : Form
    {
        DataTable OrderList;
        string OrderNumber;
        ReceivingPQ RdFm;
        public ReceivingPQDetail(DataTable _OrderList, string _OrderNumber, ReceivingPQ _RdFm)
        {
            InitializeComponent();
           
            this.OrderNumber = _OrderNumber;

            this.RdFm = _RdFm;
           //根据订单号获取当前订单数据
            this.OrderList = GetOrderInfo();
            
            //添加用户状态 ，锁定单号
            try
            {
                CC.Singleton().service().UpdateUserState(double.Parse(mainForm._logUser.ID.ToString()), OrderNumber, "RC");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
            txtCustName.Text = OrderList.Rows[0]["supplier_name"].ToString();
            txtReceivingNumber.Text = OrderNumber;
            txtPartNumber.Focus();
            txtPartNumber.SelectAll();
            Cursor.Current = Cursors.Default;
          
        }

        private DataTable GetOrderInfo()
        {
            DataTable data=new DataTable();
            try
            {
                data = CC.Singleton().service().LoadMainDoc(OrderNumber, double.Parse(mainForm._logUser.ID.ToString()));
                if (data.TableName == "OrderRV")
                {
                    data.TableName = "OrderList";
                }

            }
            catch (Exception ex)
            {
                lblMessage.Text = "网络错误:" + ex.Message;
                return data;
            }
            if (data.Rows.Count < 1)
            {
                lblMessage.Text = "收货单号不存在!";
                txtReceivingNumber.SelectAll();
                Cursor.Current = Cursors.Default;
                return data;
            }

            if (data.TableName.Equals("OrderPQ") || data.TableName.Equals("OrderCL"))
            {
                lblMessage.Text = "收货单包装已完成!";
                txtReceivingNumber.SelectAll();
              
               
                Cursor.Current = Cursors.Default;
                return data;
            }
            if (data.TableName.Contains("#"))
            {
                lblMessage.Text = "收货单正在被" + data.TableName.Substring(1,data.TableName.Length-1) + "包装!";
                txtReceivingNumber.SelectAll();
              
               
                Cursor.Current = Cursors.Default;
                return data;
            }
          
            try
            {
                if (!CC.Singleton().service().IsUserLoginOtherDevice(mainForm._logUser.LOGIN_NAME, mainForm._logUser.EXTEND_COLUMN_0))
                {
                    lblMessage.Text = "该账号已经在别处登陆!请重新登陆!";
                    Cursor.Current = Cursors.Default;
                    return data;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "验证用户出现异常,请检查网络后重试!";
                return data;
            }
            return data;
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            //重新获取最新数据
            OrderList=GetOrderInfo();

            lblMessage.Text = string.Empty;

            #region 检查空值

            if (txtPartNumber.Text.Trim() == string.Empty)
            {
                txtPartNumber.Focus();
                lblMessage.Text = "零件号不能为空!";
                return;
            }
            if (OrderList.Select("ITEM_CODE='" + txtPartNumber.Text.Trim() + "'").Length < 1)
            {
                lblMessage.Text = "零件编码" + txtPartNumber.Text.Trim() + "不在订单中!";
                txtPartNumber.SelectAll();
                txtPartNumber.Focus();
                return;
            }
            if (txtInCount.Text.Trim() == string.Empty)
            {
                txtInCount.Focus();
                lblMessage.Text = "零件数量不能为空!";
                return;
            }

            DataTable MRow = OrderList.Clone();
            foreach (DataRow item in OrderList.Select("ITEM_CODE='" + txtPartNumber.Text.Trim() + "'"))
            {
                MRow.Rows.Add(item.ItemArray);
            }
            
            float Count = float.Parse(MRow.Compute("SUM(EXPECTED_QTY)", "DID>0").ToString());//计划收货数量总和
            float LastCount = float.Parse(MRow.Compute("SUM(PQQTY)", "DID>0").ToString());//实际收货数量总和

            //判断上架数量与包装数量
            double InCount = 0.00;
            float APCoumt = float.Parse(MRow.Compute("SUM(ACTUAL_QTY)", "DID>0").ToString()); //已上架数量
            if ((Count - APCoumt) < (Count - LastCount))
            {
                InCount = double.Parse(txtInCount.Text.Trim().Replace(" ", "").ToString()) + APCoumt;
            }
            else
            {
                InCount = double.Parse(txtInCount.Text.Trim().Replace(" ", "").ToString()) + LastCount;
            }

            if (double.Parse(txtInCount.Text.Trim().Replace(" ", "").ToString()) < 1 || InCount > Count)
            {
                lblMessage.Text = "数量为0或大于计划数!已包装:" + LastCount.ToString() + ",已上架:" + APCoumt.ToString() + ",计划:" + Count.ToString();
                txtInCount.SelectAll();
                GC.Collect();
                return;
            }
            else
            {
                txtInCount.Focus();
                GC.Collect();
            }
            #endregion

            Cursor.Current = Cursors.WaitCursor;
            CheckLocWithComment();//提交当前

            GC.Collect();
            Cursor.Current = Cursors.Default;
        }

        private void txtInArea_GotFocus(object sender, EventArgs e)
        {

        }
        private void txtInArea_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtInCount_GotFocus(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
            if (txtPartNumber.Text == string.Empty)
            {
                lblMessage.Text = "零件号不能为空!";
                txtPartNumber.Focus();
                return;
            }
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

                DataTable MRow = OrderList.Clone();
                foreach (DataRow item in OrderList.Select("ITEM_CODE='" + txtPartNumber.Text.Trim() + "'"))
                {
                    MRow.Rows.Add(item.ItemArray);
                }

                float Count = float.Parse(MRow.Compute("SUM(EXPECTED_QTY)", "DID>0").ToString());//计划收货数量总和
                float LastCount = float.Parse(MRow.Compute("SUM(PQQTY)", "DID>0").ToString());//实际收货数量总和

                //判断上架数量与包装数量
                double InCount = 0.00;
                float APCoumt = float.Parse(MRow.Compute("SUM(ACTUAL_QTY)", "DID>0").ToString()); //已上架数量
                if ((Count - APCoumt) < (Count - LastCount))
                {
                    InCount = double.Parse(txtInCount.Text.Trim().Replace(" ", "").ToString()) + LastCount;
                }
                else
                {
                    InCount = double.Parse(txtInCount.Text.Trim().Replace(" ", "").ToString()) + LastCount;
                }

                //double InCount = double.Parse(txtInCount.Text.Trim().Replace(" ", "").ToString()) + LastCount;
                if (double.Parse(txtInCount.Text.Trim().Replace(" ", "").ToString()) < 1 || InCount > Count)
                {
                    lblMessage.Text = "数量为0或大于计划数!已包装:" + LastCount.ToString() + ",已上架:" + APCoumt.ToString() + ",计划:" + Count.ToString();
                    txtInCount.SelectAll();
                    GC.Collect();
                    return;
                }
                else
                {

                    btnOK_Click(null, null);
                }
            }
        }

        private void txtPartNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblMessage.Text = string.Empty;
            if (e.KeyChar == 0x20)  //禁止空格键  
            {
                e.Handled = true;
            }
            //判断零件是否在收货单内
            if (e.KeyChar == 13)    //Enter
            {
                CheckPartNumber();
                return;
            }
        }

        private void CheckPartNumber()
        {
            //检查零件
            if (txtPartNumber.Text == string.Empty)
            {
                lblMessage.Text = "零件号不能为空!";
                txtPartNumber.Focus();
                return;
            }
            if (OrderList.Select("ITEM_CODE='" + txtPartNumber.Text.Trim() + "'").Length < 1)
            {
                lblMessage.Text = "零件编码" + txtPartNumber.Text.Trim() + "不在订单中!";
                txtPartNumber.SelectAll();
                txtPartNumber.Focus();
                return;
            }
            if (OrderList.Select("ITEM_CODE='" + txtPartNumber.Text.Trim() + "' AND EXTEND_COLUMN_2 <>'PQ'").Length < 1)
            {
                if (OrderList.Select("ITEM_CODE='" + txtPartNumber.Text.Trim() + "' AND EXTEND_COLUMN_2 <>'OP'").Length == OrderList.Select("ITEM_CODE='" + txtPartNumber.Text.Trim() + "'").Length)
                {
                    lblMessage.Text = "零件" + txtPartNumber.Text.Trim() + "已包装完成!";
                    txtPartNumber.SelectAll();
                    txtPartNumber.Focus();
                    return;
                }
            }
            else
            {
                txtInCount.Focus();
                GC.Collect();
            }

        }

        private void CheckLocWithComment()
        {
            //检查默认库位并提交

            try
            {

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
                DataRow[] TempRows = OrderList.Select("ITEM_CODE='" + txtPartNumber.Text.Trim() + "' AND EXTEND_COLUMN_2<>'AP' AND isnull(EXPECTED_QTY,0)<>isnull(PQ_QTY,0) ");
                if (TempRows.Length < 2 && TempRows.Length != 0)
                {
                    DataRow TempRow = OrderList.NewRow();
                    TempRow.ItemArray = TempRows[0].ItemArray;

                    float LastCount = float.Parse(TempRow["PQQTY"].ToString());
                    float EXPECTED_QTY = float.Parse(TempRow["EXPECTED_QTY"].ToString());

                    //float InCount = float.Parse(Convert.ToDouble(txtInCount.Text.Trim()).ToString()) + LastCount;
                    //判断上架数量与包装数量 
                    float InCount = 0;
                    float APCoumt = float.Parse(TempRow["ACTUAL_QTY"].ToString()); //已上架数量
                    if ((EXPECTED_QTY - APCoumt) < (EXPECTED_QTY - LastCount))
                    {
                       // InCount = float.Parse(txtInCount.Text.Trim().Replace(" ", "").ToString()) + LastCount;
                        if (float.Parse(Convert.ToDouble(txtInCount.Text.Trim()).ToString()) < 1 || InCount + APCoumt > EXPECTED_QTY)
                        {
                            lblMessage.Text = "数量为0或大于计划数!已包装:" + LastCount.ToString() + ",已上架:" + APCoumt.ToString() + ",计划:" + EXPECTED_QTY.ToString(); ;
                            txtInCount.SelectAll();
                            return;
                        }
                    }
                    else
                    {
                       // InCount = float.Parse(txtInCount.Text.Trim().Replace(" ", "").ToString()) + LastCount;
                        if (float.Parse(Convert.ToDouble(txtInCount.Text.Trim()).ToString()) < 1 || InCount + LastCount > EXPECTED_QTY)
                        {
                            lblMessage.Text = "数量为0或大于计划数!已包装:" + LastCount.ToString() + ",已上架:" + APCoumt.ToString() + ",计划:" + EXPECTED_QTY.ToString(); ;
                            txtInCount.SelectAll();
                            return;
                        }
                    }
                    InCount = float.Parse(txtInCount.Text.Trim().Replace(" ", "").ToString()) + LastCount;
                    if (float.Parse(Convert.ToDouble(txtInCount.Text.Trim()).ToString()) < 1 || InCount > EXPECTED_QTY)
                    {
                        lblMessage.Text = "数量为0或大于计划数!已包装:" + LastCount.ToString() + ",已上架:" + APCoumt.ToString() + ",计划:" + EXPECTED_QTY.ToString(); ;
                        txtInCount.SelectAll();
                        return;
                    }
                    bool ISLOC = false;

                    //提交

                    Cursor.Current = Cursors.WaitCursor;
                    string OutMsg = "";//最上级主表ID
                    try
                    {
                        if (CC.Singleton().service().SaveAllReceivingPQ(
                            TempRow["DID"].ToString(),
                            TempRow["ITEM_ID"].ToString(),
                            float.Parse(Convert.ToDouble(txtInCount.Text.Trim()).ToString()),
                            InCount,
                            EXPECTED_QTY,
                            txtLoc.Text.Trim(),
                            double.Parse(TempRow["WHSE_ID"].ToString()),
                            TempRow["RECEIVEDATE"].ToString(),
                            ISLOC,
                            double.Parse(TempRow["SUPPLIER_ID"].ToString()),
                            mainForm._logUser.ID.Value,
                            TempRow["RID"].ToString(),
                            out OutMsg
                            ))
                        {
                            OrderList.Select("ITEM_CODE='" + txtPartNumber.Text.Trim() + "'")[0]["PQQTY"] = InCount;
                            lblMessage.Text = "包装成功!";
                            txtPartNumber.Text = string.Empty;
                            txtInCount.Text = string.Empty;
                            txtPartNumber.Focus();
                        }
                        else
                        {
                            lblMessage.Text = "包装失败!";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = ex.Message.Substring(ex.Message.IndexOf("该"), ex.Message.IndexOf("!") + 1 - ex.Message.IndexOf("该"));
                        txtInCount.SelectAll();
                        Cursor.Current = Cursors.Default;
                        return;
                    }
                    //MessageBox.Show(InCount.ToString() + EXPECTED_QTY.ToString());

                    if (OutMsg.Equals("OK"))
                    {
                        RdFm.lblMessage.Text = "单据" + OrderNumber + "已包装完毕!";
                        Cursor.Current = Cursors.Default;
                        RdFm.Activate();
                        DialogResult rst = MessageBox.Show(
                "当前包装已完成", "",
                MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        this.Close();


                    }

                    if (OutMsg.Equals("Catch"))
                    {
                        Cursor.Current = Cursors.Default;
                        lblMessage.Text = "修改主单据出现异常!请重试";
                        return;
                    }
                    if (InCount == EXPECTED_QTY)
                    {
                        OrderList.Select("DID=" + TempRow["DID"] + "")[0]["EXTEND_COLUMN_2"] = "AP";
                    }

                }
                if (TempRows.Length > 1)
                {
                    DataTable MRow = OrderList.Clone();
                    foreach (DataRow item in TempRows)
                    {
                        MRow.Rows.Add(item.ItemArray);
                    }
                    double ComtCount = 0;//成功条数

                    float Sum_LastCount = float.Parse(MRow.Compute("SUM(PQQTY)", "DID>0").ToString());//实际收货数量总和
                    float Sum_EXPECTED_QTY = float.Parse(MRow.Compute("SUM(EXPECTED_QTY)", "DID>0").ToString());//计划收货数量总和
                    float APCount = float.Parse(MRow.Compute("SUM(ACTUAL_QTY)", "DID>0").ToString()); //上架数量
                    float Sum_InCount = float.Parse(Convert.ToDouble(txtInCount.Text.Trim()).ToString());//此次提交总收货量
                    float InCount = float.Parse(Convert.ToDouble(txtInCount.Text.Trim()).ToString());//此次提交收货数量
                    foreach (DataRow TempRow in MRow.Rows)
                    {
                        if (Sum_InCount == 0)
                        {
                            break;
                        }

                        float LastCount = float.Parse(TempRow["PQQTY"].ToString());//实际收货数量
                        float EXPECTED_QTY = float.Parse(TempRow["EXPECTED_QTY"].ToString());//计划收货数量
                        if ((Sum_EXPECTED_QTY - APCount) < (Sum_EXPECTED_QTY - Sum_LastCount))
                        {
                            if (float.Parse(Convert.ToDouble(txtInCount.Text.Trim()).ToString()) < 1 || InCount + APCount > Sum_EXPECTED_QTY)
                            {
                                lblMessage.Text = "数量为0或大于计划数!已包装:" + Sum_LastCount.ToString() + ",已上架:" + APCount.ToString() + ",计划:" + Sum_EXPECTED_QTY.ToString(); ;
                                txtInCount.SelectAll();
                                continue;
                                //return;
                            }
                        }
                        else
                        {
                            if (float.Parse(Convert.ToDouble(txtInCount.Text.Trim()).ToString()) < 1 || InCount + Sum_LastCount > Sum_EXPECTED_QTY)
                            {
                                lblMessage.Text = "数量为0或大于计划数!已包装:" + Sum_LastCount.ToString() +",已上架:" + APCount.ToString() + ",计划:" + Sum_EXPECTED_QTY.ToString(); ;
                                txtInCount.SelectAll();
                                continue;
                                //return;
                            }
                        }
                        bool ISLOC = true;

                        //提交                        
                        if (InCount > EXPECTED_QTY - LastCount)
                        {
                            InCount = EXPECTED_QTY - LastCount;
                        }
                        Cursor.Current = Cursors.WaitCursor;
                        string OutMsg = "";//最上级主表ID
                        try
                        {
                            if (CC.Singleton().service().SaveAllReceivingPQ(
                                TempRow["DID"].ToString(),
                                TempRow["ITEM_ID"].ToString(),
                                InCount,
                                InCount + LastCount,
                                EXPECTED_QTY,
                                txtLoc.Text.Trim(),
                                double.Parse(TempRow["WHSE_ID"].ToString()),
                                TempRow["RECEIVEDATE"].ToString(),
                                ISLOC,
                                double.Parse(TempRow["SUPPLIER_ID"].ToString()),
                                mainForm._logUser.ID.Value,
                                TempRow["RID"].ToString(),
                                out OutMsg
                                ))
                            {
                                Sum_InCount = Sum_InCount - InCount;
                                OrderList.Select("DID=" + TempRow["DID"] + "")[0]["PQQTY"] = LastCount + InCount;
                                ComtCount = ComtCount + InCount;

                                InCount = Sum_InCount;
                                if (Sum_InCount == 0)
                                {
                                    lblMessage.Text = "包装成功!";
                                    txtPartNumber.Text = string.Empty;
                                    txtInCount.Text = string.Empty;
                                    txtPartNumber.Focus();


                                }

                            }
                            else
                            {
                                lblMessage.Text = "包装失败!成功:" + ComtCount.ToString() + "个,失败:" + (Sum_InCount - ComtCount).ToString();

                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            lblMessage.Text = ex.Message.Substring(ex.Message.IndexOf("该"), ex.Message.IndexOf("!") + 1 - ex.Message.IndexOf("该"));
                            txtInCount.SelectAll();
                            Cursor.Current = Cursors.Default;
                            return;
                        }

                        if (OutMsg.Equals("OK"))
                        {
                            RdFm.lblMessage.Text = "单据" + OrderNumber + "已包装完毕!";
                            GC.Collect();
                            Cursor.Current = Cursors.Default;
                            DialogResult rst = MessageBox.Show(
                            "当前包装已完成", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            this.Close();
                            RdFm.Activate();
                            return;
                        }

                        if (OutMsg.Equals("Catch"))
                        {
                            Cursor.Current = Cursors.Default;
                            lblMessage.Text = "修改主单据出现异常!请重试";
                            GC.Collect();
                            return;
                        }
                        if (InCount + LastCount == EXPECTED_QTY)
                        {
                            OrderList.Select("DID=" + TempRow["DID"] + "")[0]["EXTEND_COLUMN_2"] = "AP";
                        }
                    }
                }
                GC.Collect();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                //lblMessage.Text = ex.Message;
                MessageBox.Show(ex.Message);
                Cursor.Current = Cursors.Default;
            }

        }
    }
}