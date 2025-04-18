using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Finanzmanagementsystem.Converters
{
    public class VerfuegbarZuFarbeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal verfuegbar)
            {
                if (verfuegbar < 0)
                    return Brushes.Tomato;
                if (verfuegbar == 0)
                    return Brushes.Gold;
                if (verfuegbar < 100)
                    return Brushes.Yellow;

                return Brushes.LightGreen;
            }
            return Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
