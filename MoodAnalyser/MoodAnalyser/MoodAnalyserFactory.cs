using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection;

namespace MoodAnalyser
{
    public class MoodAnalyserFactory
    {
        //method returns instance of class type & also throws excption if occur
        public static object CreateMoodAnalyseMethod(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);

            if (result.Success)
            {
                try
                {
                    //get executing assembly & find type of classname & create instance of it
                    Assembly executingAssembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executingAssembly.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    //throw no such class exception
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_CLASS, "Class not Found");
                }
            
            }
            else 
            {
                // no such method or constructor exception
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "Constructor is not Found");
            }
        }

        //parameterized constructor returns instance & also throws exception if occur
        public static object CreatedMoodAnalyserUsingParameterizedConstructor(string className, string constructorName, string message1)
        {
            Type type = typeof(MoodAnalyse);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                    object instance = constructorInfo.Invoke(new object[] { message1 });
                    return instance;
                }
                else
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "Constructor is not found");
                }
            }
            else
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_CLASS, "Class not found");
            }
        }

        /// Use Reflection to Invoke the method
        public static string InvokeMethod(string className, string methodName, string message)
        {
            Type type1 = typeof(MoodAnalyse);
            try
            {
                ConstructorInfo constructor = type1.GetConstructor(new[] { typeof(string) });
                object obj = MoodAnalyserFactory.CreatedMoodAnalyserUsingParameterizedConstructor(className, methodName, message);
                Assembly excutingAssambly = Assembly.GetExecutingAssembly();
                Type type = excutingAssambly.GetType(className);
                MethodInfo getMoodMethod = type.GetMethod(methodName);
                string msg = (string)getMoodMethod.Invoke(obj, null);
                return msg;
            }
            catch (Exception)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.INVALID_INPUT, "No Such Method");
            }
        }

    }
}
