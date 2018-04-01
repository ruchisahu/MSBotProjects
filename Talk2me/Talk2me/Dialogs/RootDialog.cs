using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using System.Text.RegularExpressions;
using Microsoft.Bot.Connector;
using System;
using System.Web;

namespace Talk2me.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(this.MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            var regex = new Regex(@"\b(hello|hi|hey|how are you)\b");

            // calculate something for us to return

            if (regex.IsMatch(message.Text))
            {

                await context.PostAsync($"Hello!Welcome to the talk2me ");
            }

            else if (message.Text.ToLower().Contains("Do you know any songs") || message.Text.ToLower().Contains("music"))
            {

                await context.PostAsync(" I dont , however you should **try this** out at [Bing](https://www.bing.com/search?q=best%20+" + HttpUtility.UrlEncode("music"));
            }
            else if (message.Text.ToLower().Contains("help") || message.Text.ToLower().Contains("support") || message.Text.ToLower().Contains("problem"))
            {
                await context.PostAsync($"You ask for a help: [Bing](http://bing.com)");
            }
            else if (message.Text.ToLower().Contains("GetFoodPlaces") || message.Text.ToLower().Contains("Food") || message.Text.ToLower().Contains("hotal"))
            {


                await context.PostAsync($"good food places: [Bing](http://bing.com)");
            }

            else
            {
                await context.PostAsync("I'm sorry. I didn't understand you.");
            }

            context.Wait(this.MessageReceivedAsync);
        }

    }
}
    