using Golumn.Core.Data;
using Microsoft.Extensions.Configuration;

namespace Golumn.Core.Service
{
    public class BaseService
    {
        protected TimeEventsContext _context { get; set; }
        protected string _csvOutfilePath { get; set; }
        protected IConfiguration _config { get; set; }

        public BaseService()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            var csvOutfilePath = _config.GetValue<string>("reportFilename");

            _context = new TimeEventsContext();
        }
    }
}