using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CatApiApp.Services
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            //ApiClient.DefaultRequestHeaders.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/jason"));
            ApiClient.DefaultRequestHeaders.Add("x-api-key", "42030dee-dc15-4010-a931-b9aaf28fbd09");
            ApiClient.Timeout = TimeSpan.FromMinutes(5);
            ApiClient.BaseAddress = new Uri("https://api.thecatapi.com/");
            //ApiClient.DefaultRequestHeaders.ConnectionClose = true;
            //ApiClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("identity"));
            //ApiClient.DefaultRequestHeaders.Add("Accept-Encoding", "identity");
            //ApiClient.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue();
            //ApiClient.DefaultRequestHeaders.CacheControl.NoCache = true;
            //ApiClient.DefaultRequestHeaders.Pragma.Add(new NameValueHeaderValue("no-cache"));
        }
    }
}
