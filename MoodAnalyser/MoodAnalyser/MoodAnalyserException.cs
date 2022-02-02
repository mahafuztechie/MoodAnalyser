﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser
{
    public class MoodAnalyserException : Exception
    {
        public ExceptionType type;
        public enum ExceptionType
        {
            NULL_EXCEPTION, EMPTY_EXCEPTION
        }
        public MoodAnalyserException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}