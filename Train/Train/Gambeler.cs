using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Train
{
    internal class Gambeler
    {
        int[] ticket = new int[6];
    
        public Gambeler()
        {
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                ticket[i] = random.Next(1, 38);
            }
        }

        public int[] GetTicket()
        {
            return this.ticket;
        }

        public void HandelLotteryDrawn(object sender, LotteryEventArgs e)
        {
            int[] lottery_numbers = e.LotteryNumbers;
            int correct = 0;
            for (int i = 0; i < 6; i++)
            {
                if (lottery_numbers.Contains(ticket[i]))
                {
                    correct++;
                }
            }
            Console.WriteLine("the winning numbers are: " + string.Join(", ", lottery_numbers));
            if (correct == 6)
            {
                Console.WriteLine("You won the lottery!");
            }
            else
            {
                Console.WriteLine("You did not win the lottery!");
            }
            ticketexpaierd((Lottery)sender);
        }

        public void BuyTicket(Lottery lottery)
        {
            Console.WriteLine("You bought a ticket with the numbers: " + string.Join(", ", ticket));
            lottery.LotteryDrawn += HandelLotteryDrawn;
        }

        public void ticketexpaierd(Lottery lottery)
        {
            lottery.LotteryDrawn -= HandelLotteryDrawn;
        }


    }
        
    
}
