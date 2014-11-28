using System;
using System.Collections.Specialized;

namespace Geta.Bring.Shipping.Model.QueryParameters
{
    public class ShippingDateAndTime : IQueryParameter
    {
        public ShippingDateAndTime(DateTime date)
        {
            Items = new NameValueCollection
            {
                {"date", date.ToString("yyyy-MM-dd")}
            };
        }

        public ShippingDateAndTime(DateTime date, TimeSpan time)
        {
            Items = new NameValueCollection
            {
                {"date", date.ToString("yyyy-MM-dd")},
                {"time", time.ToString("HH:mm")}
            };
        }

        public NameValueCollection Items { get; private set; }
    }
}