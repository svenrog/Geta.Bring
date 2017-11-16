namespace Geta.Bring.Pickup.Model
{
    public class PickupPoint
    {
        public PickupPoint(
           string id,
           string unitId,
           string name,
           string address,
           string postalCode,
           string city,
           string countryCode,
           string municipality,
           string county,
           string visitingAddress,
           string visitingPostalCode,
           string visitingCity,
           string locationDescription,
           string openingHoursNorwegian,
           string openingHoursEnglish,
           string openingHoursFinnish,
           string openingHoursSwedish,
           string openingHoursDanish,
           double latitude,
           double longitude,
           string utmX,
           string utmY,
           string postenMapsLink,
           string googleMapsLink,
           string distanceInKm,
           string distanceType,
           string type,
           string additionalServiceCode,
           string routeMapsLink)
        {
            Id = id;
            UnitId = unitId;
            Name = name;
            Address = address;
            PostalCode = postalCode;
            City = city;
            CountryCode = countryCode;
            Municipality = municipality;
            Country = county;
            VisitingAddress = visitingAddress;
            VisitingPostalCode = visitingPostalCode;
            VisitingCity = visitingCity;
            LocationDescription = locationDescription;
            OpeningHoursNorwegian = openingHoursNorwegian;
            OpeningHoursEnglish = openingHoursEnglish;
            OpeningHoursFinnish = openingHoursFinnish;
            OpeningHoursSwedish = openingHoursSwedish;
            OpeningHoursDanish = openingHoursDanish;
            Latitude = latitude;
            Longitude = longitude;
            UtmX = utmX;
            UtmY = utmY;
            PostenMapsLink = postenMapsLink;
            GoogleMapsLink = googleMapsLink;
            DistanceInKm = distanceInKm;
            DistanceType = distanceType;
            Type = type;
            AdditionalServiceCode = additionalServiceCode;
            RouteMapsLink = routeMapsLink;
        }

        public string Id { get; private set; }

        public string UnitId { get; private set; }

        public string Name { get; private set; }

        public string Address { get; private set; }

        public string PostalCode { get; private set; }

        public string City { get; private set; }

        public string CountryCode { get; private set; }

        public string Municipality { get; private set; }

        public string Country { get; private set; }

        public string VisitingAddress { get; private set; }

        public string VisitingPostalCode { get; private set; }

        public string VisitingCity { get; private set; }

        public string LocationDescription { get; private set; }

        public string OpeningHoursNorwegian { get; private set; }

        public string OpeningHoursEnglish { get; private set; }

        public string OpeningHoursFinnish { get; private set; }

        public string OpeningHoursDanish { get; private set; }

        public string OpeningHoursSwedish { get; private set; }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public string UtmX { get; private set; }

        public string UtmY { get; private set; }

        public string PostenMapsLink { get; private set; }

        public string GoogleMapsLink { get; private set; }

        public string DistanceInKm { get; private set; }

        public string DistanceType { get; private set; }

        public string Type { get; private set; }

        public string AdditionalServiceCode { get; private set; }

        public string RouteMapsLink { get; private set; }
    }
}