using CST.WebUserInfo.Model;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;

namespace CST.WebUserInfo.WebApp
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //context.Response.Write("Hello World");

            BLL.UserInfoService userInfoService = new BLL.UserInfoService();

            List<UserInfo> list = userInfoService.GetUserList();

            StringBuilder sb = new StringBuilder();

            foreach (UserInfo userinfo in list)

            {
                sb.AppendFormat(

                    "<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td></tr>",

                   userinfo.UserID, userinfo.UserName, userinfo.UserPassword, userinfo.UserMobile, userinfo.UserEmail, userinfo.DelFlag, userinfo.CreateDate.ToShortDateString());

            }



            // get file path
            string filePath = context.Request.MapPath("UserInfoList.html");
            string fileContent = File.ReadAllText(filePath);
            fileContent = fileContent.Replace("@tbody", sb.ToString());

            context.Response.Write(fileContent);




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