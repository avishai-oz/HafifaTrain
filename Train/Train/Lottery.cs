using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public class Lottery : ILotery
    {
        int[] lottery_numbers = new int[6];
        public event EventHandler<LotteryEventArgs> LotteryDrawn;

        public Lottery()
        {
           
        }

        public int[] GambelType()
        {
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                lottery_numbers[i] = random.Next(1, 2);
            }
            return lottery_numbers;
        }
        public void Draw(Func<int[]> gambelType)
        {
            lottery_numbers = gambelType();
            LotteryEventArgs args = new LotteryEventArgs(lottery_numbers);
            LotteryDrawn?.Invoke(this, args);
            Console.WriteLine("the winning numbers are: " + string.Join(", ", lottery_numbers));

        }
        
    }


    
}
