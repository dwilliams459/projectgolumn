using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using PR.Ado.Core.Data;
using PR.Ado.Core.Domain;

namespace PR.Ado.Core.Service
{
    public class WorkItemService
    {
        private readonly TfsApiContext ctx;

        // Get Team IDs for WIQL queries
        // https://dev.azure.com/PRDR/_apis/teams?api-version=6.0-preview

        public WorkItemService()
        {
            ctx = new TfsApiContext();
        }

        public async Task<List<WorkItem>> GetWorkItemsAsync(Options options) //string searchTerm = null, string type = "")
        {
            try
            {
                var fields = new[] { "System.Id", "System.Title", "System.WorkItemType", "System.AssignedTo", "System.State", "Custom.Contract", "Custom.Workstream", "System.IterationPath", "System.Parent" };
                bool filterIterationByString;
                Wiql wiql;
                // create a wiql object and build our query
                wiql = new Wiql()
                {
                    Query = BuildQuery(options, fields, out filterIterationByString)
                };

                var workItems = await ctx.GetAdoTfsWorkItemResponse(wiql, fields).ConfigureAwait(false);

                workItems = FilterIterationsByString(options, filterIterationByString, workItems);

                return workItems;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<WorkItem>();
            }
        }

        private List<WorkItem> FilterIterationsByString(Options options, bool filterIterationByString, List<WorkItem> workItems)
        {
            if (filterIterationByString)
            {
                workItems = workItems.Where(wi => Field(wi, "System.IterationPath").Contains(options.Iteration)).ToList();
            }

            return workItems;
        }

        private string BuildQuery(Options options, string[] fields, out bool filterIterationByString)
        {
            var fieldString = String.Join(",", fields);

            var query = $"SELECT {fieldString} "
                        + " FROM workitems "
                        + " WHERE[System.TeamProject] = 'PR' AND [System.WorkItemType] <> 'Task' "
                        + " AND NOT[System.State] IN('Cancelled', 'In Refinement') ";


            List<string> validIterations = new List<string> { "-5", "-4", "-3", "-2", "-1", "0", "+1", "+2", "+3", "+4", "+5" };
            filterIterationByString = false;
            if (string.IsNullOrWhiteSpace(options.Iteration))
            {
                query = query + " AND ( ";
                query = query + "    [System.IterationPath] = @currentIteration('[PR]\\SWAT <id:a4ce66e4-33d8-425d-ba93-132fe7047da0>') - 1 ";
                query = query + "    OR [System.IterationPath] = @currentIteration('[PR]\\SWAT <id:a4ce66e4-33d8-425d-ba93-132fe7047da0>') ";
                query = query + "    OR [System.IterationPath] = @currentIteration('[PR]\\SWAT <id:a4ce66e4-33d8-425d-ba93-132fe7047da0>') + 1 ";
                query = query + " ) ";
            }
            else if (options.Iteration != null && validIterations.Contains(options.Iteration))  // [PR]\\SWAT <id:a4ce66e4-33d8-425d-ba93-132fe7047da0> = PR\SWAT iteration
            {
                if (options.Iteration == "0")
                    query = query + $" AND [System.IterationPath] = @currentIteration('[PR]\\SWAT <id:a4ce66e4-33d8-425d-ba93-132fe7047da0>') ";
                else
                    query = query + $" AND [System.IterationPath] = @currentIteration('[PR]\\SWAT <id:a4ce66e4-33d8-425d-ba93-132fe7047da0>') {options.Iteration} ";
            }
            else
            {
                filterIterationByString = true;
            }

            if (options.All)
            {
                query += $" AND EVER [System.AssignedTo] = '{options.CgiUsername}' "; //David Williams <david.williams1@cgi.com>' ";
            }
            else if (!string.IsNullOrWhiteSpace(options.OneUserStory))
            {
                query += $" AND [SYSTEM.Id] = {options.OneUserStory} ";
            }
            else
            {
                query += $" AND [System.AssignedTo] = '{options.CgiUsername}' "; //David Williams <david.williams1@cgi.com>' ";
            }

            if (options.Bugs)
            {
                query = query + "AND [System.WorkItemType] CONTAINS 'Bug' ";
            }

            if (options.UserStories)
            {
                query = query + "AND [System.WorkItemType] CONTAINS 'User Story' ";
            }

            if (!String.IsNullOrEmpty(options.SearchText))
            {
                query = query + $"AND [System.Title] CONTAINS '{options.SearchText}' ";
            }

            query = query + " ORDER BY [System.Id]";

            return query;
        }

