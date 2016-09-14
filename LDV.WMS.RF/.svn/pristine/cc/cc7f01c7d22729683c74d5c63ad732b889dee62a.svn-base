using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClientForward;
using System.Collections;

namespace LDV.WMS.RF.ClientForm
{
    public partial class PickScan : Form
    {
        int RemoveCount = 0;
        int CurrIndex = 1;
        string OrderNumber;
        //订单主表状态
        string st;
        DataTable OrderList;
        //初始化时把未拣货的行索引+进去
        ArrayList list1 = new ArrayList();
        //点击拣下一个货物按钮 如未拣则加进去行索引
        ArrayList list = new ArrayList();
        ArrayList list4 = new ArrayList();
        PickCheckOrder CheckOrder;
        public PickScan(DataTable _OrderList, string _orderNumber, PickCheckOrder _CheckOrder)
        {
            InitializeComponent();
            this.OrderList = _OrderList;
            this.OrderNumber = _orderNumber;
            this.CheckOrder = _CheckOrder;
            this.txtPickArea.Focus();
            try
            {
                //添加用户状态 ，锁定单号
                CC.Singleton().service().UpdateUserState(double.Parse(mainForm._logUser.ID.ToString()), OrderNumber, "PC");
            }
            catch(Exception ex)
            {
                lblMessage.Text = "服务器无法处理请求。 --->";
                throw ex;
            }
            //DisplayText(OrderList.Rows[CurrIndex]);
            Cursor.Current = Cursors.Default;
        }

        public void nextpart1()
        {
            int count = OrderList.Rows.Count;
            int rowCount=0;
            if (CurrIndex >= 0)
            {
                rowCount = CurrIndex;
            }

            for (int i = 0; i < list1.Count; i++)
            {
                CurrIndex++;
                if (CurrIndex == list1.Count)
                {
                    CurrIndex = 0;
                    i = 0;
                }
                DataRow dtRow = OrderList.Rows[Convert.ToInt32(list1[CurrIndex].ToString())];
                if (Convert.ToDouble(dtRow["ALLOCATED_QTY"].ToString()) != 0)
                {
                    int conut1 = Convert.ToInt32(list1[CurrIndex].ToString());
                    SetPickScanTxt(dtRow, conut1, count);
                    break;
                }
                else
                {
                    continue;
                }
            }
            if (list.Count == 1)
            {
                this.btnNextPart.Enabled = false;
            }
            if (RemoveCount == list1.Count && list.Count == 0)
            {
                EndPick();
                
            }
        }

