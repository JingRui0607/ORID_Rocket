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
    /// TargetofWeek 的摘要描述
    /// </summary>
    public class TargetofWeek : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string sql = File.ReadAllText(HttpContext.Current.Server.MapPath("/TargetofWeek.sql"));

            string config = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ORIDConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(config);

            DataTable user = new DataTable();

            SqlCommand command = new SqlCommand(sql, connection);


            command.Parameters.Add("@Sid", SqlDbType.Int);
            command.Parameters["@Sid"].Value = context.Request.QueryString["Sid"];


            command.Parameters.Add("@week", SqlDbType.Int);
            command.Parameters["@week"].Value = context.Request.QueryString["week"];




            SqlDataAdapter Adapter = new SqlDataAdapter(command);


            Adapter.Fill(user);

            string API1 = JsonConvert.SerializeObject(user);
            //JsonConvert.SerializeObject(物件)，將物件序列化成JSON格式的字串。
            context.Response.Write(API1);//傳出的都是字串

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