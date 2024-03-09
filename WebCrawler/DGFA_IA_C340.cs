using EIPLibrary.WebCrawler;
using Newtonsoft.Json;
using NPOI.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using static prjC349WebMVC.Library.WebCrawler.DGFA_IA_C340.Model;

namespace prjC349WebMVC.Library.WebCrawler
{
    public class DGFA_IA_C340
    {
        public EIP eip { get; set; }

        public List<string> warehouseList { get { return _warehouseList; } }
        private List<string> _warehouseList = new List<string>();

        public string userId { get; set; }
        public DGFA_IA_C340(EIP eipinstance)
        {
            this.eip = eipinstance;
        }
        public class Model
        {

        }

        public void PostToGetData()
        {

            try
            {
                string url = "http://iscm.csc.com.tw/erp/gf/jsp/sso/gfjjRDCA.jsp";
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.CookieContainer = eip.cookieContainer;
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7";
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                string PostData = $"btnExport=E&delimeter=%2C&keepHeader=Y&openWin=Y&INFO_ID=IA_C340&DB2_ID=HOST&COST=1185&HOST_DB2=db2tgf&OWNER_ID=195347&SQL_SELECT=SELECT+CASE+WHEN+LEFT%28ORD_ITEM_IABF%2C1%29+IN+%28%27Q%27%2C%27E%27%2C%27F%27%29+THEN+%27%A5%7E%BEP%27%0D%0A+WHEN+LEFT%28ORD_ITEM_IABF%2C1%29+IN+%28%27J%27%2C%27D%27%2C%27L%27%29+THEN+%27%A4%BA%BEP%27+WHEN+LEFT%28ORD_ITEM_IABF%2C1%29+%3D+%27T%27+THEN+%27%A4%BA%B3%A1%27+ELSE+%27%B3%C6%B3f%27+END+AS+%BEP%B0%E2%C3%FE%A7O%2CCUST_NO+AS+%AB%C8%A4%E1%BDs%B8%B9%2CCUST_NM_C+AS+%AB%C8%A4%E1%A6W%BA%D9%2C%28NEWLOC_MILL_IABF%7C%7C+SUBSTR%28NEWLOC_PLT_IABF%2C1%2C3%29%29++AS+%C0x%A6%EC+%2C+LIFT_DATE_E_IABF+AS+%A6Q%B2%BE%A4%E9%B4%C1%2CLIFOUT_DATE_E_IABF+AS+%A6Q%B2%A7%A4%E9%B4%C1%2C+LIFT_NO_IABF+AS+%A6Q%B2%BE%B3%E6%B8%B9%2C%0D%0A%28PLT_SRL_IABF+%7C%7C+PLT_ID_IABF%29+AS+%AAO%B8%B9+%2CREL_DATE_E_IABF+AS++%A9%F1%A6%E6%A4%E9%2CSHIP_REQ_SOM2+AS+%ADq%B3%E6%A5%E6%B4%C1%2C+SPEC+AS+%ADq%B3%E6%B3W%AE%E6%2C+ORD_ITEM_IABF+AS+%ADq%B3%E6%B8%B9%BDX%2CINVOICE_NO_IABF+AS+%B4%A3%B3%E6%B8%B9%BDX%2CITEM_KG_PCS_SOM2+AS+%AD%AB%B6q%2CITEM_STUS_SOM2+AS+%ADq%B3%E6%AA%AC%BAA&SQL_FROM=%2CCASE+WHEN+LEFT%28ORDER_NO_SOM2%2C1%29+IN+%28%27Q%27%2C%27E%27%2C%27F%27%29+THEN+HARBOR_ID_SOM2+ELSE+SHIP_TO_CODE_SOM2+END+AS+%A5%E6%B9B%B0%CF%B8%B9%2CVESSEL_NO_SPB1+as+%B2%EE%B8%B9%2CHOLD_NO_SP0X+as+%BF%B5%B8%B9%2CHOLD_SEQ_1_SP0X+as+%BF%B5%A7%C7%2CORD_LTH_IABF+AS+%AA%F8%AB%D7%2CORD_THK_IABF+AS+%ABp%AB%D7%2CORD_WTH_IABF+AS+%BCe%AB%D7&SQL_JOIN=&SQL_WHERE=FROM+IA.TBIABF%0D%0ALEFT+JOIN+WA.TBWAMF%0D%0AON+ORD_ITEM_IABF+%3D+ORD_ITEM%0D%0ALEFT+JOIN+SO.TBSOM2+++%0D%0AON++ORDER_NO_SOM2+%3D+SUBSTR%28ORD_ITEM_IABF%2C1%2C7%29%0D%0AAND+ITEM_NO_SOM2+%3D++SUBSTR%28ORD_ITEM_IABF%2C8%2C3%29%0D%0ALEFT+JOIN+SP.TBSPB1%0D%0AON+INVOICE_NO_IABF%3DINVOICE_NO_SPB1%0D%0ALEFT+JOIN+SP.TBSP0X+%0D%0AON+INVOICE_NO_IABF+%3D+INVOICE_NO_SP0X%0D%0AAND+ORD_ITEM_IABF+%3D+ORDER_ITEM_NO_SP0X+%0D%0AAND+VESSEL_NO_SP0X+%3D+VESSEL_NO_SPB1%0D%0AWHERE+PRODCD_STUS_IABF+IN+%28%27%27%2C%27A%27%29%0D%0AAND+LOAD_NO_IABF+%3D+%27%27+%0D%0AAND+LIFT_NO_IABF+%3C%3E+%27%27%0D%0AAND+%28NEWLOC_MILL_IABF+IN+%28%2704%27%29%0D%0A+++OR++NEWLOC_MILL_IABF+IN+%28SELECT+LOC_MILL_IAMO+FROM+IA.TBIAMO+WHERE+TAKE_EFFECT_STUS_IAMO+%3D+%27Y%27%29%29&SQL_OTHERS=&PARAM_DESC=&SQL_PARAM=";
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(PostData);
                request.ContentLength = bytes.Length;

                //把資料寫入串流，準備發送
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(bytes, 0, bytes.Length);
                    dataStream.Close();
                }
                //看到.GetResponse()才代表真正把 request 送到 伺服器
                using (FileStream fs = new FileStream(@$"IA_C340.XLS", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        using (var sr = response.GetResponseStream())
                        {
                            sr.CopyTo(fs);
                        }
                    }
                }
            }
            catch
            {
                //Response.Write("下載失敗,1分鐘後重新下載");
            }

        }
    }
}