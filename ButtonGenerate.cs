using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;


namespace IntroBot.Controllers
{
    public class ButtonGenerate
    {
        public static Activity getCommand(Activity reply) {
            //string retrivedFileName = RetrivedFileName;
            SearchClass searchObj = new SearchClass();
            reply.Attachments = new List<Attachment>();

            Dictionary<string, string> cardContentList = new Dictionary<string, string>();
            cardContentList.Add("Hello", "http://3.bp.blogspot.com/-u20vmVOWcio/UGB8ckVaaCI/AAAAAAAAAaM/phdCqgziTIE/s1600/Hello+(2).jpg");

            List<CardAction> cardButtons = new List<CardAction>();
            Button button = new Button();
            foreach (KeyValuePair<string, string> cardContent in cardContentList)
            {
                List<CardImage> cardImages = new List<CardImage>();
                cardImages.Add(new CardImage(url: cardContent.Value));
                CardAction button1 = new CardAction()
                {

                    Title = "Hello",
                    Type="openUrl",
                    Value = $"https://www.google.com/{cardContent.Key}"
                };


                cardButtons.Add(button1);

                HeroCard card1 = new HeroCard()
                {
                    Buttons = cardButtons,
                    Images = cardImages
                    
                };
                Attachment attachButtons = card1.ToAttachment();
                reply.Attachments.Add(attachButtons);
            }  
            return reply;
        }
    }
}