using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public class User : IUser
    {
        public string name { get; set; }
        public int id { get; set; }
        public Gender Gender { get; set; }
        public int Wallet { get; set; }

        public ITicket ticket { get; set; }

        public User(string name, int id, Gender gender, int wallet , ITicket ticket)
        {
            this.name = name;
            this.id = id;
            Gender = gender;
            Wallet = wallet;
            this.ticket = ticket;
        }
        public User()
        {
        }


    }
}
