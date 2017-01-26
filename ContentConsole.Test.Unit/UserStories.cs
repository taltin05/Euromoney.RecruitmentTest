using System.Collections.Generic;
using NUnit.Framework;
using Models2;
using Moq;
using DataAccess;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class UserStories
    {
        private Admin _admin;
        private Reader _reader;
        private Curator _curator;
        private Mock<IAdminDal> _mock;
       
        [SetUp]
        public void Setup()
        {    
            _mock = new Mock<IAdminDal>();     
            List<string> negativeWords = new List<string>() { "Bad", "Horrible", "bad", "horrible", "swine", "nasty" };
            _mock.Setup(x => x.GetNegativeWords()).Returns(negativeWords);
        }

        [Test]
        [TestCase ("The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.", 2)]
        [TestCase("The weather in Manchester in winter is Swine. It NASty all the horrible - it must be hoRRible for people visiting.", 3)]
        public void DoesUserSeeCorrectNumberOfNegativeWords(string content, int count)
        {
            User user = new User();
            Assert.AreEqual(user.CountNegativeWords(content), count);           
        }

        [Test]
        [TestCase("The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.", 2)]
        public void DoesAdminCountNegativeWords(string content, int count)
        {
            _admin = new Admin(_mock.Object);
            Assert.That(_admin.CountNegativeWords(content), Is.EqualTo(count), "Test failed!");
        }

        [Test]
        [TestCase("Horrible", "H######e")]
        public void FilterTest(string word, string filteredText)
        {            
            string result = word.Filter();
            Assert.That(filteredText, Is.EqualTo(result), "Filter Test Failed!");
        }

        [Test]
        [TestCase("The weather in Manchester in winter is horrible.",
            "The weather in Manchester in winter is h######e.")]
        public void DoesReaderSeeFilteredContent(string content, string filteredContent)
        {
            _reader = new Reader(_mock.Object);
            Assert.That(_reader.FilterText(content), Is.EqualTo(filteredContent), "Test failed!");
        }

        [Test]
        [TestCase("The weather in Manchester in winter is horrible.",
            "The weather in Manchester in winter is h######e.", true)]
        [TestCase("The weather in Manchester in winter is bad.",
            "The weather in Manchester in winter is bad.", false)]
        [TestCase("The weather in Manchester in winter is bad. it must be horrible for people visiting.",
            "The weather in Manchester in winter is b#d. it must be h######e for people visiting.", true)]
        public void CanCuratorDisableWordFiltering(string content, string filteredContent, bool shouldFilter)
        {
            _curator = new Curator(_mock.Object);
            _curator.ShouldFilterText = shouldFilter;
            Assert.That(_curator.FormatContent(content), Is.EqualTo(filteredContent), "Test failed!");
        }




    }
}
