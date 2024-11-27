using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public class CatGambler : AbstractGambler
    {
        public CatGambler(string _name)
        {
            name = _name;
        }
        public override void selebration()
        {
            Console.WriteLine("meyao");
        }
    }
}
