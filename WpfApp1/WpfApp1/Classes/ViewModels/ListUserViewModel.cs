using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Test_Task_WPF_Table.Classes;
using WpfApp1.ClassesConverter;

namespace WpfApp1.Classes.ViewModels
{
    public class ListUserViewModel : BasicViewModel
    {
        public ObservableCollection<User> Users { get; set; }

        public UserControllViewModel UserControllViewModel { get; set; }

        public ListUserViewModel(UserControllViewModel userControll)
        {
            db.Users.Load();
            Users = db.Users.Local.ToObservableCollection();
            UserControllViewModel = userControll;
            UserControllViewModel.Users = Users;
        }
    }
}
