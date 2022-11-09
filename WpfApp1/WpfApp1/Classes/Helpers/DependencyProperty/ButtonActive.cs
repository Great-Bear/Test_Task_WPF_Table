using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Test_Task_WPF_Table.Classes;


namespace WpfApp1.ClassesConverter.DependencyProperty
{
    public class CustomButton : Button, INotifyPropertyChanged
    {
        public static readonly System.Windows.DependencyProperty dependencyPropertyAbility =
             System.Windows.DependencyProperty.Register("SetAbility", typeof(bool), typeof(CustomButton),
                 new PropertyMetadata(false, new PropertyChangedCallback(ChangeAbility)));
        public bool SetAbility
        {
            get => (bool)GetValue(dependencyPropertyAbility);
            set { 
                SetValue(dependencyPropertyAbility, value);
                OnPropertyChanged();
            }
        }

        private static void ChangeAbility(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           (d as CustomButton).SetAbility = (bool)e.NewValue;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
