using Golumn.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Golumn.Core.Data
{
    public class TimeEventsContext : DbContext
    {
        public DbSet<TimeEvent> TimeEvents { get; set; }

        public string DbPath { get; private set; }    

        public TimeEventsContext()
        {
            DbPath = "./data/TimeEvents.db";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}