using Microsoft.Extensions.Configuration;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PR.Ado.Core.Data
{
    public class AdoContext
    {
        private readonly string baseUrl; 
        private readonly string personalAccessToken = "zzz"; 

        public AdoContext() //string orgName, string personalAccessToken)
        {
            baseUrl = "https://dev.azure.com/PRDR/PR/_apis/"; // Uri("https://dev.azure.com/prdr");
            personalAccessToken = "zzz";
        }

        private string FullUrl(string endpointQuery) => $"{this.baseUrl}/{endpointQuery}";

        public async Task<string> GetAdoRequestResponse(string endpointQuery)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(
                        System.Text.ASCIIEncoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", "", personalAccessToken))));

                using (HttpResponseMessage response = client.GetAsync(FullUrl(endpointQuery)).Result)
                {
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
            }
        }

        public async Task<T> GetAdoRequestResponse<T>(string endpointQuery)
        {
            var response = await GetAdoRequestResponse(endpointQuery);
            var result = JsonConvert.DeserializeObject<T>(response);
            return result;
        }
    }
}
