using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Schema;

namespace SQL_PROJECT_PERSONAL
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        // All the variables that i will use in this window
        bool MainOption1 = true;
        bool MainOption2 = true;
        bool deposit = false;
        long totalAmount;
        int pin;
        int DBBalance;
        string clientName;

        /// <summary>
        /// I receive data from MainWindow Here and Insert them into the variables that i have on top of them
        /// </summary>
        /// <param name="getBalance"></param>
        /// <param name="GetClient_Name"></param>
        /// <param name="Getpin"></param>
        public Window1(string getBalance, string GetClient_Name, int Getpin)
        {
            
            InitializeComponent();

            clientName = GetClient_Name;

            //MessageBox.Show(getBalance + " window 2 " +  GetClient_Name);

            MoneyText.Content = getBalance;

            Card_Holder_Name.Content = GetClient_Name;

            pin = Getpin;

            DBBalance = Convert.ToInt32(getBalance);

        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the number from the Button's Tag property
            Button button = (Button)sender;
            string number = button.Tag.ToString();

            if (MainOption1 && number == "1")
            {
                deposit = true;

                // hidding all the unecessary things from the screen

                DepositBox.Visibility = Visibility.Hidden;

                WithdrawBox.Visibility = Visibility.Hidden;

                LogOutBox.Visibility = Visibility.Hidden;

                // showing all the necessary things on the screen

                TransactionBox.Visibility = Visibility.Visible;

                QuestionText.Visibility = Visibility.Visible;

                EnterText.Visibility = Visibility.Visible;

                TransactionText.Visibility = Visibility.Visible;

                MainOption1 = false;

                MainOption2 = false;

                TransactionBox.Text = "";
            }
            else if (MainOption2 && number == "2")
            {
                // hidding all the unecessary things from the screen

                DepositBox.Visibility = Visibility.Hidden;

                WithdrawBox.Visibility = Visibility.Hidden;

                LogOutBox.Visibility = Visibility.Hidden;

                // showing all the necessary things on the screen

                TransactionBox.Visibility = Visibility.Visible;

                QuestionText.Visibility = Visibility.Visible;

                EnterText.Visibility = Visibility.Visible;

                TransactionText.Visibility = Visibility.Visible;

                MainOption1 = false;
 
                MainOption2 = false;

                TransactionBox.Text = "";
            }
            else
            {
                TransactionText.Visibility = Visibility.Hidden;

                if (TransactionBox.Text.Length < 9)
                {
                    TransactionBox.Text = TransactionBox.Text + number;
                }
                totalAmount = Convert.ToInt32(TransactionBox.Text);
            }
        }

        /// <summary>
        /// This Button is to Clear the transaction (readonly textbox) the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionText.Visibility = Visibility.Hidden;

            TransactionBox.Text = "";
        }

        /// <summary>
        /// This Button is to log out of this window the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
            {
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();

            this.Close();
        }

        /// <summary>
        /// This Button has different operations
        /// 1. This Button will make sure that you have sellected the MainOption (Which is deposit/withdraw)
        /// 2. This Button will make sure that you have insert a value
        /// 3. This Button will then Connect C# with SQL Server through user MainOption 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainOption1 || MainOption2) // Checking if user have choosen the MainOption
            {
                MessageBox.Show("Please select an option ");
            }
            else if (TransactionBox.Text == "") // Checking if user have insert a value
            {
                MessageBox.Show("Please insert an amount");
            }
            else if (deposit)
            {
                if ((DBBalance + totalAmount) > int.MaxValue) // Just to make sure that user's insert value is not higher then Int Max Value.
                {
                    MessageBox.Show("You have deposit more than we can hold. be Aware that we can run away with your money");
                }
                else // This will connect to the SQL StoredProcedure
                {
                    Datalayer data = new Datalayer();
                    data.Deposit(TransactionBox, pin, totalAmount);
                    BackToMainWindow();
                }
            }
            else // This will connect to the SQL StoredProcedure
            {
                Datalayer data = new Datalayer();
                data.Withdraw(pin, totalAmount, DBBalance.ToString(), clientName);
                BackToMainWindow();
            }

        }

        public void BackToMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
