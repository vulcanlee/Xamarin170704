using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFWebListView.Models
{

    public class 營建署所屬景點活動
    {
        public string id { get; set; }
        public string orgname { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public string contact { get; set; }
        public string extraurl { get; set; }
        public string created { get; set; }
        public string introtext { get; set; }

        public HtmlWebViewSource WebViewSource { get; set; }
    }

}
