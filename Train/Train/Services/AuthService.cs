using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Train
{
    public class AuthService : IUserService
    {
        public void RegisterUser(IUser user)
        {
            DBUserManager db = new DBUserManager();
            db.SaveUser(user);
        }
        public void SignInUser(IUser user)
        {
            // Sign in user
        }
    }
}