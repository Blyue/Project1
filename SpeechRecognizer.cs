using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Speech.AudioFormat;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows;
using System.Speech.Recognition.SrgsGrammar;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.CompilerServices;

namespace IntroBot
{
    public class SpeechRecognizer
    {
        public static string UserVoiceToText() {
            string  userText;
            SpeechRecognitionEngine recogObj = new SpeechRecognitionEngine();
            Grammar DictationgrammerObj = new DictationGrammar();
            recogObj.LoadGrammar(DictationgrammerObj);
            try
            {
                recogObj.SetInputToDefaultAudioDevice();
                recogObj.SpeechRecognized += SpeechRecognized;
                userText="Call Invalid";
                return userText;
                
            }
            catch (InvalidOperationException opx)
            {
                userText = "cannot recognize your voice!"+opx.ToString();
                return userText;
            }
            finally {
                recogObj.UnloadAllGrammars();
            }

    }

        public static void SpeechRecognized(object sender, SpeechRecognizedEventArgs e)

        {
            string userText;
            userText = e.Result.Text;
            Console.WriteLine(userText);
            ///final answer from the engine
        }

    }
}