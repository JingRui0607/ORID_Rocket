using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ORID_api_Rocket
{
    /// <summary>
    /// SelectStudents 的摘要描述
    /// </summary>
    public class SelectStudents : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string config = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ORIDConnectionString"].ConnectionString;
            SqlConnection Connection = new SqlConnection(config);
            SqlCommand command1 = new SqlCommand(" SELECT id,name, image,class, startDate, endDate, exOccupation, futureOccupation  FROM  Student where presence='true' ", Connection);
            //SqlCommand command1 = new SqlCommand(" SELECT name, class FROM  Students ", Connection);
            


            SqlDataAdapter loginAdapter1 = new SqlDataAdapter(command1);
            DataTable user1 = new DataTable();

           
         

            JArray jArray=new JArray();
           




            loginAdapter1.Fill(user1);



            int maxClass = Convert.ToInt32(user1.AsEnumerable().Max(x => x["class"]));


            for (int i = 1; i <= maxClass; i++)
            {
                JArray jArray2 = new JArray();
                //DataView dataView=new DataView(user1);
                //dataView.RowFilter = "class="+i;

                DataRow[] dataRows = user1.Select("class=" + i);


                //JObject jObject = new JObject(user1.AsEnumerable().Where(x=>Convert.ToInt32(x["class"])==i));
                foreach (DataRow dataRow in dataRows)
                {
                    //JObject jObject = new JObject {{"class", i}, {"name", dataRow["name"].ToString()}};
                    JObject jObject = new JObject {{"id",Convert.ToInt32(dataRow["id"])}, { "class", i }, { "name", dataRow["name"].ToString() }, { "image", dataRow["image"].ToString() }, { "startDate", dataRow["startDate"].ToString() }, { "endDate", dataRow["endDate"].ToString() } , { "exOccupation", dataRow["exOccupation"].ToString() } , { "futureOccupation", dataRow["futureOccupation"].ToString() } }; 
                    jArray2.Add(jObject);
                }

                
                    
                jArray.Add(jArray2);
                

                
                

            }


            string API = JsonConvert.SerializeObject(jArray);
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