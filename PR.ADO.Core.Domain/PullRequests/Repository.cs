using System.Text.Json.Serialization; 
namespace PR.Ado.Core.Domain.PullRequests{ 

    public class Repository
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("project")]
        public Project Project { get; set; }
    }

}