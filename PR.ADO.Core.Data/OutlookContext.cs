using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;
using System.Collections;
using PR.Recovery.Ado.Data;
using PR.Ado.Core.Domain;

namespace PR.Recovery.Ado.Data
{


    public class OutlookContext
    {
        public List<CalendarEvent> CalendarEvents { get; set; }

        public async Task<List<CalendarEvent>> GetAllCalendarItems()
        {
            CalendarEvents = new List<CalendarEvent>();

            var outlookApp = new Application();
            var mapiNamespace = outlookApp.GetNamespace("MAPI");
            var CalendarFolder = mapiNamespace.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);

            var outlookCalendarItems = CalendarFolder.Items;
            outlookCalendarItems.IncludeRecurrences = false;
            
            try
            {
                foreach (AppointmentItem calEvent in outlookCalendarItems)
                {
                    if (calEvent.Start > DateTime.Now.AddDays(-7) && calEvent.End < DateTime.Now.AddDays(7))
                    {
                        CalendarEvents.Add(new CalendarEvent
                        {
                            Title = calEvent.Subject,
                            EndDate = calEvent.End,
                            StartDate = calEvent.Start
                        });
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return CalendarEvents;
        }
    }
}


//if (item.IsRecurring)
//{
//    RecurrencePattern rp = item.GetRecurrencePattern();
//    DateTime first = FirstDayOfWeek(DateTime.Now); // DateTime(2019, 7, 14, item.Start.Hour, item.Start.Minute, 0);
//    DateTime last = LastDayOfWeek(DateTime.Now);
//    AppointmentItem recur = null;

//    for (DateTime cur = first; cur <= last; cur = cur.AddDays(1))
//    {
//        try
//        {
//            recur = rp.GetOccurrence(cur);
//            Console.WriteLine(recur.Subject + " -> " + cur.ToLongDateString() + recur);
//        }
//        catch (System.Exception ex)
//        {
//            Console.WriteLine(ex.Message);
//        }
//    }
//}
//else
//{
//    Console.WriteLine(item.Subject);
//    var eventLength = item.Start - item.End;
//    Console.WriteLine($"    {eventLength}: {item.Start.ToString("MM/dd/yyyy hh:mm")} to {item.End.ToString("MM/dd/yyyy hh:mm")}");
//}