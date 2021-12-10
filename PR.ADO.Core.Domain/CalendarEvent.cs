using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.Ado.Core.Domain
{
    public class CalendarEvent
    {
        private string _title = string.Empty;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;

                if (value.StartsWith("#"))
                {
                    var workItemId = value.Split(' ').First().Replace("#", "");
                    if (int.TryParse(workItemId, out int wiIdInteger))
                    {
                        WorkItemId = wiIdInteger;
                    }
                }
            }
        }

        public int WorkItemId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan Duration()
        {
            return EndDate - StartDate;
        }
    }

}
