using System.Collections.Generic;
using System.Linq;
using Geta.Bring.Booking.Model;
using Geta.Bring.Booking.Model.Dtos;

namespace Geta.Bring.Booking.Mapping
{
    internal static class BookingResponseMappingExtensions
    {
        public static IEnumerable<Confirmation> ToConfirmation(this BookingResponse response)
        {
            return response.Consignments.Select(ToConfirmation);
        }

        private static Confirmation ToConfirmation(BookingResponse.Consignment consignment)
        {
            var errors = (consignment.Errors ?? Enumerable.Empty<Error>()).ToArray();
            if (errors.Any())
            {
                return Confirmation.CreateError(errors);
            }
            var confirmation = consignment.Confirmation ?? new BookingResponse.Confirmation();
            var links = confirmation.Links ?? new BookingResponse.Links();
            var dates = confirmation.DateAndTimes ?? new BookingResponse.DateAndTimes();
            var packages = (confirmation.Packages ?? Enumerable.Empty<BookingResponse.Package>()).ToArray();
            var packageConfirmations = packages.Select(ToPackageConfirmation);

            return Confirmation.CreateSuccess(
                consignment.CorrelationId,
                confirmation.ConsignmentNumber,
                links.Labels,
                links.Tracking,
                dates.EarliestPickup,
                dates.ExpectedDelivery,
                packageConfirmations);
        }

        private static PackageConfirmation ToPackageConfirmation(BookingResponse.Package package)
        {
            return new PackageConfirmation(package.CorrelationId, package.PackageNumber);
        }
    }
}