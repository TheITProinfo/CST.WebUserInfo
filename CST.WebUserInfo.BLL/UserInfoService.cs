using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CST.WebUserInfo.DAL;
using CST.WebUserInfo.Model;

namespace CST.WebUserInfo.BLL
{
    public class UserInfoService
    {

        DAL.UserInfoDal userInfoDal = new DAL.UserInfoDal();

        public List<UserInfo> GetUserList()

        {
            return userInfoDal.GetUserList();
        }


        // return bool 
        public bool AddUserInfo(UserInfo userInfo)

        {
            return userInfoDal.AddUserInfo(userInfo) > 0;
        }


    //
    }
}
