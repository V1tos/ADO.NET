using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WPF_7___CRUD__AsyncDelegates_
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        List<Group> groups = new List<Group>();
        public Student Student { get; set; }
        bool isCreate = true;
        SqlConnection connection;

        public Window1(Student student, SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;


            ReadFromGroups();
            cbGroup.ItemsSource = groups;
            Student = new Student();
            if (student != null)
            {
                Student = student;
                isCreate = false;
                FillFields(Student);
            }

        }
        private void ReadFromGroups()
        {
            groups.Clear();
            string cmdRead = "Select * from Groups";
            SqlCommand command = new SqlCommand(cmdRead, connection);
            command.BeginExecuteReader(ReaderCallback, command);
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
                        groups.Add(new Group
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    });
                }
            }

            reader.Close();
        }

        private void FillFields(Student student)
        {
            tbName.Text = student.Name;
            tbSurname.Text = student.Surname;
            cbGroup.SelectedItem = groups.Find(x => x.Id == student.GroupId);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Student.Name = tbName.Text;
            Student.Surname = tbSurname.Text;
            Student.GroupId = groups.Find(x => x.Name == cbGroup.Text).Id;
            if (isCreate)
                AddStudent(Student);
            else
                UpdateStudent(Student);

            this.Close();
        }

        private void AddStudent(Student student)
        {
            string cmdAdd = $"insert into Student values(@name, @surname, @idGroup)";
            SqlCommand command = new SqlCommand(cmdAdd, connection);
            command.Parameters.AddWithValue("@name", student.Name);
            command.Parameters.AddWithValue("@surname", student.Surname);
            command.Parameters.AddWithValue("@idGroup", student.GroupId);
            command.ExecuteNonQuery();
        }

        private void UpdateStudent(Student student)
        {
            string cmdUpdate = $"update student set Name = @name, Surname = @surname, IdGroup = @idGroup where id = @id";
            SqlCommand command = new SqlCommand(cmdUpdate, connection);
            command.Parameters.AddWithValue("@id", student.Id);
            command.Parameters.AddWithValue("@name", student.Name);
            command.Parameters.AddWithValue("@surname", student.Surname);
            command.Parameters.AddWithValue("@idGroup", student.GroupId);
            command.ExecuteNonQuery();
        }

    }
}
