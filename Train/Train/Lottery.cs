using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public class Lottery : ILottery
    {
        int[] lottery_numbers = new int[6];
        public event Action<LotteryEventArgs> LotteryDrawn;

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
            LotteryEventArgs args = new LotteryEventArgs(lottery_numbers,new Lottery() );
            LotteryDrawn?.Invoke(args);
            Console.WriteLine("the winning numbers are: " + string.Join(", ", lottery_numbers));

        }
        
    }


    
}
