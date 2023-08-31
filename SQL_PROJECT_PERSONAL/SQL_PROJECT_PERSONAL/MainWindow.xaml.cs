using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace SQL_PROJECT_PERSONAL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // These variables will be used in this windows
        int i = 0;
        string connString = @"Data Source=localhost;Initial Catalog=Krølls_bank;Integrated Security=True"; // SQL connection string

        public MainWindow()
        {
            InitializeComponent();
            
        }

        // all these button are used as Numpad
        private void Number1_Click(object sender, RoutedEventArgs e)
        {
            if (PinCode.Text.Length < 4)
            {
                if (i == 0)
                {
                    PinCode.Text = "";
                    i++;
                }
                PinCode.Text = PinCode.Text + 1;
            }

        }

        private void Number2_Click(object sender, RoutedEventArgs e)
        {
            if (PinCode.Text.Length < 4)
            {
                if (i == 0)
                {
                    PinCode.Text = "";
                    i++;
                }
                PinCode.Text = PinCode.Text + 2;
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            if (PinCode.Text.Length < 4)
            {
                if (i == 0)
                {
                    PinCode.Text = "";
                    i++;
                }
                PinCode.Text = PinCode.Text + 3;
            }
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            if (PinCode.Text.Length < 4)
            {
                if (i == 0)
                {
                    PinCode.Text = "";
                    i++;
                }
                PinCode.Text = PinCode.Text + 4;
            }
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            if (PinCode.Text.Length < 4)
            {
                if (i == 0)
                {
                    PinCode.Text = "";
                    i++;
                }
                PinCode.Text = PinCode.Text + 5;
            }
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            if (PinCode.Text.Length < 4)
            {
                if (i == 0)
                {
                    PinCode.Text = "";
                    i++;
                }
                PinCode.Text = PinCode.Text + 6;
            }
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            if (PinCode.Text.Length < 4)
            {
                if (i == 0)
                {
                    PinCode.Text = "";
                    i++;
                }
                PinCode.Text = PinCode.Text + 7;
            }
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            if (PinCode.Text.Length < 4)
            {
                if (i == 0)
                {
                    PinCode.Text = "";
                    i++;
                }
                PinCode.Text = PinCode.Text + 8;
            }
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            if (PinCode.Text.Length < 4)
            {
                if (i == 0)
                {
                    PinCode.Text = "";
                    i++;
                }
                PinCode.Text = PinCode.Text + 9;
            }
        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            if (PinCode.Text.Length < 4)
            {
                if (i == 0)
                {
                    PinCode.Text = "";
                    i++;
                }
                PinCode.Text = PinCode.Text + 0;
            }
        }


        /// <summary>
        /// This Button is to clear what user have already wrote using Numpad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            PinCode.Text = "";
        }

        /// <summary>
        /// This Button is to close the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        
            Datalayer data = new Datalayer();
        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            data.Connection(PinCode);
            
            this.Close();
        }

        public void OpenDashboard(string balance, string clientname, int pin)
        {
            Window1 window1 = new Window1(balance, clientname, pin);
            window1.Show();
        }
    }
}
