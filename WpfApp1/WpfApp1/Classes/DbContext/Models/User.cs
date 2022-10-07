using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task_WPF_Table.Classes
{
    public class User : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _surName;
        public string SurName {
            get => _surName;
            set
            {
                _surName = value;
                OnPropertyChanged();
            }
        }

        private string _decription;
        public string Decription
        {
            get => _decription;
            set
            {
                _decription = value;
                OnPropertyChanged();
            }
        }

        private DateTime _createdOn;
        public DateTime CreatedOn
        {
            get => _createdOn;
            set
            {
                _createdOn = value;
                OnPropertyChanged();
            }
        }

        private DateTime _subcriedTo;
        public DateTime SubcriedTo
        {
            get => _subcriedTo;
            set
            {
                _subcriedTo = value;
                OnPropertyChanged();
            }
        }

        public User()
        {
            SubcriedTo = DateTime.Now.AddDays(1);
        }

        public User(User initItem)
        {
            Id = initItem.Id;
            Name = initItem.Name;
            SurName = initItem.SurName;
            Decription = initItem.Decription;
            CreatedOn = initItem.CreatedOn;
            SubcriedTo = initItem.SubcriedTo;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
