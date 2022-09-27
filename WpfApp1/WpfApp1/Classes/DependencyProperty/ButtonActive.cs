using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Test_Task_WPF_Table.Classes;


namespace WpfApp1.Classes.DependencyProperty
{
    public class CustomButton : Button
    {
        public static readonly System.Windows.DependencyProperty dependencyProperty =
             System.Windows.DependencyProperty.Register("SetBackGroundRed", typeof(bool), typeof(CustomButton),
                 new PropertyMetadata(false, new PropertyChangedCallback(ChangeBackGround)));
        public bool SetBackGroundRed
        {
            get => (bool)GetValue(dependencyProperty);
            set => SetValue(dependencyProperty, value);
        }

        private static void ChangeBackGround(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
                (d as CustomButton).Background = Brushes.Red;
        }



        public static readonly System.Windows.DependencyProperty dependencyPropertyAbility =
             System.Windows.DependencyProperty.Register("SetAbility", typeof(User), typeof(CustomButton),
                 new PropertyMetadata(null, new PropertyChangedCallback(ChangeAbility)));
        public User SetAbility
        {
            get => (User)GetValue(dependencyPropertyAbility);
            set => SetValue(dependencyPropertyAbility, value);
        }

        private static void ChangeAbility(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           //MessageBox.Show(d.GetType().ToString());

            if ( ((User)e.NewValue) == null)
            {
                (d as Button).IsEnabled = false;
            }
            else
            {
                (d as Button).IsEnabled = true;
            }

        }

        public CustomButton()
        {
          IsEnabled = false;
        }

    }
}
