using Parsing.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelatedTweetBot.Parser
{
    class TweetSettings : IParserSettings
    {
        public TweetSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }

        public string BaseUrl { get; set; } = "https://twitter.com/search?q=";
        public string Prefix { get; set; } = "{SearchQuery}";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
