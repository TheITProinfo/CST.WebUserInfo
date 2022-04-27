using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CST.WebUserInfo.DAL
{
   public class SqlHelper
    {
        // static connection string
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;

        #region method getDataTable
        /// <summary>
        /// get ddataTable 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {

                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                {
                    if (pars != null)
                    {
                        adapter.SelectCommand.Parameters.AddRange(pars);
                    }

                    adapter.SelectCommand.CommandType = type;
                    //  adapter.SelectCommand.CommandType=CommandType.Text
                    //  adapter.SelectCommand.CommandType=CommandType.StoreProcedure

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;

                }



            }

        }
        #endregion

        #region Method return affected rows.
        /// <summary>
        /// return affected rows
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static int ExecuteNoQuery(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (pars != null)
                    {
                        cmd.Parameters.AddRange(pars);
                    }

                    cmd.CommandType = type;
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }

            }

        } 
        #endregion

        //
    }
}
