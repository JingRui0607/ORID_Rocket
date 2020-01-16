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
    /// CheckAndTarget 的摘要描述
    /// </summary>
    public class CheckAndTarget : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";//回傳的是文字所以用這行;ORID用Json

            string date = context.Request.Form["date"];

            string get = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ORIDConnectionString"].ConnectionString;
            SqlConnection getConnection = new SqlConnection(get);
            SqlCommand command = new SqlCommand($"select * from ORID_data where 填寫時間>@date and 填寫時間< DATEADD(day, 1, @date) and Sid = @Sid ", getConnection);
            command.Parameters.Add("@date", SqlDbType.DateTime);
            command.Parameters["@date"].Value = Convert.ToDateTime(date);
            command.Parameters.Add("@Sid", SqlDbType.Int);
            command.Parameters["@Sid"].Value = context.Request.Form["Sid"];
            SqlDataAdapter loginAdapter = new SqlDataAdapter(command);


            DataTable user = new DataTable();

            loginAdapter.Fill(user);
            List<string> AAA = new List<string>();




            if (user.Rows.Count > 0)
            {
                //context.Response.Write($"{date}寫過了唷");

                AAA.Add("寫過了");
                string API = JsonConvert.SerializeObject(AAA);

                context.Response.Write(API);//傳出的都是字串
            }

            else
            {
                //context.Response.Write($"{date}這天沒寫過^^再麻煩填寫");
                AAA.Add("沒寫過");

                string sql = File.ReadAllText(HttpContext.Current.Server.MapPath("/ShowTarget.sql"));
                string config = System.Web.Configuration.WebConfigurationManager
                    .ConnectionStrings["ORIDConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(config);

                SqlCommand Command = new SqlCommand(sql, connection);


                Command.Parameters.Add("@date", SqlDbType.DateTime);
                Command.Parameters["@date"].Value =
                    Convert.ToDateTime(context.Server.UrlDecode(context.Request.Form["date"]));

                Command.Parameters.Add("@name", SqlDbType.Int);
                Command.Parameters["@name"].Value = context.Request.Form["Sid"];

                SqlDataAdapter Adapter = new SqlDataAdapter(Command);
                DataTable user2 = new DataTable();
                Adapter.Fill(user2);
                string Target = "";
                if (user2.Rows.Count > 0)
                {
                    Target = user2.Rows[0][0].ToString();

                }

                AAA.Add(Target);
                //JsonConvert.SerializeObject(物件)，將物件序列化成JSON格式的字串。
                string API = JsonConvert.SerializeObject(AAA);

                context.Response.Write(API); //傳出的都是字串
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