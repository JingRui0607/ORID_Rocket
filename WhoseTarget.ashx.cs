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
    /// WhoseTarget 的摘要描述
    /// </summary>
    public class WhoseTarget : IHttpHandler
    {
        
        public void ProcessRequest(HttpContext context)
        {
            string sql = File.ReadAllText(HttpContext.Current.Server.MapPath("/WhoseTarget.sql"));

            string config = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ORIDConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(config);

            //string date1 = context.Request.QueryString["first_day"];
            //string date2 = context.Request.QueryString["last_day"];

            //double Totaldate = new TimeSpan(Convert.ToDateTime(date2).Ticks - Convert.ToDateTime(date1).Ticks).Days;//計算兩個日期有幾天
            //Totaldate = Totaldate / 7;


          //  List<ORIDTarget> weekTarget =new List<ORIDTarget>();

            


                DataTable user = new DataTable();

                SqlCommand command = new SqlCommand(sql, connection);


                command.Parameters.Add("@Sid", SqlDbType.Int);
                command.Parameters["@Sid"].Value = context.Request.QueryString["Sid"];


             


               
                SqlDataAdapter Adapter = new SqlDataAdapter(command);
              
                
                Adapter.Fill(user);

                //string API = JsonConvert.SerializeObject(user.Rows[0]);

                //ORIDTarget oridJson = JsonConvert.DeserializeObject<ORIDTarget>(API);

                //ORIDTarget orid = new ORIDTarget();
                //if (user.Rows.Count <= 0)
                //{
                   
                //    orid.target = "";
                //    weekTarget.Add(orid);
                //    //weekTarget.Add(user.NewRow());//新增一筆空白資料
                //}
                //else
                //{
                    
                //    orid.target = user.Rows[0][0].ToString();
                //    weekTarget.Add(orid);
                //}

                //weekTarget.Add((API));


            

            //ORIDTarget orid =new ORIDTarget();

            //foreach (var item in weekTarget)
            //{

            //}




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