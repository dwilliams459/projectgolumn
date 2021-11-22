using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golumn.Core.LogFile
{
    public class FileLog
    {
        public static void LogEvent(string description, string userStoryId = "", string length = "")
        {

            var dateNow = DateTime.Now.ToString("MM/dd/yy");

            var logfile = ConfigurationManager.AppSettings["filename"]; //  "c:/golumn/worklog.txt";

            //File.AppendAllText(logfile, $"{dateNow}, {text}{System.Environment.NewLine}");
            var text = $"{System.Environment.NewLine}{{ 'Time': '{dateNow}', 'UserStory': '{userStoryId}', 'Length': '{length}', 'Event': '{description}' }} {System.Environment.NewLine}";

            // Format
            dynamic parsedJson = JsonConvert.DeserializeObject(text);
            var jsonText = JsonConvert.SerializeObject(parsedJson); //, Formatting.Indented);

            bool newFile = false;
            if (!File.Exists(logfile))
            {
                var path = Path.GetDirectoryName(logfile);
                System.IO.Directory.CreateDirectory(path);
                newFile = true;
            }

            if (!newFile)
            {
                File.AppendAllText(logfile, $"{System.Environment.NewLine}");
            }

            File.AppendAllText(logfile, $"{jsonText},");
            Console.WriteLine($"Logged: {dateNow} {jsonText}");
        }

        public static void LogEventCSV(string description, string userStoryId = "", string length = "")
        {
            var dateNow = DateTime.Now.ToString("MM/dd/yy");

            var logfile = ConfigurationManager.AppSettings["filename"]; //  "c:/golumn/worklog.txt";

            var text = $"{dateNow}, {userStoryId}, {length}, {description}{System.Environment.NewLine}";

            if (!File.Exists(logfile))
            {
                var path = Path.GetDirectoryName(logfile);
                System.IO.Directory.CreateDirectory(path);
                System.IO.File.AppendAllText(logfile, $"Date,UserStory,Length,Description");
            }

            File.AppendAllText(logfile, text);
            Console.WriteLine($"Logged: {dateNow} text");
        }
    }
}
