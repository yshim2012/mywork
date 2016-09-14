using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SalesPoint.Device.Scan;
using SalesPoint.Device.Core;
using System.Threading;
using CodeBetter.Json;

namespace YTWMS.RFClient
{
    public partial class PackageR : Form
    {
        #region 变量
        public string DocumentNo;

        public DataTable DtMemory;
        private DataRow dr;

        Point p = new Point();

        #endregion

        public PackageR()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PackageR_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Sys.Initilize(); //硬件初始化
                Scanner.Initilize();
                Thread.Sleep(500);

                BindingSource bs = new BindingSource();
                bs.DataSource = BaseInfo.ProjectList;
                this.cmbProject.DataSource = bs;
                this.cmbProject.ValueMember = "Value";
                this.cmbProject.DisplayMember = "Key";

                this.tbxBach.Text = DateTime.Now.ToString("yyyyMMdd").Substring(2);

                #region datatable
                this.DtMemory = new DataTable();

                DataColumn dcPartCode = new DataColumn("PART_CODE", typeof(string));
                DataColumn dcBoxNo = new DataColumn("BOX_NO", typeof(string));
                DataColumn dcQty = new DataColumn("QTY", typeof(int));
                DataColumn dcBatch = new DataColumn("BATCH", typeof(string));
                DataColumn dcProject = new DataColumn("PROJECT_ID", typeof(int));
                DataColumn dcFurnaceNo = new DataColumn("FURNACE_NO", typeof(string));
                DataColumn dcProItemId = new DataColumn("PROJECT_ITEM_ID", typeof(int));
                DataColumn dcShotNo = new DataColumn("SHORT_NO", typeof(string));

                DtMemory.Columns.Add(dcPartCode);
                DtMemory.Columns.Add(dcBoxNo);
                DtMemory.Columns.Add(dcQty);
                DtMemory.Columns.Add(dcBatch);
                DtMemory.Columns.Add(dcProject);
                DtMemory.Columns.Add(dcFurnaceNo);
                DtMemory.Columns.Add(dcProItemId);
                DtMemory.Columns.Add(dcShotNo);

                #endregion

                this.lbMessage.Text = string.Empty;
                this.tbxCode.Focus();
                Cursor.Current = Cursors.Default;
                this.lbCount.Text = "0";
                DtMemory.TableName = "Table";
                this.dgData.DataSource = DtMemory;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("初始化错误:" + ex.Message);
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                LoginInfo info = LoginInfo.GetInstance();

                if (this.tbxPartNo.Text == string.Empty)
                {
                    this.lbMessage.Text = "请输入零件号！";
                    this.tbxPartNo.Focus();
                    return;
                }
                if (this.tboxBoxNo.Text == string.Empty)
                {
                    this.lbMessage.Text = "请输入箱号！";
                    this.tboxBoxNo.Focus();
                    return;
                }
                if (this.tboxQty.Text == string.Empty)
                {
                    this.lbMessage.Text = "请输入数量！";
                    this.tboxQty.Focus();
                    return;
                }
                else if (!RegExpLib.IsValidPosInteger(this.tboxQty.Text))
                {
                    this.lbMessage.Text = "请输入数字类型";
                    this.tboxQty.Focus();
                    return;
                }
                if (this.tbxBach.Text == string.Empty)
                {
                    this.tbxBach.Focus();
                    this.lbMessage.Text = "请输入批次！";
                    return;
                }

