using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task_WPF_Table.Classes
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime SubcriedTo { get; set; }
        public string Decription { get; set; }

        public User()
        {
            SubcriedTo = DateTime.Now.AddDays(1);
        }
    }
}
