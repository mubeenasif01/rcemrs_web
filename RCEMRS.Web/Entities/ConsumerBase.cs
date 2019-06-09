using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCEMRS.Web.Entities
{
    public class ConsumerBase
    {
        #region Constructor
        protected ConsumerBase()
        {

        }
        #endregion

        #region Properties

       private int _consumerId;
       public virtual int ConsumerId
        {
            get
            {
                return _consumerId;
            }
            set
            {
                _consumerId = value;
            }
        }

        private string _consumerName;
        public virtual string ConsumerName
        {
            get
            {
                return _consumerName;
            }
            set
            {
                _consumerName = value;
            }
        }

        private string _consumerFatherName;
        public virtual string ConsumerFatherName
        {
            get
            {
                return _consumerFatherName;
            }
            set
            {
                _consumerFatherName = value;
            }
        }


        private Int64 _consumerCnicNo;
        public virtual Int64 ConsumerCnicNo
        {
            get
            {
                return _consumerCnicNo;
            }
            set
            {
                _consumerCnicNo = value;
            }
        }

        private DateTime _consumerDob;
        public virtual DateTime ConsumerDoB
        {
            get
            {
                return _consumerDob;
            }
            set
            {
                _consumerDob = value;
            }
        }

        private long _consumerPhoneNumber;
        public virtual Int64 ConsumerPhoneNumber
        {
            get
            {
                return _consumerPhoneNumber;
            }
            set
            {
                _consumerPhoneNumber = value;
            }
        }


        private string _consumerAddress;
        public virtual string ConsumerAddress
        {
            get
            {
                return _consumerAddress;
            }
            set
            {

                _consumerAddress = value;
            }
        }

        private DateTime? _createdDate;
        public virtual DateTime? CreatedDate
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
        public virtual int CreatedBy
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
        public virtual int? UpdatedBy
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
        public virtual DateTime? UpdatedDate
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