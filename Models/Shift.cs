using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftSchedulerApi.Models
{
    public class Shift
    {
        public long Id { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }
        public ICollection<User> Attendees { get; set; }
        
    }
}
