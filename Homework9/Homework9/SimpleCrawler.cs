using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace Homework9
{
    public class SimpleCrawler
    {
        private Hashtable urls = new Hashtable();
        private Queue<string> queue = new Queue<string>();
        private int MaxPage = 20;
        private Dictionary<string, bool> pagedictionary = new Dictionary<string, bool>();
        private int count = 0;
        public static string strRef = @"(href|HREF)[]*=[]*[""'](?<url>[^""'#>]+)[""']";//判断此是否为href，并单独把url取出来
        public static string protocalRef = @"^(?<site>(?<protocal>https?)://(?<host>[\w.-]+)(:\d+)?($|/))(\w+/)*(?<file>[^#?]*)";//判断其为何种链接
        public static string isFile = @"((.html?|.aspx|.jsp|.php)$|^[^.]+$)";
        public string Host = ""; 
        public string startUrl { get; set; }
        public List<Page> donloadPages { get; set; } = new List<Page>();
        public void Start()
        {

            pagedictionary.Clear();
            queue.Clear();
            queue.Enqueue(startUrl);
            while (queue.Count > 0&& pagedictionary.Count < MaxPage)
            {
                string currentpage = queue.Dequeue();
                string page = DownLoad(currentpage);
                if(!pagedictionary.ContainsKey(currentpage))donloadPages.Add(new Page(currentpage, DateTime.Now));
                pagedictionary[currentpage] = true;
                Parse(page, currentpage);
            }

        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        private void Parse(string html, string pageUrl)
        {
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                string linkUrl = match.Groups["url"].Value;
                if (linkUrl == null || linkUrl == "" || linkUrl.StartsWith("javascript:")) continue;
                linkUrl = FixUrl(linkUrl,pageUrl);
                Match isurl = Regex.Match(linkUrl, protocalRef);
                string host = isurl.Groups["host"].Value;
                string file = isurl.Groups["file"].Value;
                
                if (Regex.IsMatch(file, isFile) &&Regex.IsMatch(host, Host)&& !pagedictionary.ContainsKey(linkUrl)) 
                {   Console.WriteLine(linkUrl);
                    queue.Enqueue(linkUrl);
                    
                }
            }
        }
        static private string FixUrl(string url, string pageUrl)
        {
            if (url.Contains("://"))
            { 
                return url;
            }
            if (url.StartsWith("//"))
            {
                Match urlmatches = Regex.Match(pageUrl, protocalRef);
                string protocal = urlmatches.Groups["protocal"].Value;
                return protocal + ":" + url;
            }
            if (url.StartsWith("/"))
            {
                Match urlmatches = Regex.Match(pageUrl, protocalRef);
                String site = urlmatches.Groups["site"].Value;
                return site.EndsWith("/") ? site + url.Substring(1) : site + url;
            }

            if (url.StartsWith("../"))
            {
                url = url.Substring(3);
                int idx = pageUrl.LastIndexOf('/');
                return FixUrl(url, pageUrl.Substring(0, idx));
            }

            if (url.StartsWith("./"))
            {
                return FixUrl(url.Substring(2), pageUrl);
            }

            int end = pageUrl.LastIndexOf("/");
            return pageUrl.Substring(0, end) + "/" + url;
        }
    }
}
