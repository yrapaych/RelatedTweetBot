using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parsing.Core;
using RelatedTweetBot.Controllers;
using RelatedTweetBot.Models;
using RelatedTweetBot.Parser;
using Telegram.Bot.Types;

namespace RelatedTweetBot
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var control = new MessageController();
            while (true) { control.Update().Wait(); }
        }

        public static void newdata(object obj, string[] str)
        {
            foreach(string s in str)
            {
                Console.WriteLine(s);
            }
        }
    }
}
