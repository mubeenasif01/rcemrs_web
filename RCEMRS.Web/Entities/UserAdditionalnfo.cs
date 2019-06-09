using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCEMRS.Entites
{
     public class UserAdditionalnfo: UserAdditionalInfoBase
    {
        #region Constructor
        public UserAdditionalnfo() : base() { }
        #endregion

        public string UserLoginName { get; set; }

        public string UserPassword { get; set; }

        public string DisplayName { get; set; }

        public string Role { get; set; }


    }
}
