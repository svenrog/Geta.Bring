using System;
using System.Collections.Generic;
using FluentAssertions;
using Geta.Bring.Booking.Infrastructure;
using Geta.Bring.Booking.Model;
using Geta.Bring.Booking.Model.Dtos;
using Newtonsoft.Json;
using Xunit;

namespace Booking.Tests.Integration
{
    public class ResponseDeserializationTests
    {
        [Fact]
        public void it_can_be_deserialized()
        {
            var expected = new BookingResponse
            {
                Consignments = new List<BookingResponse.Consignment>
                {
                    new BookingResponse.Consignment
                    {
                        CorrelationId = "INTERNAL-123456",
                        Confirmation = new BookingResponse.Confirmation
                        {
                            ConsignmentNumber = "70438101268018539",
                            Links = new BookingResponse.Links
                            {
                                Labels = new Uri("https://www.mybring.com/booking/labels/2968466?auth-token=5cf1dcee-4f01-4c9a-9870-3ba6d9ba050b"),
                                Tracking = new Uri("http://sporing.bring.no/sporing.html?q=70438101268018539")
                            },
                            DateAndTimes = new BookingResponse.DateAndTimes
                            {
                                EarliestPickup = null,
                                ExpectedDelivery = DateTime.Parse("Sat, 22 Nov 2014 13:33:56.515")
                            },
                            Packages = new List<BookingResponse.Package>
                            {
                                new BookingResponse.Package
                                {
                                    CorrelationId = "PACKAGE-123",
                                    PackageNumber = "370438101268058536"
                                }
                            }
                        },
                        Errors = null
                    }
                }
            }; 

            var actual = JsonConvert.DeserializeObject<BookingResponse>(SuccessJsonResponse, new MilisecondEpochConverter());

            expected.ShouldBeEquivalentTo(actual);
        }

        [Fact]
        public void it_can_be_deserialized_when_has_errors()
        {
            var expected = new BookingResponse
            {
                Consignments = new List<BookingResponse.Consignment>
                {
                    new BookingResponse.Consignment
                    {
                        CorrelationId = null,
                        Confirmation = null,
                        Errors = new List<Error>
                        {
                            new Error(
                                "b2e73d9f-6281-4ed2-91ee-431eba33f766",
                                "BOOK-INPUT-023",
                                new List<ErrorMessage>
                                {
                                    new ErrorMessage(
                                        "en",
                                        "The shipment is too big to send with the given product"
                                    )
                                }
                            )
                        }
                    }
                }
            };

            var actual = JsonConvert.DeserializeObject<BookingResponse>(ErrorJsonResponse, new MilisecondEpochConverter());

            expected.ShouldBeEquivalentTo(actual);
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
        private const string ErrorJsonResponse = @"
{
	""consignments"":[{
		""confirmation"":null,
		""errors"":[{
			""uniqueId"":""b2e73d9f-6281-4ed2-91ee-431eba33f766"",
			""code"":""BOOK-INPUT-023"",
			""messages"":[{
				""lang"":""en"",
				""message"":""The shipment is too big to send with the given product""
			}],
			""consignmentCorrelationId"":null,
			""packageCorrelationId"":null
		}]
	}]
}
";
    }
}