using System;
using System.Collections.Generic;
using FluentAssertions;
using Geta.Bring.Booking.Infrastructure;
using Geta.Bring.Booking.Model;
using Geta.Bring.Booking.Model.Dtos;
using Newtonsoft.Json;
using Xunit;

namespace Tests.Integration.Booking
{
    public class RequestSerializationTests
    {
        [Fact]
        public void it_can_be_serialized()
        {
            var expected = JsonConvert.DeserializeObject<BookingRequest>(ExpectedJson, new MilisecondEpochConverter());
            var request = new BookingRequest
            {
                TestIndicator = true,
                SchemaVersion = 1,
                Consignments = new List<Consignment>
                {
                    new Consignment(
                        "INTERNAL-123456",
                        DateTime.Parse("Sat, 22 Nov 2014 13:33:56.483"),
                        new Parties(
                            new Party(
                                "Ola Nordmann",
                                "Testsvingen 12",
                                null,
                                "0263",
                                "OSLO",
                                "no",
                                "1234",
                                "Hentes på baksiden etter klokken to",
                                new Contact(
                                    "Trond Nordmann",
                                    "trond@nordmanntest.no",
                                    "99999999"
                                )),
                            new Party(
                                "Tore Mottaker",
                                "Mottakerveien 14",
                                "c/o Tina Mottaker",
                                "0659",
                                "OSLO",
                                "no",
                                "43242",
                                "Bruk ringeklokken",
                                new Contact(
                                    "Tore mottaker",
                                    "tore@mottakertest.no",
                                    "88888888"
                                ))
                            ),
                        new Product(
                            "SERVICEPAKKE",
                            "PARCELS_NORWAY-10005540322"),
                        new[]
                        {
                            new Package(
                                "PACKAGE-123",
                                1.1,
                                "Testing equipment",
                                new Dimensions(13, 23, 10)
                            )
                        })
                }
            };
            var result = JsonConvert.SerializeObject(request, new MilisecondEpochConverter());
            var actual = JsonConvert.DeserializeObject<BookingRequest>(result, new MilisecondEpochConverter());

            expected.Should().BeEquivalentTo(actual);
        }

        private const string ExpectedJson = @"
{
    ""testIndicator"": true,
    ""schemaVersion"": 1,
    ""consignments"": [
        {
            ""correlationId"": ""INTERNAL-123456"",
            ""shippingDateTime"": 1416663236483,
            ""parties"": {
                ""sender"": {
                    ""name"": ""Ola Nordmann"",
                    ""addressLine"": ""Testsvingen 12"",
                    ""addressLine2"": null,
                    ""postalCode"": ""0263"",
                    ""city"": ""OSLO"",
                    ""countryCode"": ""no"",
                    ""reference"": ""1234"",
                    ""additionalAddressInfo"": ""Hentes på baksiden etter klokken to"",
                    ""contact"": {
                        ""name"": ""Trond Nordmann"",
                        ""email"": ""trond@nordmanntest.no"",
                        ""phoneNumber"": ""99999999""
                    }
                },
                ""recipient"": {
                    ""name"": ""Tore Mottaker"",
                    ""addressLine"": ""Mottakerveien 14"",
                    ""addressLine2"": ""c/o Tina Mottaker"",
                    ""postalCode"": ""0659"",
                    ""city"": ""OSLO"",
                    ""countryCode"": ""no"",
                    ""reference"": ""43242"",
                    ""additionalAddressInfo"": ""Bruk ringeklokken"",
                    ""contact"": {
                        ""name"": ""Tore mottaker"",
                        ""email"": ""tore@mottakertest.no"",
                        ""phoneNumber"": ""88888888""
                    }
                }
            },
            ""product"": {
                ""id"": ""SERVICEPAKKE"",
                ""customerNumber"": ""PARCELS_NORWAY-10005540322""
            },
            ""packages"": [
                {
                    ""correlationId"": ""PACKAGE-123"",
                    ""weightInKg"": 1.1,
                    ""goodsDescription"": ""Testing equipment"",
                    ""dimensions"": {
                        ""heightInCm"": 13,
                        ""widthInCm"": 23,
                        ""lengthInCm"": 10
                    }
                }
            ]
        }
    ]
}
";
    }
}