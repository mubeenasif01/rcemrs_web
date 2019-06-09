using RCEMRS.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCEMRS.Entites
{
    public class User : UserBase
    {
        #region Constructors
        public User() : base()
        {
            
        }
        #endregion

        public UserAdditionalnfo userAdditionalInfo { get; set; }

        #region Additional Properties
        public int ConsumerId { get; set; }

        public int MeterId { get; set; }

        public string ConsumerName { get; set; }
        #endregion
    }
}
