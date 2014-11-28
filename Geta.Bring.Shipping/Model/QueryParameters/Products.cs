using System;
using System.Collections.Specialized;
using System.Linq;

namespace Geta.Bring.Shipping.Model.QueryParameters
{
    public class Products : IQueryParameter
    {
        private const string ParameterName = "product";

        public Products(Product product, params Product[] additionalProducts)
        {
            if (product == null) throw new ArgumentNullException("product");
            var products = additionalProducts.ToList();
            products.ForEach(x =>
            {
                if (x == null)
                    throw new ArgumentException("additionalProducts contains null item", "additionalProducts");
            });

            Items = new NameValueCollection
            {
                {ParameterName, product.Code}
            };

            products
                .ForEach(x => Items.Add(ParameterName, x.Code));
        }

        public NameValueCollection Items { get; private set; }
    }
}