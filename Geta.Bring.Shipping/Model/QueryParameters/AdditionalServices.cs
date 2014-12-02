using System;
using System.Collections.Specialized;
using System.Linq;

namespace Geta.Bring.Shipping.Model.QueryParameters
{
    public class AdditionalServices : IQueryParameter
    {
        private const string ParameterName = "additional";

        public AdditionalServices(params AdditionalService[] additionalServices)
        {
            var services = additionalServices.ToList();
            services.ForEach(x =>
            {
                if (x == null)
                    throw new ArgumentException("additionalServices contains null item", "additionalServices");
            });

            Items = new NameValueCollection();

            services
                .ForEach(x => Items.Add(ParameterName, x.Code));
        }

        public NameValueCollection Items { get; private set; }
    }
}