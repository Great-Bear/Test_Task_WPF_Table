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
    public class UserControllViewModel : BasicViewModel, INotifyPropertyChanged
    {
        public ObservableCollection<User> Users { get; set; }

        private User _selectedUser;
        public User SelectedUser {
            get
            {
                return _selectedUser;
            }
            set
            {
                _selectedUser = value;
                OnPropertyChanged();
            }
        }

        private IList _selectedUsers;
        public IList SelectedUsers
        {
            get => _selectedUsers;
            set
            {
                _selectedUsers = value;
            }
        }

        public UserControllViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        RelayCommand? deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((obj) =>
                  {

                      var selectedUsersIE = SelectedUsers.Cast<User>();

                      while(selectedUsersIE.Count() > 0)
                      {
                          var item = selectedUsersIE.FirstOrDefault();
                          Users.Remove(item);
                          db.Users.Remove(item);
                      }

                      db.SaveChangesAsync();
                  }));
            }
        }

    }
}
