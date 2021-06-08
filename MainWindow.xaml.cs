using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG6221_ICE4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string pathA = System.IO.Path.GetFullPath(@"..\..\") + "loginDetails.txt";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader(pathA, true);

            string[] Usernames = new string[File.ReadAllLines(pathA).Count()/2];
            string[] Passwords = new string[File.ReadAllLines(pathA).Count()/2];

            for (int x = 0; x < Usernames.Length; x++)
            {
                Usernames[x] = sr.ReadLine();
                Passwords[x] = sr.ReadLine();
            }

            //Checks if usernames and passwords match with same indexes.
            if (Usernames.Contains(txtLogin.Text) && Passwords.Contains(txtPassword.Password) && Array.IndexOf(Usernames, txtLogin.Text) == Array.IndexOf(Passwords, txtPassword.Password))
            {
                
                WelcomePage pg = new WelcomePage();
                pg.lblUserName.Content = txtLogin.Text;
                this.Hide();
                //Swithes windows
                pg.ShowDialog();
            } 
            else
            {
                lblMain2.Content = "Incorrect!";
            }
               
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!File.Exists(pathA))
                {
                    using (StreamWriter sw = File.CreateText(pathA))
                    {
                        sw.WriteLine(txtLogin.Text);
                        sw.WriteLine(txtPassword.Password);
                    }
                    lblMain2.Content = "Registered!";
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(pathA, true))
                    {
                        sw.WriteLine(txtLogin.Text);
                        sw.WriteLine(txtPassword.Password);
                    }
                    lblMain2.Content = "Registered!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
                throw;
            }
        }
    }
}
