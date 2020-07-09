using MoodanalyzerTest;
using System;
using System.Net.Http;
using System.Reflection;

namespace Mood_analyzer
{
    public class Moodanalyzer
    {
        private string message;

        public Moodanalyzer(){

        }

        public Moodanalyzer(string message)
        {
            this.message = message;
        }

        public string AnalyzeMood()
        {
            try
            {
                if (message.Length == 0)
                {
                    throw new MoodanalyzerException(MoodanalyzerException.ExceptionType.EMPTY_STRING_EXCEPTION, "enter right message");
                }

                else if (message == null)
                {
                    throw new MoodanalyzerException(MoodanalyzerException.ExceptionType.NULL_POINTER_EXCEPTION, "enter proper message");
                }

                else if (message.Contains("Sad"))
                {
                    return "SAD";
                }
                else
                    return "HAPPY";
            }
            catch(Exception )
            {
                throw new MoodanalyzerException(MoodanalyzerException.ExceptionType.EMPTY_STRING_EXCEPTION, "enter message");   
            }
         
        }
        static void Main(string[] args)
        {
              }
    }
}
