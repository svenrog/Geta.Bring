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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return Equals((Dimensions)obj);
        }

        protected bool Equals(Dimensions other)
        {
            return HeightInCm == other.HeightInCm && WidthInCm == other.WidthInCm && LengthInCm == other.LengthInCm;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = HeightInCm;
                hashCode = (hashCode*397) ^ WidthInCm;
                hashCode = (hashCode*397) ^ LengthInCm;
                return hashCode;
            }
        }
    }
}