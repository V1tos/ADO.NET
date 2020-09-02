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

namespace WPF_2___Params
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

        SqlConnection connection;
        string connectionString;

      

        private void cbConnect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearListBoxes();
            ComboBox comboBox = sender as ComboBox;
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    btnConnect.IsEnabled = true;
                    tbIP.IsEnabled = tbLogin.IsEnabled = tbPassword.IsEnabled = false;
                    break;
                case 1:
                    btnConnect.IsEnabled = true;
                    tbIP.IsEnabled = tbLogin.IsEnabled = tbPassword.IsEnabled = true;
                    break;
                default:
                    break;
            }
        }

        private void ClearListBoxes()
        {
            cbDatabases.Items.Clear();
            lbData.Items.Clear();
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            switch (cbConnection.SelectedIndex)
            {
                case 0:
                    connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                             Initial Catalog=master;
                                             Integrated Security=true;";
                    break;
                case 1:
                    connectionString = $@"Data Source = {tbIP.Text};
                    Initial Catalog = master;
                    Integrated Security = false;
                    User ID = {tbLogin.Text};
                    Password = {tbPassword.Text};";
 
                    break;
                default:
                    break;
            }

            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                ShowDataBases(connection);
            }
            spTables.Visibility = Visibility.Visible;
        }
        private void ShowDataBases(SqlConnection connection)
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("Select * from sys.databases", connection))
                {
                    
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            cbDatabases.Items.Add(dataReader[0]);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private void cbDB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbTables.Items.Clear();
            ComboBox dataBases = sender as ComboBox;


            using (connection = new SqlConnection(connectionString))
            {
                ShowTables(connection, dataBases.SelectedItem.ToString());
            }
        }

        private void ShowTables(SqlConnection connection, string dbName)
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"use {dbName}; Select * from sys.tables", connection))
                {
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            lbTables.Items.Add(dataReader[0]);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private void lbTables_SelectionChanged(object sender, RoutedEventArgs e)
        {
            lbData.Items.Clear();
            ListBox tables = sender as ListBox;

            using (connection = new SqlConnection(connectionString))
            {
                ShowData(connection, tables.SelectedItem.ToString());
            }

            spData.Visibility = Visibility.Visible;
        }

        private void ShowData(SqlConnection connection, string tableName)
        {
            try
            {
                connection.Open();
                string commandString = $"use {cbDatabases.SelectedItem.ToString()};Select * from {tableName}";
                using (SqlCommand command = new SqlCommand(commandString, connection))
                {
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            lbData.Items.Add(dataReader[1]);
                        }
                    }        
                }

            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        //string shapka="";
        //string vmist="";

      

        
    }
}
