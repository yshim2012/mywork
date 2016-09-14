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
    public partial class WarehouseMoveNew : Form
    {

        /// <summary>
        /// 行号
        /// </summary>
        private int SelectIndex
        {
            get;
            set;
        }

        public WarehouseMoveNew()
        {
            InitializeComponent();
        }

        private void dataGrid1_MouseUp(object sender, MouseEventArgs e)
        {
            System.Drawing.Point pt = new Point(e.X, e.Y);
            DataGrid.HitTestInfo hti = dataGrid1.HitTest(e.X, e.Y);
            if (hti.Type == DataGrid.HitTestType.Cell)
            {
                dataGrid1.CurrentCell = new DataGridCell(hti.Row, hti.Column);
                dataGrid1.Select(hti.Row);
                dataGrid1_CurrentCellChanged(sender, e);
            }   
            if (hti.Type == DataGrid.HitTestType.RowHeader)
            {
                dataGrid1.CurrentCell = new DataGridCell(hti.Row, hti.Column);
                dataGrid1.Select(hti.Row);
                dataGrid1_CurrentCellChanged(sender,e);
            }   
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 开始移库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartM_Click(object sender, EventArgs e)
        {
            try
            {
                this.lbMessage.Text = string.Empty;
                Cursor.Current = Cursors.WaitCursor;
                string moveNumber = this.txtPlanNo.Text.Trim();
                if (moveNumber == string.Empty)
                {
                    this.lbMessage.Text = "移库编号不能为空";
                    Cursor.Current = Cursors.Default;
                    return;
                }
                DataTable dtPlanList = CC.Singleton().service().QueryMovePlanDetailByPlanNo(moveNumber);


                if (dtPlanList==null|| dtPlanList.Rows.Count == 0)
                {
                    this.lbMessage.Text = "该移库编号不存在或已移库完成！";
                    this.txtPlanNo.SelectAll();
                    Cursor.Current = Cursors.Default;
                    return;
                }
                WarehouseMoveScan WMS = new WarehouseMoveScan(dtPlanList);
                WMS.ShowDialog();
             
            }
            catch (Exception ex)
            {
                this.lbMessage.Text = ex.Message;
                lbMessage.Text = lbMessage.Text.Replace("服务器无法处理请求。 --->", "");
                Cursor.Current = Cursors.Default;
                return;
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        public void BindData()
        {
            try
            {
                DataTable dtPlan = CC.Singleton().service().QueryMovePlan();
                dtPlan.TableName = "OrderList";
                dataGrid1.DataSource = dtPlan;
                if (dtPlan.Rows.Count < 1)
                {
                    lbMessage.Text = "未查询到数据!";
                    return;
                }
                this.txtPlanNo.Focus();

            }
            catch (Exception ex)
            {
                lbMessage.Text = "网络错误:" + ex.Message;
                Cursor.Current = Cursors.Default;
                return;
            }
        }

        /// <summary>
        /// 回车选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPlanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DataTable dt = (DataTable)dataGrid1.DataSource;

                if (dt==null || dt.Rows.Count <= 0)
                {
                    lbMessage.Text = "无移库计划请返回刷新"; 
                    Cursor.Current = Cursors.Default;
                    return;
                }
                //foreach (DataRow dr in dt.Rows)
                //{
                //    if (dr["move_loc_num"].ToString() == this.txtPlanNo.Text.Trim())
                //    {
                //        SelectIndex = dt.Rows.IndexOf(dr);
                //        break;
                //    }
                //}

                //dataGrid1_GotFocus(sender, e);
                btnStartM_Click(sender, e);
            }
        }

        /// <summary>
        /// /初始窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WarehouseMoveNew_Load(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 焦点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGrid1_GotFocus(object sender, EventArgs e)
        {

        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            int rowIndex = this.dataGrid1.CurrentRowIndex;
            this.txtPlanNo.Text = dataGrid1[rowIndex, 0].ToString();
            this.txtPlanNo.SelectAll();
        }

        private void dataGrid1_Click(object sender, EventArgs e)
        {
            txtPlanNo.Focus();
        }
    }
}