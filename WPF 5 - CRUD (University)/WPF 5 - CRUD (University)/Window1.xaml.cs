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
using System.Windows.Shapes;

namespace WPF_5___CRUD__University_
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
            if (student!=null)
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
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        groups.Add(new Group
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                }
            }
        }

        private void FillFields(Student student)
        {
            tbName.Text = student.Name;
            tbSurname.Text = student.Surname;
            cbGroup.SelectedItem = groups.Find(x=>x.Id == student.GroupId);
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
            SqlCommand command = new SqlCommand($"insert into Student values(@name, @surname, @idGroup)", connection);
            command.Parameters.AddWithValue("@name", student.Name);
            command.Parameters.AddWithValue("@surname", student.Surname);
            command.Parameters.AddWithValue("@idGroup", student.GroupId);
            command.ExecuteNonQuery();
        }

        private void UpdateStudent(Student student)
        {
            SqlCommand command = new SqlCommand($"update student set Name = @name, Surname = @surname, IdGroup = @idGroup where id = @id", connection);
            command.Parameters.AddWithValue("@id", student.Id);
            command.Parameters.AddWithValue("@name", student.Name);
            command.Parameters.AddWithValue("@surname", student.Surname);
            command.Parameters.AddWithValue("@idGroup", student.GroupId);
            command.ExecuteNonQuery();
        }

        


    }
}
