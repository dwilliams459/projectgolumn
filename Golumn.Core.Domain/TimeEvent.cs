using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace Golumn.Core.Domain
{
    public class TimeEvent
    {
        [Key]
        public int? Id { get; set; }
        public DateTime EventDate { get; set; }
        public int? UserStory { get; set; }
        public decimal? Length { get; set; }
        public string Description { get; set; }

        // Work Item Fields
        [JsonIgnore]
        public string Contract { get; set; }
        [JsonIgnore]
        public string Workstream { get; set; }
        [JsonIgnore]
        public string Parent { get; set; }
        [JsonIgnore]
        public string Name { get; set; }
        [JsonIgnore]
        public string ParentId { get; set; }

        // Other
        [JsonIgnore]
        public string UserId { get; set; }
        
        public string CRName()
        {
            if (Parent != null && Parent.StartsWith("CR"))
            {
                var words = Parent.Split(' ');
                return words[0];
            }
            return "NA";
        }

        public string EventDateFormated()
        {
            return EventDate.ToString("MM/dd/yyyy");
        }
    }
}