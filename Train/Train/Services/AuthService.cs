using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Train
{
    public class AuthService : IUserService
    {
        public void RegisterUser(IUser user, IDBManager db)
        {
            if (Validators.UserNameExists(user.name, db))
            {
                throw new InvalidOperationException("User name already exists.");
            }

            if (Validators.UserIdExists(user.id, db))
            {
                throw new InvalidOperationException("User ID already exists.");
            }

            db.Save(user); 
            Console.WriteLine("User registration successful!");
        }

        public bool SignInUser(string name, int id, IDBManager db)
        {
            var isNameValid = Validators.UserNameExists(name, db);
            var isIdValid = Validators.UserIdExists(id, db);

            return isNameValid && isIdValid;
        }
        


        public AuthService() { }
    }
}