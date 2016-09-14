using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LDV.WMS.RF.ClientForm
{
    public partial class DataQueryMain : Form
    {
        public DataQueryMain()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FreeLibraryQuery free = new FreeLibraryQuery();
            free.ShowDialog();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {

        }

        private void menuBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            PartsQuery Part = new PartsQuery();
            Part.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainLibraryQuery main = new MainLibraryQuery();
            main.ShowDialog();
        }
    }
}