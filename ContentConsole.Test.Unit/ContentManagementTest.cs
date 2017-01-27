using System.Collections.Generic;
using System;
using ContentConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContentConsole.Tests
{
    [TestClass]
    public partial class ContentManagementTest
    {

        [TestMethod()]
        public void BannedWordCounterStringTest()
        {
            //arrange
            var contentManagement = new ContentManagement();
            var text = "The weather in Manchester in winter is bad. It rains all the bad time - it must be horrible for people visiting.";
            var bannedWords = "bad, horrible";

            //act
            List<BannedWord> bannedWord = contentManagement.BannedWordCounter(text, bannedWords);

            //assert
            Assert.AreEqual(2, bannedWord[0].Count);
            Assert.AreEqual(1, bannedWord[1].Count);
        }

        [TestMethod()]
        public void BannedWordCounterStringMissingItemTest()
        {
            //arrange
            var contentManagement = new ContentManagement();
            var text = "The weather in Manchester in winter is bad. It rains all the bad time - it must be horrible for people visiting.";
            var bannedWords = "bad, , horrible";

            //act
            List<BannedWord> bannedWord = contentManagement.BannedWordCounter(text, bannedWords);

            //assert
            Assert.AreEqual(2, bannedWord[0].Count);
            Assert.AreEqual(1, bannedWord[1].Count);
        }

        [TestMethod()]
        public void BannedWordCounterStringEmptyTest()
        {
            //arrange
            var contentManagement = new ContentManagement();
            var text = "The weather in Manchester in winter is bad. It rains all the bad time - it must be horrible for people visiting.";
            var bannedWords = "";

            //act
            List<BannedWord> bannedWord = contentManagement.BannedWordCounter(text, bannedWords);

            //assert
            Assert.AreEqual(0, bannedWord.Count);
        }

        [TestMethod()]
        public void BannedWordCounterArrayTest()
        {
            //arrange
            var contentManagement = new ContentManagement();
            var text = "The weather in Manchester in winter is bad. It rains all the bad time - it must be horrible for people visiting.";
            var bannedWords = "bad, horrible";
            string[] arrBannedWords = bannedWords.Split(',');

            //act
            List<BannedWord> bannedWord = contentManagement.BannedWordCounter(text, arrBannedWords);

            //assert
            Assert.AreEqual(2, bannedWord[0].Count);
            Assert.AreEqual(1, bannedWord[1].Count);
        }

        [TestMethod()]
        public void BannedWordCounterArrayMissingItemTest()
        {
            //arrange
            var contentManagement = new ContentManagement();
            var text = "The weather in Manchester in winter is bad. It rains all the bad time - it must be horrible for people visiting.";
            var bannedWords = "bad, horrible";
            string[] arrBannedWords = bannedWords.Split(',');

            //act
            List<BannedWord> bannedWord = contentManagement.BannedWordCounter(text, arrBannedWords);

            //assert
            Assert.AreEqual(2, bannedWord[0].Count);
            Assert.AreEqual(1, bannedWord[1].Count);
        }

        [TestMethod()]
        public void BannedWordCounterArrayEmptyTest()
        {
            //arrange
            var contentManagement = new ContentManagement();
            var text = "The weather in Manchester in winter is bad. It rains all the bad time - it must be horrible for people visiting.";
            var bannedWords = "";
            string[] arrBannedWords = bannedWords.Split(',');

            //act
            List<BannedWord> bannedWord = contentManagement.BannedWordCounter(text, arrBannedWords);

            //assert
            Assert.AreEqual(0, bannedWord.Count);
        }

        [TestMethod()]
        public void BannedWordReplacerTest()
        {
            //arrange
            var contentManagement = new ContentManagement();
            var text = "The weather in Manchester in winter is bad. It rains all the bad time - it must be horrible for people visiting.";
            var bannedWords = "bad, horrible";
            string[] arrBannedWords = bannedWords.Split(',');

            //act
            string replacedText = contentManagement.BannedWordReplacer(text, arrBannedWords);

            //assert
            Assert.AreEqual("The weather in Manchester in winter is b#d. It rains all the b#d time - it must be h######e for people visiting.", replacedText);
        }

        [TestMethod()]
        public void BannedWordReplacerMissingItemTest()
        {
            //arrange
            var contentManagement = new ContentManagement();
            var text = "The weather in Manchester in winter is bad. It rains all the bad time - it must be horrible for people visiting.";
            var bannedWords = "bad, , horrible";
            string[] arrBannedWords = bannedWords.Split(',');

            //act
            string replacedText = contentManagement.BannedWordReplacer(text, arrBannedWords);

            //assert
            Assert.AreEqual("The weather in Manchester in winter is b#d. It rains all the b#d time - it must be h######e for people visiting.", replacedText);
        }

        [TestMethod()]
        public void BannedWordReplacerEmptyTest()
        {
            //arrange
            var contentManagement = new ContentManagement();
            var text = "The weather in Manchester in winter is bad. It rains all the bad time - it must be horrible for people visiting.";
            var bannedWords = "";
            string[] arrBannedWords = bannedWords.Split(',');

            //act
            string replacedText = contentManagement.BannedWordReplacer(text, arrBannedWords);

            //assert
            Assert.AreEqual("The weather in Manchester in winter is bad. It rains all the bad time - it must be horrible for people visiting.", replacedText);
        }
    }
}
