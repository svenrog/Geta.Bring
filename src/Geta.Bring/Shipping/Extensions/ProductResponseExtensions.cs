using Geta.Bring.Shipping.Model;

namespace Geta.Bring.Shipping.Extensions
{
    internal static class ProductResponseExtensions
    {
        public static PackagePrice GetPackagePrice(this ProductResponse response)
        {
            if (response.NetPrice != null) 
                return response.NetPrice;

            return response.Price;
        }
    }
}