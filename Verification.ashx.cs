using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Newtonsoft.Json;

namespace ORID_api_Rocket
{
    /// <summary>
    /// Verification 的摘要描述
    /// </summary>
    public class Verification : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            
            string token = context.Request["hiddenToken"];
            string tokencContent = PostJsonContent(token);

            //取得隱藏欄位token
            ResponseToken responseToken = JsonConvert.DeserializeObject<ResponseToken>(tokencContent);
            context.Session["verification"] = responseToken.success;
            //verification = bool.Parse(context.Session["verification"].ToString());
            context.Response.Write(context.Session["verification"]);
            if (!string.IsNullOrEmpty(context.Session["verification"].ToString()))
            {
                context.Response.Write("成功");
            }
            else
            {
                context.Response.Write("失敗");
            }
           


        }
        private static string PostJsonContent(string token)
        {
            string key = "6LdGz78UAAAAAATw4hbJKtOcsb07ObYSfO5cCUVc";
            try
            {
                WebRequest request = HttpWebRequest.Create("https://www.google.com/recaptcha/api/siteverify");
                request.Method = "POST";
                //使用 application/x-www-form-urlencoded
                request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";

                //要傳送的資料內容(依字串表示)
                string postData = $"secret={key}&response={token}";
                //將傳送的字串轉為 byte array
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                //告訴 server content 的長度
                request.ContentLength = byteArray.Length;
                //將 byte array 寫到 request stream 中 
                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(byteArray, 0, byteArray.Length);
                }

                using (var httpResponse = (HttpWebResponse) request.GetResponse())
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return result;
                }

            }

            catch (Exception)
            {
                return string.Empty;
            }

        }
        public class ResponseToken
        {
            public DateTime challenge_ts { get; set; }
            public float score { get; set; }
            public string action { get; set; }
            public bool success { get; set; }
            public string hostname { get; set; }
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