using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public interface IUser
    {
        public string name { get; set; }
        public int id { get; set; }
        public Gender Gender { get; set; }
        public int Wallet { get; set; }
        public ITicket ticket { get; set; }
    }
}
