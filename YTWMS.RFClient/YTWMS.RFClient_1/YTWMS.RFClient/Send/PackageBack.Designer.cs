namespace YTWMS.RFClient
{
    partial class PackageBack
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
            this.cmbTruckNo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxMobile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxDriver = new System.Windows.Forms.TextBox();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbTruckNo
            // 
            this.cmbTruckNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbTruckNo.Location = new System.Drawing.Point(94, 61);
            this.cmbTruckNo.Name = "cmbTruckNo";
            this.cmbTruckNo.Size = new System.Drawing.Size(137, 23);
            this.cmbTruckNo.TabIndex = 156;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.Text = "车牌号:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbxMobile
            // 
            this.tbxMobile.Location = new System.Drawing.Point(94, 128);
            this.tbxMobile.Name = "tbxMobile";
            this.tbxMobile.Size = new System.Drawing.Size(133, 23);
            this.tbxMobile.TabIndex = 155;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.Text = "联系电话:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbxDriver
            // 
            this.tbxDriver.Location = new System.Drawing.Point(94, 95);
            this.tbxDriver.Name = "tbxDriver";
            this.tbxDriver.Size = new System.Drawing.Size(133, 23);
            this.tbxDriver.TabIndex = 153;
            // 
            // lblProductCode
            // 
            this.lblProductCode.Location = new System.Drawing.Point(13, 95);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(80, 20);
            this.lblProductCode.Text = "司机:";
            this.lblProductCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.SteelBlue;
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(144, 176);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 20);
            this.btnNext.TabIndex = 152;
            this.btnNext.Text = "下一步";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // BtnBack
            // 
            this.BtnBack.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnBack.ForeColor = System.Drawing.Color.White;
            this.BtnBack.Location = new System.Drawing.Point(21, 176);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(72, 20);
            this.BtnBack.TabIndex = 151;
            this.BtnBack.Text = "返  回";
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbSupplier.Location = new System.Drawing.Point(94, 27);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(137, 23);
            this.cmbSupplier.TabIndex = 162;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.Text = "供应商名称:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PackageBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(243, 455);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTruckNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxMobile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxDriver);
            this.Controls.Add(this.lblProductCode);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.BtnBack);
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "PackageBack";
            this.Text = "退供应商信息";
            this.Load += new System.EventHandler(this.PackageBack_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTruckNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxMobile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxDriver;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label label1;
    }
}