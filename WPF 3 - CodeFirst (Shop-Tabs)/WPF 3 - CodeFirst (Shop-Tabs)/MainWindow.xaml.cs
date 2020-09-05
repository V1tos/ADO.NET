using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using WPF_3___CodeFirst__Shop_Tabs_.Entities;

namespace WPF_3___CodeFirst__Shop_Tabs_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }
 

        private void LoadData()
        {
            ApplicationContext context = new ApplicationContext();

            FillClientTab(context);
            FillOrderTab(context);
            FillProductTab(context);

        }

        private void FillClientTab(ApplicationContext context)
        {
            context.Clients.Load();
            dgClients.ItemsSource = context.Clients.Local.ToBindingList();
        }

        private void FillProductTab(ApplicationContext context)
        {
            context.Products.Load();
            dgProducts.ItemsSource = context.Products.Local.ToBindingList();
        }

        private void FillOrderTab(ApplicationContext context)
        {
            context.Orders.Load();
            dgOrders.ItemsSource = context.Orders.Local.ToBindingList();
        }
    }
}
