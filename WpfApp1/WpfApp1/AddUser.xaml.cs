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
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    /// 
    public partial class AddUser : Page
    {
        public User UserForm { get; set; }
        public ObservableCollection<User> Users { get; set; }

        private ApplicationContext _db;
        public AddUser(ApplicationContext dbInstance, ObservableCollection<User> users)
        {
            InitializeComponent();
            _db = dbInstance;
            Users = users;

            UserForm = new User();
            UserForm.Name = "Name Test";
            SaveBtn.Click += SaveUserClick;
            ResetBtn.Click += ResetUserClick;

            DataContext = UserForm;
        }

        private async void SaveUserClick(object sender, RoutedEventArgs e)
        {
            UserForm.CreatedOn = DateTime.Now;
            UserForm.SubcriedTo = DateTime.Now.AddDays(1);
   
            Users.Add(UserForm);
            await _db.Users.AddAsync(UserForm);
            await _db.SaveChangesAsync();
            ResetForm();
        }

        private void ResetUserClick(object sender, RoutedEventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            UserForm = new User();
            NameTbx.Text = String.Empty;
            SurNameTbx.Text = String.Empty;
            DescriptionTbx.Text = String.Empty;
        }

    }
}
