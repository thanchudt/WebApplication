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

namespace UrlScapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //HtmlWeb hw = new HtmlWeb();
            //string url = "http://www.vatgia.com";
            //HtmlDocument doc = hw.Load(url);
            //foreach (HtmlNode link in doc.DocumentElement.SelectNodes("//a[@href]"))
            //{
                
            //}

            //using (WebClient webClient = new WebClient())
            //{
            //    webClient.Encoding = Encoding.UTF8;
            //    //string url = "http://www.vatgia.com/10183/2313690/diamond-gsv3000.html";
            //    //string url = "http://www.vatgia.com/395/1582820/m%C3%A1y-in-canon-laser-printer-lbp-2900.html";
            //    //string url = "http://www.vatgia.com";
            //    string url = "http://www.vatgia.com/1285,month/bao-dung-op-lung-dien-thoai.html,3_28";
            //    //id = type_product
            //    var content = webClient.DownloadString(url);
            //    CQ domContent = content;
            //    CQ items = domContent["a[href$='.html']"];
            //    List<string> list = new List<string>();
            //    string s = "";
            //    foreach (var t in items)
            //    {
            //        string text = t.Cq().Attr("href");
            //        //string tmp = WebUtility.HtmlDecode(text);
            //        list.Add(text);
            //        s += text + "\n";
            //    }
                
            //}

            //using (WebClient webClient = new WebClient())
            //{
            //    webClient.Encoding = Encoding.UTF8;
            //    string url = "http://www.vatgia.com/500/may-anh-may-quay.html";
            //    //id = type_product
            //    var content = webClient.DownloadString(url);
            //    CQ domContent = content;
            //    CQ items = domContent["#category_listing a"];
            //    List<string> list = new List<string>();
            //    string s = "";
            //    foreach (var t in items)
            //    {
            //        string text =  "http://www.vatgia.com" + t.Cq().Attr("href");
            //        //string tmp = WebUtility.HtmlDecode(text);
            //        list.Add(text);
            //        s += text + "\n";
            //    }

            //}        
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                string url = "http://www.vatgia.com";                
                var content = webClient.DownloadString(url);
                CQ domContent = content;                
                CQ menus = domContent["#menu a"];                
                string orgurl = "http://www.vatgia.com";
                List<Item> items = new List<Item>();
                foreach (var menu in menus)
                {
                    string category = menu.Cq().Text();                    
                    string newurl = orgurl + menu.Cq().Attr("href");
                    GetItem(webClient, newurl, ref items);                    
                }
            }  
        }

        private static void GetItem(WebClient webClient, string newurl, ref List<Item> items)
        {
            var newContent = webClient.DownloadString(newurl);
            CQ domNewContent = newContent;
            string urlHeader = "http://www.vatgia.com" + domNewContent["script[src^='/cache/title_position_v3/']:first"].Attr("src");
            var header = webClient.DownloadString(urlHeader);
            string sub = "var vatgiaTitlePosition = ";
            CQ header_navigate = header.Substring(sub.Length);
            var categories = header_navigate.Select("span");
            Item item = new Item();
            item.Url = newurl;
            foreach (var cat in categories)
            {
                string text = cat.Cq().Text();
                item.Categories.Add(text);
            }

            CQ subCats = domNewContent["#category_listing a"];
            foreach (var t in subCats)
            {
                string subCatUrl = "http://www.vatgia.com" + t.Cq().Attr("href");
                item.SubCategoryUrls.Add(subCatUrl);
                GetItem(webClient, subCatUrl, ref items);   
            }
            if (subCats.Length == 0)
            {
                items.Add(item);

                string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\";
                for (int i = 0; i < item.Categories.Count - 1; i++ )
                    fileName += item.Categories[i] + "_";
                fileName = fileName.Substring(0, fileName.Length - 1) + ".txt";
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, true))
                {
                    file.WriteLine(item.Url);
                }
            }
        }
    }

    public class Item
    {
        public Item()
        {
            Categories = new List<string>();
            SubCategoryUrls = new List<string>();
        }       
        public string Url { get; set; }
        public List<string> Categories { get; set; }
        public List<string> SubCategoryUrls { get; set; }        
    }
}
