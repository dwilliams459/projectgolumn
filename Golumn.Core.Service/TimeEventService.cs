using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Golumn.Core.Data;
using Golumn.Core.Domain;

namespace Golumn.Core.Service
{
    public class TimeEventService : BaseService
    {
        public TimeEventsContext _eventContext { get; set; }

        public TimeEventService() : base()
        {
            _eventContext = new TimeEventsContext();
        }
        
        public async Task AddEvent(TimeEvent timeEvent)
        {
            _eventContext.TimeEvents.Add(timeEvent);
            await _eventContext.SaveChangesAsync();
        }

        public async Task AddEvent(string length, string description, string userStoryid, string userId)
        {
            var newEvent = new TimeEvent
            {
                EventDate = DateTime.Now,
                UserId = userId,
                Description = description,
            };

            if (int.TryParse(userStoryid, out int userStory))
            {
                newEvent.UserStory = userStory;
            }
            if (decimal.TryParse(length, out decimal eventHours))
            {
                newEvent.Length = eventHours;
            }

            await AddEvent(newEvent);
        }

    }
}
