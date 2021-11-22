using Golumn.Core.Common;
using Golumn.Core.Domain;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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
        public async Task<bool> WriteTimeReportCSV(DateTime? startDate = null, DateTime? endDate = null)
        {
            startDate = (startDate ?? DateTime.Now.FirstDayOfWeek());
            endDate = (endDate ?? DateTime.Now.LastDayOfWeek());

            try
            {
                var logFilePath = _config.GetValue<string>("logFilename");
                var logText = await File.ReadAllTextAsync(logFilePath);

                if (string.IsNullOrWhiteSpace(logText))
                {
                    return true;
                }

                logText = logText.Trim().TrimEnd(',');
                logText = $"[ {logText} ]";

                // Get Log Text Object
                var eventList = JsonConvert.DeserializeObject<List<TimeEvent>>(logText);

                // Add Work Item data

                // Build csv
                await BuildCsvFile(eventList);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error building or writing time report: " + ex.Message);
                return false;
            }
        }

        private async Task BuildCsvFile(List<TimeEvent> eventList)
        {
            var reportFilename = _config.GetValue<string>("reportFilename");

            // Create directories if not exist
            var path = Path.GetDirectoryName(reportFilename);
            System.IO.Directory.CreateDirectory(path);

            // Delete if exists
            if (File.Exists(reportFilename))
            {
                File.Delete(reportFilename);
            }

            // Build CSV Text
            var csvText = new StringBuilder();
            csvText.AppendLine($"Date,UserStory,Length,Description");

            // Write Body
            foreach (var te in eventList)
            {
                csvText.AppendLine($"{te.EventDateFormated()}, {te.UserStory}, {te.Length}, {te.Description} ");
            }

            // Write File
            await File.AppendAllTextAsync(reportFilename, csvText.ToString());
        }
    }
}
 