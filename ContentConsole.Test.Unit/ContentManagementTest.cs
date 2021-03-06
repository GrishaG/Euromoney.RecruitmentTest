using System.Collections.Generic;
using System;
using ContentConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContentConsole.Tests
{
    [TestClass]
    public partial class ContentManagementTest
    {
        IContentManagement _contentManagement = new ContentManagement();
        string _textToCheck = "The weather in Manchester in winter is bad. It rains all the bad time - it must be horrible for people visiting.";

        [TestMethod()]
        public void BannedWordCounterStringTest()
        {
            //arrange
            var bannedWords = "bad, horrible";

            //act
            List<BannedWord> bannedWord = _contentManagement.BannedWordCounter(_textToCheck, bannedWords);

            //assert
            Assert.AreEqual(2, bannedWord[0].Count);
            Assert.AreEqual(1, bannedWord[1].Count);
        }
        [TestMethod()]
        public void BannedWordCounterStringMissingItemTest()
        {
            //arrange
            var bannedWords = "bad, , horrible";

            //act
            List<BannedWord> bannedWord = _contentManagement.BannedWordCounter(_textToCheck, bannedWords);

            //assert
            Assert.AreEqual(2, bannedWord[0].Count);
            Assert.AreEqual(1, bannedWord[1].Count);
        }
        [TestMethod()]
        public void BannedWordCounterStringEmptyTest()
        {
            //arrange
            var bannedWords = "";

            //act
            List<BannedWord> bannedWord = _contentManagement.BannedWordCounter(_textToCheck, bannedWords);

            //assert
            Assert.AreEqual(0, bannedWord.Count);
        }
        [TestMethod()]
        public void BannedWordCounterStringWithSpacesTest()
        {
            //arrange
            var bannedWords = "  bad , , horrible ";

            //act
            List<BannedWord> bannedWord = _contentManagement.BannedWordCounter(_textToCheck, bannedWords);

            //assert
            //assert
            Assert.AreEqual(2, bannedWord[0].Count);
            Assert.AreEqual(1, bannedWord[1].Count);
        }
        [TestMethod()]
        public void BannedWordCounterStringDuplicateTest()
        {
            //arrange
            var bannedWords = "  bad ,bad,  , horrible , Bad";

            //act
            List<BannedWord> bannedWord = _contentManagement.BannedWordCounter(_textToCheck, bannedWords);

            //assert
            Assert.AreEqual(2, bannedWord.Count);
        }


        [TestMethod()]
        public void BannedWordCounterArrayTest()
        {
            //arrange
            var bannedWords = "bad, horrible";
            string[] arrBannedWords = bannedWords.Split(',');

            //act
            List<BannedWord> bannedWord = _contentManagement.BannedWordCounter(_textToCheck, arrBannedWords);

            //assert
            Assert.AreEqual(2, bannedWord[0].Count);
            Assert.AreEqual(1, bannedWord[1].Count);
        }
        [TestMethod()]
        public void BannedWordCounterArrayMissingItemTest()
        {
            //arrange
            var bannedWords = "bad, horrible";
            string[] arrBannedWords = bannedWords.Split(',');

            //act
            List<BannedWord> bannedWord = _contentManagement.BannedWordCounter(_textToCheck, arrBannedWords);

            //assert
            Assert.AreEqual(2, bannedWord[0].Count);
            Assert.AreEqual(1, bannedWord[1].Count);
        }
        [TestMethod()]
        public void BannedWordCounterArrayEmptyTest()
        {
            //arrange
            //var contentManagement = new ContentManagement();
            var bannedWords = "";
            string[] arrBannedWords = bannedWords.Split(',');

            //act
            List<BannedWord> bannedWord = _contentManagement.BannedWordCounter(_textToCheck, arrBannedWords);

            //assert
            Assert.AreEqual(0, bannedWord.Count);
        }
        [TestMethod()]
        public void BannedWordCounterArrayWithSpacesTest()
        {
            //arrange
            var bannedWords = "  bad , , horrible ";
            string[] arrBannedWords = bannedWords.Split(',');

            //act
            List<BannedWord> bannedWord = _contentManagement.BannedWordCounter(_textToCheck, arrBannedWords);

            //assert
            Assert.AreEqual(2, bannedWord[0].Count);
            Assert.AreEqual(1, bannedWord[1].Count);
        }
        [TestMethod()]
        public void BannedWordCounterArrayDuplicateTest()
        {
            //arrange
            var bannedWords = "  bad ,bad,  , horrible , Bad ";
            string[] arrBannedWords = bannedWords.Split(',');

            //act
            List<BannedWord> bannedWord = _contentManagement.BannedWordCounter(_textToCheck, arrBannedWords);

            //assert
            Assert.AreEqual(2, bannedWord.Count);
        }

        [TestMethod()]
        public void BannedWordReplacerTest()
        {
            //arrange
            var expectedResult = "The weather in Manchester in winter is b#d. It rains all the b#d time - it must be h######e for people visiting.";
            var bannedWords = "bad, horrible";
            string[] arrBannedWords = bannedWords.Split(',');

            //act
            string replacedText = _contentManagement.BannedWordReplacer(_textToCheck, arrBannedWords);

            //assert
            Assert.AreEqual(expectedResult, replacedText);
        }
        [TestMethod()]
        public void BannedWordReplacerMissingItemTest()
        {
            //arrange
            var expectedResult = "The weather in Manchester in winter is b#d. It rains all the b#d time - it must be h######e for people visiting.";
            var bannedWords = "bad, , horrible";
            string[] arrBannedWords = bannedWords.Split(',');

            //act
            string replacedText = _contentManagement.BannedWordReplacer(_textToCheck, arrBannedWords);

            //assert
            Assert.AreEqual(expectedResult, replacedText);
        }
        [TestMethod()]
        public void BannedWordReplacerEmptyTest()
        {
            //arrange
            var expectedResult = "The weather in Manchester in winter is bad. It rains all the bad time - it must be horrible for people visiting.";
            var bannedWords = "";
            string[] arrBannedWords = bannedWords.Split(',');

            //act
            string replacedText = _contentManagement.BannedWordReplacer(_textToCheck, arrBannedWords);

            //assert
            Assert.AreEqual(expectedResult, replacedText);
        }
        [TestMethod()]
        public void BannedWordReplacerWithSpacesTest()
        {
            //arrange
            var expectedResult = "The weather in Manchester in winter is b#d. It rains all the b#d time - it must be h######e for people visiting.";
            var bannedWords = "  bad, , horrible ";
            string[] arrBannedWords = bannedWords.Split(',');

            //act
            string replacedText = _contentManagement.BannedWordReplacer(_textToCheck, arrBannedWords);

            //assert
            Assert.AreEqual(expectedResult, replacedText);
        }
        [TestMethod()]
        public void BannedWordReplacerDuplicateTest()
        {
            //arrange
            var expectedResult = "The weather in Manchester in winter is b#d. It rains all the b#d time - it must be h######e for people visiting.";
            var bannedWords = "  bad, , horrible , bad, BAD";
            string[] arrBannedWords = bannedWords.Split(',');

            //act
            string replacedText = _contentManagement.BannedWordReplacer(_textToCheck, arrBannedWords);

            //assert
            Assert.AreEqual(expectedResult, replacedText);
        }
    }
}
