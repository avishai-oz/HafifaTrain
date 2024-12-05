using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public class WalletService : IWalletService
    {
        public void LoadMoney(IUser user, int amount, IDBManager db)
        {
            user.Wallet += amount;
            db.UpdateAtt(user, "name", "Wallet", user.Wallet);
        }

        public void DeductMoney(IUser user, int amount, IDBManager db)
        {
            user.Wallet -= amount;
            db.UpdateAtt(user, "name", "Wallet", user.Wallet);
        }
    }
}
