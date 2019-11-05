using System;
using System.Collections.Generic;
using System.Text;

namespace PAccountant2.Common
{
    public static class DateHelper
    {
        public static TimeSpan CreateTimeSpan(DateTime dateFrom, DateTime dateTo)
        {
            var timeSpan = dateTo - dateFrom;

            return timeSpan;
        }
    }
}
