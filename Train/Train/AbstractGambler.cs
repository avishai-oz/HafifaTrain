using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public abstract class AbstractGambler
    {
        public int[] ticket = new int[6];
        public string name { get; set; }

        public abstract void selebration();

        public virtual void HandelLotteryDrawn(object sender, LotteryEventArgs e)
        {
            int[] lottery_numbers = e.LotteryNumbers;
            int correct = 0;
            bool win = true;
            for (int i = 0; i < 6; i++)
            {
                if (lottery_numbers.Contains(ticket[i]))
                {
                    correct++;
                }
                else
                {
                    Console.WriteLine($"{name} not win the lottery!");
                    ticketexpaierd((Lottery)sender);
                    win = false;
                    break;
                }
            }
            if (win)
            {
                Console.WriteLine($"{name} won the lottery!");
                selebration();
                ticketexpaierd((Lottery)sender);
            }
            
        }

        public virtual void BuyTicket(Lottery lottery)
        {
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                ticket[i] = random.Next(1, 2);
            }
            Console.WriteLine("You bought a ticket with the numbers: " + string.Join(", ", ticket));
            lottery.LotteryDrawn += HandelLotteryDrawn;
        }

        public virtual void ticketexpaierd(Lottery lottery)
        {
            lottery.LotteryDrawn -= HandelLotteryDrawn;
        }

    }

}
