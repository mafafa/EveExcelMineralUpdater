using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EveExcelMineralUpdater.Views.Converters
{
    public class StringToUIntListConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            String controlString = value as String;
            Regex regex = new Regex(@"""[^""\r\n]*""|'[^'\r\n]*'|[^,\r\n]*");            
            ICollection<uint> values = new List<uint>();

            if ((controlString != null) && (regex.Match(controlString).Success))
            {
                Match regexMatch = regex.Match(controlString);

                if (regexMatch.Success)
                {
                    while (regexMatch.Success)
                    {
                        values.Add(uint.Parse(controlString));
                        regexMatch = regexMatch.NextMatch();
                    }                    
                }
            }

            return values;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ()
            {
                
            }
            else
            {
                
            }
        }
    }
}
