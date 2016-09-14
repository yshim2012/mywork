﻿namespace LDV.WMS.RF.ClientForm
{
    partial class WarehouseMoveNew
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
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.column1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.column2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.column3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnStartM = new System.Windows.Forms.Button();
            this.txtPlanNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.dataGrid1.Location = new System.Drawing.Point(0, 0);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeadersVisible = false;
            this.dataGrid1.Size = new System.Drawing.Size(239, 230);
            this.dataGrid1.TabIndex = 19;
            this.dataGrid1.TableStyles.Add(this.dataGridTableStyle1);
            this.dataGrid1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGrid1_MouseUp);
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.column1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.column2);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.column3);
            this.dataGridTableStyle1.MappingName = "OrderList";
            // 
            // column1
            // 
            this.column1.Format = "";
            this.column1.FormatInfo = null;
            this.column1.HeaderText = "移库编码";
            this.column1.MappingName = "MOVE_LOC_NUM";
            this.column1.Width = 100;
            // 
            // column2
            // 
            this.column2.Format = "";
            this.column2.FormatInfo = null;
            this.column2.HeaderText = "移库库区";
            this.column2.MappingName = "DESCRIPTION";
            this.column2.Width = 100;
            // 
            // column3
            // 
            this.column3.Format = "";
            this.column3.FormatInfo = null;
            this.column3.HeaderText = "移库条数";
            this.column3.MappingName = "DETAIL_COUNT";
            this.column3.Width = 100;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Green;
            this.btnBack.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(10, 302);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 31);
            this.btnBack.TabIndex = 21;
            this.btnBack.Text = "返回";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // btnStartM
            // 
            this.btnStartM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnStartM.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.btnStartM.ForeColor = System.Drawing.Color.White;
            this.btnStartM.Location = new System.Drawing.Point(151, 302);
            this.btnStartM.Name = "btnStartM";
            this.btnStartM.Size = new System.Drawing.Size(80, 31);
            this.btnStartM.TabIndex = 20;
            this.btnStartM.Text = "开始移库";
            this.btnStartM.Click += new System.EventHandler(this.btnStartM_Click);
            // 
            // txtPlanNo
            // 
            this.txtPlanNo.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtPlanNo.Location = new System.Drawing.Point(73, 243);
            this.txtPlanNo.Name = "txtPlanNo";
            this.txtPlanNo.Size = new System.Drawing.Size(158, 26);
            this.txtPlanNo.TabIndex = 23;
            this.txtPlanNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlanNo_KeyPress);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(-2, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.Text = "移库编码：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbMessage
            // 
            this.lbMessage.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.lbMessage.ForeColor = System.Drawing.Color.Red;
            this.lbMessage.Location = new System.Drawing.Point(-1, 278);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(238, 17);
            // 
            // WarehouseMoveNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(243, 352);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.txtPlanNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnStartM);
            this.Controls.Add(this.dataGrid1);
            this.Name = "WarehouseMoveNew";
            this.Text = "计划移库";
            this.Load += new System.EventHandler(this.WarehouseMoveNew_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnStartM;
        private System.Windows.Forms.TextBox txtPlanNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.DataGridTextBoxColumn column1;
        private System.Windows.Forms.DataGridTextBoxColumn column2;
        private System.Windows.Forms.DataGridTextBoxColumn column3;
    }
}