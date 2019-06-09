using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCEMRS.Web.Entities
{
    public class Meter:MeterBase
    {
        #region Constructor
        public Meter() : base() { }
        #endregion

        public Int64 CurrentReading { get; set; }

        public string PaymentStatus { get; set; }

        public int ConsumerId { get; set; }
    }
}