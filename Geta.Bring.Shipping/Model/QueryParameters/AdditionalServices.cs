using System;
using System.Collections.Specialized;
using System.Linq;

namespace Geta.Bring.Shipping.Model.QueryParameters
{
    public class AdditionalServices : IQueryParameter
    {
        private const string ParameterName = "additional";

        public AdditionalServices(AdditionalService service, params AdditionalService[] additionalServices)
        {
            if (service == null) throw new ArgumentNullException("service");
            var services = additionalServices.ToList();
            services.ForEach(x =>
            {
                if (x == null)
                    throw new ArgumentException("additionalServices contains null item", "additionalServices");
            });

            Items = new NameValueCollection
            {
                {ParameterName, service.Code}
            };

            services
                .ForEach(x => Items.Add(ParameterName, x.Code));
        }

        public NameValueCollection Items { get; private set; }
    }
}