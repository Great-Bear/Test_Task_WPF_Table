using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using WpfApp1.Classes.DbContext.Models;
using WpfApp1.ClassesConverter;

namespace WpfApp1.Classes.Helpers.DependencyProperty
{
    public class UserForm : Button, INotifyPropertyChanged
    {
        public string Title { get; set; }

        public static readonly System.Windows.DependencyProperty dependencyFeedBackMessage =
          System.Windows.DependencyProperty.Register("FeedBackMessage", typeof(string), typeof(UserForm),
              new PropertyMetadata(null, new PropertyChangedCallback(ChangeFeedBackMessage)));
        public string FeedBackMessage
        {
            get => (string)GetValue(dependencyFeedBackMessage);
            set { SetValue(dependencyFeedBackMessage, value); }
        }
        private static void ChangeFeedBackMessage(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as UserForm).FeedBackMessage = (string)e.NewValue;
        }


        public static readonly System.Windows.DependencyProperty dependencyCanShowMessage =
         System.Windows.DependencyProperty.Register("CanShowMessage", typeof(bool), typeof(UserForm),
             new PropertyMetadata(false, new PropertyChangedCallback(ChangeCanShowMessage)));
        public bool CanShowMessage
        {
            get => (bool)GetValue(dependencyCanShowMessage);
            set { SetValue(dependencyCanShowMessage, value); }
        }
        private static void ChangeCanShowMessage(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as UserForm).CanShowMessage = (bool)e.NewValue;
        }



        public static readonly System.Windows.DependencyProperty dependencyRightButtonCommand =
          System.Windows.DependencyProperty.Register("RightButtonCommand", typeof(RelayCommand), typeof(UserForm),
              new PropertyMetadata(null, new PropertyChangedCallback(ChangeRightCommand)));
        public RelayCommand RightButtonCommand
        {
            get => (RelayCommand)GetValue(dependencyRightButtonCommand);
            set { SetValue(dependencyRightButtonCommand, value); }
        }

        private static void ChangeRightCommand(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as UserForm).RightButtonCommand = (RelayCommand)e.NewValue;
        }



        public static readonly System.Windows.DependencyProperty dependencyLeftButtonCommand =
          System.Windows.DependencyProperty.Register("LeftButtonCommand", typeof(RelayCommand), typeof(UserForm),
              new PropertyMetadata(null, new PropertyChangedCallback(ChangeLeftButtonCommand)));
        public RelayCommand LeftButtonCommand
        {
            get => (RelayCommand)GetValue(dependencyLeftButtonCommand);
            set { SetValue(dependencyLeftButtonCommand, value); }
        }

        private static void ChangeLeftButtonCommand(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as UserForm).LeftButtonCommand = (RelayCommand)e.NewValue;
        }



        public static readonly System.Windows.DependencyProperty dependencyUser =
         System.Windows.DependencyProperty.Register("User", typeof(UserValidate), typeof(UserForm),
             new PropertyMetadata(null, new PropertyChangedCallback(ChangeUser)));
        public UserValidate User
        {
            get => (UserValidate)GetValue(dependencyUser);
            set { SetValue(dependencyUser, value); }
        }
        private static void ChangeUser(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           // (d as UserForm).User = (UserValidate)e.NewValue;

        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
