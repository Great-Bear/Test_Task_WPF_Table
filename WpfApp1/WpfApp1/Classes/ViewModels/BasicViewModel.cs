using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Test_Task_WPF_Table.Classes;

namespace WpfApp1.Classes.ViewModels
{
    public class BasicViewModel : INotifyPropertyChanged
    {
        static ApplicationContext staticInstanceDb;
        public ApplicationContext db;

        public BasicViewModel()
        {
            db = new ApplicationContext();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
