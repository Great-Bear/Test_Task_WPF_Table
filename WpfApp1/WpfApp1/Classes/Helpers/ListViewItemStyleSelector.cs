using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Test_Task_WPF_Table.Classes;

namespace WpfApp1.ClassesConverter
{
    public class ListViewItemStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item,
         DependencyObject container)
        {
            Style st = new Style();
            st.TargetType = typeof(ListViewItem);
            Setter backGroundSetter = new Setter();
            Setter height = new Setter();

            backGroundSetter.Property = ListViewItem.BackgroundProperty;
            height.Property = ListViewItem.HeightProperty;

            ListView listView = ItemsControl.ItemsControlFromItemContainer(container) as ListView ;

            var user = item as User;

            double heightValue = 30;
            height.Value = heightValue;
            if (user.SubcriedTo < DateTime.Now)
            {
                backGroundSetter.Value = Brushes.Red;
            }
            else
            {
                 backGroundSetter.Value = Brushes.AntiqueWhite;
            }
            st.Setters.Add(backGroundSetter);
            st.Setters.Add(height);
            return st;
        }
    }
}
