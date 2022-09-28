using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    public class EditUserViewModel : BasicViewModel, INotifyPropertyChanged
    {
        private User _newUser;

        public EditUserViewModel(User selectedUser)
        {
            NewUser = selectedUser;
        }

        public User NewUser
        {
            get { return _newUser; }
            set
            {
                _newUser = value;
                OnPropertyChanged();
            }
        }

        RelayCommand? editCommand;

        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                    (editCommand = new RelayCommand((obj) =>
                    {
                        NewUser.CreatedOn = DateTime.Now;
                        db.Entry(NewUser).State = EntityState.Modified;
                        db.SaveChangesAsync();
                        ClearUser();
                    }));
            }
        }

        RelayCommand? clearUserCommand;
        public RelayCommand ClearUserCommand
        {
            get
            {
                return clearUserCommand ??
                    (clearUserCommand = new RelayCommand((obj) =>
                    {
                        MessageBox.Show(NewUser.Name);
                        ClearUser();
                    }));
            }
        }

        private void ClearUser()
        {
            NewUser = new User();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
