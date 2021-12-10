using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace PR.Ado.Core.Domain.PullRequests{ 

    public class CompletionOptions
    {
        [JsonPropertyName("mergeCommitMessage")]
        public string MergeCommitMessage { get; set; }

        [JsonPropertyName("mergeStrategy")]
        public string MergeStrategy { get; set; }

        [JsonPropertyName("autoCompleteIgnoreConfigIds")]
        public List<object> AutoCompleteIgnoreConfigIds { get; set; }

        [JsonPropertyName("transitionWorkItems")]
        public bool? TransitionWorkItems { get; set; }
    }

}