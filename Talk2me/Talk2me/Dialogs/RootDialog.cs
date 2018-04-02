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


        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(this.MessageReceivedAsync);

         //   return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            var regex = new Regex(@"\b(hello|hi|hey|how are you)\b");


            if (regex.IsMatch(message.Text))
            {

                await context.PostAsync($"Hello!Welcome to the talk2me.Do you want any suggestions in music and food ");
            }

            else if (message.Text.ToLower().Contains("songs") || message.Text.ToLower().Contains("music"))
            {
                await context.PostAsync($"what type of music do you want to hear");
                context.Call(new musicForm(), this.ResumeAfterOptionDialog);
                
            }
            else if (message.Text.ToLower().Contains("FoodPlaces") || message.Text.ToLower().Contains("Food") || message.Text.ToLower().Contains("restaurants"))
            {
                await context.PostAsync($"what type of food do you want to eat");
                context.Call(new FoodForm(), this.ResumeAfterOptionDialog);
            }

            else if (message.Text.ToLower().Contains("help") || message.Text.ToLower().Contains("support") || message.Text.ToLower().Contains("problem"))
            {
                await context.PostAsync($"You asked for help: [Bing](http://bing.com)");
            }
            

            else
            {
                await context.PostAsync("I'm sorry. I didn't understand you.");
            }

         //   context.Wait(this.MessageReceivedAsync);
        }

       

        private async Task ResumeAfterOptionDialog(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync($"Thanks for using Talk2me.");
            context.Wait(this.MessageReceivedAsync);
        }


    }
}
    