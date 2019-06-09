using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCEMRS.Web.Entities
{
    public class Billing:BillingBase
    {
        #region Constructor
        public Billing() : base() { }
        #endregion

        #region Additional Properties
        public int MeterId { get; set; }

        #endregion
    }
}