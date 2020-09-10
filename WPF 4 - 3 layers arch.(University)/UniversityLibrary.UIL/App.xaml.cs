using Autofac;
using System.Windows;
using UniversityLibrary.DAL;
using AutoMapper;
using UniversityLibrary.BLL.Services;
using UniversityLibrary.BLL.Utils;
using UniversityLibrary.DAL.Repository;
using System.Data.Entity;

namespace UniversityLibrary.UIL
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ApplicationContext>().As<DbContext>().SingleInstance();
            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterType<StudentService>().As<IStudentService>();
            builder.RegisterType<MainWindow>().AsSelf();

            var config = new MapperConfiguration(cgf => cgf.AddProfile(new MapperConfig()));
            builder.RegisterInstance(config.CreateMapper());

            using (var scope = builder.Build().BeginLifetimeScope())
            {
                var window = scope.Resolve<MainWindow>();
                window.ShowDialog();
            }
        }
    }
}
