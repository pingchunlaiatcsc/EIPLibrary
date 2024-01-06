using EIPLibrary.WebCrawler;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using static prjC349WebMVC.Library.WebCrawler.IA77.Model;

namespace prjC349WebMVC.Library.WebCrawler
{
    public class IA77
    {
        public EIP eip { get; set; }
        public List<Model> IA77DataList { get { return _IA77DataList; } }
        private List<Model> _IA77DataList = new List<Model>();

        public List<string> warehouseList { get { return _warehouseList; } }
        private List<string> _warehouseList = new List<string>();

        public string userId { get; set; }
        public IA77(EIP eipinstance)
        {
            this.eip = eipinstance;
            //this._warehouseList = GetWarehouseData();
            //foreach (var warehouse in warehouseList)
            //{
            //    this._IA77DataList.Add(PostToGetData(warehouse));
            //}
            //this._IA77DataList = PostToGetData();
        }
        public class Model
        {
            public int id { get; set; }
            public string OP { get; set; }
            public string Loc { get; set; }
            public string Layer { get; set; }
            public string OrdNumber { get; set; }
            public string BillOfLading { get; set; }
            public string ShipToCode { get; set; }
            public string LiftNumber { get; set; }
            public string Weight { get; set; }
            public string Thickness { get; set; }
            public string Width { get; set; }
            public string Length { get; set; }
            public string PcsCount { get; set; }
            public string Ok_ReleasedCode { get; set; }
            public string ReceivedDate { get; set; }
            public string ReceivedDate8 { get; set; }
            public string MoveDate { get; set; }
            public string MoveDate8 { get; set; }
            public string DeliveryDate { get; set; }
            public string CustomerName { get; set; }
            public string OrderCustomerName { get; set; }
            public string Spec { get; set; }
            public string PltNumber { get; set; }
            public string PlateType { get; set; }
        }

        public void GetLocData(string loc)
        {
            try
            {
                Model LocData = new Model();
                string url = $"http://eas.csc.com.tw/ia/location/ia77?loc={loc}";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //set the cookie container object
                request.CookieContainer = eip.cookieContainer;
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7";
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

                        //// 要保存为HTML的文本内容
                        //string htmlContent = z;

                        //// 保存为HTML文件的路径
                        //string filePath = "IA77.html";

                        //// HTML内容輸出成檔案 *hint：這樣才是最準的!直接看實際網頁可能會被javascript動過結構!
                        //File.WriteAllText(filePath, htmlContent);

                        

                        HtmlAgilityPack.HtmlNodeCollection optionNodes = document.DocumentNode.SelectNodes("/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr");

                        if (optionNodes != null && optionNodes.Count > 1)
                        {
                            for (int i = 0; i < optionNodes.Count - 1; i++)
                            {
                                Model tmp_model = new Model();
                                tmp_model.id = i;
                                tmp_model.OP = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[1]/label").InnerText;
                                tmp_model.Loc = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[2]/label").InnerText;
                                tmp_model.Layer = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[3]/label").InnerText;
                                tmp_model.OrdNumber = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[4]/label").InnerText;
                                tmp_model.BillOfLading = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[5]/label").InnerText;
                                tmp_model.ShipToCode = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[6]/label").InnerText.Trim();
                                tmp_model.LiftNumber = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[7]/label").InnerText;
                                tmp_model.Weight = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[8]/label").InnerText;
                                tmp_model.Thickness = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[9]/label").InnerText;
                                tmp_model.Width = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[10]/label").InnerText;
                                tmp_model.Length = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[11]/label").InnerText;
                                tmp_model.PcsCount = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[13]/label").InnerText;
                                tmp_model.Ok_ReleasedCode = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[14]/label").InnerText;
                                tmp_model.ReceivedDate = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[17]/label").InnerText;
                                tmp_model.ReceivedDate8 = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[18]/label").InnerText;
                                tmp_model.MoveDate = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[19]/label").InnerText;
                                tmp_model.MoveDate8 = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[20]/label").InnerText;
                                tmp_model.DeliveryDate = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[21]/label").InnerText;
                                tmp_model.CustomerName = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[23]/label").InnerText.Trim();
                                tmp_model.OrderCustomerName = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[24]/label").InnerText.Trim();
                                tmp_model.Spec = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[25]/label").InnerText.Trim();
                                tmp_model.PltNumber = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[26]/label").InnerText.Trim();
                                tmp_model.PlateType = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[28]/label").InnerText.Trim();
                                // /html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[1]/td[1]/label
                                // /html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[1]/td[2]/label
                                IA77DataList.Add(tmp_model);
                            }
                        }

                    }
                }
            }

            catch
            {
                //Response.Write("下載失敗,1分鐘後重新下載");
            }
        }
        //public Model PostToGetData(string warehouse)
        //{
        //    Model returnData = new Model();
        //    DateTime qdate = DateTime.Today.Date;
        //    var days = DateTime.DaysInMonth(qdate.Year, qdate.Month);

        //    try
        //    {
        //        string url = "http://eas.csc.com.tw/ia/location/IA77";
        //        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
        //        request.CookieContainer = eip.cookieContainer;
        //        request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
        //        request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7";
        //        request.Method = "POST";
        //        request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
        //        string PostData = $"locMillInq={warehouse}&_action=query";
        //        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(PostData);
        //        request.ContentLength = bytes.Length;

        //        //把資料寫入串流，準備發送
        //        using (Stream dataStream = request.GetRequestStream())
        //        {
        //            dataStream.Write(bytes, 0, bytes.Length);
        //            dataStream.Close();
        //        }
        //        //看到.GetResponse()才代表真正把 request 送到 伺服器
        //        using (WebResponse response = request.GetResponse())
        //        {
        //            using (StreamReader sr = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
        //            {
        //                var z = sr.ReadToEnd();
        //                var document = new HtmlAgilityPack.HtmlDocument();
        //                document.LoadHtml(z);
        //                // 要保存为HTML的文本内容
        //                //string htmlContent = z;

        //                // 保存为HTML文件的路径
        //                //string filePath = "IA77.html";

        //                // HTML内容輸出成檔案 *hint：這樣才是最準的!直接看實際網頁可能會被javascript動過結構!
        //                //File.WriteAllText(filePath, htmlContent);

        //                HtmlAgilityPack.HtmlNodeCollection optionNodes = document.DocumentNode.SelectNodes("/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr");

        //                int area_count = optionNodes.Count;

        //                //setDatas[0].locPlt
        //                returnData.warehouse = warehouse;
        //                List<string> tmp_area_List = new List<string>();
        //                for (int i = 0; i < area_count; i++)
        //                {
        //                    string myParse1 = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i+1}]/td[2]/input").GetAttributeValue("value", "default");
        //                    tmp_area_List.Add(myParse1);
        //                }
        //                returnData.area = tmp_area_List;
        //                // /html/body/div[3]/div[3]/form/div[2]/div[1]/div[2]/div[2]/table/tbody/tr[1]/td[2]/input
        //                // /html/body/div[3]/div[3]/form/div[2]/div[1]/div[2]/div[2]/table/tbody/tr[1]
        //                // 解析JSON數據並映射到C#對象                     
        //            }
        //        }
        //        return returnData;
        //    }
        //    catch
        //    {
        //        return returnData;
        //        //Response.Write("下載失敗,1分鐘後重新下載");
        //    }

        //}
    }
}