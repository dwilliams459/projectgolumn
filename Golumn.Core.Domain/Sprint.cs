using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golumn.Core.Domain
{
    public class Sprint
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Project {get; set; }
        public string IsCurrent { get; set; }
    }
}
