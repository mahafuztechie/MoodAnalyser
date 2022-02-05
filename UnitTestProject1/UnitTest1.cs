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
        [TestMethod]
        public void Given_MoodAnalyser_ClassName_ShouldReturn_MoodAnalyseObject()
        {
            object expected = new MoodAnalyse("NULL");
            object obj = MoodAnalyserFactory.CreateMoodAnalyseMethod("MoodAnalyser.MoodAnalyse", "MoodAnalyse");
            expected.Equals(obj);
        }

        [TestMethod]
        public void GivenInvalidClassName_ShouldThrow_MoodAnalyserException()
        {
            string expected = "Class not Found";
            try
            {
                //creating instance of class
                object obj = MoodAnalyserFactory.CreateMoodAnalyseMethod("MoodAnalyser.MoodAnalyse", "MoodAnalyse");
            }
            catch (MoodAnalyserException e)
            {
                //catch & compare exception
                Assert.AreEqual(expected, e.Message);
            }
        }

        [TestMethod]
        public void GivenClass_WhenNotProper_Constructor_ShouldThrow_MoodAnalyserException()
        {
            string expected = "Constructor is not Found";
            try
            {
                //creating instance of class
                object obj = MoodAnalyserFactory.CreateMoodAnalyseMethod("MoodAnalyser.MoodAnalyse", "WrongConstructor");
            }
            catch (MoodAnalyserException e)
            {
                //catch & compare exception
                Assert.AreEqual(expected, e.Message);
            }
        }

        [TestMethod]
        public void GivenMoodAnalyser_WhenCorrect_Return_MoodAnalyseObject()
        {
            object expected = new MoodAnalyse("HAPPY");
            object obj = MoodAnalyserFactory.CreatedMoodAnalyserUsingParameterizedConstructor("MoodAnalyser.MoodAnalyse", "MoodAnalyse", "HAPPY");
            expected.Equals(obj);
        }

        [TestMethod]
        public void GivenInvalidClassName_ShouldThrow_MoodAnalyserException_Of_ParameterisedConstructor()
        {
            string expected = "Class not found";
            try
            {
                object obj = MoodAnalyserFactory.CreatedMoodAnalyserUsingParameterizedConstructor("MoodAnalyser.sampleClass", "MoodAnalyse", "HAPPY");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }

        /// This test case is for
        ///  Given Invalid constructor name should throw MoodAnalyserException.
    
        [TestMethod]
        public void GivenInvalidConstructorName_ShouldThrow_MoodAnalyserException_Of_ParameterizedConstructor()
        {
            string expected = "Constructor is not found";
            try
            {
                object obj = MoodAnalyserFactory.CreatedMoodAnalyserUsingParameterizedConstructor("MoodAnalyser.MoodAnalyse", "sampleClass", "HAPPY");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
       
        // Happy message passing using Reflection when correct
        // should return HAPPY Mood
        [TestMethod]
        public void GivenHappyMessage_UsingReflection_IfCorrect_Should_ReturnHappy()
        {
            string message = MoodAnalyserFactory.InvokeMethod("MoodAnalyser.MoodAnalyse", "GetMood", "happy");
            Assert.AreEqual("HAPPY", message);
        }

        // Given Happy message when incorrect method 
        // should throw MoodAnalyserException
        [TestMethod]
        public void GivenHappyMessage_UsingReflection_WhenIncorrectMethod_shouldThrow_MoodAnayserException()
        {
            try
            {
                string message = MoodAnalyserFactory.InvokeMethod("MoodAnalyser.MoodAnalyse", "getMethod", "happy");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.INVALID_INPUT, e.Message);
            }
        }
    }
}
