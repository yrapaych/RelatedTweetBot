using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;
using Parsing.Core;

namespace RelatedTweetBot.Parser
{
    class TweetParse : IParser<string[]>
    { 
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("p").Where(item => item.ClassName != null && item.ClassName.Contains("TweetTextSize  js-tweet-text tweet-text"));
            var authorItems = document.QuerySelectorAll("strong").Where(item => item.ClassName != null && item.ClassName.Contains("fullname show-popup-with-id u-textTruncate"));

            var aulist = authorItems.ToList();
            var itlist = items.ToList();


            for (int i = 0; i < (items.Count() > 5 ? 5:items.Count()); i++)
            {
                list.Add(aulist[i].TextContent  + ":\n" + itlist[i].TextContent);
            }

            return list.ToArray();
        }
    }
}
