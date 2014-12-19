using System;

namespace Geta.Bring.Booking.Model
{
    /// <summary>
    /// Package information to  book.
    /// </summary>
    public class Package
    {
        /// <summary>
        /// Initializes new instance of <see cref="Package"/>.
        /// </summary>
        /// <param name="correlationId">Correlation ID.</param>
        /// <param name="weightInKg">Package weight in kilograms.</param>
        /// <param name="goodsDescription">Package goods description.</param>
        /// <param name="dimensions">Package dimensions. For more see: <see cref="Dimensions"/>.</param>
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

        /// <summary>
        /// Correlation ID.
        /// </summary>
        public string CorrelationId { get; private set; }

        /// <summary>
        /// Package weight in kilograms.
        /// </summary>
        public double WeightInKg { get; private set; }

        /// <summary>
        /// Package goods description.
        /// </summary>
        public string GoodsDescription { get; private set; }

        /// <summary>
        /// Package dimensions. For more see: <see cref="Dimensions"/>.
        /// </summary>
        public Dimensions Dimensions { get; private set; }
    }
}