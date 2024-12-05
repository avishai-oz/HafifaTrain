using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public class GeographicCoordinate
    {
        // Properties for Latitude and Longitude
        public double Latitude { get; set; }  // רוחב
        public double Longitude { get; set; } // אורך

        // Constructor
        public GeographicCoordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        // Method to calculate distance to another geographic coordinate in kilometers
        public double DistanceTo(GeographicCoordinate other)
        {
            const double EarthRadiusKm = 6371.0; // Earth's radius in kilometers

            // Convert degrees to radians
            double lat1Rad = DegreesToRadians(Latitude);
            double lon1Rad = DegreesToRadians(Longitude);
            double lat2Rad = DegreesToRadians(other.Latitude);
            double lon2Rad = DegreesToRadians(other.Longitude);

            // Calculate differences
            double deltaLat = lat2Rad - lat1Rad;
            double deltaLon = lon2Rad - lon1Rad;

            // Apply Haversine formula
            double a = Math.Pow(Math.Sin(deltaLat / 2), 2) +
                       Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                       Math.Pow(Math.Sin(deltaLon / 2), 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return EarthRadiusKm * c; // Distance in kilometers
        }

        // Convert degrees to radians
        private static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

        // Override ToString for better representation
        public override string ToString()
        {
            return $"({Latitude}°, {Longitude}°)";
        }
    }

}
