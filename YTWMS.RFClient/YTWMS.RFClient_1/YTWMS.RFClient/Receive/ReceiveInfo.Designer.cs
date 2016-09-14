namespace YTWMS.RFClient
{
    partial class ReceiveInfo
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
            this.BtnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.tbxDocumentNo = new System.Windows.Forms.TextBox();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnBack
            // 
            this.BtnBack.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnBack.ForeColor = System.Drawing.Color.White;
            this.BtnBack.Location = new System.Drawing.Point(15, 181);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(72, 20);
            this.BtnBack.TabIndex = 127;
            this.BtnBack.Text = "返  回";
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.SteelBlue;
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(160, 181);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 20);
            this.btnNext.TabIndex = 128;
            this.btnNext.Text = "下一步";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tbxDocumentNo
            // 
            this.tbxDocumentNo.Location = new System.Drawing.Point(99, 82);
            this.tbxDocumentNo.Name = "tbxDocumentNo";
            this.tbxDocumentNo.Size = new System.Drawing.Size(133, 23);
            this.tbxDocumentNo.TabIndex = 130;
            // 
            // lblProductCode
            // 
            this.lblProductCode.Location = new System.Drawing.Point(15, 86);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(80, 20);
            this.lblProductCode.Text = "收货单号:";
            this.lblProductCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ReceiveInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(243, 455);
            this.Controls.Add(this.tbxDocumentNo);
            this.Controls.Add(this.lblProductCode);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.BtnBack);
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "ReceiveInfo";
            this.Text = "整箱收货";
            this.Load += new System.EventHandler(this.ReceiveInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox tbxDocumentNo;
        private System.Windows.Forms.Label lblProductCode;

    }
}