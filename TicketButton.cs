using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace IntroBot.Controllers
{
    public class TicketButton
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
                Value = "CRM",
                Type = "imBack",
                Title = "CRM"
                
            };
            cardButtons.Add(plButton1);
            

            CardAction plButton2 = new CardAction()
            {
                Value = "POS",
                Type = "imBack",
                Title = "POS"
            };
            cardButtons.Add(plButton2);

            CardAction plButton3 = new CardAction()
            {
                Value = "RAC",
                Type = "imBack",
                Title = "RAC"
            };
            cardButtons.Add(plButton3);

            CardAction plButton4 = new CardAction()
            {
                Value = "EMS",
                Type = "imBack",
                Title = "EMS"        
            };
            cardButtons.Add(plButton4);

            HeroCard plCard = new HeroCard()
            {
                Title = "Please select your problem",
               
                Images = cardImages,
                Buttons = cardButtons
            };
            
            Attachment plAttachment = plCard.ToAttachment();
            reply.Attachments.Add(plAttachment);

            return reply;

        }
    }
}