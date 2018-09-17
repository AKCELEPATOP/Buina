using BuinyaService.Implementations;
using BuinyaService.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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

namespace Buinya.Views
{
    /// <summary>
    /// Логика взаимодействия для Accounts.xaml
    /// </summary>
    public partial class Accounts : UserControl
    {

        private IAccount service;

        public Accounts()
        {
            InitializeComponent();
            service = new AccountService();
        }

        private async void Accounts_Load(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = await service.GetTable();
            //dataGrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = service.GetTable() });
        }
    }
}
