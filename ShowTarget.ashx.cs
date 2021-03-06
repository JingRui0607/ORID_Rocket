﻿using System;
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
    /// ShowTarget 的摘要描述
    /// </summary>
    public class ShowTarget : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string sql = File.ReadAllText(HttpContext.Current.Server.MapPath("/ShowTarget.sql"));
            string config = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ORIDConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(config);

            SqlCommand Command = new SqlCommand(sql, connection);


            Command.Parameters.Add("@date", SqlDbType.DateTime);
            Command.Parameters["@date"].Value =
                Convert.ToDateTime(context.Server.UrlDecode(context.Request.Form["date"]));

            Command.Parameters.Add("@name", SqlDbType.Int);
            Command.Parameters["@name"].Value = context.Request.Form["name"];

            SqlDataAdapter Adapter = new SqlDataAdapter(Command);
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