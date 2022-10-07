using System;
using System.Collections.Generic;
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
using WpfApp1.Classes.ViewModels;

namespace WpfApp1
{
    public partial class UserControll : Page
    {

        public UserControll()
        {
            InitializeComponent();
            var userControllViewModel = new UserControllViewModel();
            DataContext = userControllViewModel;
             frame.Navigate(new ListUsers(userControllViewModel));
            // frame.Navigate(new RadiaGradientTest());

        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new AddUser());
        }

        private void EditUserBtn_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new EditUser( ((UserControllViewModel)DataContext).SelectedUser ));

            // SelectedUser = null нужно чтобы пропало выделение кнопки Edit и Delete
            ((UserControllViewModel)DataContext).SelectedUser = null;
        }
    }
}