        public string GetParentWorkItemDescription(int? parentId = null)
        {
            try
            {
                if (parentId == null)
                {
                    return string.Empty;
                }

                var fields = new[] { "System.Id", "System.Title", "System.WorkItemType", "System.AssignedTo", "System.Parent" };
                var fieldString = String.Join(", ", fields);

                var query = $"SELECT {fieldString} FROM workitems WHERE[System.Id] = {parentId} ";

                // create a wiql object and build our query
                var wiql = new Wiql()
                {
                    Query = query
                };

                var workItems = ctx.GetAdoTfsWorkItemResponse(wiql, fields).Result;

                if (workItems == null || workItems.Count() == 0)
                {
                    return string.Empty;
                }
                else
                {
                    var wiTitle = Field(workItems.FirstOrDefault(), "System.Title");
                    return wiTitle;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }

        public string GetParentWorkItemParentDescription(string parentId)
        {

            var fields = new[] { "System.Id", "System.Title", "System.WorkItemType", "System.AssignedTo", "System.Parent" };
            var fieldString = String.Join(",", fields);

            var query = $"SELECT {fieldString} FROM WorkItems ";
            query = query + @"
                 WHERE (
                         [Source].[System.TeamProject] = 'PR'
                         AND [Source].[System.WorkItemType] <> 'Task'
                         AND [Source].[System.State] <> ''
                         AND [Source].[System.AssignedTo] = 'david.williams@recovery.pr'
                       )
                       AND ( [System.Links.LinkType] = 'System.LinkTypes.Hierarchy-Reverse' )
                       AND ( [Target].[System.TeamProject] = 'PR' AND [Target].[System.WorkItemType] <> '' )
                 MODE (MustContain) ";

            // create a wiql object and build our query
            var wiql = new Wiql()
            {
                Query = query
            };

            try
            {
                var workItems = ctx.GetAdoTfsWorkItemResponse(wiql, fields).Result;

                if (workItems == null || workItems.Count() == 0)
                {
                    return string.Empty;
                }
                else
                {
                    var wiTitle = Field(workItems.FirstOrDefault(), "System.Title");
                    return wiTitle;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Get Parent Error: " + ex.Message);
                return string.Empty;
            }
        }

        public async Task<List<WorkItem>> GetWorkItemTasks(string workItem)
        {
            var fields = new[] { "System.Id", "System.Title", "System.WorkItemType", "System.AssignedTo", "System.State", "Custom.Contract", "Custom.Workstream", "System.IterationPath", "System.Parent" };
            var fieldString = String.Join(",", fields);
            return null;

            // var query = $"SELECT {fieldString} "
            //             + " FROM workitems "
            //             + $" [System.ID] == '{workItem}' "
            //             WHERE[System.TeamProject] = 'PR' AND [System.WorkItemType] = 'Task' "
            //             + " AND NOT[System.State] IN('Closed', 'In Build Preparation', 'Cancelled', 'In Refinement') "
            //             + $" AND [System.ChangedDate] > '{DateTime.Now.AddDays(-14).ToString("yyyy-MM-dd")}' ";

            //  AND ([System.Links.LinkType] = 'Child')
            // http://venkateswarlu.net/dot-net/wiql-query-to-get-all-child-work-items-in-c-sharp
        }

        public static string Field(Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem workItem, string fieldName)
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
