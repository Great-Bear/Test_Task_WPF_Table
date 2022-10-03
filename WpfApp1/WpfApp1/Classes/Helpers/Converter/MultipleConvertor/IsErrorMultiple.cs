using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp1.Classes.Helpers.Converter.MultipleConvertor
{
    internal class IsErrorMultiple : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var answer = true;

            foreach (bool item in values)
            {
                if (item)
                {
                    answer = false;
                    break;
                }
            }

            return answer;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }  
    }
}
