using PR.Ado.Core.Data;
using PR.Recovery.Ado.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;
using PR.Ado.Core.Domain;
using Golumn.Core.Service;

namespace PR.Recovery.Ado.Console
{
    class Program
    {
        private const string Username = "david.williams1@cgi.com";

        public static async Task Main(string[] args)
        {
            System.Console.WriteLine("ADO query");

            try
            {
                Options options = new Options();

                var result = Parser.Default.ParseArguments<Options>(args);
                result.WithParsed(o =>
                {
                    options = o;
                }).WithNotParsed(o =>
                {
                    Environment.Exit(1);
                });

                if (options.PullRequest)
                {
                    System.Console.WriteLine("PullRequests");
                    RunPullRequests(options);
                }
                else
                {
                    await ListWorkItems(options);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                System.Console.WriteLine(ex.StackTrace);
            }
        }

        private static async Task RunPullRequests(Options options)
        {
            var waitTime = 10000;
            do
            {
                await ListPullRequests(options);
                if (options.Repeat)
                {
                    Task.Delay(waitTime).Wait();
                }
            } while (options.Repeat);
        }

        private static async Task ListPullRequests(Options options)
        {
            try
            {
                var pullRequestService = new PullRequestService();
                //var pullRequests = await pullRequestService.GetActivePullRequests(5);
                var pullRequests = await pullRequestService.GetPullRequestsAssignedToMe("david.williams1@cgi.com", 600);

                System.Console.Clear();

                if (pullRequests.Count() > 0)
                {
                    System.Console.BackgroundColor = ConsoleColor.DarkRed;
                    System.Console.ForegroundColor = ConsoleColor.White;
                    System.Console.WriteLine($"\rTotal active pull requrests ready for review: {pullRequests.Count} ({DateTime.Now.ToString("HH:mm:ss")}) ");
                }
                else
                {
                    System.Console.WriteLine($"\rNo active pull requrests ready for review: ({DateTime.Now.ToString("HH:mm:ss")}) ");
                }

                System.Console.ResetColor();
                System.Console.ForegroundColor = ConsoleColor.Cyan;

                pullRequests.ForEach(pr =>
                {
                    System.Console.WriteLine("");
                    System.Console.WriteLine($"{pr.PullRequestId} {pr.Title}");
                    System.Console.WriteLine($"   Status: {pr.Status} (merge {pr.MergeStatus})");

                    System.Console.WriteLine($"   CreationDate: {pr.CreationDate.ToString("yyyy-MM-dd HH:mm")}");
                    System.Console.WriteLine($"   CreatedBy: {pr.CreatedBy.DisplayName}");
                    System.Console.WriteLine($"   URL: https://prdr.visualstudio.com/PR/_git/PRDR/pullrequest/{pr.PullRequestId}");
                    System.Console.WriteLine($"   Is Draft: {pr.IsDraft}");

                    var reviewerList = pr.Reviewers.Select(r => $"{r.DisplayName} Vote:{r.VoteName()}");
                    var reviewers = String.Join(", ", reviewerList);

                    System.Console.WriteLine($"   Reviewers: {reviewers}");

                    var myReview = pr.ReviewVote(Username);
                    if (myReview == null)
                    {
                        System.Console.WriteLine("   My Review: na");
                    }
                    else
                    {
                        var voteName = string.Empty;
                        if (myReview == 10) voteName = "pass";
                        if (myReview == -10) voteName = "fail";
                        if (myReview == 0) voteName = "none";
                        System.Console.WriteLine($"   My Review: {voteName}");
                    }
                });

                if (pullRequests.Count() > 0)
                {
                    System.Console.WriteLine("==============");
                    System.Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                System.Console.ResetColor();
            }
        }

        public static async Task ListWorkItems(Options options)
        {
            var workItemService = new WorkItemService();

            var workItems = await workItemService.GetWorkItems(options);

            // Loop though work items and write to console
            foreach (var wi in workItems)
            {
                // "System.WorkItemType", "System.AssignedTo", "System.State", "Custom.Contract", "Custom.Workstream", "System.Parent"
                var title = Field(wi, "System.Title");
                System.Console.WriteLine($"{wi.Id} ({Field(wi, "System.Title")})");
                System.Console.WriteLine($"    URL: https://prdr.visualstudio.com/PR/_workitems/edit/{wi.Id}");
                System.Console.WriteLine($"    Type: {Field(wi, "System.WorkItemType")}, Iteration: {Field(wi, "System.IterationPath")}");

                if (options.Parent)
                {
                    var parentTitle = await workItemService.GetParentWorkItemDescription(Field(wi, "System.Parent"));
                    System.Console.WriteLine($"    Parent: {parentTitle}");
                }
                
                System.Console.Write($"    State: ");
                System.Console.ForegroundColor = ConsoleColor.Cyan;
                System.Console.WriteLine(Field(wi, "System.State"));
                System.Console.ResetColor();

                System.Console.WriteLine($"    Contract:{Field(wi, "Custom.Contract")}, Workstream:{Field(wi, "Custom.Workstream")}");

                System.Console.WriteLine("---------------------------");
            }
        }

        private static string Field(Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem workItem, string fieldName)
        {
            var field = workItem.Fields.Where(f => f.Key == fieldName).FirstOrDefault();
            if (field.Value != null)
            {
                return field.Value.ToString();
            }
            return string.Empty;

        }

    }
}
