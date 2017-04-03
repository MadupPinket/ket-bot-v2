using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using KetBot.Bot.Dialogs;
using System;
using KetBot.Data;

namespace KetBot.Bot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        //private IKetbotMongoRepository ketbotRepository;

        //public MessagesController(IKetbotMongoRepository repository)
        //{
        //    ketbotRepository = repository;
        //}

        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                if (activity.Text.StartsWith("처음"))
                {
                    // Ketbot Introduce by himself. 
                    // Ketbot이 스스로 자기소개 하기. 여기서 작업의 범위를 지정해준다. 
                    var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                    connector.Conversations.ReplyToActivity(activity.CreateReply("안녕하세요. 저는 켓봇이라고 합니다"));
                }
                else
                {
                    await Conversation.SendAsync(activity, () => new KetbotLuisDialog());
                }
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}