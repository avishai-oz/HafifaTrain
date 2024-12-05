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

        //public Station GetStationById(int id)
        //{
        //    // not implemented yet
        //}
    }
}
