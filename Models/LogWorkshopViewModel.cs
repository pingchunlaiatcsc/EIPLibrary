using EIPLibrary.WebCrawler;

namespace EIPLibrary.Models
{
    public class LogWorkshopViewModel
    {
        public string userId { get; set; }
        public string userPassword { get; set; }
        public LogWorkshop.Model model { get; set; }
        public List<string> DutyOfficers { get; set; }
    }
}
