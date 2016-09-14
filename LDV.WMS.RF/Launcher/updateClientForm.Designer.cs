namespace Launcher
{
    partial class updateClientForm
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
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.menuConfig = new System.Windows.Forms.MenuItem();
            this.btStart = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuExit);
            this.mainMenu1.MenuItems.Add(this.menuConfig);
            // 
            // menuExit
            // 
            this.menuExit.Text = "退出系统";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuConfig
            // 
            this.menuConfig.Text = "配置";
            this.menuConfig.Click += new System.EventHandler(this.menuConfig_Click);
            // 
            // btStart
            // 
            this.btStart.BackColor = System.Drawing.Color.SteelBlue;
            this.btStart.ForeColor = System.Drawing.Color.White;
            this.btStart.Location = new System.Drawing.Point(145, 259);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(83, 33);
            this.btStart.TabIndex = 3;
            this.btStart.Text = "进入系统";
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(0, 49);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(241, 200);
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btUpdate
            // 
            this.btUpdate.BackColor = System.Drawing.Color.SteelBlue;
            this.btUpdate.ForeColor = System.Drawing.Color.White;
            this.btUpdate.Location = new System.Drawing.Point(17, 259);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(83, 33);
            this.btUpdate.TabIndex = 5;
            this.btUpdate.Text = "更新应用";
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // updateClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(243, 352);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "updateClientForm";
            this.Text = "版本检查";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.MenuItem menuExit;
        private System.Windows.Forms.MenuItem menuConfig;
    }
}