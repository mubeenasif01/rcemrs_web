using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCEMRS.Entites
{
    public class UserAdditionalInfoBase
    {
        #region Constructor
        protected UserAdditionalInfoBase()
        {

        }
        #endregion
        #region Properties

        private int? _createdBy;
        public virtual int? CreatedBy
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

        private int _userAdditionalInfoId;
        public virtual int UserAdditionalInfoId
        {
            get
            {
                return _userAdditionalInfoId;
            }
            set
            {
                _userAdditionalInfoId = value;

            }
        }

        private string _firstName;
        public virtual string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;

            }
        }

        private int _isActive;
        public virtual int IsActive
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

        private string _lastName;
        public virtual string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        private string _address;
        public virtual string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }

        private string _email;
        public virtual string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;

            }
        }

        private Int64 _phoneNumber;
        public virtual Int64 PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
            }
        }

        private Int64 _cnicNumber;
        public virtual Int64 CnicNumber 
        {
            get
            {
                return _cnicNumber;
            }
            set
            {
                _cnicNumber = value;
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

        private int _userId;
        public virtual int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }

        #endregion
    }
}
