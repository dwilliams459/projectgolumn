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
        public bool Repeat { get; set; }
        public string DaysOfWeek { get; set; }
    }
}
