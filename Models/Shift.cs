using System;
using System.Collections.Generic;

namespace ShiftSchedulerApi.Models
{
    public class Shift
    {
        public long Id { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }
        public ICollection<ShiftUser> Attendees { get; set; }
    }
}
