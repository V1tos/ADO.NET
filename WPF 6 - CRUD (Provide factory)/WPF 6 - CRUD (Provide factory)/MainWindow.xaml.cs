using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.Common;
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

namespace WPF_6___CRUD__Provide_factory_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string provider = ConfigurationManager.AppSettings["provider"];
        string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();

        DbProviderFactory factory;
        DbConnection connection;

        public MainWindow()
        {
            InitializeComponent();
            factory = DbProviderFactories.GetFactory(provider);
            connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;
            OpenConection(connection);
            lbStudents.ItemsSource = Students;
        }

        private void OpenConection(DbConnection connection)
        {
            try
            {
                connection.Open();
            }
            catch (DbException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1(null, factory, connection);
            window.ShowDialog();
            ReadFromStudent();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lbStudents.SelectedItem == null)
                return;
            Student updateStudent = lbStudents.SelectedItem as Student;
            Window1 window = new Window1(updateStudent,factory, connection);
            window.ShowDialog();
            ReadFromStudent();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbStudents.SelectedItem == null)
                return;

            Student deleteStudent = lbStudents.SelectedItem as Student;
            DeleteFromStudent(deleteStudent);
            ReadFromStudent();
        }

        private void DeleteFromStudent(DbCommand command)
        {
            try
            {
                command.ExecuteNonQuery();
            }
            catch (DbException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void DeleteFromStudent(Student student)
        {
            int deleteStudentId = student.Id;
            string cmdDelete = $"Delete Student Where Id = {deleteStudentId}";
            DbCommand command = factory.CreateCommand();
            command.CommandText = cmdDelete;
            command.Connection = connection;
            DeleteFromStudent(command);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (DbException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            ReadFromStudent();
        }


        private void ReadFromStudent()
        {
            string cmdRead = "Select * From Student";
            DbCommand command = factory.CreateCommand();
            command.CommandText = cmdRead;
            command.Connection = connection;

            Students.Clear();
            using (DbDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Students.Add(new Student
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Surname = reader.GetString(2),
                            GroupId = reader.GetValue(3) as Nullable<int>
                        });
                    }
                }
            }
        }

        private void ReadFromStudent(DbCommand command)
        {
            Students.Clear();
            using (DbDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Students.Add(new Student
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Surname = reader.GetString(2),
                            GroupId = reader.GetValue(3) as Nullable<int>
                        });
                    }
                }
            }
        }
    }
}
