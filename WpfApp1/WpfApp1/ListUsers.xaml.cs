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
using WpfApp1.Classes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ListUsers.xaml
    /// </summary>
    public partial class ListUsers : Page
    {
        public DateTime TimeTest { get; set; } = DateTime.Now;    
        private ApplicationContext _db { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public ListUsers(ApplicationContext dbInstance, ObservableCollection<User> users)
        {
            InitializeComponent();
            DeleteBtn.Click += DeleteUsersChanged;
            _db = dbInstance;
            Users = users;
            DataContext = this;
        }
        private void DeleteUsersChanged(object sender, RoutedEventArgs e)
        {
         
            if(UsersList.SelectedItems.Count == 0)
            {
                MessageBox.Show($"Select users to delete");
            }
            else
            {
                var selectedUsers = UsersList.SelectedItems;
                var confirm = MessageBox.Show($"Are you sure want delete {selectedUsers.Count } users?", "Alert",MessageBoxButton.YesNoCancel);
                if (confirm == MessageBoxResult.Yes)
                {               
                    while(selectedUsers.Count > 0)
                    {
                        var objectForDele = (User)selectedUsers[0]!;
                        _db.Users.Remove(objectForDele);
                        Users.Remove(objectForDele);
                    }
                    _db.SaveChangesAsync();
                }
            }         
        }
    }
}
