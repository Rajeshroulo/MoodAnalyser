using System;

namespace MoodanalyzerTest
{
    public class MoodanalyzerException : Exception
    {
     
        public string message;
       public enum ExceptionType
        {
            NULL_POINTER_EXCEPTION,EMPTY_STRING_EXCEPTION, METHOD_NOT_FOUND, CLASS_NOT_FOUND
        }

        public ExceptionType eType;

        public MoodanalyzerException(ExceptionType eType, string message) : base(message)
        {
            this.eType = eType;
            this.message = message;
        }     
    
    }
}