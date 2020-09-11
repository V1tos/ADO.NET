using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.Common;
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

namespace WPF_7___CRUD__AsyncDelegates_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);
        SqlConnection connection;

        public MainWindow()
        {
            InitializeComponent();
            builder.AsynchronousProcessing = true;
            connection = new SqlConnection(builder.ConnectionString);
            OpenConection(connection);
            lbStudents.ItemsSource = Students;
        }

        private void OpenConection(SqlConnection connection)
        {
            try
            {
                connection.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1(null, connection);
            window.ShowDialog();
            ReadFromStudent();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lbStudents.SelectedItem == null)
                return;
            Student updateStudent = lbStudents.SelectedItem as Student;
            Window1 window = new Window1(updateStudent, connection);
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
        private void DeleteFromStudent(Student student)
        {
            int deleteStudentId = student.Id;
            string cmdDelete = $"Delete Student Where Id = {deleteStudentId}";
            SqlCommand command = new SqlCommand(cmdDelete, connection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
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
            SqlCommand command = new SqlCommand(cmdRead, connection);
            Students.Clear();
            var reader = command.BeginExecuteReader(ReaderCallback, command);

        }

        private void ReaderCallback(IAsyncResult ar)
        {
            var result = (SqlCommand)ar.AsyncState;
            var reader = result.EndExecuteReader(ar);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Dispatcher.Invoke(() =>
                    {
                        Students.Add(new Student
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Surname = reader.GetString(2),
                            GroupId = reader.GetValue(3) as Nullable<int>
                        });
                    });
                }
            }

            reader.Close();
        }
    }
}

