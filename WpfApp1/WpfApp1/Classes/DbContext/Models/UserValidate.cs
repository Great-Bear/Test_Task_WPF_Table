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
        public string Error => string.Empty;

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;

                switch (columnName)
                {
                    case "Name":
                        if (Name != null)
                        {
                            if (Name.Length > 50)
                            {
                                error = "Имя должно быть меньше 2 символов";
                            }
                            else if (Name.Length == 0)
                            {
                                error = "Поле не может быть пустым";
                            }
                        }
                        else
                        {
                            error = " ";
                        }

                        break;
                    case "SurName":
                        if (SurName != null)
                        {
                            if (SurName.Length > 50)
                            {
                                error = "Фамилия должно быть меньше 2 символов";
                            }
                            else if (SurName.Length == 0)
                            {
                                error = "Поле не может быть пустым";
                            }
                        }
                        else
                        {
                            error = " ";
                        }
                        break;
                    case "Decription":
                        if (Decription != null) 
                        { 
                            if (Decription.Length > 100)
                            {
                                error = "Фамилия должно быть меньше 2 символов";
                            }
                            else if (Decription.Length == 0)
                            {
                                error = "Поле не может быть пустым";
                            }
                        }
                        else
                        {
                            error = " ";
                        }
                        break;
                }
                return error;
            }
        }
    }
}
