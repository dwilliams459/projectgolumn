using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace PR.Ado.Core.Domain.PullRequests{ 

    public class Reviewer
    {
        [JsonPropertyName("reviewerUrl")]
        public string ReviewerUrl { get; set; }

        [JsonPropertyName("vote")]
        public int Vote { get; set; }

        public string VoteName()
        {
            if (Vote == 10) return "pass";
            if (Vote == -10) return "fail";
            if (Vote == 0) return "none";
            return Vote.ToString();
        }

        [JsonPropertyName("votedFor")]
        public List<VotedFor> VotedFor { get; set; }

        [JsonPropertyName("hasDeclined")]
        public bool HasDeclined { get; set; }

        [JsonPropertyName("isFlagged")]
        public bool IsFlagged { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("_links")]
        public Links Links { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("uniqueName")]
        public string UniqueName { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("isRequired")]
        public bool? IsRequired { get; set; }

        [JsonPropertyName("isContainer")]
        public bool? IsContainer { get; set; }
    }

}