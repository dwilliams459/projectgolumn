using System;
using System.ComponentModel.DataAnnotations;

namespace Golumn.Core.Domain
{
    public class TimeEvent
    {
        [Key]
        public int? Id { get; set; }
        public DateTime? EventDate { get; set; }
        public string UserStory { get; set; }
        public decimal? Length { get; set; }
        public string Description { get; set; }

        public string EventDateFormated()
        {
            if (EventDate == null)
            {
                return string.Empty;
            }

            return EventDate == null ? null : EventDate.Value.ToString("MM/dd/yyyy");
        }
    }
}