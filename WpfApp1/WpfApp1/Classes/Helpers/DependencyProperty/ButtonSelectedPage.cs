using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Test_Task_WPF_Table.Classes;

namespace WpfApp1.Classes.Helpers.DependencyProperty
{
    public class ButtonSelectedPage : Button
    {
        public static readonly System.Windows.DependencyProperty dependencyIsSelected =
             System.Windows.DependencyProperty.Register("IsSelected", typeof(bool), typeof(ButtonSelectedPage),
                 new PropertyMetadata(false, new PropertyChangedCallback(ChangeAbility)));
        public bool IsSelected
        {
            get => (bool)GetValue(dependencyIsSelected);
            set => SetValue(dependencyIsSelected, value);
        }

        private static void ChangeAbility(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as ButtonSelectedPage).IsSelected = (bool)e.NewValue ;
        }
    }
}
