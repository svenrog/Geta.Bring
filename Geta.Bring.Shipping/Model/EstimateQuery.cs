using System;
using System.Collections.Specialized;
using System.Linq;
using Geta.Bring.Shipping.Model.QueryParameters;

namespace Geta.Bring.Shipping.Model
{
    public class EstimateQuery
    {
        public EstimateQuery(
            ShipmentLeg shipmentLeg, 
            PackageSize packageSize,
            params IQueryParameter[] additionalParameters)
        {
            if (shipmentLeg == null) throw new ArgumentNullException("shipmentLeg");
            if (packageSize == null) throw new ArgumentNullException("packageSize");
            var parameters = additionalParameters.ToList();
            parameters.ForEach(x =>
            {
                if (x == null)
                    throw new ArgumentException("additionalParameters contains null item", "additionalParameters");
            });


            Items = new NameValueCollection
            {
                shipmentLeg.Items,
                packageSize.Items
            };

            parameters
                .ForEach(x => Items.Add(x.Items));
        }

        public NameValueCollection Items { get; private set; }
    }
}