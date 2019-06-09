using RCEMRS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCEMRS.Web.Service
{
    public class UserServiceBase
    {
        public UserBase GetUserByCredential(string userName , string userPassword)
        {
            UserBase user = new UserBase() { UserId = 1, UserName = "atif", UserPassword = "atif" };

            if (user.UserName == userName && user.UserPassword == userPassword)
            {
                return user;
            }
            else
            {
                return null;
            }
           
        }
    }
}