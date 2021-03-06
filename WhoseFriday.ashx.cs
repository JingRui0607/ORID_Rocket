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
    /// WhoseFriday 的摘要描述
    /// </summary>
    public class WhoseFriday : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            string sql = File.ReadAllText(HttpContext.Current.Server.MapPath("/WhoseFriday.sql"));
            string config = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ORIDConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(config);

            
           
            DataTable user = new DataTable();
            DataTable user2 = new DataTable();
            //string[] Friarray = new string[user.Rows.Count + 1];


            //取得每周目標
            SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@name", SqlDbType.Int);
                command.Parameters["@name"].Value = context.Request.QueryString["Sid"];

              


                SqlDataAdapter Adapter = new SqlDataAdapter(command);
               
                Adapter.Fill(user);

            //取得學員名字
            SqlCommand command2 = new SqlCommand("select name from Student where id=@name", connection);
            command2.Parameters.Add("@name", SqlDbType.Int);
            command2.Parameters["@name"].Value = context.Request.QueryString["Sid"];

            SqlDataAdapter Adapter2 = new SqlDataAdapter(command2);

            Adapter2.Fill(user2);




            //存入陣列
            string[] Friarray = new string[user.Rows.Count + 1];


          

            Friarray[0] = user2.Rows[0][0].ToString();

            for (int i = 1; i <= user.Rows.Count; i++)
            {
                Friarray[i] = user.Rows[i-1][0].ToString();
                
            }



            string API = JsonConvert.SerializeObject(Friarray);

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