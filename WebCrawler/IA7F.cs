using EIPLibrary.WebCrawler;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using static prjC349WebMVC.Library.WebCrawler.IA7F.Model;

namespace prjC349WebMVC.Library.WebCrawler
{
    public class IA7F
    {
        public EIP eip { get; set; }
        public List<Model> IA7FDataList { get { return _IA7FDataList; } }
        private List<Model> _IA7FDataList = new List<Model>();

        public List<string> warehouseList { get { return _warehouseList; } }
        private List<string> _warehouseList = new List<string>();

        public string userId { get; set; }
        public IA7F(EIP eipinstance)
        {
            this.eip = eipinstance;
            this._warehouseList = GetWarehouseData();
            foreach (var warehouse in warehouseList)
            {
                this._IA7FDataList.Add(PostToGetData(warehouse));
            }
            //this._IA7FDataList = PostToGetData();
        }
        public class Model
        {
            public string warehouse;

            public List<string> areaList;
        }

        public List<string> GetWarehouseData()
        {
            try
            {
                string url = "http://eas.csc.com.tw/ia/location/ia7f";

                List<string> warehouseList = new List<string>();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
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

                        HtmlAgilityPack.HtmlNodeCollection optionNodes = document.DocumentNode.SelectNodes("/html/body/div[3]/div[3]/form/div[1]/div/div/div[1]/div/select/option");

                        if (optionNodes != null)
                        {
                            foreach (var optionNode in optionNodes)
                            {
                                warehouseList.Add(optionNode.InnerText);
                            }
                        }

                        return warehouseList;
                    }
                }
            }

            catch
            {
                return warehouseList;
                //Response.Write("下載失敗,1分鐘後重新下載");
            }
        }
        public Model PostToGetData(string warehouse)
        {
            Model returnData = new Model();
            DateTime qdate = DateTime.Today.Date;
            var days = DateTime.DaysInMonth(qdate.Year, qdate.Month);

            try
            {
                string url = "http://eas.csc.com.tw/ia/location/ia7f";
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.CookieContainer = eip.cookieContainer;
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7";
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                string PostData = $"locMillInq={warehouse}&_action=query";
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
                        var document = new HtmlAgilityPack.HtmlDocument();
                        document.LoadHtml(z);
                        // 要保存为HTML的文本内容
                        //string htmlContent = z;

                        // 保存为HTML文件的路径
                        //string filePath = "IA7F.html";

                        // HTML内容輸出成檔案 *hint：這樣才是最準的!直接看實際網頁可能會被javascript動過結構!
                        //File.WriteAllText(filePath, htmlContent);

                        HtmlAgilityPack.HtmlNodeCollection optionNodes = document.DocumentNode.SelectNodes("/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr");

                        int area_count = optionNodes.Count;

                        //setDatas[0].locPlt
                        returnData.warehouse = warehouse;
                        List<string> tmp_area_List = new List<string>();
                        for (int i = 0; i < area_count; i++)
                        {
                            string myParse1 = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i+1}]/td[2]/input").GetAttributeValue("value", "default");
                            tmp_area_List.Add(myParse1);
                        }
                        returnData.areaList = tmp_area_List;
                        // /html/body/div[3]/div[3]/form/div[2]/div[1]/div[2]/div[2]/table/tbody/tr[1]/td[2]/input
                        // /html/body/div[3]/div[3]/form/div[2]/div[1]/div[2]/div[2]/table/tbody/tr[1]
                        // 解析JSON數據並映射到C#對象                     
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