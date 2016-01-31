using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebCrawler
{
    public class Crawler
    {
        public Crawler()
        {
        }

        public string GetFirstById(string from, string elementId)
        {
            if (Uri.IsWellFormedUriString(from, UriKind.RelativeOrAbsolute))
            {
                return GetFirstById(new Uri(from), elementId);
            }
            else
            {
                var splitted = from.Split(new string[] { "http" }, StringSplitOptions.RemoveEmptyEntries);
                return string.Join(Environment.NewLine, GetFirstById(splitted.Select(x => new Uri("http" + x)), elementId));
            }
        }

        private string GetFirstById(Uri from, string elementId)
        {
            string content = null;
            using (var wc = new HttpClient())
            {
                content = wc.GetStringAsync(from).Result;
            }
            return Regex.Match(content, $@"\<{elementId}\b[^>]*\>\s*(?<{elementId.Capitalize()}>[\s\S]*?)\</{elementId}\>", RegexOptions.IgnoreCase)?.Groups[$"{elementId.Capitalize()}"]?.Value;
        }

        private IEnumerable<string> GetFirstById(IEnumerable<Uri> uriCollection, string elementId)
        {
            return uriCollection.Select(uri => GetFirstById(uri, elementId));
        }
    }
}
