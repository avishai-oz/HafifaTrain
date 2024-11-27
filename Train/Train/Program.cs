using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Lottery lottery = new Lottery();
            Gambeler gambeler = new Gambeler();
            gambeler.BuyTicket(lottery);
            lottery.Draw();
        }
    }
}