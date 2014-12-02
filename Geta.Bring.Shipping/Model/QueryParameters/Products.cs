using System;
using System.Collections.Specialized;
using System.Linq;

namespace Geta.Bring.Shipping.Model.QueryParameters
{
    public class Products : IQueryParameter
    {
        private const string ParameterName = "product";

        public Products(params Product[] additionalProducts)
        {
            var products = additionalProducts.ToList();
            products.ForEach(x =>
            {
                if (x == null)
                    throw new ArgumentException("additionalProducts contains null item", "additionalProducts");
            });

            Items = new NameValueCollection();

            products
                .ForEach(x => Items.Add(ParameterName, x.Code));
        }

        public NameValueCollection Items { get; private set; }
    }
}