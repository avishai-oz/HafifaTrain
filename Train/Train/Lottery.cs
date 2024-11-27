using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public class Lottery 
    {
        int[] lottery_numbers = new int[6];
        public event EventHandler<LotteryEventArgs> LotteryDrawn;

        public Lottery()
        {
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                lottery_numbers[i] = random.Next(1, 38);
            }
        }

        public int[] GetLotteryNumbers()
        {
            return this.lottery_numbers;
        }

        public void Draw()
        {
            LotteryEventArgs args = new LotteryEventArgs(lottery_numbers);
            LotteryDrawn?.Invoke(this, args);
        }

    }


    
}
