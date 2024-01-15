using EIPLibrary.WebCrawler;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using static prjC349WebMVC.Library.WebCrawler.IA7J.Model;
using static prjC349WebMVC.Library.WebCrawler.pbjg2F.Model;

namespace prjC349WebMVC.Library.WebCrawler
{
	public class IA7J
	{
		public EIP eip { get; set; }
		public List<Model.RootObject> IA7JDataList { get { return _IA7JDataList; } }
		private List<Model.RootObject> _IA7JDataList = new List<Model.RootObject>();

		public List<string> warehouseList { get { return _warehouseList; } }
		private List<string> _warehouseList = new List<string>();

		public string userId { get; set; }
		public IA7J(EIP eipinstance)
		{
			this.eip = eipinstance;

			//this._IA7JDataList = PostToGetData();
		}
		public class Model
		{

			public class Plate
			{
				public string OrdItem { get; set; }
				public string PlateId { get; set; }
				public string LiftNo { get; set; }
				public string LocNo { get; set; }
			}

			public class DetailStatistic
			{
				public string OrdItem { get; set; }
				public string LoadNo { get; set; }
				public string OrdItemSize { get; set; }
				public int Thick { get; set; }
				public int Width { get; set; }
				public int Length { get; set; }
				public double ItemKgPcs { get; set; }
				public int ItemPcs { get; set; }
				public int SchdPcs { get; set; }
				public int OrditemUnshipPcs { get; set; }
				public int OnDockPcs { get; set; }
				public int LoadUnshipPcs { get; set; }
				public string LocNo { get; set; }
				public List<Plate> Plates { get; set; }
				public bool ShowDetail { get; set; }
			}

			public class RootObject
			{
				public string Message { get; set; }
				public string Severity { get; set; }
				public List<DetailStatistic> DetailStatistics { get; set; } = new List<DetailStatistic>();

				public override string ToString()
				{
					StringBuilder sb = new StringBuilder();

					sb.AppendLine($"Message: {Message}");
					sb.AppendLine($"Severity: {Severity}");

					if (DetailStatistics != null)
					{
						foreach (var detailStatistic in DetailStatistics)
						{
							sb.AppendLine("DetailStatistic:");
							sb.AppendLine($"  OrdItem: {detailStatistic.OrdItem}");
							sb.AppendLine($"  LoadNo: {detailStatistic.LoadNo}");
							sb.AppendLine($"  OrdItemSize: {detailStatistic.OrdItemSize}");
							sb.AppendLine($"  Thick: {detailStatistic.Thick}");
							sb.AppendLine($"  Width: {detailStatistic.Width}");
							sb.AppendLine($"  Length: {detailStatistic.Length}");
							sb.AppendLine($"  ItemKgPcs: {detailStatistic.ItemKgPcs}");
							sb.AppendLine($"  ItemPcs: {detailStatistic.ItemPcs}");
							sb.AppendLine($"  SchdPcs: {detailStatistic.SchdPcs}");
							sb.AppendLine($"  OrditemUnshipPcs: {detailStatistic.OrditemUnshipPcs}");
							sb.AppendLine($"  OnDockPcs: {detailStatistic.OnDockPcs}");
							sb.AppendLine($"  LoadUnshipPcs: {detailStatistic.LoadUnshipPcs}");
							sb.AppendLine($"  LocNo: {detailStatistic.LocNo}");
							sb.AppendLine($"  ShowDetail: {detailStatistic.ShowDetail}");

							// 其他 DetailStatistic 的屬性

							if (detailStatistic.Plates != null)
							{
								sb.AppendLine("  Plates:");
								foreach (var plate in detailStatistic.Plates)
								{
									sb.AppendLine($"    OrdItem: {plate.OrdItem}");
									sb.AppendLine($"    PlateId: {plate.PlateId}");
									// 其他 Plate 的屬性
								}
							}

							sb.AppendLine();
						}
					}

					return sb.ToString();
				}
			}

		}

		public Model.RootObject PostToGetData(string locInq, string loadNoInq)
		{
			Model.RootObject returnData = new Model.RootObject();
			DateTime qdate = DateTime.Today.Date;
			var days = DateTime.DaysInMonth(qdate.Year, qdate.Month);

			try
			{
				string url = "http://eas.csc.com.tw/ia/location/ia7j?_action=queryDetail&_format=json";
				HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
				request.CookieContainer = eip.cookieContainer;
				request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
				request.Accept = "application/json;charset=UTF-8";
				request.Method = "POST";
				request.ContentType = "application/json, text/plain, */*";


				var PostData = new
				{
					locInq = locInq,
					loadNoInq = loadNoInq,
				};
				string json = JsonConvert.SerializeObject(PostData);
				byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json);
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
						//string filePath = "IA7J.html";

						// HTML内容輸出成檔案 *hint：這樣才是最準的!直接看實際網頁可能會被javascript動過結構!
						//File.WriteAllText(filePath, htmlContent);

						//HtmlAgilityPack.HtmlNodeCollection optionNodes = document.DocumentNode.SelectNodes("/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr");

						//int area_count = optionNodes.Count;

						////setDatas[0].locPlt
						//List<string> tmp_area_List = new List<string>();
						//for (int i = 0; i < area_count; i++)
						//{
						//	string myParse1 = document.DocumentNode.SelectSingleNode($"/html/body/div[3]/div[3]/form/div[2]/table/tbody/tr[{i + 1}]/td[2]/input").GetAttributeValue("value", "default");
						//	tmp_area_List.Add(myParse1);
						//}
						//returnData.areaList = tmp_area_List;

						_IA7JDataList.Add(JsonConvert.DeserializeObject<Model.RootObject>(z));
						
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