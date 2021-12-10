using System.Text.Json.Serialization; 
namespace PR.Ado.Core.Domain.PullRequests{ 

    public class LastMergeTargetCommit
    {
        [JsonPropertyName("commitId")]
        public string CommitId { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

}