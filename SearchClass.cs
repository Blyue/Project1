using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using IntroBot.Controllers;
using System.Diagnostics;

namespace IntroBot.Controllers
{
    public class SearchClass
    {
        static List<string> fileList;

        public  string getFiles(string FileName)
        {

            try
            {
                fileList = new List<string>();

                foreach (string dirName in Directory.GetLogicalDrives())
                {

                    DirectoryInfo di = new DirectoryInfo(dirName);
                    FileInfo[] files = di.GetFiles("*.*");
                    foreach (FileInfo fname in files)
                    {
                        string Retrivedfilename = Path.GetFileNameWithoutExtension(fname.Name);
                        if (FileName == Retrivedfilename)
                        {
                            return Retrivedfilename;
                        }

                    }

                }

                string message = "file Not Found!";
                return message;
            }

            catch (System.Exception exp)
            {
                string message = "File not found!./" + exp;
                return message;
            }

        }
        public static void OpenFile(string FileName)
        {
          
            foreach (string driveName in Directory.GetLogicalDrives())
            {

                    DirectoryInfo di = new DirectoryInfo(driveName);
                    FileInfo[] files = di.GetFiles("*.*");
                    foreach (FileInfo fname in files)
                    {

                        string Retrivedfilename = Path.GetFileName(fname.Name);

                        if (FileName == Retrivedfilename)
                        {

                            Process proc = new Process();
                            proc.EnableRaisingEvents = false;
                            proc.StartInfo.FileName = fname.FullName;
                            proc.Start();
                        }
                    }
            }
        }

        public static List<string> ReturnFileNameWithExtension(string FileName) {
            List<string> fileList = new List<string>();
            foreach (string driveName in Directory.GetLogicalDrives())
            {
           
                            DirectoryInfo di = new DirectoryInfo(driveName);
                            FileInfo[] files = di.GetFiles("*.*");
                            foreach (FileInfo fname in files)
                            {
                                string Retrivedfilename = Path.GetFileNameWithoutExtension(fname.Name);
                                if (FileName == Retrivedfilename)
                                {

                                    fileList.Add(Path.GetFileName(fname.Name));
                                }
                            }

            }
            return fileList;
        }
    }
}