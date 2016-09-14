namespace YTWMS.RFClient
{
    partial class BatchPackageR
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
            this.btnReceive = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxBach = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tboxQty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxPartNo = new System.Windows.Forms.TextBox();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.tbxDocument = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxStartNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxEndNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lbMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnReceive
            // 
            this.btnReceive.BackColor = System.Drawing.Color.SteelBlue;
            this.btnReceive.ForeColor = System.Drawing.Color.White;
            this.btnReceive.Location = new System.Drawing.Point(139, 213);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(72, 20);
            this.btnReceive.TabIndex = 130;
            this.btnReceive.Text = "收货确认";
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // BtnBack
            // 
            this.BtnBack.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnBack.ForeColor = System.Drawing.Color.White;
            this.BtnBack.Location = new System.Drawing.Point(15, 213);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(72, 20);
            this.BtnBack.TabIndex = 129;
            this.BtnBack.Text = "返  回";
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // cmbProject
            // 
            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbProject.Location = new System.Drawing.Point(91, 142);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(137, 23);
            this.cmbProject.TabIndex = 169;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(7, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.Text = "大项目:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbxBach
            // 
            this.tbxBach.Location = new System.Drawing.Point(92, 120);
            this.tbxBach.Name = "tbxBach";
            this.tbxBach.Size = new System.Drawing.Size(133, 23);
            this.tbxBach.TabIndex = 166;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.Text = "批次:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tboxQty
            // 
            this.tboxQty.Location = new System.Drawing.Point(92, 96);
            this.tboxQty.Name = "tboxQty";
            this.tboxQty.Size = new System.Drawing.Size(133, 23);
            this.tboxQty.TabIndex = 164;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.Text = "数量:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbxPartNo
            // 
            this.tbxPartNo.Location = new System.Drawing.Point(92, 73);
            this.tbxPartNo.Name = "tbxPartNo";
            this.tbxPartNo.Size = new System.Drawing.Size(133, 23);
            this.tbxPartNo.TabIndex = 162;
            this.tbxPartNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPartNo_KeyDown);
            // 
            // lblProductCode
            // 
            this.lblProductCode.Location = new System.Drawing.Point(6, 76);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(80, 20);
            this.lblProductCode.Text = "零件号:";
            this.lblProductCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbxDocument
            // 
            this.tbxDocument.Location = new System.Drawing.Point(92, 166);
            this.tbxDocument.Name = "tbxDocument";
            this.tbxDocument.Size = new System.Drawing.Size(133, 23);
            this.tbxDocument.TabIndex = 178;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(7, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 20);
            this.label6.Text = "交货单号:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbxStartNo
            // 
            this.tbxStartNo.Location = new System.Drawing.Point(92, 27);
            this.tbxStartNo.Name = "tbxStartNo";
            this.tbxStartNo.Size = new System.Drawing.Size(133, 23);
            this.tbxStartNo.TabIndex = 181;
            this.tbxStartNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxStartNo_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 20);
            this.label7.Text = "起始编号:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbxEndNo
            // 
            this.tbxEndNo.Location = new System.Drawing.Point(92, 50);
            this.tbxEndNo.Name = "tbxEndNo";
            this.tbxEndNo.Size = new System.Drawing.Size(133, 23);
            this.tbxEndNo.TabIndex = 184;
            this.tbxEndNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxEndNo_KeyDown);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 20);
            this.label8.Text = "结束编号:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbMessage
            // 
            this.lbMessage.ForeColor = System.Drawing.Color.Red;
            this.lbMessage.Location = new System.Drawing.Point(15, 191);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(223, 20);
            this.lbMessage.Text = "label6";
            // 
            // BatchPackageR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(243, 455);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.tbxEndNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbxStartNo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbxDocument);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxBach);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tboxQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxPartNo);
            this.Controls.Add(this.lblProductCode);
            this.Controls.Add(this.btnReceive);
            this.Controls.Add(this.BtnBack);
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "BatchPackageR";
            this.Text = "整箱批量收货";
            this.Load += new System.EventHandler(this.BatchPackageR_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.BatchPackageR_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReceive;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.ComboBox cmbProject;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxBach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tboxQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxPartNo;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.TextBox tbxDocument;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxStartNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxEndNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbMessage;
    }
}