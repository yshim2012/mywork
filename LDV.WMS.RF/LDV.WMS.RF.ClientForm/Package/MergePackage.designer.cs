﻿namespace LDV.WMS.RF.ClientForm
{
    partial class MergePackage
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtOldPackage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewPackage = new System.Windows.Forms.TextBox();
            this.btnConfirmed = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(18, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.Text = "原箱号：";
            // 
            // txtOldPackage
            // 
            this.txtOldPackage.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtOldPackage.Location = new System.Drawing.Point(78, 48);
            this.txtOldPackage.Name = "txtOldPackage";
            this.txtOldPackage.Size = new System.Drawing.Size(150, 26);
            this.txtOldPackage.TabIndex = 0;
            this.txtOldPackage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOldPackage_KeyPress);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(5, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.Text = "目的箱号：";
            // 
            // txtNewPackage
            // 
            this.txtNewPackage.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtNewPackage.Location = new System.Drawing.Point(78, 149);
            this.txtNewPackage.Name = "txtNewPackage";
            this.txtNewPackage.Size = new System.Drawing.Size(150, 26);
            this.txtNewPackage.TabIndex = 0;
            this.txtNewPackage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewPackage_KeyPress);
            // 
            // btnConfirmed
            // 
            this.btnConfirmed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnConfirmed.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.btnConfirmed.ForeColor = System.Drawing.Color.White;
            this.btnConfirmed.Location = new System.Drawing.Point(147, 252);
            this.btnConfirmed.Name = "btnConfirmed";
            this.btnConfirmed.Size = new System.Drawing.Size(72, 32);
            this.btnConfirmed.TabIndex = 4;
            this.btnConfirmed.Text = "确认";
            this.btnConfirmed.Click += new System.EventHandler(this.btnConfirmed_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Green;
            this.btnBack.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(27, 252);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(72, 32);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "返回";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(13, 199);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(222, 30);
            // 
            // MergePackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(243, 352);
            this.ControlBox = false;
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnConfirmed);
            this.Controls.Add(this.txtNewPackage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOldPackage);
            this.Controls.Add(this.label1);
            this.Name = "MergePackage";
            this.Text = "合箱";
            this.Load += new System.EventHandler(this.PackageChange_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOldPackage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNewPackage;
        private System.Windows.Forms.Button btnConfirmed;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblMessage;
    }
}