namespace Tests.Integration.Tracking.TestData
{
    public static class TestpackageEdi
    {
        public const string TrackingNumber = "TESTPACKAGE-EDI";

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
                    ""statusDescription"": ""Posten/Bring har fått melding fra <span rel=""tooltip"" title=""Avsender er den som har kjøpt transporttjenesten. Inntil sendingen er utlevert til mottaker er det avsender som har råderetten  og erstatningsretten over sendingen."">avsender</span> om at det kommer en <span rel=""tooltip"" title=""Alle pakker og brev som sendes med Posten kalles en postsending eller bare sending."">sending</span>, men denne er foreløpig ikke mottatt. For eventuelle spørsmål, ta kontakt med <span rel=""tooltip"" title=""Avsender er den som har kjøpt transporttjenesten. Inntil sendingen er utlevert til mottaker er det avsender som har råderetten  og erstatningsretten over sendingen."">avsender</span>"",
                    ""descriptions"": [],
                    ""packageNumber"": ""TESTPACKAGEEDI"",
                    ""previousPackageNumber"": """",
                    ""productName"": ""PÅ DØREN"",
                    ""productCode"": ""1736"",
                    ""brand"": ""POSTEN"",
                    ""lengthInCm"": 41,
                    ""widthInCm"": 38,
                    ""heightInCm"": 29,
                    ""volumeInDm3"": 45.2,
                    ""weightInKgs"": 16.5,
                    ""dateOfEstimatedDelivery"": ""30.11.2014"",
                    ""eventSet"": [
                        {
                            ""description"": ""Ingen sending er mottatt ennå, kun melding om dette"",
                            ""status"": ""PRE_NOTIFIED"",
                            ""recipientSignature"": {
                                ""name"": """"
                            },
                            ""unitId"": ""904030"",
                            ""unitType"": ""BRING"",
                            ""postalCode"": """",
                            ""city"": """",
                            ""countryCode"": """",
                            ""country"": """",
                            ""dateIso"": ""2014-11-24T12:44:12+01:00"",
                            ""displayDate"": ""24.11.2014"",
                            ""displayTime"": ""12:44"",
                            ""consignmentEvent"": false,
                            ""definitions"": [
                                {
                                    ""term"": ""sending"",
                                    ""explanation"": ""Alle pakker og brev som sendes med Posten kalles en postsending eller bare sending.""
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