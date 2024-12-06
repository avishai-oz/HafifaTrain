using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Train;

namespace Train
{
    public class StationControler
    {
        public static void Stationcontroler()
        {
            (_, IDBManager stationDB, _, _, _, _) = Interaction.Reboot("C:/Users/avish/Dev/HafifaTrain/Train/Train/DBs");
            //Station station1 = new Station(1, "Tel Aviv", new GeographicCoordinate(32.0853, 34.7818));
            //Station station2 = new Station(2, "Jerusalem", new GeographicCoordinate(31.7683, 35.2137));
            //Station station3 = new Station(3, "Haifa", new GeographicCoordinate(32.7940, 34.9896));
            //stationDB.Save(station1);
            //stationDB.Save(station2);
            //stationDB.Save(station3);
        }

        public static async Task PopulateStationsFromAPI()
        {
            (_, IDBManager stationDB, _, _, _, _) = Interaction.Reboot("C:/Users/avish/Dev/HafifaTrain/Train/Train/DBs");
            stationDB.Clear();
            System.Threading.Thread.Sleep(100);
            var back4AppService = new Back4AppService();

            string Citysjson = await back4AppService.GetCitiesAsync();
            //Console.WriteLine($"Received JSON: {stationsJson}");

            if (string.IsNullOrEmpty(Citysjson))
            {
                Console.WriteLine("No data received from the API.");
                return;
            }

            try
            {
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(Citysjson);

                if (apiResponse == null || apiResponse.Results == null || apiResponse.Results.Count == 0)
                {
                    Console.WriteLine("No stations found after deserialization.");
                    return;
                }

                //Console.WriteLine($"Found {apiResponse.Results.Count} stations.");

                foreach (var s in apiResponse.Results)
                {

                    if (s.population > 30000)
                    {
                        Station station = new Station(s.cityid, s.name, s.location);
                        stationDB.Save(station);
                        //Console.WriteLine($"Saving station: {s.name} ({s.id})");
                    }
                }

                //Console.WriteLine("Stations saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }
        }

        
    }
}
