﻿using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentAssertions;
using Geta.Bring.Tracking;
using Geta.Bring.Tracking.Model;
using Newtonsoft.Json;

namespace Tests.Integration.Tracking
{
    public class TrackingClientTests
    {
        // TODO: Check the way to ignore ConsignmentStatus.PackageSet[].EventSet[].Definitions as those changes time to time on Bring server and tests randomly fail
        //[InlineData(TestpackageAtPickuppoint.TrackingNumber, TestpackageAtPickuppoint.ExpectedJson)]
        //[InlineData(TestpackageDelivered.TrackingNumber, TestpackageDelivered.ExpectedJson)]
        //[InlineData(TestpackageEdi.TrackingNumber, TestpackageEdi.ExpectedJson)]
        //[InlineData(TestpackageLoadedForDelivery.TrackingNumber, TestpackageLoadedForDelivery.ExpectedJson)]
        //[Theory]
        public async Task it_gets_consignments_statuses(string trackingNumber, string expectedJson)
        {
            var settings = new TrackingSettings();
            var sut = new TrackingClient(settings);
            var expected = JsonConvert.DeserializeObject<TrackingResponse>(expectedJson).ConsignmentSet;

            var actual = await sut.TrackAsync(trackingNumber);

            expected.Should().BeEquivalentTo(actual,
                options => options.Excluding(ctx => Regex.IsMatch(ctx.SelectedMemberPath, @"item\[.+\].PackageSet\[.+\].EventSet\[.+\].Definitions")));
        }
    }
}