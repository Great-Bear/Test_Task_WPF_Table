using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;
using Test_Task_WPF_Table.Classes;
using WpfApp1.Classes.DbContext.Models;
using WpfApp1.ClassesConverter;

namespace WpfApp1.Classes.ViewModels
{
    public class AddUserViewModel : BasicViewModel, INotifyPropertyChanged
    {
        public string Title { get; set; }
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
        private string _feedBackMessage ;
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


        public AddUserViewModel()
        {
            NewUser = new UserValidate();
            Title = "Add User";
        }

        RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand((obj) =>
                    {
                        FeedBackMessage = "Added Successfully";
                        CanShowMessage = true;
                        var timer = new DispatcherTimer();
                        timer.Tick += new EventHandler(timer_Tick);
                        timer.Interval = new TimeSpan(0, 0, 1);
                        timer.Start();

                        NewUser.CreatedOn = DateTime.Now;
                        db.Users.Add(NewUser);
                        db.SaveChanges();
                        ClearUser();
                    }));
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            CanShowMessage = false;
            ((DispatcherTimer)sender).Stop();
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
