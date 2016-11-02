using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntroBot.Controllers
{
    public class POSIssueButton
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
                Value = "Trouble Logging Into POS",
                Type = "imBack",
                Title = "Trouble Logging Into POS"

            };
            cardButtons.Add(plButton1);


            CardAction plButton2 = new CardAction()
            {
                Value = "Unable to Perform Transaction",
                Type = "imBack",
                Title = "Unable to Perform Transaction"
            };
            cardButtons.Add(plButton2);

            CardAction plButton3 = new CardAction()
            {
                Value = "Unable to Print Receipts",
                Type = "imBack",
                Title = "Unable to Print Receipts"
            };
            cardButtons.Add(plButton3);

            CardAction plButton4 = new CardAction()
            {
                Value = "Hung POS, unable to proceed further",
                Type = "imBack",
                Title = "Hung POS, unable to proceed further"
            };
            cardButtons.Add(plButton4);

            HeroCard plCard = new HeroCard()
            {
                Title = "Select the below which describes your issue:",

                Images = cardImages,
                Buttons = cardButtons
            };

            Attachment plAttachment = plCard.ToAttachment();
            reply.Attachments.Add(plAttachment);

            return reply;

        }

    }
}