        public void EndPick()
        {
            try
            {
                CC.Singleton().service().Checked(OrderNumber, mainForm._logUser.LOGIN_NAME, Convert.ToDouble(mainForm._logUser.ID), Convert.ToDouble(this.txtBatchId.Text.Trim()));

                Cursor.Current = Cursors.Default;
                DialogResult rst = MessageBox.Show(
                 "当前拣货已完成,退出拣货", "",
                 MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                this.Close();
                CheckOrder.txtOrderNumber.Focus();
                CheckOrder.txtOrderNumber.SelectAll();
                return;
            }
            catch (Exception ex)
            {
                lblMessage.Text = "服务器无法处理请求。 --->";
                Cursor.Current = Cursors.Default;
                return;
            }
        }
        public void submit()
        {
            string mess = string.Empty;
            string type = string.Empty;
            double updateQty = 0;
            double pickedQty = 0;
            //拣货数量
            if (this.txtOutCount.Text.Trim() != string.Empty)
            {
                pickedQty = Convert.ToDouble(this.txtOutCount.Text.Trim());
            }
            string userId = mainForm._logUser.ID.ToString();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataTable dtWare = CC.Singleton().service().QueryWareHouse(Convert.ToDouble(this.txtWhId.Text.Trim()));
                //仓库名称
                string wareName = dtWare.Select("ID='" + this.txtWhId.Text.Trim() + "'")[0]["WHSE_NAME"].ToString();
                //调用移库方法
                //CC.Singleton().service().MovPickLoc(mainForm._logUser.LOGIN_NAME, mainForm._logUser.EXTEND_COLUMN_0, this.txtArea.Text.Trim(), wareName + "-F", this.txtPickPartNumber.Text.Trim(), Convert.ToInt32(this.txtOutCount.Text.Trim()),Convert.ToDouble(this.txtWantPickCount.Text.Trim()),Convert.ToDouble(this.txtVpaId.Text.Trim()),Convert.ToDouble(this.txtBatchId.Text.Trim()),Convert.ToDouble(this.txtVpqId.Text.Trim()),Convert.ToDouble(this.txtMuId.Text.Trim()),Convert.ToDouble(this.txtUidId.Text.Trim()),userId,Convert.ToDouble(this.txtPickId.Text.Trim()),Convert.ToDouble(this.txtDetailId.Text.Trim()),Convert.ToDouble(this.txtQueueId.Text.Trim()),this.txtLineNo.Text.Trim(),out mess, out type,out updateQty);
                CC.Singleton().service().MovePickLoc(mainForm._logUser.LOGIN_NAME, mainForm._logUser.EXTEND_COLUMN_0, Convert.ToDouble(this.txtVpaId.Text.Trim()), Convert.ToInt32(this.txtOutCount.Text.Trim()), wareName + "-F", mainForm._logUser.ID.ToString(), out mess, out type, out updateQty);
                if (type == "CHENGGONG")
                {
                    if (Convert.ToDouble(this.txtOutCount.Text.Trim()) == Convert.ToDouble(this.txtWantPickCount.Text.Trim()))
                    {
                        DataRow dtRowUpdate = OrderList.Rows[Convert.ToInt32(list1[CurrIndex].ToString())];
                        dtRowUpdate.BeginEdit();
                        dtRowUpdate["ALLOCATED_QTY"] = updateQty;
                        dtRowUpdate.EndEdit();
                        if (list.Contains(Convert.ToInt32(list1[CurrIndex].ToString())))
                        {
                            list.Remove(Convert.ToInt32(list1[CurrIndex].ToString()));
                            RemoveCount++;
                        }
                    }
                    else
                    {
                        DataRow dtRowUpdate = OrderList.Rows[Convert.ToInt32(list1[CurrIndex].ToString())];
                        dtRowUpdate.BeginEdit();
                        dtRowUpdate["ALLOCATED_QTY"] = updateQty;
                        dtRowUpdate.EndEdit();
                    }
                    this.lblMessage.Text = mess;
                }
                else
                {
                    this.lblMessage.Text = mess;
                    Cursor.Current = Cursors.Default;
                    this.txtPickArea.Text = string.Empty;
                    this.txtPartNumber.Text = string.Empty;
                    this.txtOutCount.Text = string.Empty;
                    this.txtPickArea.Focus();
                    return;
                }
            }
            catch (FormatException ex)
            {
                this.lblMessage.Text = "出库数量输入必须为数字";
                Cursor.Current = Cursors.Default;
                return;
            }
            catch (Exception ex)
            {
                lblMessage.Text = "服务器无法处理请求。 --->";
                Cursor.Current = Cursors.Default;
                return;
            }
        }


        //public void nextPart()
        //{
        //    try
        //    {
        //        int count = OrderList.Rows.Count;
        //        lblMessage.Text = string.Empty;
        //        string mess = string.Empty;
        //        string type = string.Empty;
        //        double updateQty = 0;          
        //        double pickedQty = 0;
        //        //拣货数量
        //        if (this.txtOutCount.Text.Trim() != string.Empty)
        //        {
        //            pickedQty = Convert.ToDouble(this.txtOutCount.Text.Trim());
        //        }
        //        string userId = mainForm._logUser.ID.ToString();
              
