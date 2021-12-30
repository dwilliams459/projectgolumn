
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Golumn.Core.Domain
{
    [Table("AT_AdoWorkItems")]
    public class AdoWorkItem
    {
        [Key]
        public int WorkItemId { get; set; }
        public string Title { get; set; }
        public string WorkItemType { get; set; }
        public string AssignedTo { get; set; }
        public string State { get; set; }
        public string Contract { get; set; }
        public string Workstream { get; set; }
        public string ItterationPath { get; set; }
        public int? ParentID { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        [NotMapped] 
        public AdoWorkItem Parent { get; set;}

        public string CRName()
        {
            if (Parent != null && Parent.Title.StartsWith("CR"))
            {
                var words = Parent.Title.Split(' ');
                return words[0];
            }
            return "NA";
        }
    }
}