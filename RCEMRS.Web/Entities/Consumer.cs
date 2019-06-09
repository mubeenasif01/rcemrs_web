using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCEMRS.Web.Entities
{
    public class Consumer:ConsumerBase
    {
        #region Constructor
        public Consumer() : base(){
           
        }

        #endregion

        #region Additional Properties
        public int MeterNumber { get; set; }
        public bool MeterStatus { get; set; }
        public int MeterType { get; set; }

        #endregion


    }
}