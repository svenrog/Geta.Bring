using System;
using System.Linq;
using FluentAssertions;
using Geta.Bring.Booking.Dtos;
using Geta.Bring.Booking.Infrastructure;
using Newtonsoft.Json;
using Xunit;

namespace Booking.Tests.Integration
{
    public class ResponseDeserializationTests
    {
        [Fact]
        public void it_can_be_deserialized()
        {
            var result = JsonConvert.DeserializeObject<BookingResponse>(SuccessJsonResponse, new MilisecondEpochConverter());

            result.Consignments.Should().NotBeNull();
            result.Consignments.Should().HaveCount(1);
            var consignment = result.Consignments.First();
            consignment.CorrelationId.Should().Be("INTERNAL-123456");

            consignment.Confirmation.Should().NotBeNull();
            var confirmation = consignment.Confirmation;
            confirmation.ConsignmentNumber.Should().Be("70438101268018539");

            confirmation.Links.Should().NotBeNull();
            confirmation.Links.Labels.Should()
                .Be(new Uri("https://www.mybring.com/booking/labels/2968466?auth-token=5cf1dcee-4f01-4c9a-9870-3ba6d9ba050b"));
            confirmation.Links.Tracking.Should()
                .Be(new Uri("http://sporing.bring.no/sporing.html?q=70438101268018539"));

            confirmation.DateAndTimes.EarliestPickup.Should().Be(null);
            confirmation.DateAndTimes.ExpectedDelivery.Should().Be(DateTime.Parse("Sat, 22 Nov 2014 13:33:56.515"));

            confirmation.Packages.Should().HaveCount(1);
            var package = confirmation.Packages.First();
            package.CorrelationId.Should().Be("PACKAGE-123");
            package.PackageNumber.Should().Be("370438101268058536");

            consignment.Errors.Should().BeNull();
        }

        

        private const string SuccessJsonResponse = @"
{
    ""consignments"": [
        {
            ""correlationId"": ""INTERNAL-123456"",
            ""confirmation"": {
                ""consignmentNumber"": ""70438101268018539"",
                ""productSpecificData"": null,
                ""links"": {
                    ""labels"": ""https://www.mybring.com/booking/labels/2968466?auth-token=5cf1dcee-4f01-4c9a-9870-3ba6d9ba050b"",
                    ""waybill"": null,
                    ""tracking"": ""http://sporing.bring.no/sporing.html?q=70438101268018539""
                },
                ""dateAndTimes"": {
                    ""earliestPickup"": null,
                    ""expectedDelivery"": 1416663236515
                },
                ""packages"": [
                    {
                        ""correlationId"": ""PACKAGE-123"",
                        ""packageNumber"": ""370438101268058536""
                    }
                ]
            },
            ""errors"": null
        }
    ]
}
";
    }
}