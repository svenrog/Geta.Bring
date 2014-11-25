namespace Geta.Bring.Booking.Model
{
    public class PackageConfirmation
    {
        public PackageConfirmation(string correlationId, string packageNumber)
        {
            PackageNumber = packageNumber;
            CorrelationId = correlationId;
        }

        public string CorrelationId { get; private set; }
        public string PackageNumber { get; private set; }
    }
}