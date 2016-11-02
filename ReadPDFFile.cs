using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;
using System.Text;

namespace IntroBot.Controllers
{
    public class ReadPDFFile
    {
        
        public static StringBuilder returnPDFLine(string fileName,FileInfo fname,int pageNumber) {

            StringBuilder text = new StringBuilder();
            PdfReader reader = new PdfReader(fname.FullName);
                text.Append(PdfTextExtractor.GetTextFromPage(reader,pageNumber));
                return text;
        }
    }
}