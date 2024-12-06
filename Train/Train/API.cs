using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train;

namespace Train
{
    public class Back4AppService
    {
        private readonly HttpClient _httpClient;

        public Back4AppService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://parseapi.back4app.com/classes/City");

            // הוסף את המפתחות ל-Headers
            _httpClient.DefaultRequestHeaders.Add("X-Parse-Application-Id", "FMtRPHyW13Cq40eKv3yYClvnSbKCcGUYs8WEafsR");
            _httpClient.DefaultRequestHeaders.Add("X-Parse-REST-API-Key", "W9Uc2MiU3Adobd3SbpvIWs2IRbLS1DdFdtiGBSsr");
        }

        // קריאה ל-GET
        public async Task<string> GetCitiesAsync()
        {
            try
            {
                //Console.WriteLine("Starting API call to fetch cities...");
                var response = await _httpClient.GetAsync("");

                // בדיקה האם התגובה מוצלחת
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"API call failed. Status code: {response.StatusCode}");
                    throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
                }

                //Console.WriteLine("API call succeeded. Reading response content...");
                string content = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(content))
                {
                    Console.WriteLine("API returned an empty or whitespace response.");
                    throw new InvalidOperationException("Empty response received from API.");
                }

                //Console.WriteLine("Response content read successfully.");
                return content;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred in GetCitiesAsync: {ex.Message}");
                throw; // מעביר את השגיאה למעלה לטיפול נוסף
            }
        }

        public async Task<string> GetCitiesWithFiltersAsync(string attribute, object value)
        {
            try
            {
                // יצירת dictionary עבור הפילטר
                var filters = new Dictionary<string, object>
        {
            { attribute, value }
        };

                // Serialize the filters dictionary into a JSON string
                string whereClause = JsonConvert.SerializeObject(filters);

                // URL encode the 'where' query
                string query = $"?where={Uri.EscapeDataString(whereClause)}";

                // Perform the GET request with the constructed query
                var response = await _httpClient.GetAsync(query);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"API call failed. Status code: {response.StatusCode}");
                    throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
                }

                string content = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(content))
                {
                    throw new InvalidOperationException("Empty response received from API.");
                }

                return content;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred in GetCitiesWithFiltersAsync: {ex.Message}");
                throw;
            }
        }

    }
    public class ApiResponse
    {
        public List<City> Results { get; set; }
    }

}
