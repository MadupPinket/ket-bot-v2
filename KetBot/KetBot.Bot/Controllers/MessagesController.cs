using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using KetBot.Data;
using KetBot.Data.Repositories;
using KetBot.Bot.Luis;
using KetBot.Data.Model;
using System.Collections.Generic;
using Microsoft.Bot.Builder.Luis.Models;
using System.Linq;

namespace KetBot.Bot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
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
                    // Ketbot이 스스로 자기소개 하기. 여기서 작업의 범위를 지정해준다. 
                    var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                    await connector.Conversations.ReplyToActivityAsync(activity.CreateReply("안녕하세요. 저는 켓봇이라고 합니다"));
                }
                else
                {
                    LuisResult ketbotLuisResult = await LUISKetbotClient.ParseUserInput(activity.Text);
                    ketbotLuisResult.TopScoringIntent = ketbotLuisResult.Intents.OrderByDescending(x => x.Score).Take(1).FirstOrDefault();
                    string strKetbot = activity.Text;
                    string strRet = string.Empty;

                    ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));

                    // Get the stateClient to get/set Bot Data
                    StateClient _stateClient = activity.GetStateClient();
                    BotData _botData = _stateClient.BotState.GetUserData(activity.ChannelId, activity.Conversation.Id);
                    Activity reply;
                    switch (ketbotLuisResult.TopScoringIntent.Intent)
                    {
                        case "None":
                            reply = activity.CreateReply("로그아웃 방법은 '핀켓 앱 실행'-'사용자설정'-'나의 정보' 에 들어가셔서 로그아웃 버튼을 누르시면 된답니다.");
                            reply.Attachments = new List<Attachment>
                            {
                                new Attachment
                                {
                                    ContentUrl = "https://fb-s-a-a.akamaihd.net/h-ak-xfp1/v/t31.0-8/14753331_1662104677413221_4328329874035870695_o.png?oh=7ecf85bcb515047af565a4b6c301ae7b&oe=5956D4ED&__gda__=1499037542_d1bb07172ac20cbd5b52f1cd7c480d76",
                                    ContentType  = "imgage/png",
                                    Name ="핀켓 포인트 모으는 방법"
                                },
                                new Attachment
                                {
                                    ContentUrl = "https://fb-s-a-a.akamaihd.net/h-ak-xfp1/v/t31.0-8/14753331_1662104677413221_4328329874035870695_o.png?oh=7ecf85bcb515047af565a4b6c301ae7b&oe=5956D4ED&__gda__=1499037542_d1bb07172ac20cbd5b52f1cd7c480d76",
                                    ContentType  = "imgage/png",
                                    Name ="핀켓 포인트 모으는 방법2"
                                },
                                new Attachment
                                {
                                    ContentUrl = "https://fb-s-a-a.akamaihd.net/h-ak-xfp1/v/t31.0-8/14753331_1662104677413221_4328329874035870695_o.png?oh=7ecf85bcb515047af565a4b6c301ae7b&oe=5956D4ED&__gda__=1499037542_d1bb07172ac20cbd5b52f1cd7c480d76",
                                    ContentType  = "imgage/png",
                                    Name ="핀켓 포인트 모으는 방법3"
                                }
                            };
                            break;
                        default:
                            reply = await ReplyAsync(activity, ketbotLuisResult);
                            break;
                    }
                    await connector.Conversations.ReplyToActivityAsync(reply);
                }
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private async Task<Activity> ReplyAsync(Activity activity, LuisResult result)
        {
            var intent = result.TopScoringIntent.Intent;
            var entities = result.Entities.Select(x => x.Entity).ToList();

            var answers = await GetAnswersAsync(intent, RemoveSpace(entities));
            var answer = answers.FirstOrDefault();

            Activity reply;
            if (answer != null)
            {
                reply = activity.CreateReply(answer.Answer);
                if (answer.attachments != null && answer.attachments.Length > 0)
                {
                    activity.Attachments = answer.attachments.Select(x => new Attachment
                    {
                        ContentUrl = x.contentUrl,
                        Name = x.name,
                        ContentType = x.contentType
                    }).ToList();
                }
            }
            else
            {
                reply = activity.CreateReply("답변이 없습니다.");
            }

            return reply;
        }

        private async Task<IEnumerable<KetBotDocument>> GetAnswersAsync(string intent, List<string> entities)
        {
            IKetbotMongoRepository ketbotRepository = new KetbotMongoRepository();
            //return await ketbotRepository.GetByKeywordWithinIntentAsync(intent, entities);
            return await ketbotRepository.GetAllByIntentAsync(intent);
        }

        private List<string> RemoveSpace(List<string> entities)
        {
            for(var i=0; i<entities.Count;i++)
            {
                entities[i] = entities[i].Replace(" ", String.Empty);
            }
            return entities;
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