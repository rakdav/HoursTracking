using HoursTracking.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HoursTracking.Converters
{
    class ToGroupNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            HoursTrackingContext db = new HoursTrackingContext();
            return db.Groups.FirstOrDefault(p => p.IdGroup == (int)value)!.NameGroup!;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
