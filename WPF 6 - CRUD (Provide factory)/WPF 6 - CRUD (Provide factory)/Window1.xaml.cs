using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WPF_6___CRUD__Provide_factory_
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        List<Group> groups = new List<Group>();
        public Student Student { get; set; }
        bool isCreate = true;

        DbProviderFactory factory;
        DbConnection connection;
        public Window1(Student student, DbProviderFactory factory, DbConnection connection)
        {
            InitializeComponent();
            this.factory = factory;
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
            DbCommand command = factory.CreateCommand();
            command.CommandText = cmdRead;
            command.Connection = connection;
            using (DbDataReader reader = command.ExecuteReader())
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
            DbCommand command = factory.CreateCommand();
            command.CommandText = cmdAdd;
            command.Connection = connection;

            AddParameter(command, "@name", student.Name);
            AddParameter(command, "@surname", student.Surname);
            AddParameter(command, "@idGroup", student.GroupId.ToString());

            command.ExecuteNonQuery();
        }

        private void UpdateStudent(Student student)
        {
            string cmdUpdate = $"update student set Name = @name, Surname = @surname, IdGroup = @idGroup where id = @id";
            DbCommand command = factory.CreateCommand();
            command.CommandText = cmdUpdate;
            command.Connection = connection;

            AddParameter(command, "@id", student.Id.ToString());
            AddParameter(command, "@name", student.Name);
            AddParameter(command, "@surname", student.Surname);
            AddParameter(command, "@idGroup", student.GroupId.ToString());

            command.ExecuteNonQuery();
        }


        private void AddParameter(DbCommand command, string parameterName, string value)
        {
            DbParameter parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }

    }
}
