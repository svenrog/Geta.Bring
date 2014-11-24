using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Geta.Bring.Booking.Dtos;
using Geta.Bring.Booking.Infrastructure;
using Geta.Bring.Booking.Mapping;
using Newtonsoft.Json;

namespace Geta.Bring.Booking
{
    public class BookingClient
    {
        public BookingSettings Settings { get; private set; }

        public BookingClient(BookingSettings settings)
        {
            if (settings == null) throw new ArgumentNullException("settings");
            Settings = settings;
        }

        public async Task<Confirmation> BookAsync(Consignment consignment)
        {
            var consignments = await BookAsync(new[] {consignment}).ConfigureAwait(false);
            var first = consignments.FirstOrDefault();
            if (first == null)
            {
                return new Confirmation(); // TODO: Create failure confirmation
            }
            return first;
        }

        public async Task<IEnumerable<Confirmation>> BookAsync(IEnumerable<Consignment> consignments)
        {
            using (var client = CreateClient())
            {
                var stringRequest = JsonConvert.SerializeObject(consignments.ToRequest(), new MilisecondEpochConverter());
                var requestContent = new StringContent(stringRequest, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Settings.BookingEndpointUri, requestContent).ConfigureAwait(false);
                var stringResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<BookingResponse>(stringResponse, new MilisecondEpochConverter())
                    .ToConfirmation();
            }
        }

        private HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-MyBring-API-Uid", Settings.Uid);
            client.DefaultRequestHeaders.Add("X-MyBring-API-Key", Settings.Key);
            client.DefaultRequestHeaders.Add("X-Bring-Client-URL", Settings.ClientUri.ToString());
            return client;
        }
    }
}