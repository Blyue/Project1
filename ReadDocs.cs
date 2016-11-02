using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Office.Interop.Word;
using System.Text;
using System.IO;

namespace IntroBot.Controllers
{
    public class ReadDocs
    {
        static Application word = new Application();
        private static Document document;
      
        public static string returnDocsLine(string fileName, FileInfo filename, string directoryName,int lineNumber)
        {
            //IEnumerable<string> lines;
            object documentAsObject = filename.FullName;
            document = word.Documents.Open(ref documentAsObject);
            object outputTxtFileNameAsObject = Path.Combine(directoryName, "Text.txt");
            object formatAsObject = WdSaveFormat.wdFormatText;
            document.SaveAs(ref outputTxtFileNameAsObject, ref formatAsObject);
            word.Application.Quit();
            int linenumber = lineNumber - 1;
            string dummyLine = "";
            string FileName = "Text.txt";
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
                            string line = lines.ElementAt(lineNumber);
                            return line;
                       
                        }
                    }
                }
            }
            return dummyLine;
        }
/*
        public void openFile(FileInfo fname) {
            object documentAsObject = fname.FullName;
            document = word.Documents.Open(ref  documentAsObject);
        }

        public string saveTextFile(string directoryName,int lineNumber) {
            object outputTxtFileNameAsObject = Path.Combine(directoryName, "Text.txt");
            object formatAsObject = WdSaveFormat.wdFormatText;
            document.SaveAs(ref outputTxtFileNameAsObject,ref formatAsObject);
            word.Application.Quit();
            int linenumber = lineNumber - 1;
            string dummyLine = "";
            string FileName = "Text.txt";
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
                            string line = lines.ElementAt(lineNumber);
                            return line;
                        }
                    }
                }
            }
            return dummyLine;
       }

        public static string ConvertWordToText(FileInfo fname, string dirName,int linenumber) {
            using (var word = new ReadDocs()) {
                word.openFile(fname);
                return word.saveTextFile(dirName, linenumber);
            }
        } */
    }
}