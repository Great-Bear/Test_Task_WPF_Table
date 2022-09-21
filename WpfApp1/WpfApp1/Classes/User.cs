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
        [NotMapped]
        public bool IsOverdue { get; set; }

        public User()
        {
            Name = string.Empty;
            SurName = string.Empty;
            Decription = string.Empty;
            CreatedOn = DateTime.Now;
            SubcriedTo = DateTime.Now.AddDays(1);
        }
    }
}
