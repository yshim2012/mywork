﻿namespace LDV.WMS.RF.ClientForm
{
    partial class WarehouseMoveScan
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
            this.lbMessage = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMoveQty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLocName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBatchNo = new System.Windows.Forms.TextBox();
            this.txtMoveLoc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMoveItem = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtActualQty = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lbCount = new System.Windows.Forms.Label();
            this.txtActualLoc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTargetLoc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbMessage
            // 
            this.lbMessage.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.lbMessage.ForeColor = System.Drawing.Color.Red;
            this.lbMessage.Location = new System.Drawing.Point(0, 267);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(243, 17);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Green;
            this.btnBack.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(9, 291);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(72, 31);
            this.btnBack.TabIndex = 24;
            this.btnBack.Text = "返回";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnConfirm.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(153, 291);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 31);
            this.btnConfirm.TabIndex = 23;
            this.btnConfirm.Text = "移下一条";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtItem
            // 
            this.txtItem.Enabled = false;
            this.txtItem.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtItem.Location = new System.Drawing.Point(85, 9);
            this.txtItem.Name = "txtItem";
            this.txtItem.ReadOnly = true;
            this.txtItem.Size = new System.Drawing.Size(148, 26);
            this.txtItem.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(4, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.Text = "拣货零件：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtItemName
            // 
            this.txtItemName.Enabled = false;
            this.txtItemName.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtItemName.Location = new System.Drawing.Point(85, 42);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(147, 26);
            this.txtItemName.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(4, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.Text = "零件名称：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtMoveQty
            // 
            this.txtMoveQty.Enabled = false;
            this.txtMoveQty.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtMoveQty.Location = new System.Drawing.Point(185, 75);
            this.txtMoveQty.Name = "txtMoveQty";
            this.txtMoveQty.Size = new System.Drawing.Size(48, 26);
            this.txtMoveQty.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(4, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.Text = "批次数量：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtLocName
            // 
            this.txtLocName.Enabled = false;
            this.txtLocName.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtLocName.Location = new System.Drawing.Point(56, 107);
            this.txtLocName.Name = "txtLocName";
            this.txtLocName.Size = new System.Drawing.Size(73, 26);
            this.txtLocName.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(2, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.Text = "库位：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.Enabled = false;
            this.txtBatchNo.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtBatchNo.Location = new System.Drawing.Point(84, 75);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.Size = new System.Drawing.Size(94, 26);
            this.txtBatchNo.TabIndex = 38;
            // 
            // txtMoveLoc
            // 
            this.txtMoveLoc.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtMoveLoc.Location = new System.Drawing.Point(86, 140);
            this.txtMoveLoc.Name = "txtMoveLoc";
            this.txtMoveLoc.Size = new System.Drawing.Size(146, 26);
            this.txtMoveLoc.TabIndex = 41;
            this.txtMoveLoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMoveLoc_KeyPress);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(1, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.Text = "移库库位：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtMoveItem
            // 
            this.txtMoveItem.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtMoveItem.Location = new System.Drawing.Point(86, 170);
            this.txtMoveItem.Name = "txtMoveItem";
            this.txtMoveItem.Size = new System.Drawing.Size(146, 26);
            this.txtMoveItem.TabIndex = 44;
            this.txtMoveItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMoveItem_KeyPress);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(1, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 20);
            this.label7.Text = "零件号：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtActualQty
            // 
            this.txtActualQty.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtActualQty.Location = new System.Drawing.Point(86, 201);
            this.txtActualQty.Name = "txtActualQty";
            this.txtActualQty.Size = new System.Drawing.Size(146, 26);
            this.txtActualQty.TabIndex = 47;
            this.txtActualQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtActualQty_KeyPress);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(1, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 20);
            this.label8.Text = "实移数量：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbCount
            // 
            this.lbCount.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.lbCount.ForeColor = System.Drawing.Color.Black;
            this.lbCount.Location = new System.Drawing.Point(74, 300);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(91, 17);
            // 
            // txtActualLoc
            // 
            this.txtActualLoc.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtActualLoc.Location = new System.Drawing.Point(86, 232);
            this.txtActualLoc.Name = "txtActualLoc";
            this.txtActualLoc.Size = new System.Drawing.Size(146, 26);
            this.txtActualLoc.TabIndex = 68;
            this.txtActualLoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtActualLoc_KeyPress_1);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label9.Location = new System.Drawing.Point(1, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 20);
            this.label9.Text = "目的库位：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTargetLoc
            // 
            this.txtTargetLoc.Enabled = false;
            this.txtTargetLoc.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtTargetLoc.Location = new System.Drawing.Point(160, 107);
            this.txtTargetLoc.Name = "txtTargetLoc";
            this.txtTargetLoc.Size = new System.Drawing.Size(76, 26);
            this.txtTargetLoc.TabIndex = 71;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label11.Location = new System.Drawing.Point(129, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 20);
            this.label11.Text = "->";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // WarehouseMoveScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(243, 352);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtLocName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTargetLoc);
            this.Controls.Add(this.txtActualLoc);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.txtActualQty);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMoveItem);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMoveLoc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBatchNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMoveQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbMessage);
            this.Name = "WarehouseMoveScan";
            this.Text = "移库扫描";
            this.Load += new System.EventHandler(this.WarehouseMoveScan_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMoveQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLocName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBatchNo;
        private System.Windows.Forms.TextBox txtMoveLoc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMoveItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtActualQty;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.TextBox txtActualLoc;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtTargetLoc;
        private System.Windows.Forms.Label label11;
    }
}