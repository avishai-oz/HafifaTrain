using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public interface ITicket
    {
        public int price { get; set; }
        public IStation DestinationStation { get; set; }
        public IStation SourceStation { get; set; }
    }
}
