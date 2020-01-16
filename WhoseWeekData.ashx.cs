using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ORID_api_Rocket
{
    /// <summary>
    /// WhoseWeekData 的摘要描述
    /// </summary>
    public class WhoseWeekData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string sql = File.ReadAllText(HttpContext.Current.Server.MapPath("/WhoseWeekData.sql"));

            string config = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ORIDConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(config);



            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.Add("@name", SqlDbType.Int);
            command.Parameters["@name"].Value = context.Request.QueryString["Sid"];

            command.Parameters.Add("@monday", SqlDbType.DateTime);
            command.Parameters["@monday"].Value = Convert.ToDateTime(context.Server.UrlDecode(context.Request.QueryString["first_mon"]));

            command.Parameters.Add("@week", SqlDbType.Int);
            command.Parameters["@week"].Value = context.Server.UrlDecode(context.Request.QueryString["week"]);


            SqlDataAdapter Adapter = new SqlDataAdapter(command);
            DataTable user = new DataTable();
            Adapter.Fill(user);

            string API = JsonConvert.SerializeObject(user);
            //JsonConvert.SerializeObject(物件)，將物件序列化成JSON格式的字串。
            context.Response.Write(API);//傳出的都是字串
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