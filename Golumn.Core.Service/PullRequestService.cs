//using Microsoft.TeamFoundation.Build.WebApi;
using PR.Ado.Core.Data;
using PR.Ado.Core.Domain.PullRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golumn.Core.Service
{
    public class PullRequestService
    {
        private AdoContext _context;

        public PullRequestService(AdoContext context = null)
        {
            _context = context;
            if (context == null)
            {
                _context = new AdoContext();
            }
        }

        public async Task<List<PullRequest>> GetActivePullRequests(int top = 10)
        {
            // https://dev.azure.com/PRDR/PR/_apis/
            string endpointQuery = $"git/pullrequests?searchCriteria.status=Active&$top={top}&api-version=6.0";

            var response = await _context.GetAdoRequestResponse<PullRequestResponse>(endpointQuery);

            if (response != null)
            {
                return response.Value;
            }
            return null;
        }

        public async Task<List<PullRequest>> GetPullRequestsAssignedToMe(string username = "david.williams@recovery.pr", int top = 10)
        {
            // https://dev.azure.com/PRDR/PR/_apis/
            string endpointQuery = $"git/pullrequests?searchCriteria.status=Active&$top={top}&api-version=6.0";

            var response = await _context.GetAdoRequestResponse<PullRequestResponse>(endpointQuery);
            if (response != null)
            {
                // Console.Clear();
                // Console.Write($"\rTotal active pull requres: {response.Count} ({DateTime.Now.ToString("HH:mm:ss")}) ");
                var myPullRequests = response.Value.Where(pr => 
                    (pr.ReviewVote(username) == 0 || pr.HasReviewer("ASP .net Developers"))
                    && pr.CreationDate > DateTime.Now.AddDays(-7));
                return myPullRequests.ToList();
            }

            return null;
        }
    }
}
