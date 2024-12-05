using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public interface IStation
    {
        public int id { get; set; }
        public string name { get; set; }
        public GeographicCoordinate location { get; set; }
    }
}
