using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShiftSchedulerApi.Models;

namespace ShiftSchedulerApi.Data
{
    public class ShiftSchedulerDbContext : DbContext
    {
        public ShiftSchedulerDbContext(DbContextOptions<ShiftSchedulerDbContext> options) : base(options)
        {

        }

            public DbSet<Shift> Shifts { get; set; }
            public DbSet<User> Users { get; set; }
    }
}
