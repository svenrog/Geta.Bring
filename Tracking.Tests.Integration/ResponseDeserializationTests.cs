using System;
using System.Linq;
using FluentAssertions;
using Geta.Bring.Tracking.Model;
using Newtonsoft.Json;
using Xunit;

namespace Tracking.Tests.Integration
{
    public class ResponseDeserializationTests
    {
        [Fact]
        public void it_can_be_deserialized()
        {
            var expected = new TrackingResponse(new[]
            {
                new ConsignmentStatus(
                    "SHIPMENTNUMBER",
                    string.Empty,
                    16.5,
                    45.2,
                    new []
                    {
                        new PackageStatus(
                            "Sendingen kan hentes på postkontor.",
                            "TESTPACKAGEATPICKUPPOINT",
                            string.Empty,
                            "KLIMANØYTRAL SERVICEPAKKE",
                            "1202",
                            "POSTEN",
                            41,
                            38,
                            29,
                            45.2,
                            16.5,
                            "AA11",
                            "01.12.2011",
                            "POSTEN NORGE AS",
                            new Address(
                                string.Empty,
                                string.Empty,
                                "1407",
                                "VINTERBRO",
                                string.Empty,
                                string.Empty
                                ),
                            new []
                            {
                                new TrackingEvent(
                                    "Sendingen er ankommet postkontor",
                                    "READY_FOR_PICKUP",
                                    new RecipientSignature(string.Empty), 
                                    "122608",
                                    new Uri("http://fraktguide.bring.no/fraktguide/api/pickuppoint/id/122608"),
                                    "BRING",
                                    "2341",
                                    "LØTEN",
                                    "NO",
                                    "Norway",
                                    DateTime.Parse("2010-10-01T08:30:25+02:00"),
                                    "01.10.2010",
                                    "08:30",
                                    false,
                                    Enumerable.Empty<TrackingEventDefinition>()
                                    ), 
                                new TrackingEvent(
                                    "Sendingen er innlevert til terminal og videresendt",
                                    "IN_TRANSIT",
                                    new RecipientSignature(string.Empty), 
                                    "032850",
                                    null,
                                    "BRING",
                                    "0024",
                                    "OSLO",
                                    "NO",
                                    "Norway",
                                    DateTime.Parse("2010-09-30T08:27:08+02:00"),
                                    "30.09.2010",
                                    "08:27",
                                    false,
                                    new []
                                    {
                                        new TrackingEventDefinition(
                                            "terminal",
                                            "Brev, pakke eller godsterminal som benyttes til sortering  og omlasting av sendinger som er underveis til mottaker."
                                            )
                                    })
                            })
                    }) 
            });

            var actual = JsonConvert.DeserializeObject<TrackingResponse>(SuccessJsonResponse);

            expected.ShouldBeEquivalentTo(actual);
        }

        private const string SuccessJsonResponse = @"
{
    ""consignmentSet"": [
        {
            ""consignmentId"": ""SHIPMENTNUMBER"",
            ""previousConsignmentId"": """",
            ""totalWeightInKgs"": 16.5,
            ""totalVolumeInDm3"": 45.2,
            ""packageSet"": [
                {
                    ""statusDescription"": ""Sendingen kan hentes på postkontor."",
                    ""descriptions"": [],
                    ""packageNumber"": ""TESTPACKAGEATPICKUPPOINT"",
                    ""previousPackageNumber"": """",
                    ""productName"": ""KLIMANØYTRAL SERVICEPAKKE"",
                    ""productCode"": ""1202"",
                    ""brand"": ""POSTEN"",
                    ""lengthInCm"": 41,
                    ""widthInCm"": 38,
                    ""heightInCm"": 29,
                    ""volumeInDm3"": 45.2,
                    ""weightInKgs"": 16.5,
                    ""pickupCode"": ""AA11"",
                    ""dateOfReturn"": ""01.12.2011"",
                    ""senderName"": ""POSTEN NORGE AS"",
                    ""recipientAddress"": {
                        ""addressLine1"": """",
                        ""addressLine2"": """",
                        ""postalCode"": ""1407"",
                        ""city"": ""VINTERBRO"",
                        ""countryCode"": """",
                        ""country"": """"
                    },
                    ""eventSet"": [
                        {
                            ""description"": ""Sendingen er ankommet postkontor"",
                            ""status"": ""READY_FOR_PICKUP"",
                            ""recipientSignature"": {
                                ""name"": """"
                            },
                            ""unitId"": ""122608"",
                            ""unitInformationUrl"": ""http://fraktguide.bring.no/fraktguide/api/pickuppoint/id/122608"",
                            ""unitType"": ""BRING"",
                            ""postalCode"": ""2341"",
                            ""city"": ""LØTEN"",
                            ""countryCode"": ""NO"",
                            ""country"": ""Norway"",
                            ""dateIso"": ""2010-10-01T08:30:25+02:00"",
                            ""displayDate"": ""01.10.2010"",
                            ""displayTime"": ""08:30"",
                            ""consignmentEvent"": false
                        },
                        {
                            ""description"": ""Sendingen er innlevert til terminal og videresendt"",
                            ""status"": ""IN_TRANSIT"",
                            ""recipientSignature"": {
                                ""name"": """"
                            },
                            ""unitId"": ""032850"",
                            ""unitType"": ""BRING"",
                            ""postalCode"": ""0024"",
                            ""city"": ""OSLO"",
                            ""countryCode"": ""NO"",
                            ""country"": ""Norway"",
                            ""dateIso"": ""2010-09-30T08:27:08+02:00"",
                            ""displayDate"": ""30.09.2010"",
                            ""displayTime"": ""08:27"",
                            ""consignmentEvent"": false,
                            ""definitions"": [
                                {
                                    ""term"": ""terminal"",
                                    ""explanation"": ""Brev, pakke eller godsterminal som benyttes til sortering  og omlasting av sendinger som er underveis til mottaker.""
                                }
                            ]
                        }
                    ]
                }
            ]
        }
    ]
}
";
    }
}