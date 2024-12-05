using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public class TicketService : ITicketService
    {
        public void BuyTicket(IUser user, IStation source, IStation destination, StationService stationService , IDBManager userDB)
        {
            double distance = stationService.CalculateDistanc(source.location, destination.location);
            int price = CalculatePrice(distance);
            
            userDB.UpdateAtt(user, "name", "Wallet", user.Wallet - price);

        }

        public int CalculatePrice(double distance)
        {
            return (int)((int)distance * 0.1);
        }
    }
}
