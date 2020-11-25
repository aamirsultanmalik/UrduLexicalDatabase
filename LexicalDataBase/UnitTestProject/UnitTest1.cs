using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LexicalDataBase;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestGetLastBaseID()
        //{
        //    XmlHandler xmlHandler = new XmlHandler();
        //    string fileAddress = @"F:\FYP\Lexical Database\FYP Lexical Database\FYP Lexical Database\LexicalDataBase\Lex Files\BaseWords.xml";
        //    Assert.AreEqual(1, xmlHandler.GetLastBaseID(fileAddress));
        //}
        //[TestMethod]
        //public void TestGetLastSynoID()
        //{
        //    XmlHandler xmlHandler = new XmlHandler();
        //    string fileAddress = @"F:\FYP\Lexical Database\FYP Lexical Database\FYP Lexical Database\LexicalDataBase\Lex Files\SynonymNoun.xml";
        //    Assert.AreEqual(7462, xmlHandler.GetLastSynoID(fileAddress));
        //}
        //[TestMethod]
        //public void TestGetLastSentenceID()
        //{
        //    XmlHandler xmlHandler = new XmlHandler();
        //    string fileAddress = @"F:\FYP\Lexical Database\FYP Lexical Database\FYP Lexical Database\LexicalDataBase\Lex Files\SentenceAdjective.xml";
        //    Assert.AreEqual(1377, xmlHandler.GetLastSenetnceID(fileAddress));
        //}
        //[TestMethod]
        //public void TestGetSynonyms()
        //{
        //    XmlHandler xmlHandler = new XmlHandler();
        //    string fileAddress = @"F:\FYP\Lexical Database\FYP Lexical Database\FYP Lexical Database\LexicalDataBase\Lex Files\SynonymAdjective.xml";
        //    int sID = 1;
        //    List<string> result = new List<string>();
        //    result.Add("نحس");
        //    result.Add("بدبختی");
        //    result.Add("بدقسمتی");
        //    result.Add("بدنصیبی");
        //    var expected = xmlHandler.GetSynonym(2, fileAddress, ref sID);
        //    Assert.AreEqual(result[0],expected[0] );
        //}
        [TestMethod]
        public void TestGetSentence()
        {
            XmlHandler xmlHandler = new XmlHandler();
            string fileAddress = @"F:\FYP\Lexical Database\FYP Lexical Database\FYP Lexical Database\LexicalDataBase\Lex Files\SentenceAdjective.xml";
            string actual = "";
            var expected = xmlHandler.GetSentence(2, fileAddress);
            Assert.AreEqual(actual, expected);
        }
    }
}
