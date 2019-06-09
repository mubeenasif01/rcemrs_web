using System;
using RCEMRS.Web.Extend;
using System.Web.Http;
using RCEMRS.Entites;
using RCEMRS.Web.DAL;
using System.Net;
using System.Collections.Generic;

namespace RCEMRS.Web.Controllers
{

    public class UserController : ApiController
    {

        [HttpGet]
        public IHttpActionResult GetAllUser()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IList<UserAdditionalnfo> userAdditionalInfo = new List<UserAdditionalnfo>();
                    userAdditionalInfo = new UserAdditionalInfoProvider().GetAllUserInfo();

                    return Ok(userAdditionalInfo);
                }
                else
                {
                    return Ok(HttpStatusCode.InternalServerError);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IHttpActionResult GetUserById(int userId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IList<UserAdditionalnfo> entity = new List<UserAdditionalnfo>();
                    entity = new UserAdditionalInfoProvider().GetUserInfoById(userId);

                    return Ok(entity);
                }
                else
                {
                    return Ok(HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IHttpActionResult AddNewUser([FromBody] UserAdditionalnfo entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool response = new UserAdditionalInfoProvider().GetRegister(entity);

                    return Ok(HttpStatusCode.OK);
                }
                else
                {
                    return Ok(HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IHttpActionResult DeleteUserById(int userId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = new UserAdditionalInfoProvider().DeleteUserByUserId(userId);

                    return Ok(res);
                }
                else
                {
                    return Ok(HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IHttpActionResult AddEditUserByUserId([FromBody] UserAdditionalnfo entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    var res  = new UserAdditionalInfoProvider().UpdateUserProfile(entity);
                    return Ok(res);
                }
                else
                {
                    return Ok(HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
       
    }
}