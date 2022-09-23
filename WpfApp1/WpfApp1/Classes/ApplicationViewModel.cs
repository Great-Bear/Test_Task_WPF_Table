using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
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
                    

                 //    var q = selectedItems as IList<User>;

                //  var selectedUsers = q.Cast<User>().ToList();


             //   db.Users.RemoveRange(selectedUsers);
               //       db.SaveChangesAsync();                  
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
                    }));
            }
        }


    }
}
