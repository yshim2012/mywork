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
    public partial class PackageChange : Form
    {
        public PackageChange()
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
            this.txtPartCode.Text = string.Empty;
            this.txtMoveCount.Text = string.Empty;
            this.txtOldPackage.Focus();
        }

        private void btnConfirmed_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInfo())
                {
                    Cursor.Current = Cursors.WaitCursor;
                    DataTable innerdt = CC.Singleton().service().QueryPackegeOn(this.txtOldPackage.Text.Trim(), null);
                    if (innerdt.Rows.Count == 0)
                    {
                        this.lblMessage.Text = "原箱号无零件信息！";
                        this.txtOldPackage.Focus();
                        Cursor.Current = Cursors.Default;
                        ClearForm();
                        return;
                    }
                    else
                    {
                        DataRow innerdtRow = innerdt.Rows[0];
                        string rowStatus=innerdtRow["STATUS"].ToString();
                        if (rowStatus == "CL")
                        {
                            this.lblMessage.Text = "原箱号已发货,不能被调整";
                            this.txtOldPackage.Focus();
                            Cursor.Current = Cursors.Default;
                            ClearForm();
                            return;
                        }
                    }
                    DataTable dt1 = CC.Singleton().service().QueryPackege(this.txtOldPackage.Text.Trim(), this.txtPartCode.Text.Trim());
                    if (dt1.Rows.Count == 0)
                    {
                        this.lblMessage.Text = "零件不在原箱号中！";
                        Cursor.Current = Cursors.Default;
                        this.txtPartCode.Focus();
                        this.txtPartCode.SelectAll();
                        return;
                    }
                    //DataRow row = dt1.Rows[0];
                    //double qty = Convert.ToDouble(row["QTY"].ToString());
                    double qty = double.Parse(dt1.Compute("SUM(QTY)", "ITEM_CODE='" + this.txtPartCode.Text.Trim().ToString() + "'").ToString());
                    if (Convert.ToDouble(this.txtMoveCount.Text.Trim()) > qty)
                    {
                        this.lblMessage.Text = "移动数量不能大于原箱号中零件数量";
                        Cursor.Current = Cursors.Default;
                        this.txtMoveCount.Focus();
                        this.txtMoveCount.SelectAll();
                        return;
                    }
                    DataTable dt = CC.Singleton().service().QueryPackege(this.txtNewPackage.Text.Trim(), null);
                    if (dt.Rows.Count == 0)
                    {
                        this.lblMessage.Text = "新箱号" + this.txtNewPackage.Text.Trim() + "不正确！";
                        Cursor.Current = Cursors.Default;
                        this.txtNewPackage.Focus();
                        this.txtNewPackage.SelectAll();
                        return;
                    }
                    
                    DataRow row1 = dt.Rows[0];
                    string status = row1["STATUS"].ToString();
                    if (status == "CL")
                    {
                        this.lblMessage.Text = "新箱号已发货,不能被调整！";
                        Cursor.Current = Cursors.Default;
                        this.txtNewPackage.Focus();
                        this.txtNewPackage.SelectAll();
                        return;
                    }
                    string oldCustomer = innerdt.Rows[0]["PICK_TICKET_CODE"].ToString();
                    string newCustomer = string.Empty;

                    //double oldCustomer = Convert.ToDouble(innerdt.Rows[0]["PICK_TICKET_CODE"].ToString());
                   // double newCustomer=0;
                    if (dt.Rows[0]["PICK_TICKET_CODE"].ToString() != string.Empty)
                    {
                         //newCustomer = Convert.ToDouble(dt.Rows[0]["PICK_TICKET_CODE"].ToString());
                        newCustomer = dt.Rows[0]["PICK_TICKET_CODE"].ToString();
                    }
                    if (oldCustomer != newCustomer && newCustomer!=string.Empty)
                    {
                        this.lblMessage.Text = "两箱订单不同,不能被调整！";
                        Cursor.Current = Cursors.Default;
                        this.txtNewPackage.Focus();
                        this.txtNewPackage.SelectAll();
                        return;
                    }
                    //拣货ID
                    //double tickticketId=Convert.ToDouble(innerdt.Rows[0]["PICK_ID"].ToString());
                    //新箱号ID
                   
                    double newId = Convert.ToDouble(dt.Rows[0]["PACKEGE_ID"].ToString());
                    //关系表ID
                    DataRow[] dtList = dt1.Select("ITEM_CODE='" + this.txtPartCode.Text.Trim() + "'");
                    bool a=true;
                    double BianQty = 0;
                    double oldQty1 = 0;
                    foreach (DataRow item in dtList)
                    {
                        double Did = double.Parse(item["D_ID"].ToString());
                        double tickticketId = double.Parse(item["PICK_ID"].ToString());
                        if (Convert.ToDouble(this.txtMoveCount.Text.Trim()) != 0 && qty != 0)
                        {
                            a = CC.Singleton().service().UpdatePackege(Did, newId, Convert.ToDouble(this.txtMoveCount.Text.Trim()), qty, tickticketId, Convert.ToDouble(mainForm._logUser.ID), this.txtPartCode.Text.Trim(), this.txtOldPackage.Text.Trim(), oldCustomer, out BianQty, out oldQty1);
                        }
                        this.txtMoveCount.Text = BianQty.ToString();
                        qty = oldQty1;
                    }
                    //double Did = Convert.ToDouble(dt1.Rows[0]["D_ID"].ToString());
                    //double Did = double.Parse(dt1.Select("ITEM_CODE='" + this.txtPartCode.Text.Trim() + "'")[0]["D_ID"].ToString());
                    
                    if (a == true)
                    {
                        //移动成功后，检查原箱数
                        int BOX_COUNT = CC.Singleton().service().PackgeCountByPickTickCode(oldCustomer);//根据出库单号查询总箱数
                        //DataTable dtInfo = CC.Singleton().service().QueryPackegeOn(this.txtOldPackage.Text.Trim(), null);
                        //double ShipQtys = 0;
                        //foreach (DataRow dr in dtInfo.Rows)
                        //{
                        //    ShipQtys +=double.Parse( dr["QTY"].ToString());
                        //}
                        if (MessageBox.Show("包装箱号调整完成，共" + BOX_COUNT + "箱。是否打印单据?", " 提示", MessageBoxButtons.OKCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                        {
                            bool b = CC.Singleton().service().SaveOrderAutoPrintInfo(oldCustomer, mainForm._logUser.ID.ToString());
                            if (b == false)
                            {
                                lblMessage.Text = "打印单据保存失败！";
                            }
                            else
                            {
                                lblMessage.Text = "移动成功，打印单据保存成功!";
                            }
                        }
                        else
                        {
                            this.lblMessage.Text = "移动成功！";                         
                        }
                        Cursor.Current = Cursors.Default;
                        ClearForm();
                    }
                    else
                    {
                        this.lblMessage.Text = "移动失败！";
                        Cursor.Current = Cursors.Default;
                        ClearForm();
                    }
                }
            }
            catch(Exception ex)
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
            if (this.txtPartCode.Text.Trim() == string.Empty)
            {
                this.lblMessage.Text = "请扫描零件编码！";
                this.txtPartCode.Focus();
                return false;
            }
            if (this.txtMoveCount.Text.Trim() == string.Empty)
            {
                this.lblMessage.Text = "请录入移动数量！";
                this.txtMoveCount.Focus();
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
                        this.txtMoveCount.Focus();
                        this.txtMoveCount.SelectAll();
                        this.lblMessage.Text = "移动数量（只能是大于零的数字）";
                        return false;
                    }
                }
                catch (Exception)
                {
                    this.txtMoveCount.Focus();
                    this.txtMoveCount.SelectAll();
                    this.lblMessage.Text = "移动数量（只能是大于零的数字）";
                    return false;
                }
            }
            if (this.txtNewPackage.Text.Trim() == string.Empty)
            {
                this.lblMessage.Text = "新箱号不能为空！";
                this.txtNewPackage.Focus();
                return false;
            }
            if (this.txtNewPackage.Text.Trim() == this.txtOldPackage.Text.Trim())
            {
                this.lblMessage.Text = "新箱号与原箱号一致！";
                this.txtNewPackage.SelectAll();
                this.txtNewPackage.Focus();
                return false;
            }
            return true;
        }

        private void txtPartCode_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (e.KeyChar == 13)
            {
                this.lblMessage.Text = string.Empty;
                if (this.txtPartCode.Text.Trim() == string.Empty)
                {
                    this.lblMessage.Text = "请扫描零件编码！";
                    this.txtPartCode.Focus();
                    return;
                }
                //DataTable dt1 = CC.Singleton().service().QueryPackege(this.txtOldPackage.Text.Trim(), this.txtPartCode.Text.Trim());
                //if (dt1.Rows.Count == 0)
                //{
                //    this.lblMessage.Text = "零件不在原箱号中！";
                //    this.txtPartCode.Focus();
                //    this.txtPartCode.SelectAll();
                //    return;
                //}
                else
                {
                    this.txtMoveCount.Focus();
                    this.txtMoveCount.SelectAll();
                }
            }
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
                //DataTable dt = CC.Singleton().service().QueryPackege(this.txtOldPackage.Text.Trim(), null);
                //if (dt.Rows.Count == 0)
                //{
                //    this.lblMessage.Text = "原箱号无零件信息！";
                //    this.txtOldPackage.Focus();
                //    this.txtOldPackage.SelectAll();
                //    return;
                //}
                else
                {
                    this.txtPartCode.Focus();
                    this.txtPartCode.SelectAll();
                }

            }
        }

        private void txtMoveCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.lblMessage.Text = string.Empty;
                if (this.txtMoveCount.Text.Trim() == string.Empty)
                {
                    this.lblMessage.Text = "请录入移动数量！";
                    this.txtMoveCount.Focus();
                    return;
                }
                else
                {
                    try
                    {
                        int count = 0;
                        count = int.Parse(this.txtMoveCount.Text.Trim());
                        if (count <= 0)
                        {
                            this.txtMoveCount.Focus();
                            this.txtMoveCount.SelectAll();
                            this.lblMessage.Text = "移动数量（只能是大于零的数字）";
                            return;
                        }
                        else
                        {
                            this.txtNewPackage.Focus();
                            this.txtNewPackage.SelectAll();
                        }
                    }
                    catch (Exception)
                    {
                        this.txtMoveCount.Focus();
                        this.txtMoveCount.SelectAll();
                        this.lblMessage.Text = "移动数量（只能是大于零的数字）";
                        return;
                    }
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