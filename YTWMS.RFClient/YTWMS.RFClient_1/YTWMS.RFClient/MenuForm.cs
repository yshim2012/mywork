using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTWMS.RFClient
{
    public partial class MenuForm : Form 
    {
        Form parentForm;
        public MenuForm(Form parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            LoginInfo info = LoginInfo.GetInstance();
            try
            {
                this.Text = "主界面";

                #region 卡车信息
                DataTable dt = ExceService.GetWareHouseTrcuks(info.LoginUser.WAREHOUSE_ID);
                IDictionary<string, string> truckList = new Dictionary<string, string>();
                foreach (DataRow dr in dt.Rows)
                {
                    truckList.Add(dr["LICENCEPLATE"].ToString(), dr["ID"].ToString());
                }
                BaseInfo.truckList = truckList;
                
                #endregion

                #region 供应商信息
                DataTable dtSupplier = ExceService.GetWareHouseSupplier(info.LoginUser.WAREHOUSE_ID);
                IDictionary<string, string> SupplierList = new Dictionary<string, string>();
                foreach (DataRow dr in dtSupplier.Rows)
                {
                    SupplierList.Add(dr["WAREHOUSE_CODE"].ToString(), dr["ID"].ToString());
                }
                BaseInfo.SupplierList = SupplierList;
                #endregion

                #region 项目信息
                DataTable dtProject = ExceService.GetWareHouseProject(info.LoginUser.WAREHOUSE_ID);
                IDictionary<string, string> projectList = new Dictionary<string, string>();
                foreach (DataRow dr in dtProject.Rows)
                {
                    projectList.Add(dr["PROJECT_NAME"].ToString(), dr["ID"].ToString());
                }
                BaseInfo.ProjectList = projectList;
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message.ToString());
            }

        }

        #region 按钮事件

        /// <summary>
        /// 发货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOut_Click(object sender, EventArgs e)
        {
            //QuereyShippingPlanForm form = new QuereyShippingPlanForm(this);
            //form.ShowDialog();
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExist_Click(object sender, EventArgs e)
        {
            this.parentForm.Show();
            this.Close();
        }

        /// <summary>
        /// 排序发货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSortSend_Click(object sender, EventArgs e)
        {
            SortSend frmSort = new SortSend();
            frmSort.ShowDialog();
        }

        /// <summary>
        /// 整箱收货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPackageReceive_Click(object sender, EventArgs e)
        {
            ReceiveInfo info = new ReceiveInfo();
            info.ShowDialog();
        }

        /// <summary>
        /// 整箱批量收货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPackageBatchReceive_Click(object sender, EventArgs e)
        {
            BatchPackageR batchReceive = new BatchPackageR();
            batchReceive.ShowDialog();
        }

        /// <summary>
        /// 整箱发货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPackageSend_Click(object sender, EventArgs e)
        {
            PackageSend pSend = new PackageSend();
            pSend.ShowDialog();
        }

        /// <summary>
        /// 退供应商发货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPackageBackSupplier_Click(object sender, EventArgs e)
        {
            PackageBack back = new PackageBack();
            back.ShowDialog();
        }

        #endregion
    }
}