using System;
using RCEMRS.Web.Extend;
using System.Web.Http;
using RCEMRS.Entites;
using RCEMRS.Web.DAL;
using System.Net;
using System.Collections.Generic;

namespace RCEMRS.Web.Controllers
{
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        /// <summary>
        /// Method to Authenticate User and will return session token to user 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        
        [HttpPost]
        public IHttpActionResult UserLogin([FromBody]User user)
        {
            try
            {
                var doesExist = new UserProvider().VerifyLogin(user);

                if (doesExist)
                    return Ok(Security.SessionToken.GenerateToken(user.LoginName));
                else
                    throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IHttpActionResult ConsumerLogin([FromBody]User user)
        {
            try
            {
                var userName = new UserProvider().VerfiyMobileUser(user);

                if (userName != null)
                    return Ok(Security.SessionToken.GenerateToken(userName.ConsumerName));
                else
                    throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}