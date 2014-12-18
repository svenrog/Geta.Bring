using System;
using Mediachase.Commerce;
using Mediachase.Commerce.Orders;

namespace Geta.Bring.EPi.Commerce.Model
{
    public class BringShippingRate : ShippingRate
    {
        public string MainDisplayCategory { get; set; }
        public string SubDisplayCategory { get; set; }
        public string Description { get; set; }
        public string HelpText { get; set; }
        public string Tip { get; set; }

        public BringShippingRate(
            Guid methodId, 
            string displayName, 
            string mainDisplayCategory, 
            string subDisplayCategory, 
            string description, 
            string helpText, 
            string tip, 
            Money money) 
            : base(methodId, displayName, money)
        {
            MainDisplayCategory = mainDisplayCategory;
            SubDisplayCategory = subDisplayCategory;
            Description = description;
            HelpText = helpText;
            Tip = tip;
        }
    }
}