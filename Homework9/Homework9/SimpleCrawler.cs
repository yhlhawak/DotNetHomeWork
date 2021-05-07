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
    class SimpleCrawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        public static string strRef = @"(href|HREF)[]*=[]*[""'](?<url>[^""'#>]+)[""']";//判断此是否位href
        public static string protocalRef = @"^(?<site>(?<protocal>https?)://(?<host>[\w.-]+)(:\d+)?($|/))(\w+/)*(?<file>[^#?]*)";//判断其为何种链接
        public static string isFile = @"((.html?|.aspx|.jsp|.php)$|^[^.]+$)";
        public string Host = "";
        static void Main(string[] args)
        {
            SimpleCrawler myCrawler = new SimpleCrawler();
            string startUrl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1) startUrl = args[0];
            myCrawler.urls.Add(startUrl, false);//加入初始页面
            Match match = Regex.Match(startUrl, protocalRef);
            if (match.Length == 0) return;
            string host = match.Groups["host"].Value;
            myCrawler.Host = "^" + host + "$";
            new Thread(myCrawler.Crawl).Start();
            Console.ReadLine();
        }

        private void Crawl()
        {
            Console.WriteLine("开始爬行了.... ");
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }
                if (current == null || count > 100) break;
                Console.WriteLine("爬行" + current + "页面!");
                string html = DownLoad(current); // 下载
                urls[current] = true;
                count++;
                Parse(html,current);//解析,并加入新的链接
                Console.WriteLine("爬行结束");
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
                if (Regex.IsMatch(file, isFile) &&Regex.IsMatch(host, Host)) 
                { 
                    if (urls[linkUrl] == null) urls[linkUrl] = false;
                    if (linkUrl.Length == 0) continue; 
                    
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
