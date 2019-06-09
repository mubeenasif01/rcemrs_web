using RCEMRS.Web.DAL;
using RCEMRS.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RCEMRS.Web.Controllers
{
    [AllowAnonymous]
    public class MeterController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAllMeter()
        {
            try
            {
                IList<Meter> meter = new List<Meter>();
                meter = new MeterProvider().GetAll();
                return Ok(meter);
            }
            catch (System.Exception)
            {

                throw;
            }
           
        }

        [HttpGet]
        public IHttpActionResult GetAllMeterById(int meterId)
        {
            try
            {
                var meter = new MeterProvider().GetByMeterId(meterId);
                return Ok(meter);
            }
            catch (System.Exception)
            {

                throw;
            }
          
        }

        [HttpGet]
        public IHttpActionResult GetAllActive()
        {
            try
            {
                var meter = new MeterProvider().GetAll().Where(x => x.IsActive == true);
                return Ok(meter);
            }
            catch (System.Exception)
            {

                throw;
            }
           
        }

        [HttpPost]
        public IHttpActionResult GetMeterReading(int meterId, int meterReading, int meterStatus)
        {
            bool result = false;

            try
            {
                result = new MeterProvider().SaveMeterReading(meterId, meterReading, meterStatus);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IHttpActionResult ChangeMeterStatus(int meterId , bool isActive)
        {
            bool result = false;
            try
            {
                result = new MeterProvider().ChangeMeterStatus(meterId, isActive);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //TODO:RegisterMeter Will Also Used For Assigning a New Meter To Already Registered Consumer
        [HttpPost]
        public IHttpActionResult RegisterMeter([FromBody]Meter meter)
        {
            try
            {
                bool result = false;
                result = new MeterProvider().Insert(meter);
                return Ok(result);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IHttpActionResult UpdateMeter([FromBody] Meter meter)
        {
            try
            {
                bool result = false;
                result = new MeterProvider().Update(meter);
                return Ok(result);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IHttpActionResult DeleteMeterById([FromBody] Meter meter)
        {
            try
            {
                bool result = false;
                result = new MeterProvider().Delete(meter);
                return Ok(result);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

       
        #region Mobile Application 

        [HttpGet]
        public IHttpActionResult GetMeterIdByForeignKey(int consumerId)
        {
            try
            {
                IList<Meter> meter = new List<Meter>();
                meter = new MeterProvider().GetAllMeterByForeignKey(consumerId);
                return Ok(meter);
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        [HttpGet]
        public IHttpActionResult GetMeterReadingByMeterId(int meterId)
        {
            try
            {
                IList<MeterReading> billing = new List<MeterReading>();
                billing = new MeterProvider().GetMeterReadingByMeterId(meterId);
                return Ok(billing);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IHttpActionResult GetBillingHistorybyForeignKey(int meterId)
        {
            try
            {
                IList<Billing> billing = new List<Billing>();
                billing = new MeterProvider().GetBillingHistorybyForeignKey(meterId);
                return Ok(billing);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IHttpActionResult ConsumerFeedback(int meterId, int consumerId, string remarks)
        {
            bool result = false;
            try
            {
                result = new MeterProvider().SaveConsumerFeedBack(meterId, consumerId, remarks);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

    }
}
