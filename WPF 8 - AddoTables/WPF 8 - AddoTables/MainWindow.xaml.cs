using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

namespace WPF_8___AddoTables
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum Functions
        {
            ReadDatabase,
            Delete,
            ReadTable
        }

        string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        SqlConnection connection;
        DataTable table;
        string tableName;

        public MainWindow()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            ConnectToDB(new SqlCommand("SELECT name FROM sys.tables"), Functions.ReadDatabase);
        }

        private void ConnectToDB(SqlCommand command, Functions functions)
        {
            using (connection)
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    command.Connection = connection;

                    switch (functions)
                    {
                        case Functions.ReadTable:
                            ReadFromDataTable(command);
                            break;
                        case Functions.ReadDatabase:
                            ReadAllTablesFromDB(command);
                            break;
                        case Functions.Delete:
                            DeleteBook(command);
                            break;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DeleteBook(SqlCommand command)
        {
            command.ExecuteNonQuery();
            DataRow[] rows = table.Select($"Id = {int.Parse(tbId.Text)}");

            if (rows.Length > 0)
                rows[0].Delete();
        }

        private void ReadAllTablesFromDB(SqlCommand command)
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataGrid grid = new DataGrid();
                        grid.Name = "grid";
                        TabItem item = new TabItem();
                        item.Header = reader["name"];
                        item.Content = grid;
                        tc.Items.Add(item);
                    }

                }
            }
        }

        private void ReadFromDataTable(SqlCommand command)
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        table.Columns.Add(reader.GetName(i));

                    do
                    {
                        while (reader.Read())
                        {
                            DataRow r = table.NewRow();
                            for (int i = 0; i < reader.FieldCount; i++)
                                r[i] = reader[i];
                            table.Rows.Add(r);
                        }
                    } while (reader.NextResult());
                }
            }
        }

        private void tc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tableName = (tc.SelectedItem as TabItem).Header.ToString();

            HideElements();

            table = new DataTable();
            table.TableName = tableName;

            ConnectToDB(new SqlCommand($"Select * from {tableName}"), Functions.ReadTable);
            ((tc.SelectedItem as TabItem).Content as DataGrid).ItemsSource = table.DefaultView;
        }

        private void HideElements()
        {
            if (tableName == "Books")
            {
                btnDelete.Visibility = lblPlaceholder.Visibility = tbId.Visibility = Visibility.Visible;
            }
            else
                btnDelete.Visibility = lblPlaceholder.Visibility = tbId.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            table.WriteXml($"{tableName}.xml");
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbId.Text))
            {
                ConnectToDB(new SqlCommand($"Delete Books where Id = {tbId.Text}"), Functions.Delete);
            }
        }
    }
}
