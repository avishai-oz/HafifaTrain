using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public interface ITicketService
    {
        public void BuyTicket(IUser user, IStation source, IStation destination, StationService stationService, IDBManager userDB);
        public int CalculatePrice(double distance);
    }
}
