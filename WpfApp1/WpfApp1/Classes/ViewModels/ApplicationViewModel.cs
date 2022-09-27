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
using System.Windows.Data;
using Test_Task_WPF_Table.Classes;

namespace WpfApp1.ClassesConverter
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        ApplicationContext db = new ApplicationContext();
        RelayCommand? addCommand;
        RelayCommand? editCommand;
        RelayCommand? deleteCommand;
        public ObservableCollection<User> Users { get; set; }

        private User _selectedUser;

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged();
            }
        }


        public ApplicationViewModel()
        {
            db.Users.Load();
            Users = db.Users.Local.ToObservableCollection();
        }
        // команда удаления
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((selectedItems) =>
                  {
                    var selectedUsersIE = (selectedItems as IEnumerable).Cast<User>();

                    while(selectedUsersIE.Count() > 0)
                    {
                        db.Users.Remove(selectedUsersIE.FirstOrDefault());
                    }
                    db.SaveChangesAsync();

                      SelectedUser = null;
                  }));
            }
        }


        public RelayCommand AddCommand
        {
            get
            {
            return addCommand ??
                (addCommand = new RelayCommand( (newUserForm) =>
                {

                    User user = newUserForm as User;

                    db.Users.Add( new User
                    {
                        Name = user.Name,
                        SurName = user.SurName,
                        Decription = user.Decription,
                        SubcriedTo = user.SubcriedTo,
                        CreatedOn = DateTime.Now
                    });
                    db.SaveChanges();
                }));
            }
        }


        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                    (editCommand = new RelayCommand((selectedItem) =>
                    {
                        var modifiedUser = selectedItem as User;
                        db.Entry(modifiedUser).State = EntityState.Modified;
                        db.SaveChanges();
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
