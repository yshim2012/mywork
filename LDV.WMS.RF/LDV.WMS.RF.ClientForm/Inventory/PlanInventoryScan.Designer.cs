﻿namespace LDV.WMS.RF.ClientForm
{
    partial class PlanInventoryScan
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
            this.txtWareHouse = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInventDoc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInventPart = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.LabThisCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.txtInventLoc = new System.Windows.Forms.Label();
            this.txtCheckLoc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPartCode = new System.Windows.Forms.TextBox();
            this.labMessage = new System.Windows.Forms.Label();
            this.txtDid = new System.Windows.Forms.TextBox();
            this.txtMainId = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtWareHouse
            // 
            this.txtWareHouse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWareHouse.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtWareHouse.Location = new System.Drawing.Point(90, 30);
            this.txtWareHouse.Name = "txtWareHouse";
            this.txtWareHouse.ReadOnly = true;
            this.txtWareHouse.Size = new System.Drawing.Size(140, 26);
            this.txtWareHouse.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(22, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.Text = "库位号：";
            // 
            // txtInventDoc
            // 
            this.txtInventDoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInventDoc.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtInventDoc.Location = new System.Drawing.Point(90, 3);
            this.txtInventDoc.Name = "txtInventDoc";
            this.txtInventDoc.ReadOnly = true;
            this.txtInventDoc.Size = new System.Drawing.Size(140, 26);
            this.txtInventDoc.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(10, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.Text = "盘点凭证：";
            // 
            // txtInventPart
            // 
            this.txtInventPart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInventPart.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtInventPart.Location = new System.Drawing.Point(90, 58);
            this.txtInventPart.Name = "txtInventPart";
            this.txtInventPart.ReadOnly = true;
            this.txtInventPart.Size = new System.Drawing.Size(140, 26);
            this.txtInventPart.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(10, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.Text = "盘点零件：";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(10, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.Text = "物料名称：";
            // 
            // txtPartName
            // 
            this.txtPartName.AcceptsTab = true;
            this.txtPartName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPartName.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtPartName.Location = new System.Drawing.Point(90, 86);
            this.txtPartName.Multiline = true;
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.ReadOnly = true;
            this.txtPartName.Size = new System.Drawing.Size(140, 35);
            this.txtPartName.TabIndex = 21;
            // 
            // LabThisCount
            // 
            this.LabThisCount.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.LabThisCount.Location = new System.Drawing.Point(20, 131);
            this.LabThisCount.Name = "LabThisCount";
            this.LabThisCount.Size = new System.Drawing.Size(73, 20);
            this.LabThisCount.Text = "0/0";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(18, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.Text = "盘点数量：";
            // 
            // txtCount
            // 
            this.txtCount.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtCount.Location = new System.Drawing.Point(92, 205);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(140, 26);
            this.txtCount.TabIndex = 21;
            this.txtCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCount_KeyPress);
            // 
            // txtInventLoc
            // 
            this.txtInventLoc.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtInventLoc.Location = new System.Drawing.Point(18, 152);
            this.txtInventLoc.Name = "txtInventLoc";
            this.txtInventLoc.Size = new System.Drawing.Size(73, 20);
            this.txtInventLoc.Text = "盘点库位：";
            // 
            // txtCheckLoc
            // 
            this.txtCheckLoc.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtCheckLoc.Location = new System.Drawing.Point(92, 150);
            this.txtCheckLoc.Name = "txtCheckLoc";
            this.txtCheckLoc.Size = new System.Drawing.Size(140, 26);
            this.txtCheckLoc.TabIndex = 23;
            this.txtCheckLoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCheckLoc_KeyPress);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(18, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 20);
            this.label7.Text = "零件编码：";
            // 
            // txtPartCode
            // 
            this.txtPartCode.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtPartCode.Location = new System.Drawing.Point(92, 177);
            this.txtPartCode.Name = "txtPartCode";
            this.txtPartCode.Size = new System.Drawing.Size(140, 26);
            this.txtPartCode.TabIndex = 20;
            this.txtPartCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPartCode_KeyPress);
            // 
            // labMessage
            // 
            this.labMessage.ForeColor = System.Drawing.Color.Red;
            this.labMessage.Location = new System.Drawing.Point(7, 238);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(227, 32);
            // 
            // txtDid
            // 
            this.txtDid.Location = new System.Drawing.Point(1, 151);
            this.txtDid.Name = "txtDid";
            this.txtDid.Size = new System.Drawing.Size(23, 21);
            this.txtDid.TabIndex = 66;
            this.txtDid.Visible = false;
            // 
            // txtMainId
            // 
            this.txtMainId.Location = new System.Drawing.Point(0, 191);
            this.txtMainId.Name = "txtMainId";
            this.txtMainId.Size = new System.Drawing.Size(23, 21);
            this.txtMainId.TabIndex = 67;
            this.txtMainId.Visible = false;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Green;
            this.btnBack.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(22, 281);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(72, 32);
            this.btnBack.TabIndex = 119;
            this.btnBack.Text = "返回";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnOk.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(147, 281);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(72, 32);
            this.btnOk.TabIndex = 118;
            this.btnOk.Text = "确认";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // PlanInventoryScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(243, 352);
            this.ControlBox = false;
            this.Controls.Add(this.txtPartCode);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCheckLoc);
            this.Controls.Add(this.txtInventLoc);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtMainId);
            this.Controls.Add(this.txtDid);
            this.Controls.Add(this.labMessage);
            this.Controls.Add(this.LabThisCount);
            this.Controls.Add(this.txtWareHouse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInventDoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPartName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInventPart);
            this.Controls.Add(this.label4);
            this.Name = "PlanInventoryScan";
            this.Text = "计划盘点扫描";
            this.Load += new System.EventHandler(this.PlanInventoryScan_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtWareHouse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInventDoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInventPart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.Label LabThisCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label txtInventLoc;
        private System.Windows.Forms.TextBox txtCheckLoc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPartCode;
        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.TextBox txtDid;
        private System.Windows.Forms.TextBox txtMainId;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnOk;
    }
}