namespace Tracking.Tests.Integration.TestData
{
    public static class TestpackageLoadedForDelivery
    {
        public const string TrackingNumber = "TESTPACKAGE-LOADED-FOR-DELIVERY";

        public const string ExpectedJson = @"
{
    ""consignmentSet"": [
        {
            ""consignmentId"": ""SHIPMENTNUMBER"",
            ""previousConsignmentId"": """",
            ""totalWeightInKgs"": 16.5,
            ""totalVolumeInDm3"": 45.2,
            ""packageSet"": [
                {
                    ""statusDescription"": ""Sendingen leveres hjem til <span rel=""tooltip"" title=""En person eller firma som får en sending tilsendt er mottaker. Kalles også adressat. Det vil si den som avsender adresserer sendingen til."">mottaker</span> i kveld mellom kl 17:00 og 21:00. Sjåføren ringer 30 - 60 minutter før levering"",
                    ""descriptions"": [],
                    ""packageNumber"": ""TESTPACKAGELOADEDFORDELIVERY"",
                    ""previousPackageNumber"": """",
                    ""productName"": ""PÅ DØREN"",
                    ""productCode"": ""1736"",
                    ""brand"": ""POSTEN"",
                    ""lengthInCm"": 41,
                    ""widthInCm"": 38,
                    ""heightInCm"": 29,
                    ""volumeInDm3"": 45.2,
                    ""weightInKgs"": 16.5,
                    ""eventSet"": [
                        {
                            ""description"": ""Sendingen er lastet opp for utkjøring"",
                            ""status"": ""TRANSPORT_TO_RECIPIENT"",
                            ""recipientSignature"": {
                                ""name"": """"
                            },
                            ""unitId"": ""971190"",
                            ""unitType"": ""BRING"",
                            ""postalCode"": ""0001"",
                            ""city"": ""OSLO"",
                            ""countryCode"": ""NO"",
                            ""country"": ""Norway"",
                            ""dateIso"": ""2010-09-30T16:48:57+02:00"",
                            ""displayDate"": ""30.09.2010"",
                            ""displayTime"": ""16:48"",
                            ""consignmentEvent"": false,
                            ""definitions"": [
                                {
                                    ""term"": ""sendingen er lastet opp for utkjøring"",
                                    ""explanation"": ""Sendingen eller pakken er på bil for utkjøring. Blir levert til mottaker samme dag.""
                                }
                            ]
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