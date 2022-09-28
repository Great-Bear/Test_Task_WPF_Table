using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Test_Task_WPF_Table.Classes;
using WpfApp1.ClassesConverter;

namespace WpfApp1.Classes.ViewModels
{
    public class EditUserViewModel : BasicViewModel, INotifyPropertyChanged
    {
        private User _newUser;

        public User NewUser
        {
            get { return _newUser; }
            set
            {
                _newUser = value;
                OnPropertyChanged();
            }
        }

        RelayCommand? addCommand;

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

        public RelayCommand ClearUserCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand((obj) =>
                    {
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
