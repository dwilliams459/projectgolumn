using Golumn.Core.Common;
using Golumn.Core.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Newtonsoft.Json;
using PR.Ado.Core.Domain;
using PR.Ado.Core.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golumn.Core.Service
{
    public class TimeReportService : BaseService
    {
        private IConfiguration _config;

        public TimeReportService()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();
        }
        public async Task<List<TimeEvent>> GetLogEvents()
        {
            var logFilePath = _config.GetValue<string>("logFilename");
            var logText = await File.ReadAllTextAsync(logFilePath);

            if (string.IsNullOrWhiteSpace(logText))
            {
                return new List<TimeEvent>();
            }

            logText = logText.Trim().TrimEnd(',');
            logText = $"[ {logText} ]";

            // Get Log Text Object
            var eventList = JsonConvert.DeserializeObject<List<TimeEvent>>(logText);
            return eventList; 
        }

        public async Task<bool> WriteTimeReportCSV(String csvText)
        {
            try
            {
                var logFilePath = _config.GetValue<string>("logFilename");
                var logText = await File.ReadAllTextAsync(logFilePath);

                if (string.IsNullOrWhiteSpace(logText))
                {
                    return true;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error building or writing time report: " + ex.Message);
                return false;
            }
        }

        public async Task<string> BuildCsvText(List<TimeEvent> eventList, string userName)
        {
            // Create directories if not exist

            // Build CSV Text
            var csvText = new StringBuilder();
            csvText.AppendLine($"User,Date,Contract,Workstream,Task,CR,Length,Description");

            // Write Body
            foreach (var te in eventList)
            {
                csvText.AppendLine($"{userName},{te.EventDateFormated()},{te.Contract},{te.Workstream},,{te.CRName()},{te.Length},{te.Id} ({te.Name}) {te.Description}");
            }

            // Return text
            return csvText.ToString();
        }

        public async Task WriteCsvToFile(string csvText)
        {
            var reportFilename = _config.GetValue<string>("reportFilename");

            var path = Path.GetDirectoryName(reportFilename);
            System.IO.Directory.CreateDirectory(path);

            // Delete if exists
            if (File.Exists(reportFilename))
            {
                File.Delete(reportFilename);
            }

            await File.AppendAllTextAsync(reportFilename, csvText);
        }

        public async Task<List<TimeEvent>> GetMergedEvents(Options options, DateTime? startDate = null, DateTime? endDate = null)
        {
            var workItemService = new WorkItemService();
            options.Parent = true;

            // Get Event list
            var eventList = await GetLogEvents();

            // Get Work Items
            var workItems = await workItemService.GetWorkItems(options);

            // Merge events together.
            var mergedEvents = (from ev in eventList
                          join wi in workItems
                          on ev.UserStory equals wi.Id
                          select new TimeEvent { 
                                UserId = options.CgiUsername, // "david.williams@recovery.pr",
                                EventDate = ev.EventDate,
                                Id = wi.Id,
                                Name = WorkItemService.Field(wi, "System.Title"),
                                Contract = WorkItemService.Field(wi, "Custom.Contract"),
                                Workstream = WorkItemService.Field(wi, "Custom.Workstream"),
                                ParentId = WorkItemService.Field(wi, "System.Parent"),
                                Description = ev.Description,
                                Length = ev.Length
                          })
                          .ToList();

            // Filter by start and end dates
            if (startDate != null)
            {
                mergedEvents = mergedEvents.Where(ev => ev.EventDate != null && ev.EventDate.Value > startDate).ToList();
            }

            if (endDate != null)
            {
                mergedEvents = mergedEvents.Where(ev => ev.EventDate != null && ev.EventDate.Value < endDate).ToList();
            }

            // Add Parent (and CR)
            if (options.Parent)
            {
                mergedEvents.ForEach(async me => {
                    var wiId = me.ParentId;
                    if (int.TryParse(wiId, out int wiIdInt))
                    {
                        var parentTitle = workItemService.GetParentWorkItemDescription(wiIdInt);
                        me.Parent = parentTitle;
                    }
                });
            }

            return mergedEvents;
        }
    }
}
 