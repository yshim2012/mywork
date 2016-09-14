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
    public partial class CycleCountScanner : Form
    {
        DataTable dtShow = new DataTable();
        public CycleCountScanner()
        {
            InitializeComponent();
        }

        private void menuBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtWareHouse_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.labMessage.Text = string.Empty;
            string locCode = this.txtWareHouse.Text.Trim();
           
            if (e.KeyChar == 13)
            {
                //DataTable dt = CC.Singleton().service().QueryByLocId(locCode);
                if (this.txtWareHouse.Text.Trim() == string.Empty)
                {
                    this.labMessage.Text = "盘点库位不能为空！";
                    this.txtWareHouse.Focus();
                    return;
                }
                //if (dt.Rows.Count == 0)
                //{
                //    this.labMessage.Text = "扫描库位不存在！";
                //    this.txtWareHouse.Focus();
                //    this.txtWareHouse.SelectAll();
                //    return;
                //}
                else
                {
                    this.txtPartCode.Focus();
                }
            }
        }

        private void txtPartCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.labMessage.Text = string.Empty;
            string itemCode = this.txtPartCode.Text.Trim();
            if (e.KeyChar == 13)
            {
                if (this.txtWareHouse.Text.Trim() == string.Empty)
                {
                    this.labMessage.Text = "盘点库位不能为空！";
                    this.txtWareHouse.Focus();
                    return;
                }
                if (this.txtPartCode.Text.Trim() == string.Empty)
                {
                    this.labMessage.Text = "零件编码不能为空！";
                    this.txtPartCode.Focus();
                    return;
                }
                //DataTable item = CC.Singleton().service().GetItem(itemCode);
                //if (item.Rows.Count == 0)
                //{
                //    this.labMessage.Text = "零件编码不存在！";
                //    this.txtPartCode.Focus();
                //    this.txtPartCode.SelectAll();
                //    return;
                //}
                else
                {
                    this.txtCount.Focus();
                }
            }
        }

        private void txtCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                this.labMessage.Text = string.Empty;
                if (e.KeyChar == 13)
                {
                    if (this.txtWareHouse.Text.Trim() == string.Empty)
                    {
                        this.labMessage.Text = "盘点库位不能为空！";
                        this.txtWareHouse.Focus();
                        return;
                    }
                    if (this.txtPartCode.Text.Trim() == string.Empty)
                    {
                        this.labMessage.Text = "零件编码不能为空！";
                        this.txtPartCode.Focus();
                        return;
                    }
                    if (this.txtCount.Text.Trim() == string.Empty)
                    {
                        this.labMessage.Text = "盘点数量不能为空！";
                        this.txtCount.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtCount.Text.Trim()) < 0)
                    {
                        this.labMessage.Text = "盘点数量必须大于等于零！";
                        this.txtCount.Focus();
                        this.txtCount.SelectAll();
                        return;
                    }
                    menuConfirmation_Click(null, null);
                }
            }
            catch (FormatException ex)
            {
                this.labMessage.Text = "盘点数量输入必须为数字";
                this.txtCount.SelectAll();
                return;
            }
                

        }

        private void menuConfirmation_Click(object sender, EventArgs e)
        {
            try
            {
                this.labMessage.Text = string.Empty;
                string messge = string.Empty;
                string locCode = this.txtWareHouse.Text.Trim();
                string itemCode = this.txtPartCode.Text.Trim();
                if (this.txtWareHouse.Text.Trim() == string.Empty)
                {
                    this.labMessage.Text = "盘点库位不能为空！";
                    this.txtWareHouse.Focus();
                    return;
                }
                if (this.txtPartCode.Text.Trim() == string.Empty)
                {
                    this.labMessage.Text = "零件编码不能为空！";
                    this.txtPartCode.Focus();
                    return;
                }
                if (this.txtCount.Text.Trim() == string.Empty)
                {
                    this.labMessage.Text = "盘点数量不能为空！";
                    this.txtCount.Focus();
                    return;
                }
                if (Convert.ToInt32(this.txtCount.Text.Trim()) < 0)
                {
                    this.labMessage.Text = "盘点数量必须大于等于零！";
                    this.txtCount.Focus();
                    this.txtCount.SelectAll();
                    return;
                }
                DataTable dt = CC.Singleton().service().QueryByLocId(locCode);
                DataTable item = CC.Singleton().service().GetItem(itemCode);
                if (dt.Rows.Count == 0)
                {
                       DialogResult rst = MessageBox.Show(
                   "扫描库位不存在!", "",
                   MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                       if (rst == DialogResult.OK)
                       {
                           //this.labMessage.Text = "扫描库位不存在!";
                           this.txtWareHouse.Focus();
                           this.txtWareHouse.SelectAll();
                           this.txtPartCode.Text = string.Empty;
                           this.txtCount.Text = string.Empty;
                           return;
                       }
                }
                if (item.Rows.Count == 0)
                {
                     DialogResult rst = MessageBox.Show(
                   "零件编码不存在!", "",
                   MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                    
                     if (rst == DialogResult.OK)
                     {
                         //this.labMessage.Text = "零件编码不存在!";
                         this.txtPartCode.Focus();
                         this.txtPartCode.SelectAll();
                         this.txtCount.Text = string.Empty;
                         return;
                     }
                }
                //验证！
                //bool a = CC.Singleton().service().CheckLoc(mainForm._logUser.LOGIN_NAME, mainForm._logUser.EXTEND_COLUMN_0, this.txtWareHouse.Text.Trim(), this.txtPartCode.Text.Trim(), Convert.ToInt32(this.txtCount.Text.Trim()), out messge);
                //if (a == false)
                //{
                    //this.labMessage.Text = messge;
                    //return;
                //}
                //else
                //{
                    double loc_id = double.Parse(dt.Select("LOC_CODE='" + this.txtWareHouse.Text.Trim() + "'")[0]["LOC_ID"].ToString());
                    double item_id=double.Parse(item.Select("ITEM_CODE='"+this.txtPartCode.Text.Trim()+"'")[0]["ID"].ToString());
                    string item_name = item.Select("ITEM_CODE='" + this.txtPartCode.Text.Trim() + "'")[0]["ITEM_NAME"].ToString();
                    double qty=Convert.ToDouble(this.txtCount.Text.Trim());
                    bool isture = CC.Singleton().service().InsertFreeCheck(loc_id, item_id, qty,Convert.ToDouble(mainForm._logUser.ID));
                    if (isture == true)
                    {
                        this.labMessage.Text = "盘点成功！";
                        
                        if (dtShow.Rows.Count == 0)
                        {
                            dtShow.Columns.Add("LOC_CODE");
                            dtShow.Columns.Add("ITEM_CODE");
                            dtShow.Columns.Add("ITEM_NAME");
                            dtShow.Columns.Add("COUNT");
                            //dtShow.Columns["LOC_CODE"].ColumnName = "库位代码";
                            //dtShow.Columns["ITEM_CODE"].ColumnName = "零件代码";
                            //dtShow.Columns["ITEM_NAME"].ColumnName = "零件名称";
                            //dtShow.Columns["COUNT"].ColumnName = "数量";
                            dtShow.Rows.Add(this.txtWareHouse.Text.Trim(), this.txtPartCode.Text.Trim(), item_name, qty);
                        }
                        else
                        {
                            DataRow newRow = dtShow.NewRow();
                            newRow["LOC_CODE"] = this.txtWareHouse.Text.Trim();
                            newRow["ITEM_CODE"]= this.txtPartCode.Text.Trim();
                            newRow["ITEM_NAME"] = item_name;
                            newRow["COUNT"] = qty;
                            dtShow.Rows.InsertAt(newRow,0);
                        }
                        dtShow.TableName = "SHOWDT";
                        this.dgList.DataSource = dtShow;
                        
                    }
                    else
                    {
                        this.labMessage.Text = "盘点失败！";
                        return;
                    }
                    this.txtPartCode.Text = string.Empty;
                    this.txtWareHouse.Text = string.Empty;
                    this.txtCount.Text = string.Empty;
                    this.txtWareHouse.Focus();
                }
            //}
            catch (FormatException ex)
            {
                this.labMessage.Text = "盘点数量输入必须为数字";
                this.txtCount.SelectAll();
                return;
            }
            catch(Exception ex)
            {
                this.labMessage.Text = "服务器无法处理请求。 --->";
                
            }
        }

        private void CycleCountScanner_Load(object sender, EventArgs e)
        {
            this.txtWareHouse.Focus();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            menuConfirmation_Click(null, null);
        }

    }
}