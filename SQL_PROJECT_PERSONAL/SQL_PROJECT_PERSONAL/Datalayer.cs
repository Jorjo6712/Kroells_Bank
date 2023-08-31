using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SQL_PROJECT_PERSONAL
{
    internal class Datalayer
    {
        public void Connection(TextBox PinCode)
        {

            int enteredPin;

            string balance = "";  // Variable to store the balance

            string clientName = "";  // Variable to store the client name

            string connString = @"Data Source=localhost;Initial Catalog=Krølls_bank; Integrated Security=True"; // SQL connection string


            if (int.TryParse(PinCode.Text, out enteredPin))
            {
                using (SqlConnection conn = new SqlConnection(connString)) // SQL Connection
                {
                    try
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand("PinToClientInfo", conn)) // This is what my procedure needs from me
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure; // This tell the program that we are working with StoredProcedure

                            cmd.Parameters.AddWithValue("@Pin", enteredPin); // This will send Data from C# to SQL server

                            using (SqlDataReader reader = cmd.ExecuteReader()) // This reads the SQL DATA
                            {
                                if (reader.Read())
                                {
                                    balance = reader[0].ToString();  // Assuming Balance is the first column in the result set

                                    clientName = reader[1].ToString();  // Assuming Client_name is the second column in the result set

                                    MainWindow mainWindow = new MainWindow();

                                    mainWindow.OpenDashboard(balance, clientName, enteredPin);

                                    
                                     // creating an object of our mainwindow so that we can go back
                                    /*mainWindow.IsVisible = false;*/
                                        

                                }
                                else
                                {
                                    MessageBox.Show("Invalid PIN. Please try again."); // If Pin code does not exist in our DataBase
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message); // If connection is not working
                    }
                }
            }
        }

        public void Deposit(TextBox transactionBox, int pin, long totalAmount)
        {

            int transaction = Convert.ToInt32(transactionBox.Text);

            string connString = @"Data Source=localhost;Initial Catalog=Krølls_bank;Integrated Security=True"; // SQL connection string

            using (SqlConnection conn = new SqlConnection(connString)) // For SQL Connection
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("PinToDepositMoney", conn)) // Telling program which Procedure it need to connect to
                    {
                        cmd.CommandType = CommandType.StoredProcedure; // tell program that it is a procedure that we are working with
                        cmd.Parameters.AddWithValue("@Pin", pin); // giving values
                        cmd.Parameters.AddWithValue("@DepositValue", totalAmount); // giving values

                        cmd.ExecuteNonQuery(); //In Modifying Section,we have Insert, Delete ,Update,...queries.so for this we need to use ExecuteNonQuery command.why because we are not querying a database, we are modifying

                        MessageBox.Show("All done!"); // Just to tell useer that everything is done

                        //MainWindow mainWindow = new MainWindow(); // creating an object of our mainwindow so that we can go back
                        //Window1 window1 = new Window1(transaction.ToString(), "", 0);

                        //mainWindow.Show();
                        //window1.Close();
                    }
                }
                catch (Exception ex) // in case of error
                {
                    MessageBox.Show(ex.Message); // if you have a problem with connection
                }
            }

        }

        public void Withdraw(int pin, long totalAmount, string balance, string clientName)
        {
            string connString = @"Data Source=localhost;Initial Catalog=Krølls_bank;Integrated Security=True"; // SQL connection string

            using (SqlConnection conn = new SqlConnection(connString)) // For SQL Connection
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("pinToWithdrawMoney", conn)) // Telling program which Procedure it need to connect to
                    {
                        cmd.CommandType = CommandType.StoredProcedure; // tell program that it is a procedure that we are working with
                        cmd.Parameters.AddWithValue("@pin", pin); // giving values
                        cmd.Parameters.AddWithValue("@WithdrawValue", totalAmount); // giving values
                        
                        // Create a new SqlParameter object to hold the return value from the stored procedure
                        SqlParameter returnValue = new SqlParameter("@ReturnVal", SqlDbType.Int);

                        // Set the direction of the parameter to ReturnValue, indicating it will hold the return value of the stored procedure
                        returnValue.Direction = ParameterDirection.ReturnValue;

                        // Add the returnValue parameter to the Parameters collection of the SqlCommand object (cmd)
                        cmd.Parameters.Add(returnValue);

                        cmd.ExecuteNonQuery(); //In Modifying Section,we have Insert, Delete ,Update,...queries.so for this we need to use ExecuteNonQuery command.why because we are not querying a database, we are modifying

                        int result = (int)returnValue.Value; // adding the return value into an int variable
                        
                        if (result == -1) // if your withdraw more then you have in your account
                        {
                            // Insufficient funds
                            throw new Exception("Insufficient funds.");
                        }
                        else
                        {
                            MessageBox.Show("All done!"); // if everything is done
                        }
                        
                        //MainWindow mainWindow = new MainWindow(); // creating an object of our mainwindow so that we can go back
                        //Window1 window1 = new Window1(balance, clientName, pin);

                        //mainWindow.Show();

                        //window1.Close();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); // if you have a problem with connection
                }
            }
        }

    }
}
