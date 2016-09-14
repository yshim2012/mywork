namespace LDV.WMS.RF.ClientForm
{
    partial class mainForm
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
            this.btnPickTask = new System.Windows.Forms.Button();
            this.btnCheckTask = new System.Windows.Forms.Button();
            this.btnDataQuery = new System.Windows.Forms.Button();
            this.btnUpDatePWD = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPickTask
            // 
            this.btnPickTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnPickTask.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.btnPickTask.ForeColor = System.Drawing.Color.White;
            this.btnPickTask.Location = new System.Drawing.Point(7, 23);
            this.btnPickTask.Name = "btnPickTask";
            this.btnPickTask.Size = new System.Drawing.Size(226, 36);
            this.btnPickTask.TabIndex = 0;
            this.btnPickTask.Text = "收发货管理";
            this.btnPickTask.Click += new System.EventHandler(this.btnPickTask_Click);
            // 
            // btnCheckTask
            // 
            this.btnCheckTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCheckTask.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.btnCheckTask.ForeColor = System.Drawing.Color.White;
            this.btnCheckTask.Location = new System.Drawing.Point(7, 83);
            this.btnCheckTask.Name = "btnCheckTask";
            this.btnCheckTask.Size = new System.Drawing.Size(226, 36);
            this.btnCheckTask.TabIndex = 1;
            this.btnCheckTask.Text = "移库盘点管理";
            this.btnCheckTask.Click += new System.EventHandler(this.btnCheckTask_Click);
            // 
            // btnDataQuery
            // 
            this.btnDataQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDataQuery.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.btnDataQuery.ForeColor = System.Drawing.Color.White;
            this.btnDataQuery.Location = new System.Drawing.Point(7, 143);
            this.btnDataQuery.Name = "btnDataQuery";
            this.btnDataQuery.Size = new System.Drawing.Size(226, 36);
            this.btnDataQuery.TabIndex = 2;
            this.btnDataQuery.Text = "数据查询";
            this.btnDataQuery.Click += new System.EventHandler(this.btnDataQuery_Click);
            // 
            // btnUpDatePWD
            // 
            this.btnUpDatePWD.BackColor = System.Drawing.Color.Green;
            this.btnUpDatePWD.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.btnUpDatePWD.ForeColor = System.Drawing.Color.White;
            this.btnUpDatePWD.Location = new System.Drawing.Point(7, 203);
            this.btnUpDatePWD.Name = "btnUpDatePWD";
            this.btnUpDatePWD.Size = new System.Drawing.Size(226, 36);
            this.btnUpDatePWD.TabIndex = 3;
            this.btnUpDatePWD.Text = "个人密码修改";
            this.btnUpDatePWD.Click += new System.EventHandler(this.btnUpDatePWD_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.Green;
            this.btnReturn.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.btnReturn.ForeColor = System.Drawing.Color.White;
            this.btnReturn.Location = new System.Drawing.Point(7, 263);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(226, 36);
            this.btnReturn.TabIndex = 3;
            this.btnReturn.Text = "返      回";
            this.btnReturn.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(243, 352);
            this.ControlBox = false;
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnUpDatePWD);
            this.Controls.Add(this.btnDataQuery);
            this.Controls.Add(this.btnCheckTask);
            this.Controls.Add(this.btnPickTask);
            this.Name = "mainForm";
            this.Text = "主菜单";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPickTask;
        private System.Windows.Forms.Button btnCheckTask;
        private System.Windows.Forms.Button btnDataQuery;
        private System.Windows.Forms.Button btnUpDatePWD;
        private System.Windows.Forms.Button btnReturn;

    }
}

