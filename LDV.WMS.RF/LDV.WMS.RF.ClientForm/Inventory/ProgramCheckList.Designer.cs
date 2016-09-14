namespace LDV.WMS.RF.ClientForm
{
    partial class ProgramCheckList
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
            this.txtInventoryDoc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConfirmed = new System.Windows.Forms.Button();
            this.dgList = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.labMessage = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInventoryDoc
            // 
            this.txtInventoryDoc.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.txtInventoryDoc.Location = new System.Drawing.Point(76, 14);
            this.txtInventoryDoc.Name = "txtInventoryDoc";
            this.txtInventoryDoc.Size = new System.Drawing.Size(145, 26);
            this.txtInventoryDoc.TabIndex = 19;
            this.txtInventoryDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInventoryDoc_KeyPress);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(4, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.Text = "盘点凭证：";
            // 
            // btnConfirmed
            // 
            this.btnConfirmed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnConfirmed.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.btnConfirmed.ForeColor = System.Drawing.Color.White;
            this.btnConfirmed.Location = new System.Drawing.Point(155, 43);
            this.btnConfirmed.Name = "btnConfirmed";
            this.btnConfirmed.Size = new System.Drawing.Size(80, 38);
            this.btnConfirmed.TabIndex = 21;
            this.btnConfirmed.Text = "开始盘点";
            this.btnConfirmed.Click += new System.EventHandler(this.btnConfirmed_Click);
            // 
            // dgList
            // 
            this.dgList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgList.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.dgList.Location = new System.Drawing.Point(0, 124);
            this.dgList.Name = "dgList";
            this.dgList.RowHeadersVisible = false;
            this.dgList.Size = new System.Drawing.Size(239, 176);
            this.dgList.TabIndex = 22;
            this.dgList.TableStyles.Add(this.dataGridTableStyle1);
            this.dgList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgList_MouseUp);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn4);
            this.dataGridTableStyle1.MappingName = "PLANCHECK";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "库位号";
            this.dataGridTextBoxColumn1.MappingName = "LOC_CODE";
            this.dataGridTextBoxColumn1.Width = 80;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "零件编号";
            this.dataGridTextBoxColumn2.MappingName = "ITEM_CODE";
            this.dataGridTextBoxColumn2.Width = 80;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "零件名称";
            this.dataGridTextBoxColumn3.MappingName = "ITEM_NAME";
            this.dataGridTextBoxColumn3.Width = 80;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "盘点数量";
            this.dataGridTextBoxColumn4.MappingName = "CHECK_QTY";
            this.dataGridTextBoxColumn4.Width = 70;
            // 
            // labMessage
            // 
            this.labMessage.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.labMessage.ForeColor = System.Drawing.Color.Red;
            this.labMessage.Location = new System.Drawing.Point(4, 88);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(239, 28);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Green;
            this.btnBack.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(5, 307);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(72, 32);
            this.btnBack.TabIndex = 120;
            this.btnBack.Text = "返回";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ProgramCheckList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(243, 352);
            this.ControlBox = false;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.labMessage);
            this.Controls.Add(this.btnConfirmed);
            this.Controls.Add(this.txtInventoryDoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgList);
            this.Name = "ProgramCheckList";
            this.Text = "计划盘点明细";
            this.Load += new System.EventHandler(this.ProgramCheckList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConfirmed;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.Button btnBack;
        public System.Windows.Forms.TextBox txtInventoryDoc;
        public System.Windows.Forms.DataGrid dgList;
    }
}