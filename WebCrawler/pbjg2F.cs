using EIPLibrary.WebCrawler;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using static prjC349WebMVC.Library.WebCrawler.pbjg2F.Model;

namespace prjC349WebMVC.Library.WebCrawler
{
    public class pbjg2F
    {
        public EIP eip { get; set; }
        public List<Employee> memberList { get { return _memberList; } }
        private List<Employee> _memberList = new List<Employee>();
        public string userId { get; set; }
        public pbjg2F(EIP eipinstance)
        {
            this.eip = eipinstance;
            this._memberList = PostToGetData();
        }
        public class Model
        {
            public class Employee
            {
                [JsonProperty("SUPPORT_DEPT_PBA0")]
                public string SUPPORT_DEPT_PBA0 { get; set; }

                [JsonProperty("EXT")]
                public string EXT { get; set; }

                [JsonProperty("EMP_NAME_PBA0")]
                public string EMP_NAME_PBA0 { get; set; }

                [JsonProperty("EMPNO_PBA0")]
                public string EMPNO_PBA0 { get; set; }

                [JsonProperty("IDNO_PBA0")]
                public string IDNO_PBA0 { get; set; }

                [JsonProperty("CNAME_PBA0")]
                public string CNAME_PBA0 { get; set; }

                [JsonProperty("NAME_1_PCAF")]
                public string NAME_1_PCAF { get; set; }

                [JsonProperty("NEW_DEPT_PBA0")]
                public string NEW_DEPT_PBA0 { get; set; }

                [JsonProperty("EX_SDATE")]
                public string EX_SDATE { get; set; }

                [JsonProperty("EX_CMP")]
                public string EX_CMP { get; set; }

                [JsonProperty("DATE_TMNT_PBA0")]
                public string DATE_TMNT_PBA0 { get; set; }

                [JsonProperty("JOBCODE_PBA0")]
                public string JOBCODE_PBA0 { get; set; }
            }

            public class RootObject
            {
                public string e { get; set; }
                public string id { get; set; }
                public string t { get; set; }
                public Dictionary<string, object> i { get; set; }
                public List<Employee> pbu8Grid { get; set; }
                public string _gk_js_ { get; set; }
                public bool enable { get; set; }
            }
        }
        public List<Employee> PostToGetData()
        {
            List<Employee> returnData = new List<Employee>();
            DateTime qdate = DateTime.Today.Date;
            var days = DateTime.DaysInMonth(qdate.Year, qdate.Month);
            
            try
            {
                string url = "http://erp.csc.com.tw/erp/pb/gul/event/put/gk/_class_pbjc2F.query.go";
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.CookieContainer = eip.cookieContainer;
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
                request.Accept = "application/json;charset=UTF-8";
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                string icd4FormValues = eip.userDept; // 可以透過變數調整                
                string PostData = $"j=%7B%22e%22%3A%22gk%22%2C%20%22id%22%3A%22_class_pbjc2F.query%22%2C%20%22i%22%3A%7B%22src%22%3A%22js_btn_INQUIRE%22%2C%20%22url%22%3A%22http%3A%2F%2Ferp.csc.com.tw%2Ferp%2Fpb%2Fgul%2Fpbjg2F.gul%22%2C%20%22icd4Form%22%3A%7B%22.dirtyField%22%3A%5B%22icd4Form.resign%22%2C%22isAuth%22%2C%22icd4Form.company%22%2C%22icd4Form.queryBy%22%2C%22icd4Form.values%22%5D%2C%20%22icd4Form.company%22%3A%220000%22%2C%20%22icd4Form.queryBy%22%3A%22C%22%2C%20%22icd4Form.values%22%3A%22{icd4FormValues}%22%2C%20%22icd4Form.resign%22%3A%220%22%2C%20%22isAuth%22%3A%22N%22%7D%2C%20%22INQUIRE.label%22%3A%22%E6%9F%A5%E8%A9%A2%22%2C%20%22dez_field%22%3A%7B%22.dirtyField%22%3A%5B%5D%2C%20%22comboBox%22%3A%22icd4Form.company%3Apb.compId%3Afalse%2Cicd4Form.queryBy%3Apb.qryType%3Afalse%22%2C%20%22required%22%3A%22%22%2C%20%22checkBox%22%3A%22%22%2C%20%22date%22%3A%22%22%2C%20%22dez_apFieldTypes%22%3A%22%22%2C%20%22dez_comboDatasrc%22%3A%22%22%7D%2C%20%22dez_apFieldTypes.list%22%3A%5B%5D%2C%20%22dez_comboDatasrc.list%22%3A%5B%7B%22name%22%3A%22icd4Form.queryBy%22%2C%20%22params%22%3A%22compId%3Dicd4Form.icd4Form.company%7CisAuth%3Dicd4Form.isAuth%22%7D%5D%7D%2C%20%22t%22%3A%22map%22%7D";
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(PostData);
                request.ContentLength = bytes.Length;

                //把資料寫入串流，準備發送
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(bytes, 0, bytes.Length);
                    dataStream.Close();
                }
                //看到.GetResponse()才代表真正把 request 送到 伺服器
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
                    {
                        var z = sr.ReadToEnd();
                        z = z.Replace(".enable", "_enable");

                        // 解析JSON數據並映射到C#對象
                        RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(z);
                        returnData = JsonConvert.DeserializeObject <List<Employee>> (rootObject.i.ElementAt(1).Value.ToString());                        
                    }
                }
                return returnData;
            }
            catch
            {
                return returnData;
                //Response.Write("下載失敗,1分鐘後重新下載");
            }

        }
    }
}