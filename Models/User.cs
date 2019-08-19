using System.Collections.Generic;

namespace ShiftSchedulerApi.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<ShiftUser> Shifts { get; set; }

    }
}
