using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Test_Task_WPF_Table.Classes;
using WpfApp1.Classes.DbContext.Models;
using WpfApp1.ClassesConverter;

namespace WpfApp1.Classes.ViewModels
{
    public class EditUserViewModel : BasicViewModel, INotifyPropertyChanged
    {
        private UserValidate _newUser;

        public EditUserViewModel(User selectedUser)
        {
            NewUser = new UserValidate(selectedUser);
            Title = "Edit User";
        }

        public string Title { get; set; }

        public UserValidate NewUser
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
                        var timer = new DispatcherTimer();
                        FeedBackMessage = "User sucessfylly changed";
                        CanShowMessage = true;
                        timer.Tick += new EventHandler(timer_Tick);
                        timer.Interval = new TimeSpan(0, 0, 1);
                        timer.Start();

                        db.Users.Update(NewUser);
                        db.SaveChangesAsync();
                        ClearUser();
                    }));
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            CanShowMessage = false;
            ((DispatcherTimer)sender).Stop();
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
        private string _feedBackMessage;
        public string FeedBackMessage
        {
            get => _feedBackMessage;
            set
            {
                _feedBackMessage = value;
                OnPropertyChanged();
            }
        }

        private bool _canShowMessage;
        public bool CanShowMessage
        {
            get => _canShowMessage;
            set
            {
                _canShowMessage = value;
                OnPropertyChanged();
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
