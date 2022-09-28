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
    public class ListUserViewModel : BasicViewModel, INotifyPropertyChanged
    {
        public ObservableCollection<User> Users { get; set; }

        public User SelectedUser { get; set; }

        public ListUserViewModel()
        {
            db.Users.Load();
            Users = db.Users.Local.ToObservableCollection();

        }

        RelayCommand? deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((selectedItems) =>
                  {

                    var selectedUsersIE = (selectedItems as IEnumerable).Cast<User>();

                    while (selectedUsersIE.Count() > 0)
                    {
                        db.Users.Remove(selectedUsersIE.FirstOrDefault());
                    }

                    db.SaveChangesAsync();
                    SelectedUser = null;
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
