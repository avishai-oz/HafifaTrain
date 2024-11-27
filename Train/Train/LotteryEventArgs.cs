using System.Dynamic;

namespace Train
{
    public class LotteryEventArgs
    {
        public int[] LotteryNumbers { get; private set; }
        public Dictionary<int,Lottery> lotteries = new Dictionary<int, Lottery>();
        static int id = 0;

        public LotteryEventArgs(int[] lotterynumbers, Lottery lottery)
        {
            LotteryNumbers = lotterynumbers;
            lotteries.Add(id, lottery);
        }

        public int getid() { return id; }
    }
}