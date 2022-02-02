using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser
{
    public class MoodAnalyse
    {
        string message;
        public MoodAnalyse(string message)
        {
            this.message = message;
        }
        public MoodAnalyse()
        {

        }

        public string AnalyseMood()
        {
            // try catch to check if exception occured
            try
            {
                message = message.ToLower();
                if (message==null)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NULL_EXCEPTION, "Message should not be null");
                }
                else if (message.Equals(string.Empty))
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.EMPTY_EXCEPTION, "Message can't be Empty");
                }
                else if( message.Contains("happy"))
                {
                    return "happy";
                }
                else
                {
                    return "sad";
                }
            }
            //catcing null refernce exception & return string as happy
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                return "happy";
            }
      
        }
    
    }
}
