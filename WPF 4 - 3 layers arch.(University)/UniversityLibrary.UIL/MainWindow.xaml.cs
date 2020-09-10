using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using UniversityLibrary.BLL.Model;
using UniversityLibrary.BLL.Services;

namespace UniversityLibrary.UIL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IStudentService service;
        public ObservableCollection<StudentDTO> Students { get; set; } = new ObservableCollection<StudentDTO>();
        public MainWindow(IStudentService studentService)
        {
            InitializeComponent();
            service = studentService;
            GetStudents(service);
            this.DataContext = Students;
        }

        private void GetStudents(IStudentService studentService)
        {
            Students.Clear();
            var temp = studentService.GetStudents();
            foreach (var item in temp)
            {
                Students.Add(item);
            }
        }

       
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            StudentDTO createStudent = new StudentDTO { Name = tbName.Text , Surname = tbSurname.Text, Group = tbGroup.Text };
            service.AddStudent(createStudent);
            GetStudents(service);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            StudentDTO deleteStudent = new StudentDTO { Name = tbName.Text, Surname = tbSurname.Text, Group = tbGroup.Text};
            service.DeleteStudent(deleteStudent);
            GetStudents(service);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            StudentDTO clientDataStudent = new StudentDTO { Name = tbUpdateName.Text, Surname = tbUpdateSurame.Text, Group = tbUpdateGroup.Text };
            service.UpdateStudent(clientDataStudent);
            GetStudents(service);
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbUpdateName.Text = (dg.SelectedItem as StudentDTO).Name;
            tbUpdateSurame.Text = (dg.SelectedItem as StudentDTO).Surname;
            tbUpdateGroup.Text = (dg.SelectedItem as StudentDTO).Group;
        }
    }
}
