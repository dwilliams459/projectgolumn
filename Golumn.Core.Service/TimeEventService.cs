using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Golumn.Core.Data;
using Golumn.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using PR.Ado.Core.Service;

namespace Golumn.Core.Service
{
    public class TimeEventService : BaseService
    {
        public TimeEventsContext _eventContext { get; set; }

        public TimeEventService() : base()
        {
            _eventContext = new TimeEventsContext();
        }

        public async Task AddEvent(TimeEvent timeEvent)
        {
            _eventContext.TimeEvents.Add(timeEvent);
            await _eventContext.SaveChangesAsync();
        }

        public async Task AddEvent(string length, string description, string userStoryid, string userId)
        {
            var newEvent = new TimeEvent
            {
                EventDate = DateTime.Now,
                UserId = userId,
                Description = description,
            };

            if (int.TryParse(userStoryid, out int userStory))
            {
                newEvent.UserStory = userStory;
            }
            if (decimal.TryParse(length, out decimal eventHours))
            {
                newEvent.Length = eventHours;
            }

            await AddEvent(newEvent);
        }

        public async Task<int> PopulateAdoEvents(int? startWorkItemId = 110000, int? endWorkItemId = 110005)
        {
            var wiService = new WorkItemService();
            var workItems = await wiService.GetAllCurrentWorkItems(startWorkItemId.Value, endWorkItemId.Value);

            var adoWorkItems = new List<AdoWorkItem>();

            var dbWorkItems = await _eventContext.AdoWorkItems.Where(wi => wi.WorkItemId >= startWorkItemId && wi.WorkItemId <= endWorkItemId)
                                                        .Select(wi => wi.WorkItemId).ToListAsync();

            _eventContext.AdoWorkItems.RemoveRange(_eventContext.AdoWorkItems.Where(wi => dbWorkItems.Contains(wi.WorkItemId)));
            var removed = await _eventContext.SaveChangesAsync();

            foreach (var wi in workItems)
            {
                var adoWorkItem = MapWorkItem(wi);
                if (adoWorkItems != null)
                {
                    _eventContext.AdoWorkItems.Add(adoWorkItem);
                }
            }            

            return await _eventContext.SaveChangesAsync();
        }

        public static AdoWorkItem MapWorkItem(WorkItem workItem)
        {
            WorkItemService.Field(workItem, "System.Title");

            // Fields: "System.Id", "System.Title", "System.WorkItemType", "System.AssignedTo", "System.State", "Custom.Contract", "Custom.Workstream", 
            //         "System.IterationPath", "System.Parent", "System.ChangedDate"
            if (workItem.Id == null)
            {
                Console.WriteLine("WorkItem id is null");
                return null;
            }

            try
            {
                var AdoWorkItem = new AdoWorkItem()
                {
                    WorkItemId = workItem.Id ?? 0,
                    Title = WorkItemService.Field(workItem, "System.Title"),
                    WorkItemType = WorkItemService.Field(workItem, "System.WorkItemType"),
                    AssignedTo = WorkItemService.Field(workItem, "System.AssignedTo"),
                    State = WorkItemService.Field(workItem, "System.State"),
                    Contract = WorkItemService.Field(workItem, "Custom.Contract"),
                    Workstream = WorkItemService.Field(workItem, "Custom.Workstream"),
                    ItterationPath = WorkItemService.Field(workItem, "System.IterationPath"),
                    ParentID = WorkItemService.FieldInt(workItem, "System.Parent"),
                    LastUpdated = WorkItemService.FieldDateTime(workItem, "System.ChangedDate"),
                    CreatedDate = DateTime.Now
                };

                return AdoWorkItem;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
