using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Geta.Bring.Booking;
using Xunit;

namespace Booking.Tests.Integration
{
    public class BookingClientTests
    {
        [Fact]
        public async Task it_books_consignment()
        {
            var settings = new BookingSettings(TestSettings.Uid, TestSettings.Key, TestSettings.ClientUri);
            var sut = new BookingClient(settings);
            var consignment = new Consignment();

            /*var confirmation = await sut.Book(consignment);

            confirmation.Success.Should().BeTrue();*/
        }


        /*[Fact]
        public async Task it_returns_confirmations_for_valid_request()
        {
            var settings = new BookingSettings(TestSettings.Uid, TestSettings.Key, TestSettings.ClientUri);
            var request = CreateValidRequest();
            var sut = new BookingClient(settings);

            var response = await sut.Book(request);

            response.Consignments.Should().NotBeEmpty();
            var consignment = response.Consignments.First();
            consignment.HasErrors.Should().BeFalse();
            consignment.Confirmation.Should().NotBeNull();
        }
        
        [Fact]
        public async Task it_returns_errors_for_invalid_request()
        {
            var settings = new BookingSettings(TestSettings.Uid, TestSettings.Key, TestSettings.ClientUri);
            var request = CreateInvalidRequest();
            var sut = new BookingClient(settings);

            var response = await sut.Book(request); 

            var consignment = response.Consignments.First();
            consignment.HasErrors.Should().BeTrue();
        }

        private BookingRequest CreateValidRequest()
        {
            return new BookingRequest();
        }

        private BookingRequest CreateInvalidRequest()
        {
            return new BookingRequest();
        }*/
    }

    public static class TestSettings
    {
        public static string Uid = "testuid";
        public static string Key = "testkey";
        public static Uri ClientUri = new Uri("http://bringtest.localtest.me");
    }
}