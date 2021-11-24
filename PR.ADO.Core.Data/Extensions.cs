using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.Ado.Core.Data
{
    public static class DateExtensions
    {
        public static DateTime FirstDayOfWeek(this DateTime value) => value.AddDays(0 - value.DayOfWeek);
        public static DateTime LastDayOfWeek(this DateTime value) => FirstDayOfWeek(value).AddDays(6);

    }
}
