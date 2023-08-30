using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connString = @"Data Source=ZBC-S-jona993p;Initial Catalog=Krølls_bank;User ID=PinManager;Password=admin;Integrated Security=True";

        int i = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        // Numbers to pin
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

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            PinCode.Text = "";
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            int enteredPin;

            if (int.TryParse(PinCode.Text, out enteredPin))
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand("PinToClientInfo", conn))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Pin", enteredPin);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {

                                    // Show the existing Window1.xaml
                                    Window1 window1 = new Window1();
                                    window1.Show();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid PIN. Please try again.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid PIN format. Please enter numbers only.");
            }
        }
    }
}
