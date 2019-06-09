using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCEMRS.Entites
{
    [Serializable]
   public class UserBase
    {
        #region Constructor
        protected UserBase()
        {

        }
        #endregion
        #region Properties

        private string _displayName;
        public virtual string DispalayName
        {
            get
            {
                return _displayName;
            }
            set
            {
                if(_displayName == value)
                _displayName = value;
             
            }
        }

        private Int32 _userId;
        public virtual Int32 UserId
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

        private string _loginName;
        public virtual string LoginName
        {
            get
            {
                return _loginName;
            }
            set
            {
                _loginName = value;
               
            }
        }

        private string _password;
        public virtual string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                
            }
        }

        private string _role;
        public virtual string Role
        {
            get
            {
                return _role;
            }
            set
            {
                
                _role = value;
            }
        }
        #endregion
    }
}
