using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCEMRS.Web.Entities
{
    
    public class BillingBase
    {
        #region Constructor
        protected BillingBase(){ }
        #endregion

    #region Properties

        private int _billingId;
        public int BillingId
        {
            get
            {
                return _billingId;
            }
            set
            {
                _billingId = value;
            }
        }

        private Int32 _billingMonth;
        public Int32 BillingMonth
        {
            get
            {
                return _billingMonth;
            }
            set
            {
                _billingMonth = value;
            }
        }

        private DateTime _issueDate;
        public DateTime IssueDate
        {
            get
            {
                return _issueDate;
            }
            set
            {
                _issueDate = value;
            }
        }

        private DateTime _dueDate;
        public DateTime DueDate
        {
            get
            {
                return _dueDate;
            }
            set
            {
                _dueDate = value;
            }
        }

        private Int64 _payableAmount;
        public Int64 PayableAmount
        {
            get
            {
                return _payableAmount;
            }
            set
            {
                _payableAmount = value;
            }
        }

        private Int64 _payableAmountAfterDueDate;
        public Int64 PayableAmountAfterDueDate
        {
            get
            {
                return _payableAmountAfterDueDate;
            }
            set
            {
                _payableAmountAfterDueDate = value;
            }
        }

        private bool _paymentStatus;
        public bool PaymentStatus
        {
            get
            {
                return _paymentStatus;
            }
            set
            {
                _paymentStatus = value;
            }
        }
        #endregion
    }
}