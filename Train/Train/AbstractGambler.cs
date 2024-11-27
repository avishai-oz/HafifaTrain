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

        public abstract void celebration();

        public virtual void HandelLotteryDrawn(LotteryEventArgs e)
        {
            int[] lottery_numbers = e.LotteryNumbers;
            int correct = 0;
            bool win = true;
            int id = e.getid();
            for (int i = 0; i < 6; i++)
            {
                if (lottery_numbers.Contains(ticket[i]))
                {
                    correct++;
                }
                else
                {
                    Console.WriteLine($"{name} not win the lottery!");
                    ticketexpaierd(e.lotteries[id]);
                    win = false;
                    break;
                }
            }
            if (win)
            {
                Console.WriteLine($"{name} won the lottery!");
                celebration();
                ticketexpaierd(e.lotteries[id]);
            }

        }

        public virtual void BuyTicket(ILottery lottery)
        {
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                ticket[i] = random.Next(1, 2);
            }
            Console.WriteLine("You bought a ticket with the numbers: " + string.Join(", ", ticket));
            lottery.LotteryDrawn += HandelLotteryDrawn;
        }

        public virtual void ticketexpaierd(ILottery lottery)
        {
            lottery.LotteryDrawn -= HandelLotteryDrawn;
        }

    }

}
