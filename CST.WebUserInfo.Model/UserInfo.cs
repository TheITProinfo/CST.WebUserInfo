using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST.WebUserInfo.Model
{
   public class UserInfo
    {
        public int UserID { get; set; }
        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public string  UserMobile { get; set; }

        public string UserEmail { get; set; }

        public int UserAge { get; set; }

        public DateTime CreateDate { get; set; }

        public short DelFlag { get; set; }



    }
}
