using RCEMRS.Entites;
using RCEMRS.Web.DAL;
using RCEMRS.Web.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RCEMRS.Web.Controllers
{
    public class ConsumerController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAllConsumer()
        {
            try
            {
                var entity = new ConsumerProvider().GetAll();
                return Ok(entity);
            }
            catch (Exception ex)
            {

                return Ok(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetConsumerById(int consumerId)
        {
            var entity = new ConsumerProvider().GetByConsumerId(consumerId);
            return Ok(entity);
        }

        [HttpGet]
        public IHttpActionResult GetAllActive()
        {
            var entity = new ConsumerProvider().GetAll().Where(x => x.IsActive == true);
            return Ok(entity);
        }

        [HttpPost]
        public IHttpActionResult AddNewConsumer([FromBody] Consumer entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = new ConsumerProvider().RegisterConsumer(entity);
                    return Ok(res);
                }
                else
                {
                    return Ok("Object is invalid");
                }

            }
            catch (Exception ex)
            {

                return Ok(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult UpdateConsumer(Consumer entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = new ConsumerProvider().Update(entity);
                    return Ok(response);
                }
                else
                {
                    return Ok("Object is invalid");
                }
            }
            catch (Exception ex)
            {

                return Ok(ex); 
            }

        }

        [HttpPost]
        public IHttpActionResult DeleteConsumer(int consumerId)
        {

            try
            {
                Consumer entity = new Consumer()
                {
                    ConsumerId = consumerId
                };
                var response = new ConsumerProvider().Delete(entity);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult DeleteConsumerMeterDetail(int consumerId)
        {
            try
            {
                var response = new ConsumerProvider().DeleteConsumerMeterDetail(consumerId);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult IsActiveConsumer(int consumerId, bool isActive)
        {
            try
            {
                var result = new ConsumerProvider().IsActiveConsumer(consumerId, isActive);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return Ok(ex);
            }
        }

    }
}
