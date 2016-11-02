using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace IntroBot.Controllers
{
    public class SignInButton
    {
        public static Activity getCommand(Activity reply)
        {
            reply.Attachments = new List<Attachment>();
            List<CardAction> cardButtons = new List<CardAction>();
            CardAction plButton = new CardAction()
            {
                Value= "https://login.live.com/ppsecure/secure.srf?lc=1033&sf=1&id=74335&ru=https://profile.microsoft.com/RegSysProfileCenter/wizard.aspx%3fwizid%3df4502d34-3b8f-4a04-b741-289e08aa1782%26wp%3dMCLBI%26lcid%3d1033%26fu%3dhttps%253a%252f%252fwww.microsoft.com%252fen-us%252faccount%252fdefault.aspx&tw=0&fs=0&kv=0&cb=LCID%3d1033%26WizID%3df4502d34-3b8f-4a04-b741-289e08aa1782%26brand%3dmicrosoft%26subbrand%3dprofile%2bcenter&cbcxt=&cbid=50861&wp=MCMBI&wa=wsignin1.0&wreply=https://profile.microsoft.com/RegSysProfileCenter/wizard.aspx%3fwizid%3df4502d34-3b8f-4a04-b741-289e08aa1782%26wp%3dMCLBI%26lcid%3d1033%26fu%3dhttps%253a%252f%252fwww.microsoft.com%252fen-us%252faccount%252fdefault.aspx",
                Type = "signin",
                Title = "Connect"
            };
            cardButtons.Add(plButton);
            SigninCard plCard = new SigninCard()
            {
                Text="you need to authorize me ",
                Buttons= cardButtons
            };
            Attachment plAttachment = plCard.ToAttachment();
            reply.Attachments.Add(plAttachment);
            return reply;
        }
        
            

        /*
         
        cardButtons.Add(plButton);
        SigninCard plCard = new SigninCard(title: "You need to authorize me", button: plButton);
        Attachment plAttachment = plCard.ToAttachment();
        replyToConversation.Attachments.Add(plAttachment);
        var reply = await connector.Conversations.SendToConversationAsync(replyToConversation);

         */
        //public static Activity getCommand(Activity reply)
        //{        
        //    reply.Attachments = new List<Attachment>();
        //    Dictionary<string, string> cardContentList = new Dictionary<string, string>();
        //    cardContentList.Add("Hello", "http://3.bp.blogspot.com/-u20vmVOWcio/UGB8ckVaaCI/AAAAAAAAAaM/phdCqgziTIE/s1600/Hello+(2).jpg");
        //    List<CardAction> cardButtons = new List<CardAction>();
        //    Button button = new Button();
        //    foreach (KeyValuePair<string, string> cardContent in cardContentList)
        //    {
        //        List<CardImage> cardImages = new List<CardImage>();
        //        cardImages.Add(new CardImage(url: cardContent.Value));
        //        CardAction button1 = new CardAction()
        //        {
        //            Title = "Hello",
        //            Type = "openUrl",
        //            Value = $"https://www.google.com/{cardContent.Key}"
        //        };           
        //        cardButtons.Add(button1);
        //        HeroCard card1 = new HeroCard()
        //        {
        //            Buttons = cardButtons,
        //            Images = cardImages
        //        };
        //        Attachment attachButtons = card1.ToAttachment();
        //        reply.Attachments.Add(attachButtons);
        //    }
        //    return reply;
        //}
    }



}