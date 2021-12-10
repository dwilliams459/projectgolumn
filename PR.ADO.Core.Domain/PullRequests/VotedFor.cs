using System.Text.Json.Serialization; 
namespace PR.Ado.Core.Domain.PullRequests{ 

    public class VotedFor
    {
        [JsonPropertyName("reviewerUrl")]
        public string ReviewerUrl { get; set; }

        [JsonPropertyName("vote")]
        public int Vote { get; set; }

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

        [JsonPropertyName("isContainer")]
        public bool IsContainer { get; set; }
    }

}