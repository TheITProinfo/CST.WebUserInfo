using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CST.WebUserInfo.Model;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace CST.WebUserInfo.DAL
{
    public class UserInfoDal
    {
        #region Get UserList
        public List<UserInfo> GetUserList()

        {
            string sql = "select UserID,UserName,UserPassword,UserAge,UserMobile,UserEmail,DelFlag,Createdate from UserInfo";

            DataTable dt = SqlHelper.GetDataTable(sql, CommandType.Text); // no parameter

            List<UserInfo> list = null;

            if (dt.Rows.Count > 0)
            {
                list = new List<UserInfo>();

                UserInfo userInfo = null;

                foreach (DataRow row in dt.Rows)

                {
                    userInfo = new UserInfo();
                    LoadEntity(userInfo, row);
                    list.Add(userInfo);


                }

            }

            return list;


        }
        #endregion


        #region Load Entity
        private void LoadEntity(UserInfo userInfo, DataRow row)
        {
            // each data in row assigned to userInfo

            userInfo.UserID = Convert.ToInt32(row["UserID"]);

            userInfo.UserName = row["UserName"].ToString();

            userInfo.UserPassword = row["UserPassword"] != DBNull.Value ? row["UserPassword"].ToString() : string.Empty;
            userInfo.UserMobile = row["UserMobile"] != DBNull.Value ? row["UserMobile"].ToString() : string.Empty; userInfo.UserEmail = row["UserEmail"] != DBNull.Value ? row["UserEmail"].ToString() : string.Empty;

            userInfo.UserAge = short.Parse(row["UserAge"] == DBNull.Value ? "18" : row["UserAge"].ToString());
            userInfo.DelFlag = short.Parse(row["DelFlag"] == DBNull.Value ? "0" : row["DelFlag"].ToString());
            userInfo.CreateDate = DateTime.Parse(row["CreateDate"] == DBNull.Value ? SqlDateTime.MinValue.ToString() : row["CreateDate"].ToString());


        }
        #endregion



        #region insert one userInfo to database.
        public int AddUserInfo(UserInfo userInfo)
        {
            string sql = "insert into UserInfo(UserName,UserPassword,UserEmail,CreateDate) values(@UserName,@UserPassword,@UserEmail,@CreateDate)";

            SqlParameter[] pars = {

                   new SqlParameter("@UserName",SqlDbType.VarChar,50),
                   new SqlParameter("UserPassword",SqlDbType.VarChar,50),
                   new SqlParameter("UserEmail",SqlDbType.VarChar,100),
                   new SqlParameter("@CreateDate",SqlDbType.DateTime)

            };
            pars[0].Value = userInfo.UserName;
            pars[1].Value = userInfo.UserPassword;
            pars[2].Value = userInfo.UserEmail;
            pars[3].Value = userInfo.CreateDate;

            return SqlHelper.ExecuteNoQuery(sql, CommandType.Text, pars);


        } 
        #endregion




        //
    }
}
