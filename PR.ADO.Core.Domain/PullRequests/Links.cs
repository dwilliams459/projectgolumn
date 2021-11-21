using System.Text.Json.Serialization; 
namespace PR.Ado.Core.Domain.PullRequests{ 

    public class Links
    {
        [JsonPropertyName("avatar")]
        public Avatar Avatar { get; set; }
    }

}