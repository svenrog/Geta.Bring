using System.Linq;
using Mediachase.Commerce.Orders.Dto;

namespace Geta.Bring.EPi.Commerce.Extensions
{
    internal static class ShippingMethodDtoExtensions
    {
        public static string GetShippingMethodParameterValue(
            this ShippingMethodDto shippingMethod,
            string parameterName,
            string defaultValue = "")
        {
            var row = shippingMethod.ShippingMethodParameter
                .FirstOrDefault(x => x.Parameter == parameterName);
            
            if (row == null)
            {
                return defaultValue;
            }

            return string.IsNullOrWhiteSpace(row.Value) 
                ? defaultValue 
                : row.Value;
        }

        public static string GetShippingOptionParameterValue(
            this ShippingMethodDto shippingMethod,
            string parameterName,
            string defaultValue = "")
        {
            var row = shippingMethod.ShippingOptionParameter
                .FirstOrDefault(x => x.Parameter == parameterName);

            if (row == null)
            {
                return defaultValue;
            }

            return string.IsNullOrWhiteSpace(row.Value)
                ? defaultValue
                : row.Value;
        }
    }
}