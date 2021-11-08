using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace RelatedTweetBot.Models.Commands
{
    public class HelloCommand : Command
    {
        public override string NAME => "hello";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(message.Chat.Id, "hello!", replyToMessageId: 0);
        }
    }
}