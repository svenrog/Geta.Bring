namespace Tests.Integration.Tracking.TestData
{
    public static class TestpackageDelivered
    {
        public const string TrackingNumber = "TESTPACKAGE-DELIVERED";

        public const string ExpectedJson = @"
{
	""consignmentSet"" : [{
			""consignmentId"" : ""SHIPMENTNUMBER"",
			""previousConsignmentId"" : """",
			""totalWeightInKgs"" : 16.5,
			""totalVolumeInDm3"" : 45.2,
			""packageSet"" : [{
					""statusDescription"" : """",
					""descriptions"" : [],
					""packageNumber"" : ""TESTPACKAGEDELIVERED"",
					""previousPackageNumber"" : """",
					""productName"" : ""PÅ DØREN"",
					""productCode"" : ""1736"",
					""brand"" : ""POSTEN"",
					""lengthInCm"" : 41,
					""widthInCm"" : 38,
					""heightInCm"" : 29,
					""volumeInDm3"" : 45.2,
					""weightInKgs"" : 16.5,
					""eventSet"" : [{
							""description"" : ""Sendingen er utlevert"",
							""status"" : ""DELIVERED"",
							""recipientSignature"" : {
								""name"" : ""O Nordmann""
							},
							""unitId"" : ""971190"",
							""unitType"" : ""BRING"",
							""postalCode"" : """",
							""city"" : """",
							""countryCode"" : """",
							""country"" : """",
							""dateIso"" : ""2010-09-30T17:45:25+02:00"",
							""displayDate"" : ""30.09.2010"",
							""displayTime"" : ""17:45"",
							""consignmentEvent"" : false
						}, {
							""description"" : ""Sendingen er lastet opp for utkjøring"",
							""status"" : ""TRANSPORT_TO_RECIPIENT"",
							""recipientSignature"" : {
								""name"" : """"
							},
							""unitId"" : ""971190"",
							""unitType"" : ""BRING"",
							""postalCode"" : ""0001"",
							""city"" : ""OSLO"",
							""countryCode"" : ""NO"",
							""country"" : ""Norway"",
							""dateIso"" : ""2010-09-30T16:48:57+02:00"",
							""displayDate"" : ""30.09.2010"",
							""displayTime"" : ""16:48"",
							""consignmentEvent"" : false,
							""definitions"" : [{
									""term"" : ""distribusjon"",
									""explanation"" : ""Forskjellige avdelinger hos Posten og Bring som omdeler eller transporterer brev, pakker eller gods. Eksempel: omdeling av brev og pakker til postmottakere (sluttmottaker).""
								}
							]
						}, {
							""description"" : ""Sendingen er innlevert til terminal og videresendt"",
							""status"" : ""IN_TRANSIT"",
							""recipientSignature"" : {
								""name"" : """"
							},
							""unitId"" : ""032850"",
							""unitType"" : ""BRING"",
							""postalCode"" : ""0024"",
							""city"" : ""OSLO"",
							""countryCode"" : ""NO"",
							""country"" : ""Norway"",
							""dateIso"" : ""2010-09-30T08:27:08+02:00"",
							""displayDate"" : ""30.09.2010"",
							""displayTime"" : ""08:27"",
							""consignmentEvent"" : false
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