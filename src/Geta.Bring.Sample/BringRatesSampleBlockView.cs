using System;
using System.Collections.Generic;
using Geta.Bring.Shipping.Model;

namespace Geta.Bring.Sample
{
    public class BringRatesSampleBlockView
    {
        public IEnumerable<EstimateGroup> EstimateGroups { get; private set; }

        public BringRatesSampleBlockView(IEnumerable<EstimateGroup> estimateGroups)
        {
            EstimateGroups = estimateGroups;
        }

        public class EstimateGroup
        {
            public string MainCategory { get; private set; }
            public IEnumerable<ShipmentEstimate> Estimates { get; private set; }

            public EstimateGroup(string mainCategory, IEnumerable<ShipmentEstimate> estimates)
            {
                if (mainCategory == null) throw new ArgumentNullException("mainCategory");
                if (estimates == null) throw new ArgumentNullException("estimates");
                MainCategory = mainCategory;
                Estimates = estimates;
            }
        }
    }
}