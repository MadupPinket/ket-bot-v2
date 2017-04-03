using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using KetBot.Data.Repositories;

namespace KetBot.Bot.Dialogs
{
    [Serializable]
    public class LuisRootDialog : IDialog<object>
    {
        private IKetbotMongoRepository answerRepository;
        public LuisRootDialog(IKetbotMongoRepository repository)
        {
            answerRepository = repository;
        }

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var activity = await argument;

        }
    }
}