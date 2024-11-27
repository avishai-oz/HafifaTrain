using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Train
{
    public class Gambeler : AbstractGambler
    {

        public Gambeler(string _name)
        {
            name = _name;
        }

        public override void celebration()
        {
            Console.WriteLine("OMG Arela i love you");
        }
    }
}
