using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyTools
{
    public static class LinkUrlParser
    {
        public static string GetNextURL(this System.Net.Http.Headers.HttpResponseHeaders headers)
        {
            Regex reg = new Regex(@"<(\S*)>");
            IEnumerable<string> links;
            headers.TryGetValues("Link", out links);

            string Url = links.First().Split(',').FirstOrDefault(s => s.Contains("rel=\"next\""));
            if (Url != null)
            {
                return Url = reg.Match(Url).Groups[1].Value;
            }
            else
            {
                return null;
            }
        }
    }
}
