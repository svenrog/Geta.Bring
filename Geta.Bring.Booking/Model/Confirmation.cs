namespace Geta.Bring.Booking.Model
{
    public class Confirmation
    {
        protected Confirmation(bool success)
        {
            Success = success;
        }

        public static Confirmation Error(string reason)
        {
            return new Confirmation(false);
        }

        public bool Success { get; private set; }
    }
}