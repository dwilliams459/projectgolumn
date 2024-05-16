using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golumn.Core.Domain
{
    public class Alert
    {
        public string Title { get; set; }
        public DateTime AlertDateTime { get; set; }
        public DateTime? AlertEndTime { get; set; }
        public bool Repeat { get; set; }
        public string DaysOfWeek()
        {
            var days = new StringBuilder();

            if (Monday == true) { days.Append("Mon, ");  }
            if (Tuesday == true) { days.Append("Tue, "); }
            if (Wednesday == true) { days.Append("Wend, "); }
            if (Thursday == true) { days.Append("Thur, "); }
            if (Friday == true) { days.Append("Fri, "); }

            return days.ToString().TrimEnd(' ').TrimEnd(',');
        }
        public bool? Monday {  get; set; }
        public bool? Tuesday { get; set; }
        public bool? Wednesday { get; set; }
        public bool? Thursday { get; set; }
        public bool? Friday { get; set; }



    }
}
