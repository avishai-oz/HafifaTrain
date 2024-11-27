using System.Dynamic;

namespace Train
{
    public class LotteryEventArgs
    {
        public int[] LotteryNumbers { get; private set; }

        public LotteryEventArgs(int[] lotterynumbers)
        {
            LotteryNumbers = lotterynumbers;
        }


    }
}