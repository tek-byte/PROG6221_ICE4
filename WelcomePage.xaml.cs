using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PROG6221_ICE4
{
    /// <summary>
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Window
    {
        MainWindow mw = new MainWindow();
        private static string pathb = System.IO.Path.GetFullPath(@"..\..\") + "UserDetails.txt";
      
        
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();
                if (!File.Exists(pathb))
                {
                    using (StreamWriter sw = File.CreateText(pathb))
                    {
                    sw.WriteLine("Movies");
                    sw.WriteLine("Watch new SpiderMan");
                    sw.WriteLine("7 November 2021");
                    sw.WriteLine("17:00");
                    sw.Close();
                    }
                    //txtView.Text = "Nothing in here.";
                }

            try
            {
                StreamReader sr = new StreamReader(pathb, true);
                for (int x = 0; x != File.ReadAllLines(pathb).Count() / 4; x++)
                {
                    listView.Items.Add("Plan: " + sr.ReadLine() + "\n");
                    listView.Items.Add("Description: " + sr.ReadLine() + "\n");
                    listView.Items.Add("Date: " + sr.ReadLine() + "\n");
                    listView.Items.Add("Time: " + sr.ReadLine() + "\n");
                    listView.Items.Add("\n");

                }
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex);
            }

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();
            txtplan.Text = String.Empty;
            txtdesc.Text = String.Empty;
            txtdate.Text = String.Empty;
            txtTime.Text = String.Empty;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            mw.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!File.Exists(pathb))
                {
                    using (StreamWriter sw = File.CreateText(pathb))
                    {
                        sw.WriteLine("Movies");
                        sw.WriteLine("Watch new SpiderMan");
                        sw.WriteLine("7 November 2021");
                        sw.WriteLine("17:00");
                        sw.Close();
                    }
                    //txtView.Text = "Nothing in here.";
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(pathb, true))
                    {
                        sw.WriteLine(txtplan.Text);
                        sw.WriteLine(txtdesc.Text);
                        sw.WriteLine(txtdate.Text);
                        sw.WriteLine(txtTime.Text);
                        sw.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
                throw;
            }
            //lblUserName.Content = "Saved!";
        }

    }
}
