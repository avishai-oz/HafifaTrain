using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public class StationService : IStationService
    {
        public double CalculateDistanc(GeographicCoordinate sourc, GeographicCoordinate dest)
        {
            return sourc.DistanceTo(dest);
        }

        public static async Task<Station> GetStation(string stationName)
        {
            try
            {
                var back4AppService = new Back4AppService();

                // חיפוש תחנה לפי שם
                string filteredCitiesJson = await back4AppService.GetCitiesWithFiltersAsync("name", stationName);

                // פירוש התוצאה מה-JSON
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(filteredCitiesJson);

                if (apiResponse == null || apiResponse.Results == null || apiResponse.Results.Count == 0)
                {
                    Console.WriteLine($"Station '{stationName}' does not exist.");
                    return null;
                }

                // לקיחת התחנה הראשונה בתוצאה
                var city = apiResponse.Results.First();

                // יצירת אובייקט תחנה והחזרתו
                Station station = new Station(city.cityid, city.name, new GeographicCoordinate(city.location.Latitude, city.location.Longitude));
                return station;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred in GetStation: {ex.Message}");
                return null;
            }
        }
    }
}
