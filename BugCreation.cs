using Microsoft.Bot.Connector;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
//using Microsoft.TeamFoundation.WorkItemTracking.Client.DataStoreLoader;

namespace IntroBot.Controllers
{
    public class BugCreation
    {


        public static string getCommand()
        {
            string id = "";
            Uri collectionUri = new Uri("https://masssluis.visualstudio.com/DefaultCollection");
            const string serviceUser = "MasssLUIS";
            const string servicePassword = "Masss12345";
            //const string teamProject = "MyFirstProject";

            NetworkCredential netCred = new NetworkCredential(serviceUser, servicePassword);
            BasicAuthCredential basicCred = new BasicAuthCredential(netCred);
            TfsClientCredentials tfsCred = new TfsClientCredentials(basicCred);
            tfsCred.AllowInteractive = false;
            
            TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(new Uri("https://masssluis.visualstudio.com/DefaultCollection"), tfsCred);
            tfs.Authenticate();

     
 
            WorkItemStore workItemStore = tfs.GetService<WorkItemStore>();
            Project teamProject1 = workItemStore.Projects["MyFirstProject"];
            WorkItemType workItemType = teamProject1.WorkItemTypes["Bug"];

            // Create the work item. 
            WorkItem userStory = new WorkItem(workItemType)
            {
                // The title is generally the only required field that doesn’t have a default value. 
                // You must set it, or you can’t save the work item. If you’re working with another
                // type of work item, there may be other fields that you’ll have to set.
                Title = "this is a test bug by masss team"

            };

            // Save the new user story. 
            userStory.Save();
            id = userStory.Id.ToString();
            return id;

        }
       

    }

}
    #region unused code
    //var workItemStore = tfs.GetService<WorkItemStore>();
    //if (workItemStore == null)
    //{
    //    //just for the error handling once more the call 
    //    var tmpTest = new WorkItemStore(tfs);
    //}

    //if (workItemStore != null)
    //{
    //    WorkItemTypeCollection workItemTypes = workItemStore.Projects[teamProject].WorkItemTypes;

    //    //Define Workitem Type as Bug 
    //    WorkItemType workItemType = workItemTypes["Bug"];

    //    //Assign values to each mandatory field 
    //    var workItem = new WorkItem(workItemType);

    //    string workItemTitle = "YOUR WORK ITEM TITLE";
    //    //string workItemIterationPath = @"YOURAREAPATH\Release 1";
    //   // string workItemAreaPath = "YOURAREAPATH";


    //    workItem.Title = workItemTitle;
    //    //workItem.AreaPath = workItemAreaPath;
    //   // workItem.IterationPath = workItemIterationPath;

    //    //Check for Validation errors before saving 
    //    var validationErrors = workItem.Validate();
    //    if (validationErrors.Count == 0)
    //    {
    //        workItem.Save();

    //       id= workItem.Id.ToString();
    //        return id;
    //    }
    //    else
    //    {
    //       // return validationErrors.Count.ToString(CultureInfo.InvariantCulture);
    //    }
    //}

    //return id;
    #endregion

      
    

