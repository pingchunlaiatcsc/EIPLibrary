using EIPLibrary.WebCrawler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace prjC349WebMVC.Library.WebCrawler
{
    public class pdwn
    {
        public EIP eip { get; set; }
        public List<Model> List { get { return _List; } }
        private List<Model> _List = new List<pdwn.Model>();
        public string userId { get; set; }
        public int monthShift { get; set; }
        public pdwn(EIP eipinstance, List<string> EMPNO_List,string monthShift_construct)
        {
            this.monthShift = int.Parse(monthShift_construct);
            this.eip = eipinstance;
            foreach (string EMPNO in EMPNO_List)
            {
               _List.Add(PostToGetData(EMPNO, this.monthShift));
            }
        }
        public class Model
        {
            public string EMPNO { get; set; }
            public List<string> WorkShift { get; set; } = new List<string>();
                        
        }
        public pdwn.Model PostToGetData(string EMPNO_local,int monthShift_local)
        {
            pdwn.Model returnData = new pdwn.Model();
            returnData.EMPNO = EMPNO_local;
            DateTime qdate = DateTime.Today.Date.AddMonths(monthShift_local);
            var days = DateTime.DaysInMonth(qdate.Year, qdate.Month);

            try
            {

                string url = "http://eas.csc.com.tw/pd/attend/pdwn";   //pdwn網址
                                                                       //string url = "http://eas.csc.com.tw/pd/attend/pdwn";
                System.Uri uri = null;
                uri = new System.Uri(url);


                String postData = string.Format("inqPam.doCompQ=0000&inqPam.doUserQ=214585&inqPam.authU=false&inqPam.authA=false&inqPam.authC=false&inqPam.typeQ=id&inqPam.inputQ={0}&inqPam.ymQ={1}&_action=search&detail.userId=&detail.name=&detail.tmntDesc=&detail.dept=&detail.supDept=&detail.jobCode=&detail.attendId=&detail.oAttendId=&detail.teamId=&detail.oTeamId=&detail.oClassId=&detail.classId=&detail.effDate=&detail.deptMachines=&detail.cardVersion=&detail.cardVersionShow=&detail.oCardVersion=&detail.scannerNo1=&detail.scannerNo2=&detail.scannerNo3=&detail.scannerNo4=&detail.scannerNo5=&detail.scannerNo6=&detail.lastComp=&detail.lastUserId=&detail.lastName=&detail.lastDate=&detail.lastTime=&detail.ym=&detail.workHrs=&detail.workHrsAll=&detail.day01=&detail.day02=&detail.day03=&detail.day04=&detail.day05=&detail.day06=&detail.day07=&detail.day08=&detail.day09=&detail.day10=&detail.day11=&detail.day12=&detail.day13=&detail.day14=&detail.day15=&detail.week01=&detail.week02=&detail.week03=&detail.week04=&detail.week05=&detail.week06=&detail.week07=&detail.week08=&detail.week09=&detail.week10=&detail.week11=&detail.week12=&detail.week13=&detail.week14=&detail.week15=&detail.shiftIdA01=&detail.shiftIdA02=&detail.shiftIdA03=&detail.shiftIdA04=&detail.shiftIdA05=&detail.shiftIdA06=&detail.shiftIdA07=&detail.shiftIdA08=&detail.shiftIdA09=&detail.shiftIdA10=&detail.shiftIdA11=&detail.shiftIdA12=&detail.shiftIdA13=&detail.shiftIdA14=&detail.shiftIdA15=&detail.shiftIdB01=&detail.shiftIdB02=&detail.shiftIdB03=&detail.shiftIdB04=&detail.shiftIdB05=&detail.shiftIdB06=&detail.shiftIdB07=&detail.shiftIdB08=&detail.shiftIdB09=&detail.shiftIdB10=&detail.shiftIdB11=&detail.shiftIdB12=&detail.shiftIdB13=&detail.shiftIdB14=&detail.shiftIdB15=&detail.day16=&detail.day17=&detail.day18=&detail.day19=&detail.day20=&detail.day21=&detail.day22=&detail.day23=&detail.day24=&detail.day25=&detail.day26=&detail.day27=&detail.day28=&detail.day29=&detail.day30=&detail.day31=&detail.week16=&detail.week17=&detail.week18=&detail.week19=&detail.week20=&detail.week21=&detail.week22=&detail.week23=&detail.week24=&detail.week25=&detail.week26=&detail.week27=&detail.week28=&detail.week29=&detail.week30=&detail.week31=&detail.shiftIdA16=&detail.shiftIdA17=&detail.shiftIdA18=&detail.shiftIdA19=&detail.shiftIdA20=&detail.shiftIdA21=&detail.shiftIdA22=&detail.shiftIdA23=&detail.shiftIdA24=&detail.shiftIdA25=&detail.shiftIdA26=&detail.shiftIdA27=&detail.shiftIdA28=&detail.shiftIdA29=&detail.shiftIdA30=&detail.shiftIdA31=&detail.shiftIdB16=&detail.shiftIdB17=&detail.shiftIdB18=&detail.shiftIdB19=&detail.shiftIdB20=&detail.shiftIdB21=&detail.shiftIdB22=&detail.shiftIdB23=&detail.shiftIdB24=&detail.shiftIdB25=&detail.shiftIdB26=&detail.shiftIdB27=&detail.shiftIdB28=&detail.shiftIdB29=&detail.shiftIdB30=&detail.shiftIdB31=&detail.oShiftIdA01=&detail.oShiftIdA02=&detail.oShiftIdA03=&detail.oShiftIdA04=&detail.oShiftIdA05=&detail.oShiftIdA06=&detail.oShiftIdA07=&detail.oShiftIdA08=&detail.oShiftIdA09=&detail.oShiftIdA10=&detail.oShiftIdA11=&detail.oShiftIdA12=&detail.oShiftIdA13=&detail.oShiftIdA14=&detail.oShiftIdA15=&detail.oShiftIdA16=&detail.oShiftIdA17=&detail.oShiftIdA18=&detail.oShiftIdA19=&detail.oShiftIdA20=&detail.oShiftIdA21=&detail.oShiftIdA22=&detail.oShiftIdA23=&detail.oShiftIdA24=&detail.oShiftIdA25=&detail.oShiftIdA26=&detail.oShiftIdA27=&detail.oShiftIdA28=&detail.oShiftIdA29=&detail.oShiftIdA30=&detail.oShiftIdA31=&detail.oShiftIdB01=&detail.oShiftIdB02=&detail.oShiftIdB03=&detail.oShiftIdB04=&detail.oShiftIdB05=&detail.oShiftIdB06=&detail.oShiftIdB07=&detail.oShiftIdB08=&detail.oShiftIdB09=&detail.oShiftIdB10=&detail.oShiftIdB11=&detail.oShiftIdB12=&detail.oShiftIdB13=&detail.oShiftIdB14=&detail.oShiftIdB15=&detail.oShiftIdB16=&detail.oShiftIdB17=&detail.oShiftIdB18=&detail.oShiftIdB19=&detail.oShiftIdB20=&detail.oShiftIdB21=&detail.oShiftIdB22=&detail.oShiftIdB23=&detail.oShiftIdB24=&detail.oShiftIdB25=&detail.oShiftIdB26=&detail.oShiftIdB27=&detail.oShiftIdB28=&detail.oShiftIdB29=&detail.oShiftIdB30=&detail.oShiftIdB31=&inqPam.dateChQ=&inqPam.typeChQ=2&inqPam.dateChTQ=&inqPam.rptTypeQ=&inqPam.rptInputQ=&inqPam.rptAttendIdQ=&inqPam.rptTeamIdQ=&inqPam.rptYmQ{1}=&inqPam.copyYmQ=&inqPam.copyFrUserIdQ=&inqPam.copyToUserIdQ=&_action=", EMPNO_local, ROCDate(qdate).Substring(0, 5));
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.CookieContainer = eip.cookieContainer;

                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";


                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(postData);
                request.ContentLength = bytes.Length;
                //意義不明
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
                        int tmpIndex;
                        for (tmpIndex = 1; tmpIndex <= days; tmpIndex++)
                        {
                            returnData.WorkShift.Add(
                                document.DocumentNode.SelectSingleNode(
                                    $"//input[@name='detail.oShiftIdA{tmpIndex.ToString().PadLeft(2,'0')}']"
                                    ).GetAttributeValue("value", "default")
                                    );                            
                        }
                    }


                }


            }
            catch
            {
                //Response.Write("下載失敗,1分鐘後重新下載");
            }
            return returnData;
        }
        private string ROCDate(DateTime indate)
        {
            string ROCDate = "";
            var myDate = indate;
            //var myDate = DateTime.Today.AddDays(-1);//測試用，可調整日期

            string myYear = myDate.Year.ToString();
            string myMonth = myDate.Month.ToString();
            string myDay = myDate.Day.ToString();
            int myROCYear = Int32.Parse(myYear) - 1911;

            if (Int32.Parse(myMonth) < 10) { myMonth = 0 + myMonth; }
            if (Int32.Parse(myDay) < 10) { myDay = 0 + myDay; }
            ROCDate = myROCYear + myMonth + myDay;

            return ROCDate.ToString();
        }

    }

}
