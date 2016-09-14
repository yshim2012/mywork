namespace YTWMS.RFClient
{
    partial class PackageSend
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
            this.tbxDriver = new System.Windows.Forms.TextBox();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.tboxPullNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxMobile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTruckNo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbxDriver
            // 
            this.tbxDriver.Location = new System.Drawing.Point(88, 74);
            this.tbxDriver.Name = "tbxDriver";
            this.tbxDriver.Size = new System.Drawing.Size(136, 23);
            this.tbxDriver.TabIndex = 134;
            // 
            // lblProductCode
            // 
            this.lblProductCode.Location = new System.Drawing.Point(5, 75);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(80, 20);
            this.lblProductCode.Text = "司机:";
            this.lblProductCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.SteelBlue;
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(131, 147);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 20);
            this.btnNext.TabIndex = 133;
            this.btnNext.Text = "下一步";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // BtnBack
            // 
            this.BtnBack.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnBack.ForeColor = System.Drawing.Color.White;
            this.BtnBack.Location = new System.Drawing.Point(23, 147);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(72, 20);
            this.BtnBack.TabIndex = 132;
            this.BtnBack.Text = "返  回";
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // tboxPullNo
            // 
            this.tboxPullNo.Location = new System.Drawing.Point(90, 27);
            this.tboxPullNo.Name = "tboxPullNo";
            this.tboxPullNo.Size = new System.Drawing.Size(133, 23);
            this.tboxPullNo.TabIndex = 140;
            this.tboxPullNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tboxPullNo_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.Text = "拉动单号:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbxMobile
            // 
            this.tbxMobile.Location = new System.Drawing.Point(87, 97);
            this.tbxMobile.Name = "tbxMobile";
            this.tbxMobile.Size = new System.Drawing.Size(137, 23);
            this.tbxMobile.TabIndex = 143;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.Text = "联系电话:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbTruckNo
            // 
            this.cmbTruckNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbTruckNo.Location = new System.Drawing.Point(88, 50);
            this.cmbTruckNo.Name = "cmbTruckNo";
            this.cmbTruckNo.Size = new System.Drawing.Size(137, 23);
            this.cmbTruckNo.TabIndex = 146;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.Text = "车牌号:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbMessage
            // 
            this.lbMessage.ForeColor = System.Drawing.Color.Red;
            this.lbMessage.Location = new System.Drawing.Point(6, 123);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(223, 20);
            this.lbMessage.Text = "label6";
            // 
            // PackageSend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(243, 455);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.cmbTruckNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxMobile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tboxPullNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxDriver);
            this.Controls.Add(this.lblProductCode);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.BtnBack);
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "PackageSend";
            this.Text = "发货信息";
            this.Load += new System.EventHandler(this.PackageSend_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbxDriver;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.TextBox tboxPullNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxMobile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTruckNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbMessage;
    }
}