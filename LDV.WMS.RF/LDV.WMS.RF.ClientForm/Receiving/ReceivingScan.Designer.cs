﻿namespace LDV.WMS.RF.ClientForm
{
    partial class ReceivingScan
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtPartNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInArea = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtMloc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(14, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "物料号：";
            // 
            // txtPartNumber
            // 
            this.txtPartNumber.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtPartNumber.Location = new System.Drawing.Point(79, 22);
            this.txtPartNumber.MaxLength = 20;
            this.txtPartNumber.Name = "txtPartNumber";
            this.txtPartNumber.Size = new System.Drawing.Size(150, 26);
            this.txtPartNumber.TabIndex = 6;
            this.txtPartNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPartNumber_KeyPress);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(2, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "入库数量：";
            // 
            // txtInCount
            // 
            this.txtInCount.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtInCount.Location = new System.Drawing.Point(79, 60);
            this.txtInCount.MaxLength = 16;
            this.txtInCount.Name = "txtInCount";
            this.txtInCount.Size = new System.Drawing.Size(150, 26);
            this.txtInCount.TabIndex = 8;
            this.txtInCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInCount_KeyPress);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(2, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.Text = "推荐库位：";
            // 
            // txtLoc
            // 
            this.txtLoc.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtLoc.Location = new System.Drawing.Point(79, 137);
            this.txtLoc.MaxLength = 16;
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.ReadOnly = true;
            this.txtLoc.Size = new System.Drawing.Size(150, 26);
            this.txtLoc.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(2, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.Text = "入库库位：";
            // 
            // txtInArea
            // 
            this.txtInArea.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtInArea.Location = new System.Drawing.Point(79, 175);
            this.txtInArea.MaxLength = 16;
            this.txtInArea.Name = "txtInArea";
            this.txtInArea.Size = new System.Drawing.Size(150, 26);
            this.txtInArea.TabIndex = 14;
            this.txtInArea.GotFocus += new System.EventHandler(this.txtInArea_GotFocus);
            this.txtInArea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInArea_KeyPress);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(153, 266);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 32);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "上架确认";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.Green;
            this.btnReturn.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.btnReturn.ForeColor = System.Drawing.Color.White;
            this.btnReturn.Location = new System.Drawing.Point(18, 266);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(72, 32);
            this.btnReturn.TabIndex = 16;
            this.btnReturn.Text = "返回";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(18, 218);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(201, 29);
            // 
            // txtMloc
            // 
            this.txtMloc.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtMloc.Location = new System.Drawing.Point(79, 99);
            this.txtMloc.MaxLength = 16;
            this.txtMloc.Name = "txtMloc";
            this.txtMloc.ReadOnly = true;
            this.txtMloc.Size = new System.Drawing.Size(150, 26);
            this.txtMloc.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(15, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.Text = "主库位：";
            // 
            // ReceivingScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(243, 352);
            this.ControlBox = false;
            this.Controls.Add(this.txtMloc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtInArea);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLoc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtInCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPartNumber);
            this.Controls.Add(this.label3);
            this.Name = "ReceivingScan";
            this.Text = "上架扫描";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPartNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLoc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInArea;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtMloc;
        private System.Windows.Forms.Label label1;
    }
}