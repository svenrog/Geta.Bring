using System.Collections.Specialized;
using System.Globalization;

namespace Geta.Bring.Shipping.Model.QueryParameters
{
    public class PriceAdjustment : IQueryParameter
    {
        private const string ParameterName = "priceAdjustment";
        private const string IncreaseFormat = "p{0}";
        private const string DecreaseFormat = "m{0}";
        private const string PercentFormat = "{0}p";
        private const string ProductFormat = "{0}_{1}";

        private PriceAdjustment() { }

        public NameValueCollection Items { get; private set; }

        public static PriceAdjustment Fixed(int fixedPrice)
        {
            return NewWithParameter(fixedPrice.ToString(CultureInfo.InvariantCulture));
        }

        public static PriceAdjustment Fixed(Product product, int fixedPrice)
        {
            return NewWithParameter(AsProductValue(product, fixedPrice.ToString(CultureInfo.InvariantCulture)));
        }

        public static PriceAdjustment Increase(int amount)
        {
            return NewWithParameter(AsIncreaseValue(amount)); 
        }

        public static PriceAdjustment Increase(Product product, int amount)
        {
            return NewWithParameter(AsProductValue(product, AsIncreaseValue(amount)));
        }

        public static PriceAdjustment IncreasePercent(int percent)
        {
            return NewWithParameter(AsIncreaseValue(AsPercentValue(percent)));
        }

        public static PriceAdjustment IncreasePercent(Product product, int percent)
        {
            return NewWithParameter(AsProductValue(product, AsIncreaseValue(AsPercentValue(percent))));
        }

        public static PriceAdjustment Decrease(int amount)
        {
            return NewWithParameter(AsDecreaseValue(amount));
        }

        public static PriceAdjustment Decrease(Product product, int amount)
        {
            return NewWithParameter(AsProductValue(product, AsDecreaseValue(amount)));
        }

        public static PriceAdjustment DecreasePercent(int percent)
        {
            return NewWithParameter(AsDecreaseValue(AsPercentValue(percent)));
        }

        public static PriceAdjustment DecreasePercent(Product product, int percent)
        {
            return NewWithParameter(AsProductValue(product, AsDecreaseValue(AsPercentValue(percent))));
        }

        private static PriceAdjustment NewWithParameter(string parameterValue)
        {
            return new PriceAdjustment
            {
                Items = new NameValueCollection
                {
                    {ParameterName, parameterValue}
                }
            };
        }

        private static string AsIncreaseValue(object value)
        {
            return string.Format(IncreaseFormat, value);
        }

        private static string AsDecreaseValue(object value)
        {
            return string.Format(DecreaseFormat, value);
        }

        private static string AsProductValue(Product product, object value)
        {
            return string.Format(ProductFormat, product.Code, value);
        }

        private static string AsPercentValue(object value)
        {
            return string.Format(PercentFormat, value);
        }
    }
}