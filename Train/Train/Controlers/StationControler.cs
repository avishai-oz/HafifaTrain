using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public class StationControler
    {
        public static void Stationcontroler()
        {
            (_, IDBManager stationDB, _, _,_,_) = Interaction.Reboot("C:/Users/avish/Dev/HafifaTrain/Train/Train/DBs");
            Station station1 = new Station(1, "Tel Aviv", new GeographicCoordinate(32.0853, 34.7818));
            Station station2 = new Station(2, "Jerusalem", new GeographicCoordinate(31.7683, 35.2137));
            Station station3 = new Station(3, "Haifa", new GeographicCoordinate(32.7940, 34.9896));
            stationDB.Save(station1);
            stationDB.Save(station2);
            stationDB.Save(station3);
        }
        
        

    }
}
