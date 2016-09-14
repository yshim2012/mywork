namespace YTWMS.RFClient
{
    partial class PackageR
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
            System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.dgData = new System.Windows.Forms.DataGrid();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.tbxPartNo = new System.Windows.Forms.TextBox();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.tboxBoxNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tboxQty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxBach = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxCode = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.lbMessage = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer();
            this.lbCount = new System.Windows.Forms.Label();
            dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.SuspendLayout();
            // 
            // dataGridTableStyle1
            // 
            dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn4);
            dataGridTableStyle1.MappingName = "Table";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "零件号";
            this.dataGridTextBoxColumn1.MappingName = "PART_CODE";
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "箱号";
            this.dataGridTextBoxColumn2.MappingName = "BOX_NO";
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "数量";
            this.dataGridTextBoxColumn3.MappingName = "QTY";
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "尾号";
            this.dataGridTextBoxColumn4.MappingName = "SHORT_NO";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem3);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "收货确认";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "返回";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // dgData
            // 
            this.dgData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgData.ContextMenu = this.contextMenu1;
            this.dgData.Location = new System.Drawing.Point(4, 197);
            this.dgData.Name = "dgData";
            this.dgData.Size = new System.Drawing.Size(231, 111);
            this.dgData.TabIndex = 81;
            this.dgData.TableStyles.Add(dataGridTableStyle1);
            this.dgData.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgData_MouseDown);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.Add(this.menuItem2);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "删除";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // tbxPartNo
            // 
            this.tbxPartNo.Location = new System.Drawing.Point(83, 27);
            this.tbxPartNo.Name = "tbxPartNo";
            this.tbxPartNo.Size = new System.Drawing.Size(133, 23);
            this.tbxPartNo.TabIndex = 132;
            this.tbxPartNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPartNo_KeyDown);
            // 
            // lblProductCode
            // 
            this.lblProductCode.Location = new System.Drawing.Point(-1, 27);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(80, 20);
            this.lblProductCode.Text = "零件号:";
            this.lblProductCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tboxBoxNo
            // 
            this.tboxBoxNo.Location = new System.Drawing.Point(83, 51);
            this.tboxBoxNo.Name = "tboxBoxNo";
            this.tboxBoxNo.Size = new System.Drawing.Size(133, 23);
            this.tboxBoxNo.TabIndex = 135;
            this.tboxBoxNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tboxBoxNo_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-1, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.Text = "箱号:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tboxQty
            // 
            this.tboxQty.Location = new System.Drawing.Point(83, 75);
            this.tboxQty.Name = "tboxQty";
            this.tboxQty.Size = new System.Drawing.Size(133, 23);
            this.tboxQty.TabIndex = 138;
            this.tboxQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tboxQty_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-1, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.Text = "数量:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbxBach
            // 
            this.tbxBach.Location = new System.Drawing.Point(83, 99);
            this.tbxBach.Name = "tbxBach";
            this.tbxBach.Size = new System.Drawing.Size(133, 23);
            this.tbxBach.TabIndex = 144;
            this.tbxBach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxBach_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-1, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.Text = "批次:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-1, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.Text = "大项目:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbxCode
            // 
            this.tbxCode.Location = new System.Drawing.Point(38, 172);
            this.tbxCode.Name = "tbxCode";
            this.tbxCode.Size = new System.Drawing.Size(133, 23);
            this.tbxCode.TabIndex = 151;
            this.tbxCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCode_KeyDown);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(175, 175);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(54, 20);
            this.btnAdd.TabIndex = 153;
            this.btnAdd.Text = "添  加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbProject
            // 
            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbProject.Location = new System.Drawing.Point(83, 123);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(137, 23);
            this.cmbProject.TabIndex = 154;
            // 
            // lbMessage
            // 
            this.lbMessage.ForeColor = System.Drawing.Color.Red;
            this.lbMessage.Location = new System.Drawing.Point(14, 150);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(223, 20);
            this.lbMessage.Text = "label6";
            // 
            // timer1
            // 
            this.timer1.Interval = 150;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbCount
            // 
            this.lbCount.ForeColor = System.Drawing.Color.Black;
            this.lbCount.Location = new System.Drawing.Point(6, 175);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(30, 20);
            this.lbCount.Text = "999";
            this.lbCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PackageR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(243, 351);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbxCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxBach);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tboxQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tboxBoxNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxPartNo);
            this.Controls.Add(this.lblProductCode);
            this.Controls.Add(this.dgData);
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "PackageR";
            this.Text = "整箱收货";
            this.Load += new System.EventHandler(this.PackageR_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PackageR_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbxPartNo;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.TextBox tboxBoxNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboxQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxBach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxCode;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbProject;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.DataGrid dgData;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbCount;
    }
}