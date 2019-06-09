using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCEMRS.Web.Entities
{
    public class MeterReadingBase
    {
        #region Constructor
        protected MeterReadingBase()
        {

        }
        #endregion
        #region properties
        public int _readingId;
        public virtual int ReadingId
        {
            get
            {
                return _readingId;
            }
            set
            {
                _readingId = value;
            }
        }

        public Int64 _meterReading;
        public virtual Int64 MeteReading
        {
            get
            {
                return _meterReading;
            }
            set
            {
                _meterReading = value;
            }
        }

        private DateTime _readingDate;
        public virtual DateTime ReadingDate
        {
            get
            {
                return _readingDate;
            }
            set
            {
                _readingDate = value;
            }
        }

        private Int64 _usageCost;
        public virtual Int64 UsageCost
        {
            get
            {
                return _usageCost;
            }
            set
            {
                _usageCost = value;
            }
        }

        private bool _billingStatus;
        public virtual bool BillingStatus
        {
            get
            {
                return _billingStatus;
            }
            set
            {
                _billingStatus = value;
            }
        }

        private Int64? _readingUnit;
        public virtual Int64? ReadingUnit
        {
            get
            {
                return _readingUnit;
            }
            set
            {
                _readingUnit = value;
            }
        }

        private bool _isActive;
        public virtual bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
            }
        }
        #endregion
    }
}