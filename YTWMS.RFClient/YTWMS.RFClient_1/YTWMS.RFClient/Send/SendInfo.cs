using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CodeBetter.Json;

namespace YTWMS.RFClient
{
    public partial class SendInfo : Form
    {
        public DataTable dtQuene;

        public string SortNo;

        public SendInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendInfo_Load(object sender, EventArgs e)
        {
            try
            {
                LoginInfo info = LoginInfo.GetInstance();

                BindingSource bs = new BindingSource();
                bs.DataSource = BaseInfo.truckList;
                this.cmbSelect.DataSource = bs;
                this.cmbSelect.ValueMember = "Value";
                this.cmbSelect.DisplayMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message.ToString());
            }
        }

        /// <summary>
        /// 发货确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOut_Click(object sender, EventArgs e)
        {
            try
            {
                LoginInfo info = LoginInfo.GetInstance();

                if (this.SortNo == string.Empty)
                {
                    MessageBox.Show("没有要发货的排序单号！");
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                string strJson = ExceService.SendConfirm(SortNo,info.LoginUser.ID,info.LoginUser.WAREHOUSE_ID,this.txtDock.Text.Trim(),this.txtDriver.Text.Trim(),this.cmbSelect.SelectedText.ToString());
                MessageInfo Message = Converter.Deserialize<MessageInfo>(strJson);
                if (Message.ResultState == "Succes")
                {
                    MessageBox.Show("发货成功！");
                    Cursor.Current = Cursors.Default;
                    SortSend frm = (SortSend)this.Owner;
                    frm.CurrentSeqNo = 1;
                    frm.dtMenory = null;
                    this.Close();
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    this.lbMessage.Text = Message.Info;
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
    }
}