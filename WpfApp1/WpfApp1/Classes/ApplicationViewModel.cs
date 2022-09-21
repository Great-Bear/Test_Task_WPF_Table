using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Test_Task_WPF_Table.Classes;

namespace WpfApp1.Classes
{
    public class ApplicationViewModel
    {
        ApplicationContext db = new ApplicationContext();
        RelayCommand? addCommand;
        RelayCommand? editCommand;
        RelayCommand? deleteCommand;
        public ObservableCollection<User> Users { get; set; }

        public User NewUser { get; set; } = new User();
        public User SelectedUser { get; set; } = new User();

        public ApplicationViewModel()
        {
            db.Database.EnsureCreated();
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
                      var selectedUsers = selectedItems as ObservableCollection<User>  ;

                      /*  while (selectedUsers.Count > 0)
                        {
                            var objectForDele = (User)selectedUsers[0]!;
                            db.Users.Remove(objectForDele);
                            db.Users.RemoveRange(selectedUsers);
                        }
                        */
                      db.Users.RemoveRange(selectedUsers);
                      db.SaveChangesAsync();                  
                  }));
            }
        }


        public RelayCommand AddCommand
        {
            get
            {
           
            return addCommand ??
                (addCommand = new RelayCommand( (newUser) =>
                {
                    User user = newUser as User;
                    user.CreatedOn = DateTime.Now;
                    user.SubcriedTo = user.CreatedOn.AddDays(1);
                    db.Users.Add(user);
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
                    }));
            }
        }


    }
}
