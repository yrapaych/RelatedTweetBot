using RelatedTweetBot.Models;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace RelatedTweetBot.Controllers
{
    public class MessageController 
    {
        int offset = 0;
        int timeout = 0;
       
        public async Task Update()
        {

            var client = await Bot.Get();
            var commands = Bot.Commands;
            foreach (var update in await client.GetUpdatesAsync(offset, timeout))
            {
                offset = update.Id + 1;

                var message = update.Message;
                string[] fullcom = message.Text.Split(' ');
                foreach(var com in commands)
                {
                    if (fullcom.Length > 2)
                    {
                        if (fullcom[1].Equals(com.NAME) && fullcom[0].Equals(AppSettings.NAME))
                        {
                            com.Execute(message, client);
                            break;
                        }
                    }
                }
            }
        }
    }
}