        //        for (int i = 0; i < list1.Count; i++)
        //        {
        //            if ((this.txtOutCount.Text.Trim() == "0" || this.txtOutCount.Text.Trim() == string.Empty) || !this.txtPartNumber.Text.Trim().Equals(this.txtPickPartNumber.Text.Trim()) || !this.txtPickArea.Text.Trim().Equals(this.txtArea.Text.Trim()))
        //            {                       
        //                CurrIndex++;
        //                if (CurrIndex == list1.Count)
        //                {
        //                    CurrIndex = 0;
        //                    i = 0;
        //                }

        //                DataRow dtRow = OrderList.Rows[Convert.ToInt32(list1[CurrIndex].ToString())];
        //                if (Convert.ToDouble(dtRow["ALLOCATED_QTY"].ToString()) != 0)
        //                {
        //                    int conut1 = Convert.ToInt32(list1[CurrIndex].ToString());
        //                    SetPickScanTxt(dtRow, conut1, count);                          
        //                    break;
        //                }
        //                else
        //                {
        //                    continue;
        //                }
        //            }
        //            else
        //            {
        //                if (Convert.ToDouble(this.txtOutCount.Text.Trim()) == Convert.ToDouble(this.txtWantPickCount.Text.Trim()))
        //                {
                            
        //                    if (list.Contains(Convert.ToInt32(list1[CurrIndex].ToString())))
        //                    {
        //                        list.Remove(Convert.ToInt32(list1[CurrIndex].ToString()));
        //                        RemoveCount++;
        //                    }
        //                }
        //                else if (Convert.ToDouble(this.txtOutCount.Text.Trim()) > Convert.ToDouble(this.txtWantPickCount.Text.Trim()))
        //                {
        //                    this.lblMessage.Text = "出库数量不能大于要求未拣货数量";
        //                    Cursor.Current = Cursors.Default;
        //                    this.txtOutCount.Focus();
        //                    this.txtOutCount.SelectAll();
        //                    return;
        //                }
        //                try
        //                {
        //                    Cursor.Current = Cursors.WaitCursor;
        //                    DataTable dtWare = CC.Singleton().service().QueryWareHouse(Convert.ToDouble(this.txtWhId.Text.Trim()));
        //                    //仓库名称
        //                    string wareName = dtWare.Select("ID='" + this.txtWhId.Text.Trim() + "'")[0]["WHSE_NAME"].ToString();
        //                    //调用移库方法
        //                    CC.Singleton().service().MovPickLoc(mainForm._logUser.LOGIN_NAME, mainForm._logUser.EXTEND_COLUMN_0, this.txtArea.Text.Trim(), wareName + "-F", this.txtPickPartNumber.Text.Trim(), Convert.ToInt32(this.txtOutCount.Text.Trim()),Convert.ToDouble(this.txtWantPickCount.Text.Trim()),Convert.ToDouble(this.txtVpaId.Text.Trim()),Convert.ToDouble(this.txtBatchId.Text.Trim()),Convert.ToDouble(this.txtVpqId.Text.Trim()),Convert.ToDouble(this.txtMuId.Text.Trim()),Convert.ToDouble(this.txtUidId.Text.Trim()),userId,Convert.ToDouble(this.txtPickId.Text.Trim()),Convert.ToDouble(this.txtDetailId.Text.Trim()),Convert.ToDouble(this.txtQueueId.Text.Trim()),this.txtLineNo.Text.Trim(),out mess, out type,out updateQty);
        //                }
        //                catch (Exception ex)
        //                {
        //                    lblMessage.Text = "服务器无法处理请求。 --->";
        //                    Cursor.Current = Cursors.Default;
        //                    return;
        //                }
        //            }
        //            if (type == "CHENGGONG")
        //            {
        //                if (Convert.ToDouble(this.txtOutCount.Text.Trim()) == Convert.ToDouble(this.txtWantPickCount.Text.Trim()))
        //               {
        //                    DataRow dtRowUpdate = OrderList.Rows[Convert.ToInt32(list1[CurrIndex].ToString())];
        //                    dtRowUpdate.BeginEdit();
        //                    dtRowUpdate["ALLOCATED_QTY"] = updateQty;
        //                    dtRowUpdate.EndEdit();
        //                    if (list.Contains(Convert.ToInt32(list1[CurrIndex].ToString())))
        //                    {
        //                        list.Remove(Convert.ToInt32(list1[CurrIndex].ToString()));
        //                        RemoveCount++;
        //                    }
        //                }
        //                else
        //                {
        //                     DataRow dtRowUpdate = OrderList.Rows[Convert.ToInt32(list1[CurrIndex].ToString())];
        //                    dtRowUpdate.BeginEdit();
        //                    dtRowUpdate["ALLOCATED_QTY"] = updateQty;
        //                    dtRowUpdate.EndEdit();
        //                }
        //                CurrIndex++;
        //                if (RemoveCount == list1.Count && list.Count == 0)
        //                {
        //                    try
        //                    {
        //                        CC.Singleton().service().Checked(OrderNumber, mainForm._logUser.LOGIN_NAME, Convert.ToDouble(mainForm._logUser.ID), Convert.ToDouble(this.txtBatchId.Text.Trim()));
                                
