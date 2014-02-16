using CsQuery;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceCollector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                //string url = "http://www.vatgia.com/10183/2313690/diamond-gsv3000.html";
                string url = "http://www.vatgia.com/395/1582820/m%C3%A1y-in-canon-laser-printer-lbp-2900.html";
                var content = webClient.DownloadString(url);                
                CQ domContent = content;

                //get title_position_v3 script
                string urlHeader = "http://www.vatgia.com" + domContent["script[src^='/cache/title_position_v3/']:first"].Attr("src");

                //string urlHeader = "http://www.vatgia.com/cache/title_position_v3/10183.js";
                CQ item = domContent["#header_navigate_extend:first"];
                string itemName = item["b:first"].Text();
                var c = itemName;

                
                var header = webClient.DownloadString(urlHeader);
                string sub = "var vatgiaTitlePosition = ";
                CQ header_navigate = header.Substring(sub.Length);
                var typeNames = header_navigate.Select("span");
                List<string> list = new List<string>();
                foreach (var t in typeNames)
                {
                    string text = t.Cq().Text();
                    //string tmp = WebUtility.HtmlDecode(text);
                    list.Add(text);
                }

                
            }
        }
    }
}
