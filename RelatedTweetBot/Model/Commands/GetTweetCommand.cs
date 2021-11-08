using Parsing.Core;
using RelatedTweetBot.Models.Commands;
using RelatedTweetBot.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace RelatedTweetBot.Model.Commands
{
    class GetTweetCommand : Command
    {
        ParserWorker<string[]> parser = new ParserWorker<string[]>(new TweetParse(), new TweetSettings(1, 4));
        public override string NAME => "GetTweet";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            parser.OnNewData += sendTweet;

            var split = message.Text.Split(' ');
            string buf = "";
            for(int i = 2; i < split.Length; i++)
            {
                buf += split[i] + " ";
            }
            parser.ParseOnePageSearch(buf);
            async void sendTweet(object obj, string[] str)
            {
                foreach(string st in str)
                {
                    await client.SendTextMessageAsync(message.Chat.Id, st);
                }
            }
            parser.OnNewData -= sendTweet;
        }
    }
}
