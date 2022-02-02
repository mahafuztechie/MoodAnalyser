using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [TestCategory("Happy Mood")]
        public void GivenMessageShouldReturnHappy()
        {
            //Follow AAA strategy
            //Arrange , Act & last Assert
            MoodAnalyse mood = new MoodAnalyse("Happy Mood");
            string excepted = "happy";
            var actual = mood.AnalyseMood();
            Assert.AreEqual(excepted, actual);
        }
        [TestMethod]
        [TestCategory("SAD Mood")]
        public void GivenMessageShouldReturnSad()
        {
            //Arrange , Act & Assert
            MoodAnalyse mood = new MoodAnalyse("SAD Mood");
            string excepted = "sad";
            var actual = mood.AnalyseMood();
            Assert.AreEqual(excepted, actual);
        }
        [TestMethod]
        [TestCategory("Null Exception")]
        public void GivenNullShouldReturnCustomException()
        {
            //Arrange , Act and in last Assert
          
            string excepted = "Message can't be null";
            try
            {
                MoodAnalyse mood = new MoodAnalyse(null);
                string actual = mood.AnalyseMood();
            }
            catch (MoodAnalyserException ex)
            {
                Console.WriteLine("moodanalyser exception :" + ex);
                Assert.AreEqual(excepted, ex.Message);
            }
           
        }
        [TestMethod]
        [TestCategory("Empty Exception")]
        public void GivenEmptyShouldReturnCustomException()
        {
            ///Arrange , Act and in last Assert
            
            string excepted = "Message can't be Empty";
            try
            {
                MoodAnalyse mood = new MoodAnalyse("");
                string actual = mood.AnalyseMood();
            }
            catch (MoodAnalyserException ex)
            {
                Console.WriteLine("Mood anaylser Exception :" + ex);
                Assert.AreEqual(excepted, ex.Message);
            }
         
        }
    }
}
