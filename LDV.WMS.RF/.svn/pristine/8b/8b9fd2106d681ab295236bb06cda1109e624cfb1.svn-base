using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClientForward;

namespace LDV.WMS.RF.ClientForm
{
    public partial class ReceivingOutManager : Form
    {
        public ReceivingOutManager()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 拣货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPick_Click(object sender, EventArgs e)
        {
            //MoveCheckBox order = new MoveCheckBox();
            //order.ShowDialog();
            PickCheckBox order = new PickCheckBox();
            order.ShowDialog();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 收货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReceiving_Click(object sender, EventArgs e)
        {
            //ReceivingDetail Rece = new ReceivingDetail();
            // Rece.ShowDialog();
            Receiving.NewReceivingAP ap = new LDV.WMS.RF.ClientForm.Receiving.NewReceivingAP();
            ap.ShowDialog();
        }

        /// <summary>
        /// 包装箱调整
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPackge_Click(object sender, EventArgs e)
        {
            PackageChange packge = new PackageChange();
            packge.ShowDialog();
        }

        private void btnShipments_Click(object sender, EventArgs e)
        {
            ShipmentsCheckOrder Order = new ShipmentsCheckOrder();
            Order.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Receiving.ReceivingPQ pq = new LDV.WMS.RF.ClientForm.Receiving.ReceivingPQ();
            Receiving.ReceivingPQSelect pq = new LDV.WMS.RF.ClientForm.Receiving.ReceivingPQSelect();
            pq.ShowDialog();
        }

        private void btnPickOld_Click(object sender, EventArgs e)
        {
            PickCheckOrder order = new PickCheckOrder();
            order.ShowDialog();
        }

        /// <summary>
        /// 合箱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMergePackage_Click(object sender, EventArgs e)
        {
            MergePackage mergePackage = new MergePackage();
            mergePackage.ShowDialog();
        }
    }
}