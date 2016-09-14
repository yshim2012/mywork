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
    public partial class PlanInventoryScan : Form
    {
        int CurrIndex = 1;
        DataTable CheckTable;
        string CheckCredence;
        ArrayList list1 = new ArrayList();
        ProgramCheckList CheckList;
        public PlanInventoryScan(DataTable _CheckTable, string _CheckCredence, ProgramCheckList _CheckList)
        {
            InitializeComponent();
            this.CheckTable = _CheckTable;
            this.CheckCredence = _CheckCredence;
            this.CheckList = _CheckList;
            this.txtCheckLoc.Focus();
            //添加用户状态 ，锁定单号
            CC.Singleton().service().UpdateUserState(double.Parse(mainForm._logUser.ID.ToString()), CheckCredence, "CK");
            Cursor.Current = Cursors.Default;
        }

        private void menuBack_Click(object sender, EventArgs e)
        {
            DialogResult rst = MessageBox.Show(
                "当前盘点未完成,是否返回?", "",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (rst == DialogResult.Yes)
            {
                //ProgramCheckList checkList = new ProgramCheckList();
                //checkList.ShowDialog();
                try
                {
                    CC.Singleton().service().UpdateUserState(double.Parse(mainForm._logUser.ID.ToString()), "", "");
                    CC.Singleton().service().UpdateCheckStatus(Convert.ToDouble(this.txtMainId.Text.Trim()), Convert.ToDouble(mainForm._logUser.ID), "OP");
                
               
                this.Close();
                CheckList.Activate();
                CheckList.txtInventoryDoc.Focus();
                CheckList.txtInventoryDoc.SelectAll();
                DataTable dt = CC.Singleton().service().QueryPlanCheck(CheckList.txtInventoryDoc.Text.Trim(), mainForm._logUser.LOGIN_NAME, Convert.ToDouble(mainForm._logUser.ID));
                dt.TableName = "PLANCHECK";
                CheckList.dgList.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Close();
                }
            }
        }

          //未完成的还有多少条
        public void Count()
        {
            for (int i = 0; i < CheckTable.Rows.Count; i++)
            {
                string status = CheckTable.Select("CHECK_CREDENCE='" + CheckCredence + "'")[i]["SON_STATE"].ToString();
                if (status == "OP")
                {
                    list1.Add(i);
                    continue;
                }
            }
        }

        private void PlanInventoryScan_Load(object sender, EventArgs e)
        {
            try
            {
                int count = CheckTable.Rows.Count;
                CurrIndex = 0;
                Count();
                for (int i = 0; i < list1.Count; i++)
                {
                    DataRow dtRow = CheckTable.Rows[Convert.ToInt32(list1[i].ToString())];
                    this.txtInventDoc.Text = CheckCredence;
                    this.txtWareHouse.Text = dtRow["LOC_CODE"].ToString();
                    this.txtInventPart.Text = dtRow["ITEM_CODE"].ToString();
                    this.txtPartName.Text = dtRow["ITEM_NAME"].ToString();
                    this.LabThisCount.Text = (Convert.ToInt32(list1[i].ToString()) + 1) + "/" + count;
                    this.txtDid.Text = dtRow["D_ID"].ToString();
                    this.txtMainId.Text = dtRow["MAIN_ID"].ToString();
                    CC.Singleton().service().UpdateCheckStatus(Convert.ToDouble(this.txtMainId.Text.Trim()), Convert.ToDouble(mainForm._logUser.ID), "CK");
                    break;
                }
            }
            catch (Exception ex)
            {
                this.labMessage.Text = ex.Message;
                MessageBox.Show(ex.Message);
                this.Close();
                CheckList.Activate();
                CheckList.txtInventoryDoc.Focus();
                CheckList.txtInventoryDoc.SelectAll();
            }
        }

        private void menuConfirmed_Click(object sender, EventArgs e)
        {
            if (this.txtPartCode.Text.Trim() == string.Empty)
            {
                this.labMessage.Text = "零件编码不能为空！";
                txtPartCode.Focus();
                return;
            }
            if (this.txtCheckLoc.Text.Trim() == string.Empty)
            {
                this.labMessage.Text = "盘点库位不能为空！";
                txtCheckLoc.Focus();
                return;
            }
            if (this.txtCount.Text.Trim() == string.Empty)
            {
                this.labMessage.Text = "盘点数量不能为空！";
                txtCount.Focus();
                return;
            }
            if (Convert.ToDouble(this.txtCount.Text.Trim()) < 0)
            {
                this.labMessage.Text = "录入数量必须大于等于0！";
                txtCount.Focus();
                txtCount.SelectAll();
                return;
            }
            else
            {
                nextPart();
            }
        }

        private void txtCheckLoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.labMessage.Text = string.Empty;
                if (this.txtCheckLoc.Text.Trim() == string.Empty)
                {
                    this.labMessage.Text = "盘点库位不能为空！";
                    txtCheckLoc.Focus();
                    return;
                }
                if (!this.txtCheckLoc.Text.Trim().Equals(this.txtWareHouse.Text.Trim()))
                {
                    this.labMessage.Text = "盘点库位与库位号不一致！";
                    txtCheckLoc.Focus();
                    txtCheckLoc.SelectAll();
                    return;
                }
                else
                {
                    this.txtPartCode.Focus();
                    return;
                }
            }

        }

        private void txtPartCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.labMessage.Text = string.Empty;
                if (this.txtPartCode.Text.Trim() == string.Empty)
                {
                    this.labMessage.Text = "零件编码不能为空！";
                    txtPartCode.Focus();
                    return;
                }
                if (!this.txtPartCode.Text.Trim().Equals(this.txtInventPart.Text.Trim()))
                {
                    this.labMessage.Text = "零件编码与盘点零件编码不一致！";
                    txtPartCode.Focus();
                    txtPartCode.SelectAll();
                    return;
                }
                else
                {
                    this.txtCount.Focus();
                    return;
                }
            }
        }
        //下一个零件
        public void nextPart()
        {
            try
            {
                int count = CheckTable.Rows.Count;
                labMessage.Text = string.Empty;
                for (int i = 0; i < list1.Count; i++)
                {
                    //list1.Remove(i);
                    CC.Singleton().service().UpdateCheckDetailStatus(Convert.ToDouble(this.txtDid.Text.Trim()), Convert.ToDouble(mainForm._logUser.ID), Convert.ToDouble(this.txtCount.Text.Trim()),"FI");
                    CurrIndex++;
                    if (CurrIndex == list1.Count)
                    {
                        //提示返回
                        DialogResult rst = MessageBox.Show(
                   "当前盘点已完成,即将返回!", "",
                   MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (rst == DialogResult.OK)
                        {
                            CC.Singleton().service().UpdateUserState(double.Parse(mainForm._logUser.ID.ToString()), "", "");
                            //修改主表
                            CC.Singleton().service().UpdateCheckStatus(Convert.ToDouble(this.txtMainId.Text.Trim()), Convert.ToDouble(mainForm._logUser.ID),"FI");
                            //ProgramCheckList checkList = new ProgramCheckList();
                            //checkList.ShowDialog();
                            this.Close();
                            CheckList.Activate();
                            CheckList.txtInventoryDoc.Focus();
                            CheckList.txtInventoryDoc.SelectAll();
                            DataTable dt = CC.Singleton().service().QueryPlanCheck(CheckList.txtInventoryDoc.Text.Trim(), mainForm._logUser.LOGIN_NAME, Convert.ToDouble(mainForm._logUser.ID));
                            dt.TableName = "PLANCHECK";
                            CheckList.dgList.DataSource = dt;
                            return;
                        }
                    }
                    DataRow dtRow = CheckTable.Rows[Convert.ToInt32(list1[CurrIndex].ToString())];
                    this.txtInventDoc.Text = CheckCredence;
                    this.txtWareHouse.Text = dtRow["LOC_CODE"].ToString();
                    this.txtInventPart.Text = dtRow["ITEM_CODE"].ToString();
                    this.txtPartName.Text = dtRow["ITEM_NAME"].ToString();
                    this.LabThisCount.Text = (Convert.ToInt32(list1[CurrIndex].ToString()) + 1) + "/" + count;
                    this.txtDid.Text = dtRow["D_ID"].ToString();
                    this.txtMainId.Text = dtRow["MAIN_ID"].ToString();
                    this.txtCount.Text = string.Empty;
                    this.txtPartCode.Text = string.Empty;
                    this.txtCheckLoc.Text = string.Empty;
                    this.txtCheckLoc.Focus();
                    break;
                }
            }
            catch (Exception ex) {
                this.labMessage.Text = "服务器无法处理请求。 --->";
                return;
            }
        }


        private void txtCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                this.labMessage.Text = string.Empty;
                if (e.KeyChar == 13)
                {
                    menuConfirmed_Click(null, null);
                }
            }
            catch (FormatException ex)
            {
                this.labMessage.Text = "盘点数量输入必须为数字";
                this.txtCount.SelectAll();
                return;
            }
            catch (Exception ex)
            {
                this.labMessage.Text = "服务器无法处理请求。 --->";
                this.txtCount.SelectAll();
                return;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                menuConfirmed_Click(null, null);
            }
            catch (FormatException ex)
            {
                this.labMessage.Text = "盘点数量输入必须为数字";
                return;
            }
            catch (Exception ex)
            {
                this.labMessage.Text = "服务器无法处理请求。 --->";
                return;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            menuBack_Click(null, null);
        }

       
    }
}