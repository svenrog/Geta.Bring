namespace Geta.Bring.Booking.Model
{
    public class Dimensions
    {
        public Dimensions(int heightInCm, int widthInCm, int lengthInCm)
        {
            LengthInCm = lengthInCm;
            WidthInCm = widthInCm;
            HeightInCm = heightInCm;
        }

        public int HeightInCm { get; private set; }
        public int WidthInCm { get; private set; }
        public int LengthInCm { get; private set; }
    }
}