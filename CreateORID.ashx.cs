using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Newtonsoft.Json;

namespace ORID_api_Rocket
{
    /// <summary>
    /// CreateORID 的摘要描述
    /// </summary>
    public class CreateORID : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {

            try
            {
                //    bool verification = bool.Parse(context.Session["verification"].ToString());
                //if (verification != true)
                //{
                //    context.Response.Write("機器人來來來!哩來");
                //    return;
                //}
                //else
                //{




                string sql = File.ReadAllText(HttpContext.Current.Server.MapPath("/CreateORID.sql"));
                string config = System.Web.Configuration.WebConfigurationManager
                    .ConnectionStrings["ORIDConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(config);

                SqlCommand Command = new SqlCommand(sql, connection);

                Command.Parameters.Add("@date", SqlDbType.DateTime);
                Command.Parameters["@date"].Value =
                    Convert.ToDateTime(context.Server.UrlDecode(context.Request.Form["date"]));
                Command.Parameters.Add("@name", SqlDbType.Int);
                Command.Parameters["@name"].Value = context.Request.Form["name"];
                Command.Parameters.Add("@target", SqlDbType.NVarChar);
                Command.Parameters["@target"].Value = context.Request.Unvalidated.Form["target"];
                Command.Parameters.Add("@reach", SqlDbType.NVarChar);
                Command.Parameters["@reach"].Value = context.Request.Form["reach"];
                Command.Parameters.Add("@mood", SqlDbType.NVarChar);
                Command.Parameters["@mood"].Value = context.Request.Form["mood"];
                Command.Parameters.Add("@process", SqlDbType.NVarChar);
                Command.Parameters["@process"].Value = context.Request.Unvalidated.Form["process"];
                Command.Parameters.Add("@sentiment", SqlDbType.NVarChar);
                Command.Parameters["@sentiment"].Value = context.Request.Unvalidated.Form["sentiment"];
                Command.Parameters.Add("@comprehension", SqlDbType.NVarChar);
                Command.Parameters["@comprehension"].Value = context.Request.Unvalidated.Form["comprehension"];
                Command.Parameters.Add("@strive", SqlDbType.NVarChar);
                Command.Parameters["@strive"].Value = context.Request.Unvalidated.Form["strive"];
                Command.Parameters.Add("@Friday", SqlDbType.NVarChar);
                Command.Parameters["@Friday"].Value = context.Request.Unvalidated.Form["Friday"];



                connection.Open();
                Command.ExecuteNonQuery();
                connection.Close();

                context.Response.Write("成功!");
               
            //}
            }
            catch
            {
                context.Response.Write("有任何問題!請找美麗ㄉ宜蓁處理^^");
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