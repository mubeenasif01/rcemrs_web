using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCEMRS.Web.Entities
{
    public class MeterBase
    {
        #region Constructor
        protected MeterBase()
        {

        }
        #endregion

        #region Properties
        private Int32 _meterId;
        public virtual Int32 MeterId
        {
            get
            {
                return _meterId;
            }
            set
            {
                _meterId = value;
            }
        }

        private string _meterStatus;
        public virtual string MeterStatus
        {
            get
            {
                return _meterStatus;
            }
            set
            {
                _meterStatus = value;
            }
        }

        private long _meterReading;
        public virtual long MeterReading
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

        private int _meterType;
        public virtual int MeterType
        {
            get
            {
                return _meterType;
            }
            set
            {
                _meterType = value;
            }
        }

        private int _assignMeterId;
        public int AssignMeterId
        {
            get {
                return _assignMeterId;
            }
            set {
                _assignMeterId = value;
            }
        }

        private DateTime _createdDate;
        public DateTime CreatedDate
        {
            get
            {
                return _createdDate;
            }
            set
            {
                _createdDate = value;
            }
        }

        private int _createdBy;
        public int CreatedBy
        {
            get
            {
                return _createdBy;
            }
            set
            {
                _createdBy = value;
            }
        }

        private int? _updatedBy;
        public int? UpdatedBy
        {
            get
            {
                return _updatedBy;
            }
            set
            {
                _updatedBy = value;
            }
        }

        private DateTime? _updatedDate;
        public DateTime? UpdatedDate
        {
            get
            {
                return _updatedDate;
            }
            set
            {
                _updatedDate = value;
            }
        }

        #endregion
    }
}