        //                        Cursor.Current = Cursors.Default;
        //                        DialogResult rst = MessageBox.Show(
        //                         "当前拣货已完成,退出拣货", "",
        //                         MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        //                        this.Close();
        //                        CheckOrder.txtOrderNumber.Focus();
        //                        CheckOrder.txtOrderNumber.SelectAll();
        //                        return;
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        lblMessage.Text = "服务器无法处理请求。 --->";
        //                        Cursor.Current = Cursors.Default;
        //                        return;
        //                    }
        //                }
        //                if (CurrIndex == list1.Count)
        //                {
        //                    CurrIndex = 0;
        //                    i = Convert.ToInt32(list[0].ToString());
        //                }
        //                DataRow dtRow = OrderList.Rows[Convert.ToInt32(list1[CurrIndex].ToString())];
        //                if (Convert.ToDouble(dtRow["ALLOCATED_QTY"].ToString()) != 0)
        //                {
        //                    int conut1 = Convert.ToInt32(list1[CurrIndex].ToString());
        //                    SetPickScanTxt(dtRow, conut1, count);
        //                    Cursor.Current = Cursors.Default;
        //                    break;
        //                }
        //                else
        //                {
        //                    for (int k = 0; k < list1.Count; i++)
        //                    {
        //                        dtRow = OrderList.Rows[Convert.ToInt32(list1[CurrIndex].ToString())];
        //                        if (Convert.ToDouble(dtRow["ALLOCATED_QTY"].ToString()) != 0)
        //                        {
        //                            int conut1 = Convert.ToInt32(list1[CurrIndex].ToString());
        //                            SetPickScanTxt(dtRow, conut1, count);
        //                            Cursor.Current = Cursors.Default;
        //                            break;
        //                        }
        //                        else
        //                        {
        //                            CurrIndex++;
        //                            if (CurrIndex == list1.Count)
        //                            {
        //                                CurrIndex = 0;
        //                                i = Convert.ToInt32(list[0].ToString());
        //                                Cursor.Current = Cursors.Default;
        //                            }
        //                            continue;
        //                        }
        //                    }
        //                    break;
        //                }

        //            }
        //            else
        //            {
        //                this.lblMessage.Text = mess;
        //                Cursor.Current = Cursors.Default;
        //                this.txtPickArea.Text = string.Empty;
        //                this.txtPartNumber.Text = string.Empty;
        //                this.txtOutCount.Text = string.Empty;
        //                this.txtPickArea.Focus();
        //                return;
        //            }
        //        }

        //    }
        //    catch (FormatException ex)
        //    {
        //        this.lblMessage.Text = "出库数量输入必须为数字";
        //        return;
        //    }
        //    catch (Exception ex)
        //    {
        //        lblMessage.Text = "服务器无法处理请求。 --->";
        //        return;
        //    }
           
