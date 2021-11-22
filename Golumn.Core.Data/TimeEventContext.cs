using System.IO;
using Golumn.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Options;
using System;

namespace Golumn.Core.Data
{
    public class TimeEventsContext : DbContext
    {
        public DbSet<TimeEvent> TimeEvents { get; set; }

        private readonly string dBPath; 

        public TimeEventsContext()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();
 
            dBPath = config.GetConnectionString("PREventTracker");    
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(dBPath);
    }
}