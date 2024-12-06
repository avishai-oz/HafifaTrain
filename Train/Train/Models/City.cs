using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public class City
    {
        public int cityid { get; set; }
        public string name { get; set; }
        public int population { get; set; }
        public GeographicCoordinate location { get; set; }

        public City(int cityid, string name, int population, GeographicCoordinate coordinate)
        {
            this.cityid = cityid;
            this.name = name;
            this.population = population;
            this.location = coordinate;
        }
    }
}
