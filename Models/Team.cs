using System.Collections.Generic;

namespace ShiftSchedulerApi.Models
{
    public class Team
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long AdminUserId { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Shift> Shifts { get; set; }

    }
}
