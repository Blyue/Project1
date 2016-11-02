using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using Syn.Speech.Helper;

namespace IntroBot.Controllers
{
    public class ReadFile
    {
        public static string returnFileLines(string FileName, int lineNumber)
        {
            int linenumber = lineNumber - 1;
            string dummyLine = "";
            IEnumerable<string> lines;
            foreach (string dirName in Directory.GetLogicalDrives())
            {
                DirectoryInfo di = new DirectoryInfo(dirName);
                FileInfo[] fList = di.GetFiles("*.*");
                foreach (FileInfo fname in fList)
                {
                    string Retrivedfilename = Path.GetFileName(fname.Name);

                    if (FileName == Retrivedfilename)
                    {
                        if (FileName.EndsWith(".txt"))
                        {

                            lines = File.ReadLines(fname.FullName);
                            string line = lines.ElementAt(linenumber);
                            return line;
                        }
                        else if (FileName.EndsWith(".pdf"))
                        {
                            StringBuilder text = ReadPDFFile.returnPDFLine(FileName, fname, lineNumber);
                            string line = text.ToString();
                            return line;
                        }
                        else if (FileName.EndsWith(".docx")) {
                            string line = ReadDocs.returnDocsLine(FileName,fname,dirName,lineNumber);
                            return line;
                        }
                    }
                }
            }
            return dummyLine;
        }
    }
}