namespace Talk2me.Dialogs
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder.Dialogs;
    using System.Text.RegularExpressions;
    using Microsoft.Bot.Connector;
    using System;
    using System.Web;
    [Serializable]
    public class musicForm : IDialog<object>
    {
        

        public async Task StartAsync(IDialogContext context)
        {
          

            context.Wait(this.MessageReceivedAsync);
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            /* If the message returned is a valid name, return it to the calling dialog. */
           
                await context.PostAsync(" you should **try this** out at [Bing](https://www.bing.com/search?q=best%20+" + HttpUtility.UrlEncode(message.Text));
                context.Done(message);
            
         
           
        }
    }
}
