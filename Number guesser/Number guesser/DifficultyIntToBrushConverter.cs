using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Number_guesser
{
    public class DifficultyIntToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((int)value)
            {
                case 0:
                    return "#F2E70C";
                case 1:
                    return "#0BE51C";
                case 2:
                    return "#CF9300";
                case 3:
                    return "#CF1900";
                case 4:
                    return "#610C00";

                default:
                    return "#FFFFFF";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
