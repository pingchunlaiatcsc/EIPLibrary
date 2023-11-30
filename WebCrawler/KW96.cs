using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EIPLibrary.WebCrawler
{
    public class KW96
    {
        public EIP eip { get; set; }
        public string RedirectUrl { get { return _RedirectUrl; } }
        private string _RedirectUrl = "";
        public Model ReturnData { get { return _ReturnData; } }
        private Model _ReturnData = new KW96.Model();
        public List<string> dutyOfficer { get { return _dutyOfficer; } }
        private List<string> _dutyOfficer = new List<string>();
        public string warehouse;
        public KW96(EIP eip, Model model)
        {
            this.eip = eip;
            _ReturnData = model;
        }

        public class Model
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Dept { get; set; }
            public string Date { get; set; }
            public string Time { get; set; }
            public string Vendor { get; set; }
            public string Category { get; set; }
            public string RocYear { get; set; }
            public string RocMonth { get; set; }
            public string RocDay { get; set; }
        }

        public void Read()
        {
            string url = $"http://mvatcp.csc.com.tw:7080/CICS/KW96/KWOI96/{eip.userId}";
            _RedirectUrl = url;

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.CookieContainer = eip.cookieContainer;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
            request.Accept = "application/json;charset=UTF-8";
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            string PostData = $"PREV_FUNC=I" +
            $"USER_ID={eip.userId}" +
            $"INQ_DATE_KW96={ReturnData.RocYear}{ReturnData.RocMonth.PadLeft(2, '0')}{ReturnData.RocDay.PadLeft(2, '0')}" +
            $"INQ_DEPT_KW96={ReturnData.Dept}" +
            $"INQ_VENDOR_KW96={ReturnData.Vendor}" +
            $"FUNC=I" +
            $"SEL_KW96: =1.%BCt%B0%D3";
            string postData = string.Format(PostData);
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;

            //把postData轉成資料串流
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(bytes, 0, bytes.Length);
                dataStream.Close();
            }

            //看到.GetResponse()才代表真正把 request 送到 伺服器
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    var z = sr.ReadToEnd();
                    var document = new HtmlAgilityPack.HtmlDocument();
                    document.LoadHtml(z);
                    ExtractLogWorkshopDataToModel(document);
                }
            }
        }
        public void ExtractLogWorkshopDataToModel(HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            //_PostData.TextBox14 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='TextBox14']").GetAttributeValue("value", "");
            //_PostData.TextBox1 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='TextBox1']").GetAttributeValue("value", "");
            //_PostData.DropDownList11 = htmlDocument.DocumentNode.SelectSingleNode("//select[@id='DropDownList11']/option[@selected='selected']").GetAttributeValue("value", "");
            //_PostData.DropDownList3 = htmlDocument.DocumentNode.SelectSingleNode("//select[@id='DropDownList3']/option[@selected='selected']").GetAttributeValue("value", "");
            //_PostData.DropDownList2 = htmlDocument.DocumentNode.SelectSingleNode("//select[@id='DropDownList2']/option[@selected='selected']").GetAttributeValue("value", "");
            //_PostData.DropDownList4 = htmlDocument.DocumentNode.SelectSingleNode("//select[@id='DropDownList4']/option[@selected='selected']").GetAttributeValue("value", "");
            //_PostData.TextBox3 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='TextBox3']").GetAttributeValue("value", "");
            //_PostData.TextBox4 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='TextBox4']").GetAttributeValue("value", "");
            //_PostData.DropDownList5 = htmlDocument.DocumentNode.SelectSingleNode("//select[@id='DropDownList5']/option[@selected='selected']").GetAttributeValue("value", "");
            //var optionNodes = htmlDocument.DocumentNode.SelectNodes("//select[@id='DropDownList5']/option");
            //foreach (var optionNode in optionNodes)
            //{
            //    dutyOfficer.Add(optionNode.InnerText);
            //}
            //_PostData.TextBox5 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='TextBox5']").GetAttributeValue("value", "");
            //_PostData.TextBox6 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='TextBox6']").GetAttributeValue("value", "");
            //_PostData.DropDownList6 = htmlDocument.DocumentNode.SelectSingleNode("//select[@id='DropDownList6']/option[@selected='selected']").GetAttributeValue("value", "");
            //_PostData.TextBox7 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='TextBox7']").GetAttributeValue("value", "");
            //_PostData.TextBox8 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='TextBox8']").GetAttributeValue("value", "");
            //_PostData.TextBox9 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='TextBox9']").GetAttributeValue("value", "");
            //_PostData.TextBox10 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='TextBox10']").GetAttributeValue("value", "");
            //_PostData.TextBox11 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='TextBox11']").GetAttributeValue("value", "");
            //_PostData.TextBox18 = htmlDocument.DocumentNode.SelectSingleNode("//textarea[@id='TextBox18']").InnerText;



        }


    }
}
