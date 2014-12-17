using System;
using System.Threading.Tasks;
using FluentAssertions;
using Geta.Bring.Booking;
using Geta.Bring.Booking.Model;
using Xunit;

namespace Booking.Tests.Integration
{
    public class BookingClientTests
    {
        //[Fact]
        public async Task it_books_consignment()
        {
            var settings = new BookingSettings(TestSettings.Uid, TestSettings.Key, TestSettings.ClientUri, isTest: true);
            var sut = new BookingClient(settings);

            var sender = new Party(
                "Sender Name",
                "Address 1",
                "Address 2",
                "0123",
                "Oslo",
                "NOR",
                "reference number",
                "additional info",
                new Contact("John", "john@example.com", "98745612"));

            var recipient = new Party(
                "Recipient Name",
                "Address 1",
                "Address 2",
                "0123",
                "Oslo",
                "NOR",
                "reference number",
                "additional info",
                new Contact("Tom", "tom@example.com", "23654789"));

            var product = new Product("A-POST", "customer number");

            var packages = new[]
            {
                new Package("correlation ID", 1.0, "Products", new Dimensions(10, 10, 10))
            };

            var consignment = new Consignment(
                "correlation ID",
                DateTime.UtcNow.AddDays(1),
                new Parties(sender, recipient),
                product,
                packages);

            var result = await sut.BookAsync(consignment);

            result.Success.Should().BeTrue();
        }
    }

    public static class TestSettings
    {
        public static string Uid = "testuid";
        public static string Key = "testkey";
        public static Uri ClientUri = new Uri("http://bringtest.localtest.me");
    }
}