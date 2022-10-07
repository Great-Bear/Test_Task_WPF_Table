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
                            if (Name.Length > 10)
                            {
                                error = "Name must be less than 10 symbol";
                            }
                            else if (Name.Length == 0)
                            {
                                error = "Name can`t be empty";
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
                            if (SurName.Length > 10)
                            {
                                error = "SurName must be less than 10 symbol";
                            }
                            else if (SurName.Length == 0)
                            {
                                error = "SurName can`t be empty";
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
                            if (Decription.Length > 10)
                            {
                                error = "Decription must be less than 10 symbol";
                            }
                            else if (Decription.Length == 0)
                            {
                                error = "Describe can`t be empty";
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

        public UserValidate(User baseItem) : base(baseItem)
        {

        }
        public UserValidate()
        {

        }
    }
}
