using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace PR.Ado.Core.Domain.PullRequests
{ 

    public class PullRequestResponse
    {
        [JsonPropertyName("value")]
        public List<PullRequest> Value { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}