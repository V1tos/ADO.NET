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

namespace WPF_1___WindowsOrServerAuthentication
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
        string connectionStringToWindows = @"Data Source=(localdb)\MSSQLLocalDB;
                                             Initial Catalog=master;
                                             Integrated Security=true;";
        string connectionStringToServer = $@"Data Source=(localdb)\MSSQLLocalDB;
                                             Initial Catalog=Hospital_Palamarchuk;
                                             Integrated Security=false;";
        string commandText = "Select name from sys.database";
        
        
        
                                                                        
                                            

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            switch (cbConnect.SelectedIndex)
            {
                case 0:
                    using (SqlConnection connection = new SqlConnection(connectionStringToWindows))
                    {
                        ShowDataBases(connection);
                    }
                    
                    break;
                case 1:
                    connectionStringToServer =$@"Data Source = {tbIP.Text};
                    Initial Catalog = master;
                    Integrated Security = false;
                    User ID = {tbLogin.Text};
                    Password = {tbPassword.Text};";
                    using (SqlConnection connection = new SqlConnection(connectionStringToServer))
                    {
                        ShowDataBases(connection);
                    }
                    break;
                default:
                    break;
            }
        }

        private void cbConnect_Selected(object sender, RoutedEventArgs e)
        {
            lbDB.Items.Clear();
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

        private void ShowDataBases(SqlConnection connection)
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("Select Name from sys.databases", connection))
                {
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            lbDB.Items.Add(dataReader[0].ToString());
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

    }
}
