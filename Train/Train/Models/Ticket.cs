using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public class Ticket : ITicket
    {
        public int price { get; set; }
        public IStation DestinationStation { get; set; }
        public IStation SourceStation { get; set; }

        public Ticket(int price, IStation DestinationStation, IStation SourceStation)
        {
            this.price = price;
            this.DestinationStation = DestinationStation;
            this.SourceStation = SourceStation;
        }

    }
}
