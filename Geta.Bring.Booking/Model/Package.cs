using System;

namespace Geta.Bring.Booking.Model
{
    public class Package
    {
        public Package(
            string correlationId, 
            double weightInKg, 
            string goodsDescription, 
            Dimensions dimensions)
        {
            if (correlationId == null) throw new ArgumentNullException("correlationId");
            if (goodsDescription == null) throw new ArgumentNullException("goodsDescription");
            if (dimensions == null) throw new ArgumentNullException("dimensions");
            Dimensions = dimensions;
            GoodsDescription = goodsDescription;
            WeightInKg = weightInKg;
            CorrelationId = correlationId;
        }

        public string CorrelationId { get; private set; }
        public double WeightInKg { get; private set; }
        public string GoodsDescription { get; private set; }
        public Dimensions Dimensions { get; private set; }
    }
}