                if (DtMemory != null && DtMemory.Rows.Count > 0 && DtMemory.Select("BOX_NO='" + this.tboxBoxNo.Text.Trim() + "'").Length > 0)
                {
                    this.tbxCode.Focus();
                    this.lbMessage.Text = "箱号重复扫描";
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;


                BoxInfo box = new BoxInfo();
                box.PART_CODE = this.tbxPartNo.Text.Trim();
                box.BOX_CODE = this.tboxBoxNo.Text.Trim();
                box.QTY = Convert.ToInt32(this.tboxQty.Text.Trim());
                box.BATCH_NO = this.tbxBach.Text.Trim();
                box.PROJECT_ID = Convert.ToInt32(this.cmbProject.SelectedValue.ToString());
                box.PROJECT_ITEM_ID = 0;
                box.FURNACE_NO = string.Empty;

                string strJson = Converter.Serialize(box);

                string strInfo = ExceService.CheckBoxInfo(info.LoginUser.WAREHOUSE_ID, strJson);

                MessageInfo strMessage = Converter.Deserialize<MessageInfo>(strInfo);
                if (strMessage.ResultState == "Succes")
                {
                    this.lbMessage.Text = strMessage.Info;
                }
                else
                {
                    this.lbMessage.Text = strMessage.Info;
                    this.tbxCode.Focus();
                    Cursor.Current = Cursors.Default;
                    return;
                }

                dr = DtMemory.NewRow();
                dr["PART_CODE"] = this.tbxPartNo.Text.Trim();
                dr["BOX_NO"] = this.tboxBoxNo.Text.Trim();
                dr["QTY"] = Convert.ToInt32(this.tboxQty.Text.Trim());
                dr["BATCH"] = this.tbxBach.Text.Trim();
                dr["PROJECT_ID"] = Convert.ToInt32(this.cmbProject.SelectedValue.ToString());
                dr["FURNACE_NO"] = this.tboxBoxNo.Text.Trim();
                dr["PROJECT_ITEM_ID"] = 0;
                dr["SHORT_NO"] = this.tboxBoxNo.Text.Trim().Substring(14);
                DtMemory.Rows.Add(dr);

                DataView dv = DtMemory.DefaultView;
                dv.Sort = "PART_CODE,BOX_NO";
                this.dgData.DataSource = dv.ToTable();
                this.tbxPartNo.Text = string.Empty;
                this.tboxBoxNo.Text = string.Empty;
                this.tboxQty.Text = string.Empty;
                Cursor.Current = Cursors.Default;
                this.lbMessage.Text = string.Empty;
                this.tbxCode.Focus();
                this.lbCount.Text = DtMemory.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                if (!ExceService.CheckService())
                {
                    this.lbMessage.Text = "无法连接到服务器";
                }
                else
                    MessageBox.Show("Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 收货确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                IList<BoxInfo> boxList = new List<BoxInfo>();
                if (DtMemory.Rows.Count <= 0)
                    return;

                LoginInfo info = LoginInfo.GetInstance();

                Cursor.Current = Cursors.WaitCursor;

                foreach (DataRow dr in DtMemory.Rows)
                {
                    BoxInfo box = new BoxInfo();
                    box.BATCH_NO = dr["BATCH"].ToString();
                    box.PART_CODE = dr["PART_CODE"].ToString();
                    box.PROJECT_ID = Convert.ToInt32(dr["PROJECT_ID"].ToString());
                    box.PROJECT_ITEM_ID = 0;
                    box.QTY = Convert.ToInt32(dr["QTY"].ToString());
                    box.FURNACE_NO = string.Empty;
                    box.BOX_CODE = dr["BOX_NO"].ToString();
                    boxList.Add(box);
                }

                string strJsonBox = Converter.Serialize(boxList);

                string strJson = ExceService.PackageReceive(this.DocumentNo, info.LoginUser.ID, strJsonBox, info.LoginUser.WAREHOUSE_ID);
                MessageInfo strMessage = Converter.Deserialize<MessageInfo>(strJson);
                Cursor.Current = Cursors.Default;
                if (strMessage.ResultState == "Succes")
                {
                    MessageBox.Show("收货成功！");
                    this.Close();
                }
                else
                {
                    this.lbMessage.Text = strMessage.Info;
                    MessageBox.Show(strMessage.Info);
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                if (!ExceService.CheckService())
                {
                    this.lbMessage.Text = "无法连接到服务器";
                }
                else
                    MessageBox.Show("Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PackageR_Closing(object sender, CancelEventArgs e)
        {
            try
            {
                Scanner.Deinitilize();//释放扫描头
                Thread.Sleep(500);
                Sys.Deinitilize();//释放硬件
            }
            catch (Exception ex)
            {
                MessageBox.Show("释放资源错误:" + ex.Message);
                return;
            }
        }

        /// <summary>
        /// 扫描
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (e.KeyValue == 131)
                {
                    string strCode = Scanner.StartScanDim2(ScanType.MotorSound, Encoding.UTF8);
                    strCode = ExceService.FilterByte(strCode);


                    //修改by mjy 2016-8-30 判断一维码
                    if (strCode.Split('-').Length == 3)
                    {
                        this.tbxPartNo.Text = strCode.Split('-')[0].ToString();
                        this.tboxQty.Text = strCode.Split('-')[1].ToString();
                        this.tboxBoxNo.Text = strCode.Split('-')[2].ToString();
                    }
                    else
                    {
                        if (!ExceService.IsBoxFormart(strCode))
                        {
                            Cursor.Current = Cursors.Default;
                            this.tbxCode.Focus();
                            return;
                        }
                        this.tbxPartNo.Text = strCode.Split(' ')[2].Substring(1).ToString();
                        this.tboxQty.Text = strCode.Split(' ')[3].Substring(1).ToString();
                        this.tboxBoxNo.Text = strCode.Split(' ')[4].Substring(2).ToString();
                    }
                    this.btnAdd.Focus();
                    this.lbMessage.Text = string.Empty;
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 零件号回车扫描,输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxPartNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ///零件号一维码扫描
                if (e.KeyValue == 131)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string strCode = Scanner.StartScanDim2(ScanType.MotorSound, Encoding.UTF8);
                    strCode = ExceService.FilterByte(strCode);
                    if (strCode == string.Empty || strCode.Split(' ').Length > 1 || strCode.Split('-').Length == 3)
                    {
                        Cursor.Current = Cursors.Default;
                        this.lbMessage.Text = "请扫描有效的零件号！";
                        this.tbxPartNo.Focus();
                        return;
                    }
                    this.tbxPartNo.Text = strCode;
                    this.tboxBoxNo.Focus();
                    Cursor.Current = Cursors.Default;
                    this.lbMessage.Text = string.Empty;
                }
                else if (e.KeyValue == 13)
                {
                    this.tboxBoxNo.Focus();
                    this.lbMessage.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 箱号回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tboxBoxNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ///零件号一维码扫描
                if (e.KeyValue == 131)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    string strCode = Scanner.StartScanDim2(ScanType.MotorSound, Encoding.UTF8);
                    strCode = ExceService.FilterByte(strCode);
                    if (strCode == string.Empty || strCode.Split(' ').Length > 1 || strCode.Split('-').Length == 3)
                    {
                        Cursor.Current = Cursors.Default;
                        this.lbMessage.Text = "请扫描有效的箱号！";
                        this.tboxBoxNo.Focus();
                        return;
                    }
                    this.tboxBoxNo.Text = strCode;
                    this.tboxQty.Focus();
                    this.lbMessage.Text = string.Empty;
                    Cursor.Current = Cursors.Default;
                }
                else if (e.KeyValue == 13)
                {
                    this.tboxQty.Focus();
                    this.lbMessage.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tboxQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.tbxBach.Focus();
                this.lbMessage.Text = string.Empty;
            }
        }

        /// <summary>
        /// 删除新增项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgData.CurrentRowIndex != -1)
                {
                    int curIndex = dgData.CurrentRowIndex;
                    if (curIndex < 0)
                    {
                        MessageBox.Show("没有要删除的记录!");
                    }

                    if (DtMemory == null || DtMemory.Rows.Count < 0)
                        return;

                    string strBox = dgData[curIndex, 1].ToString();

                    DataRow[] drs = DtMemory.Select(" BOX_NO='" + strBox + "'");

                    if (drs.Length < 0)
                        return;

                    DtMemory.Rows.Remove(drs[0]);
                    DataView dv = DtMemory.DefaultView;
                    dv.Sort = "PART_CODE,BOX_NO";
                    this.dgData.DataSource = dv.ToTable();
                    this.lbCount.Text = DtMemory.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 显示邮件菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgData_MouseDown(object sender, MouseEventArgs e)
        {
            if (MousePosition.IsEmpty)
                return;
            p.X = e.X;
            p.Y = e.Y;

            this.timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dgData.CurrentRowIndex < 0)
            {
                this.timer1.Enabled = false;
                return;
            }
            contextMenu1.Show(dgData, p);

            this.timer1.Enabled = false;
        }

        /// <summary>
        /// 焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxBach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.btnAdd.Focus();
                this.lbMessage.Text = string.Empty;
            }
        }
    }
}