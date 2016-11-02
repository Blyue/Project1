using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Office.Interop.Word;

namespace IntroBot.Controllers
{
    public class ReadDocuments:IDisposable
    {
        private readonly Application application;
        private Document documents;

        public ReadDocuments() {

          //  application = new ApplicationClass();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}