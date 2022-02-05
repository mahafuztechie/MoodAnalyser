using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser
{
    public class MoodAnalyserException : Exception
    {
        public ExceptionType type;
        readonly string message;
        public enum ExceptionType
        {
            NULL_EXCEPTION, EMPTY_EXCEPTION, NO_SUCH_CLASS, NO_SUCH_METHOD, INVALID_INPUT, NO_SUCH_METHOD_PRESENT,
            NO_SUCH_FIELD_PRESENT,
        }
        public MoodAnalyserException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
            this.message = message;
        }
    }
}
