using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CST.WebUserInfo.BLL;
using CST.WebUserInfo.Model;

namespace CST.WebUserInfo.WebApp.April_26
{
    public partial class ShowUserInfo : System.Web.UI.Page
            {

          public string StrHtml { get; set; }

             public List<UserInfo> UserList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.UserInfoService userInfoService = new UserInfoService();

            List<UserInfo> list= userInfoService.GetUserList();
            UserList = list;

            StringBuilder sb = new StringBuilder();

            foreach (UserInfo userInfo in list)
            {
                sb.AppendFormat(
                    "<tr><td>{0}</td><td>{1}</td></tr>",userInfo.UserName,userInfo.UserPassword
                    
                    );

                StrHtml = sb.ToString();
            
            }
        }
    }
}