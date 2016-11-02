using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Dialogs;
using IntroBot;
using IntroBot.Controllers;
using Microsoft.Bot.Builder.Luis.Models;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace IntroBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        static string nameOfPerson = "";
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public  async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {

            Activity reply;
            if (activity.Type == ActivityTypes.Message)
            {
                Random random = new Random();
                string ResponseToUser = "";

                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                ResponseLUIS resLUIS = await GetEntityFromLUIS(activity.Text);
                if (resLUIS.intents.Count() >= 0)
                {
                    switch (resLUIS.intents[0].intent)
                    {
                        case "Response":
                            #region hi-name
                            nameOfPerson = resLUIS.entities[0].entity;
                            if (!nameOfPerson.Contains("Hello") || !nameOfPerson.Contains("hi"))
                            {

                                string[] responselist = { "Hi There", resLUIS.entities[0].entity + " " + resLUIS.entities[1].entity, "Heya!" + " " + resLUIS.entities[1].entity, "Namaste" };
                                ResponseToUser = responselist[random.Next(0, responselist.Length)];
                                reply = activity.CreateReply(ResponseToUser);
                                await connector.Conversations.SendToConversationAsync(reply);

                            }
                            else if (string.IsNullOrEmpty(nameOfPerson) == false && (nameOfPerson.Contains("hello") || nameOfPerson.Contains("hi"))) {

                                string[] responselist = { "Hi There", "Heya!", "Namaste" };
                                ResponseToUser = responselist[random.Next(0, responselist.Length)];
                                reply = activity.CreateReply(ResponseToUser);
                                await connector.Conversations.SendToConversationAsync(reply);



                            }
                            
                            #endregion
                            break;

                        case "Response1":
                            #region hi
                            ResponseToUser = "Hi I'am RHD BOT :)  ";
                            reply = activity.CreateReply(ResponseToUser);
                            // ButtonGenerate.getCommand(reply);
                            // SignInButton.getCommand(reply);
                            TicketButton.getCommand(reply);                                                                    
                            await connector.Conversations.SendToConversationAsync(reply);
                            #endregion
                            break;

                        case "POS":
                            reply = activity.CreateReply(ResponseToUser);
                            POSIssueButton.getCommand(reply);
                            await connector.Conversations.SendToConversationAsync(reply);
                            break;

                        case "Hung POS":
                            reply = activity.CreateReply(ResponseToUser);
                            yesNoBtn.getCommand(reply);                     
                            await connector.Conversations.SendToConversationAsync(reply);
                            break;
                        case "YES":

                            
                            ResponseToUser =  BugCreation.getCommand();
                            reply = activity.CreateReply(ResponseToUser);
                            await connector.Conversations.SendToConversationAsync(reply);
                            break;

                            

                        #region oldcode
                        //case "Response2":
                        //    #region how are you?
                        //    string[] sentencesOfHow = { "Iam fine, Thank You!", "I am fantabulous!", "I'd be better if I won the lottery :) ",
                        //                              "Hopefully not as good as I'll ever be.", "Living the dream!",
                        //                               "Worse than yesterday but better than tomorrow" };
                        //    ResponseToUser = sentencesOfHow[random.Next(0, sentencesOfHow.Length)];
                        //    reply = activity.CreateReply(ResponseToUser);
                        //    await connector.Conversations.SendToConversationAsync(reply);
                        //    #endregion
                        //    break;
                        //case "Response3":
                        //    #region who made you?
                        //    ResponseToUser = "TechM Automation Team(Masss) has made me!";
                        //    reply = activity.CreateReply(ResponseToUser);
                        //    await connector.Conversations.SendToConversationAsync(reply);
                        //    #endregion
                        //    break;
                        //case "Response4":
                        //    #region who are you?
                        //    ResponseToUser = "I am Intro Bot. I can search,open and read files for you and much more..";
                        //    reply = activity.CreateReply(ResponseToUser);
                        //    await connector.Conversations.SendToConversationAsync(reply);
                        //    #endregion
                        //    break;
                        //case "Search":
                        //    #region Search
                        //    string fileName = resLUIS.entities[0].entity;
                        //    List<string> RetrivedfileNameList = SearchClass.ReturnFileNameWithExtension(fileName);
                        //    string ResponseToUser1 = "You have searched for:" + Environment.NewLine;
                        //    string ResponseToUser2 = string.Join(",", RetrivedfileNameList);
                        //    ResponseToUser = ResponseToUser1 + Environment.NewLine + ResponseToUser2;
                        //    reply = activity.CreateReply(ResponseToUser);
                        //    await connector.Conversations.SendToConversationAsync(reply);
                        //    string ResponseToUserHard = "Enter File Name you wish to open?";
                        //    reply = activity.CreateReply(ResponseToUserHard);
                        //    await connector.Conversations.SendToConversationAsync(reply);
                        //    // reply = activity.CreateReply(RetrivedfileName);
                        //    // searchObj.OpenFile(RetrivedfileName);
                        //    #endregion
                        //    break;
                        //case "OpenFile":
                        //    #region openfile
                        //    if (activity.Text.Contains("."))
                        //    {

                        //        SearchClass.OpenFile(activity.Text);
                        //    }
                        //    #endregion
                        //    break;
                        //case "Speak":
                        //    #region speak
                        //    SpeechRecognizer.UserVoiceToText();
                        //    reply = activity.CreateReply(ResponseToUser);
                        //    await connector.Conversations.SendToConversationAsync(reply);
                        //    #endregion
                        //    break;
                        //case "ReadFile":
                        //    #region read file
                        //    fileName = resLUIS.entities[0].entity;
                        //    fileName = fileName.Replace(" ", string.Empty);
                        //    int lineNumber = Convert.ToInt32(resLUIS.entities[1].entity);
                        //    ResponseToUser = ReadFile.returnFileLines(fileName, lineNumber);
                        //    reply = activity.CreateReply(ResponseToUser);
                        //    await connector.Conversations.SendToConversationAsync(reply);
                        //    #endregion
                        //    break;
                        //case "None":
                        //    #region None
                        //    string[] sentences = { "hmm... that's difficult for me to process", " Hey ! I am a bot, try something different :) ", "Well, I don't know but I can do something different." };
                        //    int lengthOfString = sentences.Length;
                        //    ResponseToUser = sentences[random.Next(0, lengthOfString)];
                        //    reply = activity.CreateReply(ResponseToUser);
                        //    await connector.Conversations.SendToConversationAsync(reply);
                        //    #endregion
                        //    break;
                        //case "sendOf":
                        //    #region sendOf
                        //    string[] sentencesSendOf = { "Is there anything else I might help you with today?", "Thank you for chatting with me today. Have a nice day. Good bye." , " It was nice talking to you! Can I do anything for you? ", "You too – bye!" ,
                        //    "All right – take care!"};
                        //    ResponseToUser = sentencesSendOf[random.Next(0, sentencesSendOf.Length)];
                        //    reply = activity.CreateReply(ResponseToUser);
                        //    await connector.Conversations.SendToConversationAsync(reply);
                        //    #endregion
                        //    break;
                        //case "yes":
                        //    string[] sentencesOfYes = {"How can I help you?", "In what way can I assist you?", "Sounds like a plan!", "Fine! what can I do for you?" };
                        //    ResponseToUser = sentencesOfYes[random.Next(0, sentencesOfYes.Length)];
                        //    reply = activity.CreateReply(ResponseToUser);
                        //    await connector.Conversations.SendToConversationAsync(reply);
                        //    break;
                        //case "No":
                        //    string[] sentencesOfNo = { "OK, no problem see you soon!", "Thanks! See you later.", "Bye.","Well, I know you’re busy, so I don’t want to keep you."
                        //                              ,"That’s OK. Nice talking to you.","Catch ya later!","Take care!"};
                        //    ResponseToUser = sentencesOfNo[random.Next(0, sentencesOfNo.Length)];
                        //    reply = activity.CreateReply(ResponseToUser);
                        //    await connector.Conversations.SendToConversationAsync(reply);
                        //    break;
                        //case "Like":
                        //    ResponseToUser = "Awwwwww!" + " " + activity.Text + " " + "too!";
                        //    reply = activity.CreateReply(ResponseToUser);
                        //    await connector.Conversations.SendToConversationAsync(reply);
                        //    break;
                        //case "Team Members":
                        //    ResponseToUser = " Manish,Aniket,Satyansh,Srija and Saonti are my developers! I love them :) ";
                        //    reply = activity.CreateReply(ResponseToUser);
                        //    await connector.Conversations.SendToConversationAsync(reply);
                        //    break;
                        //case "Why":
                        //    string[] sentencesOfWhy = { "Why do you ask so many questions?", "Need to process this in my CPU.. will let you know later!", "Because I am Awesome." };
                        //    ResponseToUser = sentencesOfWhy[random.Next(0, sentencesOfWhy.Length)];
                        //    reply = activity.CreateReply(ResponseToUser);
                        //    await connector.Conversations.SendToConversationAsync(reply);
                        //    break;
                        //case "Happy":
                        //    string[] sentencesOfHappy = { " You haven’t lost your smile at all, it’s right under your nose. You just forgot it was there.", " All people smile in the same language", "Because of your smile, you make life more beautiful.", "A laugh is a smile that bursts" };
                        //    ResponseToUser = sentencesOfHappy[random.Next(0, sentencesOfHappy.Length)];
                        //    reply = activity.CreateReply(ResponseToUser);
                        //    await connector.Conversations.SendToConversationAsync(reply);
                        //    break;
                        //case "Gratitude":
                        //    string[] sentencesOfGratitude = {nameOfPerson+" "+"That’s all right",nameOfPerson+" "+"you’re welcome.","You’re very welcome.","Don’t mention it.",
                        //                                     "Not at all.","It wasn’t a problem at all.","It’s nothing.","It’s my pleasure.","The pleasure is all mine.","My pleasure." };
                        //    ResponseToUser = sentencesOfGratitude[random.Next(0, sentencesOfGratitude.Length)];
                        //    reply = activity.CreateReply(ResponseToUser);
                        //    await connector.Conversations.SendToConversationAsync(reply);
                        //    break;
                        //case "user":
                        //    if (string.IsNullOrEmpty(nameOfPerson)==false&&(nameOfPerson.Contains("hello") || nameOfPerson.Contains("hi")))
                        //    {
                        //        string[] sentencesOfUser = { "May I know your Name?", "Ohoo! Your name?" };
                        //        ResponseToUser = sentencesOfUser[random.Next(0, sentencesOfUser.Length)];
                        //        reply = activity.CreateReply(ResponseToUser);
                        //        await connector.Conversations.SendToConversationAsync(reply);
                        //        break;
                        //    }
                        //    else if(!nameOfPerson.Contains("hello")||!nameOfPerson.Contains("hi")) {
                        //        string[] sentencesOfUser = { "Hmm.. Let me Guess! You are" + " " + nameOfPerson, "You are" + " " + nameOfPerson + ". " + "Isn't it?" };
                        //        ResponseToUser = sentencesOfUser[random.Next(0, sentencesOfUser.Length)];
                        //        reply = activity.CreateReply(ResponseToUser);
                        //        await connector.Conversations.SendToConversationAsync(reply);
                        //        break;
                        //    }
                        //    break;
                        #endregion
                        default:
                            #region default
                            ResponseToUser = "Sorry I am not getting you!";
                            reply = activity.CreateReply(ResponseToUser);
                            await connector.Conversations.SendToConversationAsync(reply);
                            #endregion
                            break;
                    }
                }
                else {
                    ResponseToUser = "Sorry..., I am not getting you.";
                    reply = activity.CreateReply(ResponseToUser);
                    await connector.Conversations.SendToConversationAsync(reply);
                }
            }
      
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
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
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
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
        public static async Task<ResponseLUIS> GetEntityFromLUIS(String Query)
        {
            Query = Uri.EscapeDataString(Query);
            ResponseLUIS response = new ResponseLUIS();
            using (HttpClient client = new HttpClient())
            {
                string RequestURI = "https://api.projectoxford.ai/luis/v1/application?id=b7736a2d-2509-4918-aace-3fd1facf6e0c&subscription-key=e31aa77294fc41f4854be4565f609c3c&q=" + Query;
                HttpResponseMessage msg = await client.GetAsync(RequestURI);
                if (msg.IsSuccessStatusCode)
                {
                    var JsonDataResponse = await msg.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<ResponseLUIS>(JsonDataResponse);
                }
            }
            return response;
        }
    }

}