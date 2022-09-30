using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Task_WPF_Table.Classes;

namespace WpfApp1.Classes.DbContext.Models
{
    public class UserValidate : User,  IDataErrorInfo
    {
        public string Error => throw new NotImplementedException();


        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;

                switch (columnName)
                {
                    case "Name":
                        if (Name.Length > 2)
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
                }
                return error;
            }
        }
    }
}
