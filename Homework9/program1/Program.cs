﻿using System;
using System.Text;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;


namespace program1
{
    class Program
    {
        private Hashtable urls = new Hashtable();
        private int count=0;

        static void Main(string[] args)
        {
            Program myCrawler = new Program();

            string startUrl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1)
            {
                startUrl = args[0];
            }

            myCrawler.urls.Add(startUrl, false);//加入初始界面

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            myCrawler.Crawl();
            stopwatch.Stop();
            Console.WriteLine("时间（ms）：" + stopwatch.ElapsedMilliseconds);
            Console.WriteLine("请按任意键退出：");
            Console.ReadKey();
        }

        private void Crawl()
        {
            Console.WriteLine("爬行start...");

            Parallel.For(0, 9, i =>
            {
                string current = null;

                lock (this)
                {
                    foreach (string url in urls.Keys)
                    {
                        if ((bool)urls[url])
                        {
                            continue;
                        }
                        current = url;
                    }

                    Console.WriteLine("爬行" + current + "页面！");

                    string html = DownLoad(current);

                    urls[current] = true;

                    count = i;

                    Parse(html);
                }
            });

            Console.WriteLine("爬行over\n");
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
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return "";
            }
        }

        public void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            Parallel.For(0, matches.Count, i =>
            {
                strRef = matches[i].Value.Substring(matches[i].Value.IndexOf('=') + 1).Trim('"', '\"', '#', '>');

                if (strRef.Length == 0)
                {
                    return;
                }

                if (urls[strRef] == null)
                {
                    urls[strRef] = false;
                }
            });
        }
    }
}
