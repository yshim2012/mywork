using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.IO;

namespace WpfLDVPacakge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtPart.Focus();
        }

        private void image1_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void butOK_Click(object sender, RoutedEventArgs e)
        {
            showImage();
        }
        private void showImage()
        {
            try
            {
                lbMassage.Content = "";
                string imageName = txtPart.Text.Trim();
                string imageuri = @"D:\LDVWMS\image\";
                if (System.Configuration.ConfigurationManager.AppSettings.Count > 0)
                {
                    imageuri = System.Configuration.ConfigurationManager.AppSettings[0].ToString();
                }                
                
                if (imageName != "")
                {
                    Uri uri = new Uri(@imageuri + imageName + ".png", UriKind.Relative);
                    if (File.Exists(@imageuri + imageName + ".png"))
                    {
                        BitmapImage bitmap = new BitmapImage(uri);
                        image1.Source = bitmap.Clone();
                        image1.Source = bitmap;
                    }
                    else
                    {
                        lbMassage.Content = "扫描零件号" + imageName + "不正确或无此图片！";
                        image1.Source = null;
                    }
                    //System.Threading.Thread.Sleep(40);//每秒25帧
                }
                else
                {
                    lbMassage.Content = "请扫描零件号！";
                    image1.Source = null;
                }
                txtPart.Focus();
                txtPart.SelectAll();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void txtPart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                showImage();
            }
        }
    }
}
