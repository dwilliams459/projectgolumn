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
        public string DaysOfWeek { get; set; }
        public bool? Monday {  get; set; }
        public bool? Tuesday { get; set; }
        public bool? Wednesday { get; set; }
        public bool? Thursday { get; set; }
        public bool? Friday { get; set; }

    }
}
