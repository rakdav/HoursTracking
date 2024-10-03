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
    class ToNameSubjectConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            HoursTrackingContext db = new HoursTrackingContext();
            return db.Subjects.FirstOrDefault(p => p.IdSubject == (int)value)!.NameSubject!;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
