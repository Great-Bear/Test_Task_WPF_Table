using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Test_Task_WPF_Table.Classes;

namespace WpfApp1.Classes
{
    public class ListViewItemStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item,
         DependencyObject container)
        {
            Style st = new Style();
            st.TargetType = typeof(ListViewItem);
            Setter backGroundSetter = new Setter();
            backGroundSetter.Property = ListViewItem.BackgroundProperty;
            ListView listView =
                ItemsControl.ItemsControlFromItemContainer(container)
                  as ListView;
            int index =
                listView.ItemContainerGenerator.IndexFromContainer(container);

            var user = item as User;

            if (user.SubcriedTo < DateTime.Now)
            {
                backGroundSetter.Value = Brushes.Red;
            }
            else
            {
                backGroundSetter.Value = Brushes.Beige;
            }
            st.Setters.Add(backGroundSetter);
            return st;
        }
    }
}
