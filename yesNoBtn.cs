using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntroBot.Controllers
{
    public class yesNoBtn
    {
        public static Activity getCommand(Activity reply)
        {

            reply.Attachments = new List<Attachment>();
            List<CardImage> cardImages = new List<CardImage>();
            cardImages.Add(new CardImage(url: "https://<ImageUrl1>"));
            cardImages.Add(new CardImage(url: "https://<ImageUrl2>"));
            List<CardAction> cardButtons = new List<CardAction>();
            CardAction plButton1 = new CardAction()
            {
                Value = "YES",
                Type = "imBack",
                Title = "YES"

            };
            cardButtons.Add(plButton1);


            CardAction plButton2 = new CardAction()
            {
                Value = "NO",
                Type = "imBack",
                Title = "NO"
            };
            cardButtons.Add(plButton2);

            HeroCard plCard = new HeroCard()
            {
                Title = "Do you want me to create a ticket",

                Images = cardImages,
                Buttons = cardButtons
            };

            Attachment plAttachment = plCard.ToAttachment();
            reply.Attachments.Add(plAttachment);

            return reply;

        }
    }
}