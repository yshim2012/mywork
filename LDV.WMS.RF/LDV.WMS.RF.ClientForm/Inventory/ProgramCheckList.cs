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
    public partial class ProgramCheckList : Form
    {
        public ProgramCheckList()
        {
            InitializeComponent();
            Cursor.Current = Cursors.Default;
        }
        //回车事件
        public void txtInventoryDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    this.labMessage.Text = string.Empty;
                    string checkCredence = this.txtInventoryDoc.Text;
                    DataTable dt = CC.Singleton().service().QueryPlanCheck(checkCredence, mainForm._logUser.LOGIN_NAME, Convert.ToDouble(mainForm._logUser.ID));
                    dt.TableName = "PLANCHECK";
                    this.dgList.DataSource = dt;
                    this.txtInventoryDoc.SelectAll();
                }
                catch(Exception ex)
                {
                    this.labMessage.Text = "服务器无法处理请求。 --->";
                }
            }
        }
        //开始盘点
        private void btnConfirmed_Click(object sender, EventArgs e)
        {
            try
            {
                this.labMessage.Text = string.Empty;
                Cursor.Current = Cursors.Default;
                string checkCredence = this.txtInventoryDoc.Text;
                if (this.txtInventoryDoc.Text.Trim() == string.Empty)
                {
                    this.labMessage.Text = "盘点凭证不能为空！";
                    this.txtInventoryDoc.Focus();
                    this.txtInventoryDoc.SelectAll();
                    return;
                }
                DataTable dt = CC.Singleton().service().QueryPlanCheck(checkCredence,null, Convert.ToDouble(mainForm._logUser.ID));
                if (dt.Rows.Count == 0)
                {
                    this.labMessage.Text = "该盘点凭证不存在！";
                    this.txtInventoryDoc.Focus();
                    this.txtInventoryDoc.SelectAll();
                    return;
                }
                foreach (DataRow item in dt.Rows)
                {
                    if (item["MAIN_STATE"].ToString() == "FI")
                    {
                        dt.TableName = "PLANCHECKFI";
                        break;
                    }
                    if (item["MAIN_STATE"].ToString() == "IV")
                    {
                        dt.TableName = "PLANCHECKIV";
                        break;
                    }
                    if (item["LOGINNAME"].ToString().Trim() != mainForm._logUser.LOGIN_NAME.ToString().Trim() && item["USER_PICK"].ToString() == checkCredence)
                    {
                        dt.TableName = item["LOGINNAME"].ToString();
                        break;
                    }
                    else
                    {
                        dt.TableName = "PLANCHECK";
                    }
                }
                
                if (dt.TableName.Equals("PLANCHECKFI"))
                {
                    this.labMessage.Text = "该盘点凭证已完成盘点！";
                    this.txtInventoryDoc.Focus();
                    this.txtInventoryDoc.SelectAll();
                    return;
                }
                if (dt.TableName.Equals("PLANCHECKIV"))
                {
                    this.labMessage.Text = "该盘点凭证无效！";
                    this.txtInventoryDoc.Focus();
                    this.txtInventoryDoc.SelectAll();
                    return;
                }
                if (!dt.TableName.Equals("PLANCHECKFI") && !dt.TableName.Equals("PLANCHECKIV") && !dt.TableName.Equals("PLANCHECK"))
                {
                    this.labMessage.Text = "该盘点凭证正在被" + dt.TableName.ToString().Trim() + "盘点";
                    this.txtInventoryDoc.Focus();
                    this.txtInventoryDoc.SelectAll();
                    return;
                }
                //dt.TableName = "PLANCHECK";
                this.txtInventoryDoc.SelectAll();
                this.dgList.DataSource = dt;
                PlanInventoryScan planScan = new PlanInventoryScan(dt, checkCredence, this);
                planScan.ShowDialog();
                //this.Close();
            }
            catch(Exception ex){
                this.labMessage.Text = "服务器无法处理请求。 --->";
                
            }
        }

        private void menuBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProgramCheckList_Load(object sender, EventArgs e)
        {
            this.txtInventoryDoc.Focus();
        }

        private void dgList_MouseUp(object sender, MouseEventArgs e)
        {
            System.Drawing.Point pt = new Point(e.X, e.Y);
            DataGrid.HitTestInfo hti = dgList.HitTest(e.X, e.Y);
            if (hti.Type == DataGrid.HitTestType.Cell)
            {
                dgList.CurrentCell = new DataGridCell(hti.Row, hti.Column);
                dgList.Select(hti.Row);
            }   
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        


       
    }
}