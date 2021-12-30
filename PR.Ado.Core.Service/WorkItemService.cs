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

        public async Task<List<WorkItem>> GetAllCurrentWorkItems(int startWorkItemId = 9000, int endWorkItemId = 10000)
        {
            try
            {
                var totalWorkItems = new List<WorkItem>();

                var fields = new[] { "System.Id", "System.Title", "System.WorkItemType", "System.AssignedTo", "System.State", "Custom.Contract", "Custom.Workstream", "System.IterationPath", "System.Parent" };
                var fieldString = String.Join(",", fields);

                var iterationSize = 5;
                for (int i = 0; i < 20 && (startWorkItemId + ((i * iterationSize))) <= endWorkItemId; i++)
                {
                    var query = new StringBuilder();

                    query.Append($"SELECT {fieldString}");
                    query.Append(" FROM workitems ");
                    query.Append(" WHERE [System.TeamProject] = 'PR' ");

                    var firstWorkItemId = (startWorkItemId + (i * iterationSize));
                    query.Append($" AND [System.ID] >= {firstWorkItemId} ");

                    var lastWorkItemId = Math.Min((startWorkItemId + ((i + 1) * iterationSize)), endWorkItemId + 1);
                    query.Append($" AND [System.ID] < {lastWorkItemId} ");

                    // create a wiql object and build our query
                    var workItemQuery = new Wiql()
                    {
                        Query = query.ToString()
                    };

                    var workItems = await ctx.GetAdoTfsWorkItemResponse(workItemQuery, fields).ConfigureAwait(false);

                    totalWorkItems.AddRange(workItems);
                }

                return totalWorkItems;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<WorkItem>();
            }
        }

        public async Task<List<WorkItem>> GetCsvWorkItemsAsync(Options options) //string searchTerm = null, string type = "")
        {
            try
            {
                var fields = new[] { "System.Id", "System.Title", "System.WorkItemType", "System.AssignedTo", "System.State", "Custom.Contract", "Custom.Workstream", "System.IterationPath", "System.Parent" };

                Wiql wiql;
                // create a wiql object and build our query
                wiql = new Wiql()
                {
                    Query = BuildCsvQuery(options, fields)
                };

                var workItems = await ctx.GetAdoTfsWorkItemResponse(wiql, fields).ConfigureAwait(false);

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

            var query = new StringBuilder();

            query.Append($"SELECT {fieldString}");
            query.Append(" FROM workitems ");
            query.Append(" WHERE [System.TeamProject] = 'PR' ");

            if (!string.IsNullOrWhiteSpace(options.OneUserStory))
            {
                filterIterationByString = false;
                query.Append($" AND [System.Id] = {options.OneUserStory} ");
                return query.ToString();
            }

            query.Append(" AND [System.WorkItemType] <> 'Task' ");
            query.Append(" AND NOT[System.State] IN('Cancelled', 'In Refinement') ");


            List<string> validIterations = new List<string> { "-5", "-4", "-3", "-2", "-1", "0", "+1", "+2", "+3", "+4", "+5" };
            filterIterationByString = false;
            if (string.IsNullOrWhiteSpace(options.Iteration))
            {
                query.Append(" AND ( ");
                query.Append("    [System.IterationPath] = @currentIteration('[PR]\\SWAT <id:a4ce66e4-33d8-425d-ba93-132fe7047da0>') - 1 ");
                query.Append("    OR [System.IterationPath] = @currentIteration('[PR]\\SWAT <id:a4ce66e4-33d8-425d-ba93-132fe7047da0>') ");
                query.Append("    OR [System.IterationPath] = @currentIteration('[PR]\\SWAT <id:a4ce66e4-33d8-425d-ba93-132fe7047da0>') + 1 ");
                query.Append(" ) ");
            }
            else if (options.Iteration != null && validIterations.Contains(options.Iteration))  // [PR]\\SWAT <id:a4ce66e4-33d8-425d-ba93-132fe7047da0> = PR\SWAT iteration
            {
                if (options.Iteration == "0")
                {
                    query.Append($" AND [System.IterationPath] = @currentIteration('[PR]\\SWAT <id:a4ce66e4-33d8-425d-ba93-132fe7047da0>') ");
                }
                else
                {
                    query.Append($" AND [System.IterationPath] = @currentIteration('[PR]\\SWAT <id:a4ce66e4-33d8-425d-ba93-132fe7047da0>') {options.Iteration} ");
                }
            }
            else
            {
                filterIterationByString = true;
            }


            if (options.All)
            {
                query.Append($" AND EVER [System.AssignedTo] = '{options.CgiUsername}' "); //David Williams <david.williams1@cgi.com>' ";
            }
            else
            {
                query.Append($" AND [System.AssignedTo] = '{options.CgiUsername}' "); //David Williams <david.williams1@cgi.com>' ";
            }

            if (options.Bugs)
            {
                query.Append("AND [System.WorkItemType] CONTAINS 'Bug' ");
            }

            if (options.UserStories)
            {
                query.Append("AND [System.WorkItemType] CONTAINS 'User Story' ");
            }

            if (!String.IsNullOrEmpty(options.SearchText))
            {
                query.Append($"AND [System.Title] CONTAINS '{options.SearchText}' ");
            }

            query.Append(" ORDER BY [System.Id]");

            return query.ToString();
        }
        private string BuildCsvQuery(Options options, string[] fields)
        {
            var fieldString = String.Join(",", fields);

            var query = new StringBuilder();

            query.Append($"SELECT {fieldString}");
            query.Append(" FROM workitems ");
            query.Append(" WHERE [System.TeamProject] = 'PR' ");

            query.Append(" AND [System.WorkItemType] <> 'Task' ");
            query.Append(" AND NOT[System.State] IN('Cancelled', 'In Refinement') ");
            query.Append($" AND EVER [System.AssignedTo] = '{options.CgiUsername}' "); //David Williams <david.williams1@cgi.com>' ";

            query.Append(" AND ( ");
            query.Append("    [System.IterationPath] = @currentIteration('[PR]\\SWAT <id:a4ce66e4-33d8-425d-ba93-132fe7047da0>') - 1 ");
            query.Append("    OR [System.IterationPath] = @currentIteration('[PR]\\SWAT <id:a4ce66e4-33d8-425d-ba93-132fe7047da0>') - 2  ");
            query.Append("    OR [System.IterationPath] = @currentIteration('[PR]\\SWAT <id:a4ce66e4-33d8-425d-ba93-132fe7047da0>') -3 ");
            query.Append("    OR [System.IterationPath] = @currentIteration('[PR]\\SWAT <id:a4ce66e4-33d8-425d-ba93-132fe7047da0>') -4 ");
            query.Append("    OR [System.IterationPath] = @currentIteration('[PR]\\SWAT <id:a4ce66e4-33d8-425d-ba93-132fe7047da0>') -5 ");
            query.Append("    OR [System.IterationPath] = @currentIteration('[PR]\\SWAT <id:a4ce66e4-33d8-425d-ba93-132fe7047da0>') ");
            query.Append("    OR [System.IterationPath] = @currentIteration('[PR]\\SWAT <id:a4ce66e4-33d8-425d-ba93-132fe7047da0>') + 1 ");
            query.Append("    OR [System.IterationPath] = @currentIteration('[PR]\\SWAT <id:a4ce66e4-33d8-425d-ba93-132fe7047da0>') + 2 ");
            query.Append(" ) ");

            return query.ToString();
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
            var fields = new[] { "System.Id", "System.Title", "System.WorkItemType", "System.AssignedTo", "System.State", "Custom.Contract", "Custom.Workstream", "System.IterationPath", "System.Parent", "System.ChangedDate" };
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

        public static DateTime? FieldDateTime(Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem workItem, string fieldName)
        {
            var fieldValue = Field(workItem, fieldName);
            if (fieldValue != null)
            {
                if (DateTime.TryParse(fieldValue, out DateTime fieldDateTime))
                {
                    return fieldDateTime;
                }
            }

            return null;
        }

        public static int? FieldInt(Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem workItem, string fieldName)
        {
            var fieldValue = Field(workItem, fieldName);
            if (fieldValue != null)
            {
                if (int.TryParse(fieldValue, out int fieldInt))
                {
                    return fieldInt;
                }
            }

            return null;
        }

        public static decimal? FieldDateDecimal(Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem workItem, string fieldName)
        {
            var fieldValue = Field(workItem, fieldName);
            if (fieldValue != null)
            {
                if (decimal.TryParse(fieldValue, out decimal fieldDecimal))
                {
                    return fieldDecimal;
                }
            }

            return null;
        }



    }
}
