﻿namespace ShiftSchedulerApi.Models
{
    public class ShiftUser
    {
        public long ShiftId { get; set; }
        public Shift Shift { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
