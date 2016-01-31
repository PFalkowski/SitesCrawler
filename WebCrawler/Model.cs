using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler
{
    public class Crawler
    {
        public Crawler()
        {
        }

        public async Task<string> GetFirstById(Uri from, string elementId)
        {
            var html = new HtmlAgilityPack.HtmlDocument();
            using (var wc = new HttpClient())
            {
                var content = await wc.GetStreamAsync(from);
                html.Load(content);
            }
            return html.GetElementbyId(elementId).InnerText;
        }

        //public IEnumerable<string> GetFirstById(IEnumerable<Uri> uriCollection, string elementId)
        //{
        //    foreach (var uri in uriCollection)
        //    {
        //        yield return GetFirstById(uri, elementId);
        //    }
        //}
    }
}
