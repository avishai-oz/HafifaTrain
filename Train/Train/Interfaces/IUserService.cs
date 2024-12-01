﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public interface IUserService
    {
        public void RegisterUser(IUser user);
        public void SignInUser(IUser user);
    }
}