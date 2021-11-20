using Golumn.Core.Data;

namespace Golumn.Core.Service
{
    public class BaseService
    {
        protected TimeEventsContext context { get; set; }

        public BaseService()
        {
            context = new TimeEventsContext();
        }
    }
}