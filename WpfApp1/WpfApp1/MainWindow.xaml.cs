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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ApplicationContext Db { get; private set; }
        public ObservableCollection<User> Users { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Db = new ApplicationContext();
         
            AddUserBtn.Click += AddUserClick;
            ListUsersBtn.Click += ListUsersClick;

            Db.Users.Load();
            Users = Db.Users.Local.ToObservableCollection();

            frame.Navigate(new ListUsers(Db, Users));

        }

        private void AddUserClick(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new AddUser(Db,Users));
        }
        private void ListUsersClick(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new ListUsers(Db,Users));
        }
    }
}
