using System;
using System.Collections.Generic;
using System.Linq;

namespace Geta.Bring.Tracking.Model
{
    public class TrackingEvent
    {
        public TrackingEvent(
            string description, 
            string status, 
            RecipientSignature recipientSignature, 
            string unitId, 
            Uri unitInformationUrl, 
            string unitType, 
            string postalCode, 
            string city, 
            string countryCode, 
            string country, 
            DateTime dateIso, 
            string displayDate, 
            string displayTime, 
            bool consignmentEvent, 
            IEnumerable<TrackingEventDefinition> definitions)
        {
            if (description == null) throw new ArgumentNullException("description");
            if (status == null) throw new ArgumentNullException("status");
            if (recipientSignature == null) throw new ArgumentNullException("recipientSignature");
            if (unitId == null) throw new ArgumentNullException("unitId");
            if (unitType == null) throw new ArgumentNullException("unitType");
            if (postalCode == null) throw new ArgumentNullException("postalCode");
            if (city == null) throw new ArgumentNullException("city");
            if (countryCode == null) throw new ArgumentNullException("countryCode");
            if (country == null) throw new ArgumentNullException("country");
            if (displayDate == null) throw new ArgumentNullException("displayDate");
            if (displayTime == null) throw new ArgumentNullException("displayTime");
            Definitions = definitions ?? Enumerable.Empty<TrackingEventDefinition>();
            ConsignmentEvent = consignmentEvent;
            DisplayTime = displayTime;
            DisplayDate = displayDate;
            DateIso = dateIso;
            Country = country;
            CountryCode = countryCode;
            City = city;
            PostalCode = postalCode;
            UnitType = unitType;
            UnitInformationUrl = unitInformationUrl;
            UnitId = unitId;
            RecipientSignature = recipientSignature;
            Status = status;
            Description = description;
        }

        public string Description { get; private set; }
        public string Status { get; private set; }
        public RecipientSignature RecipientSignature { get; private set; }
        public string UnitId { get; private set; }
        public Uri UnitInformationUrl { get; private set; }
        public string UnitType { get; private set; }
        public string PostalCode { get; private set; }
        public string City { get; private set; }
        public string CountryCode { get; private set; }
        public string Country { get; private set; }
        public DateTime DateIso { get; private set; }
        public string DisplayDate { get; private set; }
        public string DisplayTime { get; private set; }
        public bool ConsignmentEvent { get; private set; }
        public IEnumerable<TrackingEventDefinition> Definitions { get; private set; }
    }
}