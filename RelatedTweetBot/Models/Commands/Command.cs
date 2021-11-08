
using Telegram.Bot;
using Telegram.Bot.Types;

namespace RelatedTweetBot.Models.Commands
{
    public abstract class Command
    {
        public abstract string NAME { get; }

        public abstract void Execute(Message message, TelegramBotClient client);

        public bool Contains(string command)
        {
            return command.Contains(this.NAME) && command.Contains(AppSettings.NAME);
        }

    }
}