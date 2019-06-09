using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCEMRS.Web.Entities
{
    public class MeterReading:MeterReadingBase
    {
        #region Constructor
        public MeterReading() : base() { }
        #endregion

        public bool MeterStatus { get; set; }

        public int  MeterId { get; set; }
    }
}