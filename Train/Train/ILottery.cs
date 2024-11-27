using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public interface ILottery
    {
        public void Draw(Func<int[]> gambelType);
        public event Action<LotteryEventArgs> LotteryDrawn;
    }
}
