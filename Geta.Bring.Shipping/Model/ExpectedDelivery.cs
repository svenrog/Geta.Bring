using System;
using System.Collections.Generic;
using System.Linq;
using Geta.Bring.Shipping.Infrastructure;
using Newtonsoft.Json;

namespace Geta.Bring.Shipping.Model
{
    public class ExpectedDelivery
    {
        public ExpectedDelivery(
            string workingDays, 
            string userMessage, 
            string formattedExpectedDeliveryDate, 
            string formattedEarliestPickupDate,
            DateTime? expectedDeliveryDate,
            IEnumerable<DateTime> alternativeDeliveryDates)
        {
            AlternativeDeliveryDates = alternativeDeliveryDates ?? Enumerable.Empty<DateTime>();
            ExpectedDeliveryDate = expectedDeliveryDate;
            FormattedEarliestPickupDate = formattedEarliestPickupDate;
            FormattedExpectedDeliveryDate = formattedExpectedDeliveryDate;
            UserMessage = userMessage;
            WorkingDays = workingDays;
        }

        public string WorkingDays { get; private set; }

        public string UserMessage { get; private set; }

        public string FormattedExpectedDeliveryDate { get; private set; }

        public string FormattedEarliestPickupDate { get; private set; }

        [JsonConverter(typeof(DeliveryDateToDateTimeConverter))]
        public DateTime? ExpectedDeliveryDate { get; private set; }

        public IEnumerable<DateTime> AlternativeDeliveryDates { get; private set; }
    }

    public class DeliveryDate
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
    }
}