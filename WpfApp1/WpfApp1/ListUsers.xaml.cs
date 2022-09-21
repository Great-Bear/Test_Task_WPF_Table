using Microsoft.EntityFrameworkCore;
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
using Test_Task_WPF_Table.Classes;
using System.Windows;
using WpfApp1.Classes;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ListUsers.xaml
    /// </summary>
    public partial class ListUsers : Page
    {
        public ListUsers(ApplicationViewModel _applicationContext)
        {
            InitializeComponent();
            //  DataContext = _applicationContext;
            DataContext = _applicationContext;
        }

        private void usersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((ApplicationViewModel)DataContext).SelectedUser = (User)usersList.SelectedItem;
        }
    }
}
