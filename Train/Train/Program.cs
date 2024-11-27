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
            CatGambler catGambler = new CatGambler("rivi");
            Gambeler gambeler = new Gambeler("joe");

            catGambler.BuyTicket(lottery);
            gambeler.BuyTicket(lottery);
            lottery.Draw(lottery.GambelType);
        }
    }
}