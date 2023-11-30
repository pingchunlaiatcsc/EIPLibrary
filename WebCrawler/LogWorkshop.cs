using EIPLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class LogWorkshop
    {
        public EIP eip { get; set; }
        public string RedirectUrl { get { return _RedirectUrl; } }
        private string _RedirectUrl = "";
        public Model PostData { get { return _PostData; } }
        private Model _PostData = new LogWorkshop.Model();
        public List<string> dutyOfficer { get { return _dutyOfficer; } }
        private List<string> _dutyOfficer = new List<string>();
        public string warehouse;        
        public LogWorkshop(EIP eip, Model model)
        {
            this.eip = eip;
            _PostData = model;
        }

        private void GetViewState_ViewStateGenerator_EventValidation(EIP eip)
        {
            _PostData.__VIEWSTATE = "";
            _PostData.__VIEWSTATEGENERATOR = "";
            _PostData.__EVENTVALIDATION = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_RedirectUrl);
            //set the cookie container object
            request.CookieContainer = eip.cookieContainer;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            //set method POST and content type application/x-www-form-urlencoded
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";

            //看到.GetResponse()才代表真正把 request 送到 伺服器
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default))
                {
                    var z = sr.ReadToEnd();
                    var document = new HtmlAgilityPack.HtmlDocument();
                    document.LoadHtml(z);

                    //注意:直接從chropath插件複製出來的xPath會有/tbody/、/div/這一層，有時候要刪掉、調整才能正常讀取(div亂序)
                    
                    _PostData.__VIEWSTATE = document.DocumentNode.SelectSingleNode("//input[@id='__VIEWSTATE']").GetAttributeValue("value", "default");
                    _PostData.__VIEWSTATEGENERATOR = document.DocumentNode.SelectSingleNode("//input[@id='__VIEWSTATEGENERATOR']").GetAttributeValue("value", "default");
                    _PostData.__EVENTVALIDATION = document.DocumentNode.SelectSingleNode("//input[@id='__EVENTVALIDATION']").GetAttributeValue("value", "default");
                }
            }
        }

        public class Model
        {
            public string __VIEWSTATE { get; set; }
            public string __VIEWSTATEGENERATOR { get; set; }
            public string __EVENTVALIDATION { get; set; }
            public string TextBox14 { get; set; }
            public string TextBox1 { get; set; }
            public string DropDownList11 { get; set; }
            public string DropDownList3 { get; set; }
            public string UserLog { get; set; }
            public string DropDownList2 { get; set; }
            public string DropDownList4 { get; set; }
            public string TextBox3 { get; set; }
            public string TextBox4 { get; set; }
            public string DropDownList5 { get; set; }
            public string TextBox5 { get; set; }
            public string TextBox6 { get; set; }
            public string DropDownList6 { get; set; }
            public string TextBox7 { get; set; }
            public string TextBox8 { get; set; }
            public string TextBox9 { get; set; }
            public string TextBox10 { get; set; }
            public string TextBox11 { get; set; }
            public string TextBox18 { get; set; }
            public string AA1 { get; set; }
            public string AA2 { get; set; }
            public string AA3 { get; set; }
            public string AA4 { get; set; }
            public string AA5 { get; set; }
            public string AA6 { get; set; }
            public string AA7 { get; set; }
            public string AA8 { get; set; }
            public string AA9 { get; set; }
            public string AA10 { get; set; }
            public string AA11 { get; set; }
            public string AA12 { get; set; }
            public string AA13 { get; set; }
            public string AA14 { get; set; }
            public string AA15 { get; set; }
            public string AA16 { get; set; }
            public string AA17 { get; set; }
            public string AA18 { get; set; }
            public string AA19 { get; set; }
            public string AA20 { get; set; }
            public string AA21 { get; set; }
            public string AA22 { get; set; }
            public string AA23 { get; set; }
            public string AA24 { get; set; }
            public string AA25 { get; set; }
            public string AA26 { get; set; }
            public string AA27 { get; set; }
            public string AA28 { get; set; }
            public string AA29 { get; set; }
            public string AA30 { get; set; }
            public string AA31 { get; set; }
            public string AA32 { get; set; }
            public string AA33 { get; set; }
            public string AA34 { get; set; }
            public string AA35 { get; set; }
            public string AA36 { get; set; }
            public string AA37 { get; set; }
            public string AA38 { get; set; }
            public string AA39 { get; set; }
            public string AA40 { get; set; }
            public string AA41 { get; set; }
            public string AA42 { get; set; }
            public string AA43 { get; set; }
            public string AA44 { get; set; }
            public string AA45 { get; set; }
            public string AA46 { get; set; }
            public string AA47 { get; set; }
            public string AA48 { get; set; }
            public string AA49 { get; set; }
            public string AA50 { get; set; }
            public string AA51 { get; set; }
            public string AA52 { get; set; }
            public string AA53 { get; set; }
            public string AA54 { get; set; }
            public string AA55 { get; set; }
            public string AA56 { get; set; }
            public string AA57 { get; set; }
            public string AA58 { get; set; }
            public string AA59 { get; set; }
            public string AA60 { get; set; }
            public string AB1 { get; set; }
            public string AB2 { get; set; }
            public string AB3 { get; set; }
            public string AB4 { get; set; }
            public string AB5 { get; set; }
            public string AB6 { get; set; }
            public string AC1 { get; set; }
            public string AC2 { get; set; }
            public string AC3 { get; set; }
            public string AC4 { get; set; }
            public string AC5 { get; set; }
            public string AC6 { get; set; }
            public string FileUpload1 { get; set; }
            public string WriteXml { get; set; }
            public string DropDownList7 { get; set; }
        }

        public void Read()
        {
            string deptNum = "";
            switch (_PostData.DropDownList2)
            {
                case "41":
                    deptNum = "0";
                    break;
                case "42":
                    deptNum = "1";
                    break;
                case "45":
                    deptNum = "2";
                    break;
                case "46":
                    deptNum = "3";
                    break;
                case "48":
                    deptNum = "4";
                    break;
                case "49":
                    deptNum = "5";
                    break;
                default:
                    Console.WriteLine("單位異常");
                    break;
            }
            string turnNum = "";
            switch (_PostData.DropDownList4)
            {
                case "夜":
                    turnNum = "0";
                    break;
                case "早":
                    turnNum = "1";
                    break;
                case "中":
                    turnNum = "2";
                    break;
                default:
                    Console.WriteLine("班別異常");
                    break;
            }
            string url = $"https://dept.csc.com.tw/MIS/C34/C34Web/LogWorkshop.aspx?numm1={_PostData.TextBox14}&numm2={_PostData.TextBox1}&numm3={_PostData.DropDownList11}&numm4={deptNum}&numm5={turnNum}";
            //string url = "https://dept.csc.com.tw/MIS/C34/C34Web/LogWorkshop.aspx?numm1=112&numm2=7&numm3=30&numm4=0&numm5=2";
            _RedirectUrl = url;
            
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.CookieContainer = eip.cookieContainer;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
            request.Accept = "application/json;charset=UTF-8";
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";

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
            _PostData.TextBox14 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='TextBox14']").GetAttributeValue("value", "");
            _PostData.TextBox1 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='TextBox1']").GetAttributeValue("value", "");
            _PostData.DropDownList11 = htmlDocument.DocumentNode.SelectSingleNode("//select[@id='DropDownList11']/option[@selected='selected']").GetAttributeValue("value", "");
            _PostData.DropDownList3 = htmlDocument.DocumentNode.SelectSingleNode("//select[@id='DropDownList3']/option[@selected='selected']").GetAttributeValue("value", "");
            _PostData.DropDownList2 = htmlDocument.DocumentNode.SelectSingleNode("//select[@id='DropDownList2']/option[@selected='selected']").GetAttributeValue("value", "");
            _PostData.DropDownList4 = htmlDocument.DocumentNode.SelectSingleNode("//select[@id='DropDownList4']/option[@selected='selected']").GetAttributeValue("value", "");
            _PostData.TextBox3 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='TextBox3']").GetAttributeValue("value", "");
            _PostData.TextBox4 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='TextBox4']").GetAttributeValue("value", "");
            _PostData.DropDownList5 = htmlDocument.DocumentNode.SelectSingleNode("//select[@id='DropDownList5']/option[@selected='selected']").GetAttributeValue("value", "");
            var optionNodes = htmlDocument.DocumentNode.SelectNodes("//select[@id='DropDownList5']/option");
            foreach (var optionNode in optionNodes)
            {
                dutyOfficer.Add(optionNode.InnerText);
            }
            _PostData.TextBox5 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='TextBox5']").GetAttributeValue("value", "");
            _PostData.TextBox6 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='TextBox6']").GetAttributeValue("value", "");
            _PostData.DropDownList6 = htmlDocument.DocumentNode.SelectSingleNode("//select[@id='DropDownList6']/option[@selected='selected']").GetAttributeValue("value", "");
            _PostData.TextBox7 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='TextBox7']").GetAttributeValue("value", "");
            _PostData.TextBox8 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='TextBox8']").GetAttributeValue("value", "");
            _PostData.TextBox9 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='TextBox9']").GetAttributeValue("value", "");
            _PostData.TextBox10 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='TextBox10']").GetAttributeValue("value", "");
            _PostData.TextBox11 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='TextBox11']").GetAttributeValue("value", "");
            _PostData.TextBox18 = htmlDocument.DocumentNode.SelectSingleNode("//textarea[@id='TextBox18']").InnerText;

            try
            {
                _PostData.AA1 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA1']").GetAttributeValue("value", "");
                _PostData.AA2 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA2']").GetAttributeValue("value", "");
                _PostData.AA3 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA3']").GetAttributeValue("value", "");
                _PostData.AA4 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA4']").GetAttributeValue("value", "");
                _PostData.AA5 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA5']").GetAttributeValue("value", "");
                _PostData.AA6 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA6']").GetAttributeValue("value", "");
                _PostData.AA7 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA7']").GetAttributeValue("value", "");
                _PostData.AA8 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA8']").GetAttributeValue("value", "");
                _PostData.AA9 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA9']").GetAttributeValue("value", "");
                _PostData.AA10 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA10']").GetAttributeValue("value", "");
                _PostData.AA11 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA11']").GetAttributeValue("value", "");
                _PostData.AA12 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA12']").GetAttributeValue("value", "");
                _PostData.AA13 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA13']").GetAttributeValue("value", "");
                _PostData.AA14 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA14']").GetAttributeValue("value", "");
                _PostData.AA15 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA15']").GetAttributeValue("value", "");
                _PostData.AA16 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA16']").GetAttributeValue("value", "");
                _PostData.AA17 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA17']").GetAttributeValue("value", "");
                _PostData.AA18 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA18']").GetAttributeValue("value", "");
                _PostData.AA19 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA19']").GetAttributeValue("value", "");
                _PostData.AA20 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA20']").GetAttributeValue("value", "");
                _PostData.AA21 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA21']").GetAttributeValue("value", "");
                _PostData.AA22 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA22']").GetAttributeValue("value", "");
                _PostData.AA23 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA23']").GetAttributeValue("value", "");
                _PostData.AA24 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA24']").GetAttributeValue("value", "");
                _PostData.AA25 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA25']").GetAttributeValue("value", "");
                _PostData.AA26 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA26']").GetAttributeValue("value", "");
                _PostData.AA27 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA27']").GetAttributeValue("value", "");
                _PostData.AA28 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA28']").GetAttributeValue("value", "");
                _PostData.AA29 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA29']").GetAttributeValue("value", "");
                _PostData.AA30 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA30']").GetAttributeValue("value", "");
                _PostData.AA31 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA31']").GetAttributeValue("value", "");
                _PostData.AA32 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA32']").GetAttributeValue("value", "");
                _PostData.AA33 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA33']").GetAttributeValue("value", "");
                _PostData.AA34 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA34']").GetAttributeValue("value", "");
                _PostData.AA35 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA35']").GetAttributeValue("value", "");
                _PostData.AA36 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA36']").GetAttributeValue("value", "");
                _PostData.AA37 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA37']").GetAttributeValue("value", "");
                _PostData.AA38 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA38']").GetAttributeValue("value", "");
                _PostData.AA39 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA39']").GetAttributeValue("value", "");
                _PostData.AA40 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA40']").GetAttributeValue("value", "");
                _PostData.AA41 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA41']").GetAttributeValue("value", "");
                _PostData.AA42 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA42']").GetAttributeValue("value", "");
                _PostData.AA43 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA43']").GetAttributeValue("value", "");
                _PostData.AA44 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA44']").GetAttributeValue("value", "");
                _PostData.AA45 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA45']").GetAttributeValue("value", "");
                _PostData.AA46 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA46']").GetAttributeValue("value", "");
                _PostData.AA47 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA47']").GetAttributeValue("value", "");
                _PostData.AA48 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA48']").GetAttributeValue("value", "");
                _PostData.AA49 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA49']").GetAttributeValue("value", "");
                _PostData.AA50 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA50']").GetAttributeValue("value", "");
                _PostData.AA51 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA51']").GetAttributeValue("value", "");
                _PostData.AA52 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA52']").GetAttributeValue("value", "");
                _PostData.AA53 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA53']").GetAttributeValue("value", "");
                _PostData.AA54 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA54']").GetAttributeValue("value", "");
                _PostData.AA55 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA55']").GetAttributeValue("value", "");
                _PostData.AA56 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA56']").GetAttributeValue("value", "");
                _PostData.AA57 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA57']").GetAttributeValue("value", "");
                _PostData.AA58 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA58']").GetAttributeValue("value", "");
                _PostData.AA59 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA59']").GetAttributeValue("value", "");
                _PostData.AA60 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AA60']").GetAttributeValue("value", "");
            }
            catch
            {

            }
            try
            {
                _PostData.AB1 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AB1']").GetAttributeValue("value", "");
                _PostData.AB2 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AB2']").GetAttributeValue("value", "");
                _PostData.AB3 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AB3']").GetAttributeValue("value", "");
                _PostData.AB4 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AB4']").GetAttributeValue("value", "");
                _PostData.AB5 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AB5']").GetAttributeValue("value", "");
                _PostData.AB6 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AB6']").GetAttributeValue("value", "");
            }
            catch
            {

            }
            try
            {
                _PostData.AC1 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AC1']").GetAttributeValue("value", "");
                _PostData.AC2 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AC2']").GetAttributeValue("value", "");
                _PostData.AC3 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AC3']").GetAttributeValue("value", "");
                _PostData.AC4 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AC4']").GetAttributeValue("value", "");
                _PostData.AC5 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AC5']").GetAttributeValue("value", "");
                _PostData.AC6 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='AC6']").GetAttributeValue("value", "");
            }
            catch
            {

            }

        }
        public void Write()
        {
            string deptNum = "";
            switch(_PostData.DropDownList2) {
                case "41":
                    deptNum = "0";
                    break;
                case "42":
                    deptNum = "1";
                    break;
                case "45":
                    deptNum = "2";
                    break;
                case "46":
                    deptNum = "3";
                    break;
                case "48":
                    deptNum = "4";
                    break;
                case "49":
                    deptNum = "5";
                    break;
                default:
                    Console.WriteLine("單位異常");
                    break;
            }
            string turnNum = "";
            switch (_PostData.DropDownList4)
            {
                case "夜":
                    turnNum = "0";
                    break;
                case "早":
                    turnNum = "1";
                    break;
                case "中":
                    turnNum = "2";
                    break;
                default:
                    Console.WriteLine("班別異常");
                    break;
            }

            string url = $"https://dept.csc.com.tw/MIS/C34/C34Web/LogWorkshop.aspx?numm1={_PostData.TextBox14}&numm2={_PostData.TextBox1}&numm3={_PostData.DropDownList11}&numm4={deptNum}&numm5={turnNum}";
            //string url = "https://dept.csc.com.tw/MIS/C34/C34Web/LogWorkshop.aspx?numm1=112&numm2=7&numm3=30&numm4=0&numm5=2";
            _RedirectUrl = url;

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.CookieContainer = eip.cookieContainer;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            GetViewState_ViewStateGenerator_EventValidation(eip);
            //string PostHead = "__VIEWSTATE=" + HttpUtility.UrlEncode(_PostData.__VIEWSTATE, Encoding.UTF8) + "&__VIEWSTATEGENERATOR=" + HttpUtility.UrlEncode(_PostData.__VIEWSTATEGENERATOR) + "&__EVENTVALIDATION=" + HttpUtility.UrlEncode(_PostData.__EVENTVALIDATION);
            //string PostBody = $"&TextBox14=112&TextBox1=7&DropDownList11=30&DropDownList3=0&DropDownList2=41&DropDownList4=中&TextBox3=1500&TextBox4=2300&DropDownList5=1&AA1=6666&AA2=1.中班人員到齊(共255員)。&WriteXml=存檔";
            //string PostData = PostHead + PostBody;
            _PostData.WriteXml = "存檔";
            _PostData.DropDownList6 = _PostData.DropDownList6 == ""?"X":_PostData.DropDownList6;
            //string PostData = "";
            string PostData =
                 $"__VIEWSTATE={HttpUtility.UrlEncode(_PostData.__VIEWSTATE, Encoding.UTF8)}" +
                 $"&__VIEWSTATEGENERATOR={HttpUtility.UrlEncode(_PostData.__VIEWSTATEGENERATOR, Encoding.UTF8)}" +
                 $"&__EVENTVALIDATION={HttpUtility.UrlEncode(_PostData.__EVENTVALIDATION, Encoding.UTF8)}" +
                 $"&TextBox14={_PostData.TextBox14}" +
                 $"&TextBox1={_PostData.TextBox1}" +
                 $"&DropDownList11={_PostData.DropDownList11}" +
                 $"&DropDownList3={_PostData.DropDownList3}" +
                 $"&DropDownList2={_PostData.DropDownList2}" +
                 $"&DropDownList4={_PostData.DropDownList4}" +
                 $"&TextBox3={_PostData.TextBox3}" +
                 $"&TextBox4={_PostData.TextBox4}" +
                 $"&DropDownList5={_PostData.DropDownList5}" +
                 $"&TextBox5={_PostData.TextBox5}" +
                 $"&TextBox6={_PostData.TextBox6}" +
                 $"&DropDownList6={_PostData.DropDownList6}" +
                 $"&TextBox7={_PostData.TextBox7}" +
                 $"&TextBox8={_PostData.TextBox8}" +
                 $"&TextBox9={_PostData.TextBox9}" +
                 $"&TextBox10={_PostData.TextBox10}" +
                 $"&TextBox11={_PostData.TextBox11}" +
                 $"&AA1={_PostData.AA1}" +
                 $"&AA2={_PostData.AA2}" +
                 $"&AA3={_PostData.AA3}" +
                 $"&AA4={_PostData.AA4}" +
                 $"&AA5={_PostData.AA5}" +
                 $"&AA6={_PostData.AA6}" +
                 $"&AA7={_PostData.AA7}" +
                 $"&AA8={_PostData.AA8}" +
                 $"&AA9={_PostData.AA9}" +
                 $"&AA10={_PostData.AA10}" +
                 $"&AA11={_PostData.AA11}" +
                 $"&AA12={_PostData.AA12}" +
                 $"&AA13={_PostData.AA13}" +
                 $"&AA14={_PostData.AA14}" +
                 $"&AA15={_PostData.AA15}" +
                 $"&AA16={_PostData.AA16}" +
                 $"&AA17={_PostData.AA17}" +
                 $"&AA18={_PostData.AA18}" +
                 $"&AA19={_PostData.AA19}" +
                 $"&AA20={_PostData.AA20}" +
                 $"&AA21={_PostData.AA21}" +
                 $"&AA22={_PostData.AA22}" +
                 $"&AA23={_PostData.AA23}" +
                 $"&AA24={_PostData.AA24}" +
                 $"&AA25={_PostData.AA25}" +
                 $"&AA26={_PostData.AA26}" +
                 $"&AA27={_PostData.AA27}" +
                 $"&AA28={_PostData.AA28}" +
                 $"&AA29={_PostData.AA29}" +
                 $"&AA30={_PostData.AA30}" +
                 $"&AA31={_PostData.AA31}" +
                 $"&AA32={_PostData.AA32}" +
                 $"&AA33={_PostData.AA33}" +
                 $"&AA34={_PostData.AA34}" +
                 $"&AA35={_PostData.AA35}" +
                 $"&AA36={_PostData.AA36}" +
                 $"&AA37={_PostData.AA37}" +
                 $"&AA38={_PostData.AA38}" +
                 $"&AA39={_PostData.AA39}" +
                 $"&AA40={_PostData.AA40}" +
                 $"&AA41={_PostData.AA41}" +
                 $"&AA42={_PostData.AA42}" +
                 $"&AA43={_PostData.AA43}" +
                 $"&AA44={_PostData.AA44}" +
                 $"&AA45={_PostData.AA45}" +
                 $"&AA46={_PostData.AA46}" +
                 $"&AA47={_PostData.AA47}" +
                 $"&AA48={_PostData.AA48}" +
                 $"&AA49={_PostData.AA49}" +
                 $"&AA50={_PostData.AA50}" +
                 $"&AA51={_PostData.AA51}" +
                 $"&AA52={_PostData.AA52}" +
                 $"&AA53={_PostData.AA53}" +
                 $"&AA54={_PostData.AA54}" +
                 $"&AA55={_PostData.AA55}" +
                 $"&AA56={_PostData.AA56}" +
                 $"&AA57={_PostData.AA57}" +
                 $"&AA58={_PostData.AA58}" +
                 $"&AA59={_PostData.AA59}" +
                 $"&AA60={_PostData.AA60}" +
                 $"&AB1={_PostData.AB1}" +
                 $"&AB2={_PostData.AB2}" +
                 $"&AB3={_PostData.AB3}" +
                 $"&AB4={_PostData.AB4}" +
                 $"&AB5={_PostData.AB5}" +
                 $"&AB6={_PostData.AB6}" +
                 $"&AC1={_PostData.AC1}" +
                 $"&AC2={_PostData.AC2}" +
                 $"&AC3={_PostData.AC3}" +
                 $"&AC4={_PostData.AC4}" +
                 $"&AC5={_PostData.AC5}" +
                 $"&AC6={_PostData.AC6}" +
                 $"&WriteXml={_PostData.WriteXml}";



            //// 将PostData转换为JSON字符串
            //LogWorkshopViewModel viewModel = new LogWorkshopViewModel();
            //viewModel.model = _PostData;
            //// 将ViewModel转换为JSON字符串
            //string json = JsonConvert.SerializeObject(viewModel, Formatting.Indented);

            //// 将JSON字符串保存到文件
            //string filePath = "SaveFile/save_0.json";
            //System.IO.File.WriteAllText(filePath, json);

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

            }
        }

    }
}
