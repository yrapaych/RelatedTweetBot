using RelatedTweetBot.Models;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;

namespace RelatedTweetBot.Controllers
{
    public class MessageController : ApiController
    { 
        [Route(@"api/message/update")]
        public async Task<OkResult> Update([FromBody]Update update)
        {
            var commands = Bot.Commands;
            var message = update.Message;
            var client = await Bot.Get();


            foreach(var command in commands)
            {
                command.Execute(message, client);
                break;
            }



            return Ok();
        }
    }
}
