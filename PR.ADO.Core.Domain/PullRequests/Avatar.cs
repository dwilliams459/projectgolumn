using System.Text.Json.Serialization; 
namespace PR.Ado.Core.Domain.PullRequests{ 

    public class Avatar
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }

}