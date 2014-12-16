using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Geta.Bring.Tracking.Model;
using Newtonsoft.Json;

namespace Geta.Bring.Tracking
{
    public class TrackingClient : ITrackingClient
    {
        public TrackingClient(TrackingSettings settings)
        {
            if (settings == null) throw new ArgumentNullException("settings");
            Settings = settings;
        }

        public TrackingSettings Settings { get; private set; }

        public async Task<IEnumerable<ConsignmentStatus>> Track(string trackingNumber)
        {
            using (var client = CreateClient())
            {
                var requestUri = CreateRequestUri(trackingNumber);
                var jsonResponse = await client.GetStringAsync(requestUri).ConfigureAwait(false);
                var response = JsonConvert.DeserializeObject<TrackingResponse>(jsonResponse);
                return response.ConsignmentSet;
            }
        }

        private Uri CreateRequestUri(string trackingNumber)
        {
            var ub = new UriBuilder(Settings.EndpointUri);
            var queryValues = HttpUtility.ParseQueryString(Settings.EndpointUri.Query);
            queryValues.Add("q", trackingNumber);
            ub.Query = queryValues.ToString();
            return ub.Uri;
        }

        private HttpClient CreateClient()
        {
            var client = new HttpClient();
            return client;
        }
    }
}