using Golumn.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Golumn.Core.Data
{
    public class TimeEventsContext : DbContext
    {
        public DbSet<TimeEvent> TimeEvents { get; set; }

        private readonly string dBPath; 

        public TimeEventsContext()
        {
            dBPath = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"F:\\Projects\\Sandbox\\AdoGlmTimeTracker\\Glm Timetracker Core\\Golumn.Core.Domain\\App_Data\\PRTimeEvents.mdf\";Integrated Security=True";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(dBPath);
    }
}