using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Test_Task_WPF_Table.Classes;
using WpfApp1.Classes.DbContext.Models;
using WpfApp1.ClassesConverter;

namespace WpfApp1.Classes.ViewModels
{
    public class AddUserViewModel : BasicViewModel, INotifyPropertyChanged
    {
        private UserValidate _newUser;

        public UserValidate NewUser
        {
            get { return _newUser; }
            set
            {
                _newUser = value;
                OnPropertyChanged();
            }
        }

        public AddUserViewModel()
        {
            NewUser = new UserValidate();
            NewUser.Name = "N";
            NewUser.SurName = "S";
            NewUser.Decription = "D";
            NewUser.CreatedOn = DateTime.Now;
            NewUser.SubcriedTo = DateTime.Now;
        }

        RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand((obj) =>
                    {
                        NewUser.CreatedOn = DateTime.Now;
                        db.Users.AddAsync(NewUser);
                        
                        
                        db.SaveChangesAsync();
                        ClearUser();
                    }));
            }
        }

        RelayCommand? clearUser;
        public RelayCommand ClearUserCommand
        {
            get
            {
                return clearUser ??
                    (clearUser = new RelayCommand((obj) =>
                    {
                        ClearUser();
                    }));
            }
        }

        private void ClearUser()
        {
            NewUser = new UserValidate();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
