using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Test_Task_WPF_Table.Classes;


namespace WpfApp1.Classes.DependencyProperty
{
    public class ButtonActive : DependencyObject
    {
        public static readonly System.Windows.DependencyProperty IsSpinningProperty = System.Windows.DependencyProperty.Register(
         "IsSpinning", typeof(bool),
         typeof(Button)
         );
      
        public bool IsSpinning
        {
            get => (bool)GetValue(IsSpinningProperty);
            set => SetValue(IsSpinningProperty, value);
        }

    }
}
