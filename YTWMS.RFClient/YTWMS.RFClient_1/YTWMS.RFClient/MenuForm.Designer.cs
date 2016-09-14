namespace YTWMS.RFClient
{
    partial class MenuForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.btnExist = new System.Windows.Forms.Button();
            this.btnSortSend = new System.Windows.Forms.Button();
            this.btnPackageSend = new System.Windows.Forms.Button();
            this.btnPackageBatchReceive = new System.Windows.Forms.Button();
            this.btnPackageBackSupplier = new System.Windows.Forms.Button();
            this.btnPackageReceive = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExist
            // 
            this.btnExist.BackColor = System.Drawing.Color.Green;
            this.btnExist.ForeColor = System.Drawing.Color.White;
            this.btnExist.Location = new System.Drawing.Point(41, 198);
            this.btnExist.Name = "btnExist";
            this.btnExist.Size = new System.Drawing.Size(160, 35);
            this.btnExist.TabIndex = 2;
            this.btnExist.Text = "返      回";
            this.btnExist.Click += new System.EventHandler(this.btnExist_Click);
            // 
            // btnSortSend
            // 
            this.btnSortSend.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSortSend.ForeColor = System.Drawing.Color.White;
            this.btnSortSend.Location = new System.Drawing.Point(41, 126);
            this.btnSortSend.Name = "btnSortSend";
            this.btnSortSend.Size = new System.Drawing.Size(160, 35);
            this.btnSortSend.TabIndex = 1;
            this.btnSortSend.Text = "排序发货";
            this.btnSortSend.Click += new System.EventHandler(this.btnSortSend_Click);
            // 
            // btnPackageSend
            // 
            this.btnPackageSend.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPackageSend.ForeColor = System.Drawing.Color.White;
            this.btnPackageSend.Location = new System.Drawing.Point(41, 90);
            this.btnPackageSend.Name = "btnPackageSend";
            this.btnPackageSend.Size = new System.Drawing.Size(160, 35);
            this.btnPackageSend.TabIndex = 4;
            this.btnPackageSend.Text = "整箱发货";
            this.btnPackageSend.Click += new System.EventHandler(this.btnPackageSend_Click);
            // 
            // btnPackageBatchReceive
            // 
            this.btnPackageBatchReceive.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPackageBatchReceive.ForeColor = System.Drawing.Color.White;
            this.btnPackageBatchReceive.Location = new System.Drawing.Point(41, 54);
            this.btnPackageBatchReceive.Name = "btnPackageBatchReceive";
            this.btnPackageBatchReceive.Size = new System.Drawing.Size(160, 35);
            this.btnPackageBatchReceive.TabIndex = 5;
            this.btnPackageBatchReceive.Text = "整箱批量收货";
            this.btnPackageBatchReceive.Click += new System.EventHandler(this.btnPackageBatchReceive_Click);
            // 
            // btnPackageBackSupplier
            // 
            this.btnPackageBackSupplier.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPackageBackSupplier.ForeColor = System.Drawing.Color.White;
            this.btnPackageBackSupplier.Location = new System.Drawing.Point(41, 162);
            this.btnPackageBackSupplier.Name = "btnPackageBackSupplier";
            this.btnPackageBackSupplier.Size = new System.Drawing.Size(160, 35);
            this.btnPackageBackSupplier.TabIndex = 6;
            this.btnPackageBackSupplier.Text = "退供应商发货";
            this.btnPackageBackSupplier.Click += new System.EventHandler(this.btnPackageBackSupplier_Click);
            // 
            // btnPackageReceive
            // 
            this.btnPackageReceive.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPackageReceive.ForeColor = System.Drawing.Color.White;
            this.btnPackageReceive.Location = new System.Drawing.Point(41, 18);
            this.btnPackageReceive.Name = "btnPackageReceive";
            this.btnPackageReceive.Size = new System.Drawing.Size(160, 35);
            this.btnPackageReceive.TabIndex = 7;
            this.btnPackageReceive.Text = "整箱收货";
            this.btnPackageReceive.Click += new System.EventHandler(this.btnPackageReceive_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.ControlBox = false;
            this.Controls.Add(this.btnPackageReceive);
            this.Controls.Add(this.btnPackageBackSupplier);
            this.Controls.Add(this.btnPackageBatchReceive);
            this.Controls.Add(this.btnPackageSend);
            this.Controls.Add(this.btnExist);
            this.Controls.Add(this.btnSortSend);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MenuForm";
            this.Text = "主界面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExist;
        private System.Windows.Forms.Button btnSortSend;
        private System.Windows.Forms.Button btnPackageSend;
        private System.Windows.Forms.Button btnPackageBatchReceive;
        private System.Windows.Forms.Button btnPackageBackSupplier;
        private System.Windows.Forms.Button btnPackageReceive;
    }
}