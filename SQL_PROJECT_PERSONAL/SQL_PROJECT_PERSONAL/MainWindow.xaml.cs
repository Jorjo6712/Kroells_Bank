using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

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
        bool remove = true;
        const int pinLength = 4;


        public MainWindow()
        {
            InitializeComponent();
        }

        // All these button are used as Numpad are here in this single method
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (PinCode.Text.Length < pinLength)
            {
                if (remove)
                {
                    PinCode.Text = "";
                    remove = false;
                }

                // Retrieve the number from the Button's Tag property
                Button button = (Button)sender;
                string number = button.Tag.ToString();

                PinCode.Text = PinCode.Text + number;
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
            if (PinCode.Text.Length == pinLength)
            {
                if (data.Connection(PinCode))
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Your Pin must be 4 digits!");
            }

        }

        public void OpenDashboard(string balance, string clientname, int pin)
        {
            Window1 window1 = new Window1(balance, clientname, pin);
            window1.Show();
        }
    }
}
