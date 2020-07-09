using Mood_analyzer;
using NUnit.Framework;
using System.Reflection;

namespace MoodanalyzerTest
{
    public class MoodanalyzerTest
    {
        Moodanalyzer moodanalyzer;
        MoodanalyzerReflector moodanalyzerFactory;

        [SetUp]
        public void Setup()
        {
            moodanalyzer = new Moodanalyzer();
            moodanalyzerFactory = new MoodanalyzerReflector();
        }

        [Test]
        public void WhenMoodIssad_ShouldReturnsad()
        {
            moodanalyzer = new Moodanalyzer("I am in Sad mood");
            string mood = moodanalyzer.AnalyzeMood(); 
            Assert.AreEqual("SAD", mood);
        }

        [Test]
        public void WhenMoodIsHappy_ShouldReturnHappy()
        {
            moodanalyzer = new Moodanalyzer("I am in Happy mood");
            string mood = moodanalyzer.AnalyzeMood(); ;
            Assert.AreEqual("HAPPY", mood);
        }
        [Test]
        public void WhenNullMessageGiven_ShouldThrowException()
        {
            try
            {
                moodanalyzer = new Moodanalyzer("null");
                moodanalyzer.AnalyzeMood();
            }
            catch (MoodanalyzerException e)
            {
                Assert.AreEqual(MoodanalyzerException.ExceptionType.NULL_POINTER_EXCEPTION, e.eType);
            }

        }

        [Test]
        public void WhenEmptyMessageGiven_ShouldThrowException()
        {
            try
            {
                moodanalyzer = new Moodanalyzer("");
                moodanalyzer.AnalyzeMood();
            }
            catch (MoodanalyzerException e)
            {
                Assert.AreEqual(MoodanalyzerException.ExceptionType.EMPTY_STRING_EXCEPTION, e.eType);
            }

        }

        [Test]
        public void GivenClassName_whenImproper_ShouldThrowException()
        {
            try
            {
                ConstructorInfo constructorInfo = moodanalyzerFactory.GetConstructor(1);
                object createdObject = moodanalyzerFactory.CreateObject("class", constructorInfo, 1);
                Assert.AreEqual("HAPPY", createdObject);
            }
            catch (MoodanalyzerException e)
            {
                Assert.AreEqual(MoodanalyzerException.ExceptionType.CLASS_NOT_FOUND,e.eType);
            }
        }

        [Test]
        public void GivenClass_WhenConstructorImproper_ShouldThrowException()
        {
            try
            {
                ConstructorInfo constructorInfo = null;
                object createdObject = moodanalyzerFactory.CreateObject("Moodanalyzer", constructorInfo, 1);
                Assert.AreEqual("HAPPY", createdObject);
            }
            catch (MoodanalyzerException e)
            {
                Assert.AreEqual(MoodanalyzerException.ExceptionType.METHOD_NOT_FOUND,e.eType);
            }
        }

        [Test]
        public void GivenClass_WhenNameIsImproper_ShouldThrowException()
        {
            try
            {
                ConstructorInfo constructorInfo = moodanalyzerFactory.GetConstructor(2);
                object newObject = moodanalyzerFactory.CreateObject("wrongclass", constructorInfo, 2);
                Assert.AreEqual("SAD", newObject);
            }catch(MoodanalyzerException e)
            {
                Assert.AreEqual(MoodanalyzerException.ExceptionType.CLASS_NOT_FOUND, e.eType);
            }
        }

        [Test]
        public void GivenClass_WhenConstructorIsImproper_ShouldThrowException()
        {
            try
            {
                ConstructorInfo constructorInfo = null;
                object newObject = moodanalyzerFactory.CreateObject("Moodanalyzer", constructorInfo, 2);
                Assert.AreEqual("SAD", newObject);
            }
            catch (MoodanalyzerException e)
            {
                Assert.AreEqual(MoodanalyzerException.ExceptionType.METHOD_NOT_FOUND, e.eType);
            }
        }

        [Test]
        public void GivenMessage_WhenItIsHappy_ShouldReturnHappy()
        {
            moodanalyzer = new Moodanalyzer("I am in Happy mood");
            string mood = moodanalyzer.AnalyzeMood();
             Assert.AreEqual("HAPPY", mood);
        }

        [Test]
        public void GivenMessageHappy_WhenMethodIsWrong_ShouldThrowException()
        {
            try
            {
                moodanalyzer = new Moodanalyzer("I am in Happy mood");
                string mood = moodanalyzerFactory.InvokeMoodAnalyser("Analyzer", "HAPPY");
                Assert.AreEqual("HAPPY", mood);
            }
            catch(MoodanalyzerException e)
            {
                Assert.AreEqual(MoodanalyzerException.ExceptionType.METHOD_NOT_FOUND, e.eType);
            }
        }

        [Test]
        public void GivenMessageIsNull_ShouldThrowException()
        {
            try
            {
                moodanalyzer = new Moodanalyzer("null");
                moodanalyzer.AnalyzeMood();
               }
            catch (MoodanalyzerException e)
            {
                Assert.AreEqual(MoodanalyzerException.ExceptionType.NULL_POINTER_EXCEPTION, e.eType);
            }
        }

    }

    }

