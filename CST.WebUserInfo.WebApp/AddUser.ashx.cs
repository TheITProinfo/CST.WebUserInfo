using CST.WebUserInfo.Model;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;

namespace CST.WebUserInfo.WebApp
{
    /// <summary>
    /// Summary description for AddUser
    /// </summary>
    public class AddUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            string UserName = context.Request.Form["txtUserName"];
            string UserPassword = context.Request.Form["txtUserPassword"];
            string UserEmail = context.Request.Form["txtUserEmail"];
            UserInfo userInfo = new UserInfo();
            userInfo.UserName = UserName;
            userInfo.UserPassword = UserPassword;
            userInfo.UserEmail = UserEmail;
            userInfo.CreateDate = System.DateTime.Now;

            BLL.UserInfoService userInfoService = new BLL.UserInfoService();
            if (userInfoService.AddUserInfo(userInfo))
            {
                context.Response.Redirect("UserInfoList.ashx");
            }

            else
            {

                context.Response.Redirect("Error.html");
            }


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}