using PR.Ado.Core.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using Golumn.Core.Service;
using CommandLine.Text;
using PR.Ado.Core.Domain;
using PR.Ado.Core.Service;
using Golumn.Core.Domain;

namespace Golumn.Core.Console
{
    class Program
    {
        private const string Username = "david.williams1@cgi.com";

        public static async Task Main(string[] args)
        {
            try 
            {
                GlmOptions options = new GlmOptions();

                var result = Parser.Default.ParseArguments<GlmOptions>(args);
                result.WithParsed(o =>
                {
                    options = o;
                }).WithNotParsed(o =>
                { 
                    Environment.Exit(1);
                });

                if (options.Sync != null && options.Sync.Length > 0)
                {
                    var eventService = new TimeEventService();
                    System.Console.WriteLine($"Begining population of workitems from {options.FirstWorkItemId} to {options.LastWorkItem}");

                    var RunTime = System.DateTime.Now;
                    var updated = await eventService.PopulateAdoEvents(options.FirstWorkItemId, options.LastWorkItem);
                    var totalRunTime = DateTime.Now - RunTime;

                    System.Console.WriteLine($"Upadated {updated} work items in {totalRunTime.TotalSeconds} seconds");
                }                
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                {
                    var inner = ex.InnerException;
                    System.Console.WriteLine("Inner Exception: " + ex.InnerException);
                }
            }
        }
    }
}
