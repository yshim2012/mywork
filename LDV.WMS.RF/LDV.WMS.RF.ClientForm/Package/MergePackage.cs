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
    public partial class MergePackage : Form
    {
        public MergePackage()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ClearForm()
        {
            this.txtOldPackage.Text = string.Empty;
            this.txtNewPackage.Text = string.Empty;
            this.txtOldPackage.Focus();
            //this.lblMessage.Text = string.Empty;
        }

        private void btnConfirmed_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInfo())
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string Msg = string.Empty;
                    bool a = true;
                    a = CC.Singleton().service().MergePackage(this.txtOldPackage.Text.Trim(), this.txtNewPackage.Text.Trim(), Convert.ToDouble(mainForm._logUser.ID), out Msg);

                   
                    if (a == true)
                    {
                        DataTable innerdt = CC.Singleton().service().QueryPackegeOn(this.txtNewPackage.Text.Trim(), null);
                        string oldCustomer = innerdt.Rows[0]["PICK_TICKET_CODE"].ToString();


                        //移动成功后，检查原箱数
                        int BOX_COUNT = CC.Singleton().service().PackgeCountByPickTickCode(oldCustomer);//根据出库单号查询总箱数

                        if (MessageBox.Show("合箱完成，共" + BOX_COUNT + "箱。是否打印单据?", " 提示", MessageBoxButtons.OKCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                        {
                            bool b = CC.Singleton().service().SaveOrderAutoPrintInfo(oldCustomer, mainForm._logUser.ID.ToString());
                            if (b == false)
                            {
                                lblMessage.Text = "打印单据保存失败！";
                            }
                            else
                            {
                                lblMessage.Text = Msg + "打印单据保存成功!";
                            }
                        }
                        else
                        {
                            this.lblMessage.Text = Msg;
                        }
                        Cursor.Current = Cursors.Default;
                        ClearForm();
                    }
                    else
                    {
                        this.lblMessage.Text = Msg;
                        Cursor.Current = Cursors.Default;
                        ClearForm();
                    }
                }
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = "服务器无法处理请求。 --->";
                Cursor.Current = Cursors.Default;
                return;
            }
        }

        public bool CheckInfo()
        {
            if (this.txtOldPackage.Text.Trim() == string.Empty)
            {
                this.lblMessage.Text = "请扫描原箱号！";
                this.txtOldPackage.Focus();
                return false;
            }
            if (this.txtNewPackage.Text.Trim() == string.Empty)
            {
                this.lblMessage.Text = "目的箱号不能为空！";
                this.txtNewPackage.Focus();
                return false;
            }
            if (this.txtNewPackage.Text.Trim() == this.txtOldPackage.Text.Trim())
            {
                this.lblMessage.Text = "目的箱号与原箱号一致！";
                this.txtNewPackage.SelectAll();
                this.txtNewPackage.Focus();
                return false;
            }
            return true;
        }

        private void txtOldPackage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.lblMessage.Text = string.Empty;
                if (this.txtOldPackage.Text.Trim() == string.Empty)
                {
                    this.lblMessage.Text = "请扫描原箱号！";
                    this.txtOldPackage.Focus();
                    return;
                }
            }
        }

        private void menuConfirmed_Click(object sender, EventArgs e)
        {
            btnConfirmed_Click(null, null);
        }

        private void PackageChange_Load(object sender, EventArgs e)
        {
            this.txtOldPackage.Focus();
        }

        private void txtNewPackage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                lblMessage.Text = string.Empty;
                btnConfirmed_Click(null, null);
            }
        }
    }
}