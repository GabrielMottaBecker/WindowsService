using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace WindowsService1.Data
{
    public static class NewsRepository
    {
        private const string FilePath = @"C:\Data\news.json";

        public static void SaveNews(JArray news)
        {
            File.WriteAllText(FilePath, news.ToString());
        }
    }
}