using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using PR.Recovery.Ado.Data;
using PR.Ado.Core.Domain;

namespace PR.Recovery.Ado.Service
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

        public async Task<List<WorkItem>> GetWorkItems(Options options) //string searchTerm = null, string type = "")
        {
            var fields = new[] { "System.Id", "System.Title", "System.WorkItemType", "System.AssignedTo", "System.State", "Custom.Contract", "Custom.Workstream", "System.IterationPath", "System.Parent", "System.IterationPath" };
            var fieldString = String.Join(",", fields);

            var query = $"SELECT {fieldString} "
                        + " FROM workitems "
                        + " WHERE[System.TeamProject] = 'PR' AND [System.WorkItemType] <> 'Task' "
                        + " AND NOT[System.State] IN('Closed', 'In Build Preparation', 'Cancelled', 'In Refinement') "
                        // + @" AND [System.IterationPath] IN ('PR\PI 13\Sprint 13.3', 'PR\PI 13\Sprint 13.4', 'PR\PI 13\Sprint 13.5') "                       
                        + " AND ( " // "id:a4ce66e4-33d8-425d-ba93-132fe7047da0>" == SWAT Team
                        + @"     [System.IterationPath] = @currentIteration('[PR]\SWAT <id:a4ce66e4-33d8-425d-ba93-132fe7047da0>') "
                        + @"     OR [System.IterationPath] = @currentIteration('[PR]\SWAT <id:a4ce66e4-33d8-425d-ba93-132fe7047da0>') - 1 "
                        + @"     OR [System.IterationPath] = @currentIteration('[PR]\SWAT <id:a4ce66e4-33d8-425d-ba93-132fe7047da0>') + 1 "
                        + " ) "
                        + $" AND [System.ChangedDate] > '{DateTime.Now.AddDays(-14).ToString("yyyy-MM-dd")}' ";


            if (options.All)
            {
                query += " AND EVER [System.AssignedTo] = 'David Williams <david.williams1@cgi.com>' " ;
            }
            else if (!string.IsNullOrWhiteSpace(options.OneUserStory ))
            {
                query += $" AND [SYSTEM.Id] = {options.OneUserStory} ";
            }
            else
            {
                query += " AND [System.AssignedTo] = 'David Williams <david.williams1@cgi.com>' " ;
            }

            if (options.Bugs) 
            {
                query = query + "AND [System.WorkItemType] CONTAINS 'Bug' "; 
            }
            
            if (options.UserStories)
            {
                query = query + "AND [System.WorkItemType] CONTAINS 'User Story' "; 
            }
            
            if (!String.IsNullOrEmpty(options.SearchText()))
            {
                query = query + $"AND [System.Title] CONTAINS '{options.SearchText()}' ";
            }

            query = query + " ORDER BY [System.Id]";

            // create a wiql object and build our query
            var wiql = new Wiql()
            {
                Query = query
            };

            var workItems = await ctx.GetAdoTfsWorkItemResponse(wiql, fields).ConfigureAwait(false);

            return workItems;
        }

        public async Task<string> GetParentWorkItemDescription(string parentId)
        {
            var fields = new[] { "System.Id", "System.Title", "System.WorkItemType", "System.AssignedTo" };
            var fieldString = String.Join(",", fields);

            var query = $"SELECT {fieldString} FROM workitems WHERE[System.Id] = {parentId} ";

            // create a wiql object and build our query
            var wiql = new Wiql()
            {
                Query = query
            };

            var workItems = await ctx.GetAdoTfsWorkItemResponse(wiql, fields).ConfigureAwait(false);

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
