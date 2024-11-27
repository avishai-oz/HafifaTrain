using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public interface ILotery
    {
        public void Draw(Func<int[]> gambelType);

        public int[] GambelType();
    }
}
