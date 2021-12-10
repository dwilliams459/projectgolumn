using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;

namespace PR.Ado.Core.Data
{
    public class TfsApiContext
    {
        private readonly Uri uri;
        private readonly string personalAccessToken;

        public TfsApiContext() // string orgName, string personalAccessToken)
        {
            this.uri = new Uri("https://dev.azure.com/prdr"); // "https://dev.azure.com/" + orgName);
            this.personalAccessToken = "piwdtoyxp2wxd7l23it3xouz4tshsikulaf7v2e4joliahia2d5q"; // "q6ytsn4c3lp4f4yywiyrgcjlzzvetglepvsf3tgp66ocfmnlcvoa";  // personalAccessToken;
        }

        public async Task<List<WorkItem>> GetAdoTfsWorkItemResponse(Wiql wiql, string[] fields)
        {
            try
            {
                var credentials = new VssBasicCredential(string.Empty, this.personalAccessToken);
         
                using (var httpClient = new WorkItemTrackingHttpClient(this.uri, credentials))
                {
                    // execute the query to get the list of work items in the results
                    var result = await httpClient.QueryByWiqlAsync(wiql).ConfigureAwait(false);
                    var ids = result.WorkItems.Select(item => item.Id).ToList(); // new List<int> { 103328 }; // result.WorkItems.Select(item => item.Id).ToArray();

                    // some error handling
                    if (ids.Count == 0)
                    {
                        return new List<WorkItem>(); //  Array.Empty<WorkItem>();
                    }

                    // Get work items for the ids found in query
                    var workItems = await httpClient.GetWorkItemsAsync(ids, fields, result.AsOf).ConfigureAwait(false);
                    return workItems;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<WorkItem>();
            }
        }

    }
}