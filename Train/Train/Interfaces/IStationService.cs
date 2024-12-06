using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Train
{
    public interface IStationService
    {
        double CalculateDistanc(GeographicCoordinate sourc, GeographicCoordinate dest);

    }
}