        //}
        /// <summary>
        /// 拣下一个零件按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextPart_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = string.Empty;
                //nextPart();
                nextpart1();
            }
            catch (Exception ex)
            {
                this.lblMessage.Text=ex.Message;
                return;
            }
        }

        private void txtPickArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                CheckLocWithComment();
            }

        }
        //库位验证
        private void CheckLocWithComment()
        {
            lblMessage.Text = string.Empty;
            if (this.txtPickArea.Text.Trim() == string.Empty)
            {
                txtPickArea.Focus();
                lblMessage.Text = "拣货库位不能为空!";
                return;
            }
            if (!txtPickArea.Text.Trim().Equals(txtArea.Text.Trim()))
            {
                DialogResult rst = MessageBox.Show(
                   "当前使用扫描的库位不是系统推荐库位,不能拣货!", "",
                   MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                if (rst == DialogResult.OK)
                {
                    txtPickArea.Focus();
                    txtPickArea.SelectAll();
                    return;
                }
            }
            else
            {
                this.txtPartNumber.Focus();
                return;
            }

        }
        //零件验证
        private void CheckPartNumber()
        {
            this.lblMessage.Text = string.Empty;
            if (this.txtPartNumber.Text.Trim() == string.Empty)
            {
                txtPartNumber.Focus();
                lblMessage.Text = "零件号不能为空！";
                return;
            }
            if (!this.txtPartNumber.Text.Trim().Equals(this.txtPickPartNumber.Text.Trim()))
            {
                this.lblMessage.Text = "您当前拣的零件号必须与拣货物料号相同";
                txtPartNumber.Focus();
                txtPartNumber.SelectAll();
                return;
            }
            if (OrderList.Select("ITEM_CODE='" + txtPartNumber.Text.Trim() + "'").Length < 1)
            {
                lblMessage.Text = "零件编码" + txtPartNumber.Text.Trim() + "不在订单中!";
                txtPartNumber.Focus();
                txtPartNumber.SelectAll();
                return;
            }
            else
            {
                txtOutCount.Focus();
                return;
            }
        }

        private void txtPartNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                CheckPartNumber();
            }
        }

        private void txtOutCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                
                if (e.KeyChar == 13)
                {
                    lblMessage.Text = string.Empty;
                    //需要拣货数量
                    double wantCount = double.Parse(OrderList.Select("ITEM_CODE='" + this.txtPickPartNumber.Text.Trim() + "'")[0]["ORDER_QTY"].ToString());
                    //已经拣货数量
                    double PickCount = double.Parse(OrderList.Select("ITEM_CODE='" + this.txtPickPartNumber.Text.Trim() + "'")[0]["PICKED_QTY"].ToString());
                    //未拣货数量
                    double noPickCount = Convert.ToDouble(this.txtWantPickCount.Text.Trim());
                    if (this.txtOutCount.Text.Trim() == string.Empty)
                    {
                        lblMessage.Text = "出库数量不能为空!";
                        txtOutCount.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtOutCount.Text) <= 0)
                    {
                        lblMessage.Text = "出库数量必须大于零";
                        txtOutCount.Focus();
                        txtOutCount.SelectAll();
                        return;
                    }
                    if (Convert.ToDouble(this.txtOutCount.Text) > noPickCount)
                    {
                        lblMessage.Text = "出库数量不能大于要求未拣货数量";
                        txtOutCount.Focus();
                        txtOutCount.SelectAll();
                        return;
                    }
                    if (!this.txtPickArea.Text.Trim().Equals(this.txtArea.Text.Trim()))
                    {
                        this.lblMessage.Text = "拣货库位必须与推荐库位相同";
                        txtPickArea.Focus();
                        txtPickArea.SelectAll();
                        return;
                    }
                    if (!this.txtPartNumber.Text.Trim().Equals(this.txtPickPartNumber.Text.Trim()))
                    {
                        this.lblMessage.Text = "您当前拣的零件号必须与拣货物料号相同";
                        txtPartNumber.Focus();
                        txtPartNumber.SelectAll();
                        return;
                    }
                    //nextPart();
                   
                    submit();
                    Cursor.Current = Cursors.Default;
                    if (this.lblMessage.Text == "拣货成功!")
                     nextpart1();
                }
            }
            catch (FormatException ex)
            {
                this.lblMessage.Text = "出库数量输入必须为数字";
                txtOutCount.SelectAll();
                return;
            }
            catch(Exception ex) {
                lblMessage.Text = "服务器无法处理请求。 --->";
                return;
            }
        }
       

        //未完成的还有多少条
        public void Count()
        {
            
            for (int i = 0; i < OrderList.Rows.Count; i++)
            {
                string status = OrderList.Select("PICK_TICKET_CODE='" + OrderNumber + "'")[i]["ALLOCATED_QTY"].ToString();
                st = OrderList.Select("PICK_TICKET_CODE='" + OrderNumber + "'")[i]["ORDER_STATUS"].ToString();
                if (Convert.ToDouble(status) > 0)
                {

                    list1.Add(i);
                    list.Add(i);
                    continue;
                }
                else
                {
                    list4.Add(st);
                }
            }
           
            if (list1.Count == 1)
            {
                this.btnNextPart.Enabled = false;
            }
        }

        private void PickScan_Load_1(object sender, EventArgs e)
        {
            CurrIndex = -1;
            Count();
            if (list.Count == 0 && list4.Contains("PA"))
            {
                this.Close();
                CheckOrder.lblMessage.Text = "该订单分配拣货零件已完成";
                CheckOrder.txtOrderNumber.Focus();
                CheckOrder.txtOrderNumber.SelectAll();
                return;
            }
            nextpart1();
        }
        private void SetPickScanTxt(DataRow dtRow,int conut, int AllCount)
        {
            this.txtOrderNumber.Text = OrderNumber;
            this.txtPickPartNumber.Text = dtRow["ITEM_CODE"].ToString();
            this.txtPartName.Text = dtRow["ITEM_NAME"].ToString();
            this.txtWantPickCount.Text = dtRow["ALLOCATED_QTY"].ToString();
            this.txtArea.Text = dtRow["LOC_CODE"].ToString();
            this.label4.Text = (conut + 1) + "/" + AllCount;
            this.txtDetailId.Text = dtRow["DETAIL_ID"].ToString();
            this.txtPickId.Text = dtRow["TICKET_ID"].ToString();
            this.txtQueueId.Text = dtRow["PICK_ID"].ToString();
            this.txtBatchId.Text = dtRow["BATCH_ID"].ToString();
            this.txtMuId.Text = dtRow["MU_ID"].ToString();
            this.txtUidId.Text = dtRow["UID_ID"].ToString();
            this.txtWhId.Text = dtRow["WHSE_ID"].ToString();
            this.txtVpaId.Text = dtRow["VPA_ID"].ToString();
            this.txtPickQty.Text = dtRow["PICK_QTY"].ToString();
            this.txtVpqId.Text = dtRow["VPQ_ID"].ToString();
            this.txtLineNo.Text = dtRow["LINE_NO"].ToString();
            this.txtPickArea.Text = string.Empty;
            this.txtOutCount.Text = string.Empty;
            this.txtPartNumber.Text = string.Empty;
            this.txtPickArea.Focus();
        }
        //返回
        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rst = MessageBox.Show(
                   "当前拣货未完成,是否返回?", "",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (rst == DialogResult.Yes)
                {
                    CC.Singleton().service().UpdateUserState(double.Parse(mainForm._logUser.ID.ToString()), "", "");
                    this.Close();
                    //CheckOrder.Show();
                    CheckOrder.txtOrderNumber.Focus();
                    CheckOrder.txtOrderNumber.SelectAll();
                    //CheckOrder.Activate();
                }
            }
            catch(Exception ex)
            {
                this.Close();
              
            }
        }

       
       
     
    }
}