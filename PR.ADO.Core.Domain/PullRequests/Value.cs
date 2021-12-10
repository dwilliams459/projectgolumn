using System.Text.Json.Serialization; 
using System.Collections.Generic; 
using System;
using System.Linq;

namespace PR.Ado.Core.Domain.PullRequests
{ 

    public class PullRequest
    {
        [JsonPropertyName("repository")]
        public Repository Repository { get; set; }

        [JsonPropertyName("pullRequestId")]
        public int PullRequestId { get; set; }

        [JsonPropertyName("codeReviewId")]
        public int CodeReviewId { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("createdBy")]
        public CreatedBy CreatedBy { get; set; }

        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("sourceRefName")]
        public string SourceRefName { get; set; }

        [JsonPropertyName("targetRefName")]
        public string TargetRefName { get; set; }

        [JsonPropertyName("mergeStatus")]
        public string MergeStatus { get; set; }

        [JsonPropertyName("isDraft")]
        public bool IsDraft { get; set; }

        [JsonPropertyName("mergeId")]
        public string MergeId { get; set; }

        [JsonPropertyName("lastMergeSourceCommit")]
        public LastMergeSourceCommit LastMergeSourceCommit { get; set; }

        [JsonPropertyName("lastMergeTargetCommit")]
        public LastMergeTargetCommit LastMergeTargetCommit { get; set; }

        [JsonPropertyName("lastMergeCommit")]
        public LastMergeCommit LastMergeCommit { get; set; }

        [JsonPropertyName("reviewers")]
        public List<Reviewer> Reviewers { get; set; }

        public bool HasReviewer(string reviewerName)
        {
            return (Reviewers.Where(r => r.DisplayName.Contains(reviewerName)).Count() > 0);
        }

        public int? ReviewVote(string username)
        {
            var myReview = Reviewers.Where(r => r.UniqueName == username);
            if (myReview != null && myReview.FirstOrDefault() != null)
            {
                return myReview.FirstOrDefault().Vote;
            }
            return null;
        }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("completionOptions")]
        public CompletionOptions CompletionOptions { get; set; }

        [JsonPropertyName("supportsIterations")]
        public bool SupportsIterations { get; set; }

        [JsonPropertyName("autoCompleteSetBy")]
        public AutoCompleteSetBy AutoCompleteSetBy { get; set; }
    }

}