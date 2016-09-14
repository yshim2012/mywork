namespace YTWMS.RFClient
{
    partial class SendInfo
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.cmbSelect = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDriver = new System.Windows.Forms.TextBox();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDock = new System.Windows.Forms.TextBox();
            this.btnOut = new System.Windows.Forms.Button();
            this.lbMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbSelect
            // 
            this.cmbSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbSelect.Location = new System.Drawing.Point(93, 67);
            this.cmbSelect.Name = "cmbSelect";
            this.cmbSelect.Size = new System.Drawing.Size(137, 23);
            this.cmbSelect.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.Text = "车牌号：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDriver
            // 
            this.txtDriver.Location = new System.Drawing.Point(92, 35);
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.Size = new System.Drawing.Size(138, 23);
            this.txtDriver.TabIndex = 73;
            // 
            // lblProductCode
            // 
            this.lblProductCode.Location = new System.Drawing.Point(12, 39);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(80, 20);
            this.lblProductCode.Text = "司机：";
            this.lblProductCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.Text = "送货道口：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDock
            // 
            this.txtDock.Location = new System.Drawing.Point(92, 104);
            this.txtDock.Name = "txtDock";
            this.txtDock.Size = new System.Drawing.Size(138, 23);
            this.txtDock.TabIndex = 78;
            // 
            // btnOut
            // 
            this.btnOut.BackColor = System.Drawing.Color.SteelBlue;
            this.btnOut.ForeColor = System.Drawing.Color.White;
            this.btnOut.Location = new System.Drawing.Point(158, 161);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(72, 20);
            this.btnOut.TabIndex = 126;
            this.btnOut.Text = "确认发货";
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // lbMessage
            // 
            this.lbMessage.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbMessage.ForeColor = System.Drawing.Color.Red;
            this.lbMessage.Location = new System.Drawing.Point(12, 134);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(218, 20);
            // 
            // SendInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(241, 455);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.txtDock);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDriver);
            this.Controls.Add(this.lblProductCode);
            this.Controls.Add(this.cmbSelect);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "SendInfo";
            this.Text = "发货信息";
            this.Load += new System.EventHandler(this.SendInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSelect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDriver;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDock;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Label lbMessage;
    }
}