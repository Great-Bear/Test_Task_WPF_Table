using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task_WPF_Table.Classes
{
    public class User : IDataErrorInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Decription { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime SubcriedTo { get; set; }

        [NotMapped]

        public string Error => throw new NotImplementedException();
        [NotMapped]

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                /*
                switch (columnName)
                {
                    case "Name":
                        if (Name.Length > 20)
                        {
                            error = "Имя должно быть меньше 20 символов";
                        }
                        break;
                    case "SurName":
                        //Обработка ошибок для свойства Name
                        break;
                    case "Decription":
                        //Обработка ошибок для свойства Position
                        break;
                }*/
                return error;
            }
        }


        public User()
        {
            SubcriedTo = DateTime.Now.AddDays(1);
        }
    }
}
