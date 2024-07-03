using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Golumn.Core.Domain
{
    public class DayScheduleDataset
    {
        public DayScheduleDataset()
        {
            // Add DayHour for every 1/2 hour of a single day
            for (double i = 0; i < (24); i += .5)
            {
                DayHours.Add(new DayScheduleHour
                {
                    HalfHour = i,
                    IsWorkDayHour = (i >= (8) && i <= (18))  // Is hour between 8am and 6pm
                });
            }
        }
        public List<DayScheduleHour> DayHours { get; set; }

        public void SetHalfHour(int halfHour)
        {
            foreach (var day in DayHours)
            {
                day.Selected = (day.HalfHour == halfHour);
            }
        }
    }

    public class DayScheduleHour
    {
        public DateTime HourTimeStart { get => DateTime.Today.AddHours(HalfHour); }
        public double HalfHour { get; set; }
        public bool Selected { get; set; }
        public bool IsWorkDayHour { get; set; }
    }
}
