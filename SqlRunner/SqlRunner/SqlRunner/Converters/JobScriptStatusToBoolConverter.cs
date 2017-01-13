using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlRunner.Core;
using Xamarin.Forms;

namespace SqlRunner.Converters
{
    public class JobScriptStatusToBoolConverter : IValueConverter
    {
        public JobScriptStatus Status { get; set; } = JobScriptStatus.Queued;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is JobScriptStatus)
            {
                JobScriptStatus status = (JobScriptStatus)value;

                return status == Status;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
