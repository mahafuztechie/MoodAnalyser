using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [TestCategory("Happy Mood")]
        public void GivenMessageShouldReturnHappy()
        {
            ///Follow AAA strategy
            ///Arrange , Act & last Assert
            MoodAnalyse mood = new MoodAnalyse("Happy Mood");
            string excepted = "happy";
            var actual = mood.AnalyseMood();
            Assert.AreEqual(excepted, actual);
        }
        [TestMethod]
        [TestCategory("SAD Mood")]
        public void GivenMessageShouldReturnSad()
        {
            ///Arrange , Act & Assert
            MoodAnalyse mood = new MoodAnalyse("SAD Mood");
            string excepted = "sad";
            var actual = mood.AnalyseMood();
            Assert.AreEqual(excepted, actual);
        }
    }
}
