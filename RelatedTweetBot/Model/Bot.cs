using RelatedTweetBot.Model.Commands;
using RelatedTweetBot.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;


namespace RelatedTweetBot.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> commandList;

        public static IReadOnlyList<Command> Commands { get => commandList.AsReadOnly(); }

        public static async Task<TelegramBotClient> Get()
        {
            if (client != null) return client;

            commandList = new List<Command>();
            commandList.Add(new HelloCommand());
            commandList.Add(new GetTweetCommand());


            client = new TelegramBotClient(AppSettings.KEY);
            
            //var hook = string.Format(AppSettings.URL, "api/message/update");
            await client.SetWebhookAsync("");

            return client;
        }
    }
}