using System;
using System.Collections.Generic;
using FluentAssertions;
using Geta.Bring.Booking.Dtos;
using Geta.Bring.Booking.Infrastructure;
using Newtonsoft.Json;
using Xunit;

namespace Booking.Tests.Integration
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
                Consignments = new List<BookingRequest.Consignment>
                {
                    new BookingRequest.Consignment
                    {
                        CorrelationId = "INTERNAL-123456",
                        ShippingDateTime = DateTime.Parse("Sat, 22 Nov 2014 13:33:56.483"),

                        Parties = new BookingRequest.Parties
                        {
                            Sender = new BookingRequest.Party
                            {
                                Name = "Ola Nordmann",
                                AddressLine = "Testsvingen 12",
                                AddressLine2 = null,
                                PostalCode = "0263",
                                City = "OSLO",
                                CountryCode = "no",
                                Reference = "1234",
                                AdditionalAddressInfo = "Hentes på baksiden etter klokken to",
                                Contact = new BookingRequest.Contact
                                {
                                    Name = "Trond Nordmann",
                                    Email = "trond@nordmanntest.no",
                                    PhoneNumber = "99999999"
                                }
                            },
                            Recipient = new BookingRequest.Party
                            {
                                Name = "Tore Mottaker",
                                AddressLine = "Mottakerveien 14",
                                AddressLine2 = "c/o Tina Mottaker",
                                PostalCode = "0659",
                                City = "OSLO",
                                CountryCode = "no",
                                Reference = "43242",
                                AdditionalAddressInfo = "Bruk ringeklokken",
                                Contact = new BookingRequest.Contact
                                {
                                    Name = "Tore mottaker",
                                    Email = "tore@mottakertest.no",
                                    PhoneNumber = "88888888"
                                }
                            }
                        },
                        Product = new BookingRequest.Product
                        {
                            Id = "SERVICEPAKKE",
                            CustomerNumber = "PARCELS_NORWAY-10005540322"
                        },
                        Packages = new List<BookingRequest.Package>
                        {
                            new BookingRequest.Package
                            {
                                CorrelationId = "PACKAGE-123",
                                WeightInKg = 1.1,
                                GoodsDescription = "Testing equipment",
                                Dimensions = new BookingRequest.Dimensions
                                {
                                    HeightInCm = 13,
                                    WidthInCm = 23,
                                    LengthInCm = 10
                                }
                            }
                        }
                    }
                }
            };
            var result = JsonConvert.SerializeObject(request, new MilisecondEpochConverter());
            var actual = JsonConvert.DeserializeObject<BookingRequest>(result, new MilisecondEpochConverter()); 

            expected.ShouldBeEquivalentTo(actual);
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