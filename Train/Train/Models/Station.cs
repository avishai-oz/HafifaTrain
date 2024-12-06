using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public class Station : IStation
    {
        public int id { get; set; }
        public string name { get; set; }
        public GeographicCoordinate location { get; set; }
        public Station(int id, string name, GeographicCoordinate location)
        {
            this.id = id;
            this.name = name;
            this.location = location;
        }
    }
}
