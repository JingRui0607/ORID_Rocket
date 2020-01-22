using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace ORID_api_Rocket
{
    /// <summary>
    /// EveryPartners 的摘要描述
    /// </summary>
    public class EveryPartners : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string config = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ORIDConnectionString"].ConnectionString;
            SqlConnection Connection = new SqlConnection(config);
           
            DateTime time = DateTime.Now;
            
            SqlCommand command1 = new SqlCommand($"select id, name from Student where endDate>='{time.ToString("yyyy/MM/dd")}' and presence='true'", Connection);
            
            SqlDataAdapter loginAdapter1 = new SqlDataAdapter(command1);
            DataTable user1 = new DataTable();

            loginAdapter1.Fill(user1);
           

            string API = JsonConvert.SerializeObject(user1);
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