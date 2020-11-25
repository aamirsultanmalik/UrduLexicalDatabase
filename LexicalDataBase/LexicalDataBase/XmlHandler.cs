using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LexicalDataBase
{
    public class XmlHandler
    {
        XmlWriter fileCreator;
        XmlWriterSettings setting = new XmlWriterSettings();
        InsertHandler insert = new InsertHandler();
        ReadHandler reader = new ReadHandler();
        public static string baseWordFilName = @"F:\FYP\Lexical Database\FYP Lexical Database\FYP Lexical Database\LexicalDataBase\Lex Files\BaseWords.xml";
        public static string  synonymNounFilName = @"F:\FYP\Lexical Database\FYP Lexical Database\FYP Lexical Database\LexicalDataBase\Lex Files\SynonymNoun.xml";
        public static string synonymVerbFilName = @"F:\FYP\Lexical Database\FYP Lexical Database\FYP Lexical Database\LexicalDataBase\Lex Files\SynonymVerb.xml";
        public static string synonymAdverbFilName = @"F:\FYP\Lexical Database\FYP Lexical Database\FYP Lexical Database\LexicalDataBase\Lex Files\SynonymAdverb.xml";
        public static string synonymAdjectFilName = @"F:\FYP\Lexical Database\FYP Lexical Database\FYP Lexical Database\LexicalDataBase\Lex Files\SynonymAdjective.xml";
        public static string sentenceNounFilName = @"F:\FYP\Lexical Database\FYP Lexical Database\FYP Lexical Database\LexicalDataBase\Lex Files\SentenceNoun.xml";
        public static string sentenceVerbFilName = @"F:\FYP\Lexical Database\FYP Lexical Database\FYP Lexical Database\LexicalDataBase\Lex Files\SentenceVerb.xml";
        public static string sentenceAdverbFilName = @"F:\FYP\Lexical Database\FYP Lexical Database\FYP Lexical Database\LexicalDataBase\Lex Files\SentenceAdverb.xml";
        public static string sentenceAdjectiveFilName = @"F:\FYP\Lexical Database\FYP Lexical Database\FYP Lexical Database\LexicalDataBase\Lex Files\SentenceAdjective.xml";

        //Constructor
        public XmlHandler()
        {
            //setting.Encoding = Encoding.Unicode;
            setting.Indent = true;
            setting.NewLineOnAttributes = true;
        }
        /// <summary>
        /// this method would be called for the very fisrt time to create xml files for lexical data storage
        /// </summary>
        public void CreateFiles()
        {
            fileCreator = XmlWriter.Create(baseWordFilName, setting);
            fileCreator.Close();
            fileCreator = XmlWriter.Create(synonymNounFilName, setting);
            fileCreator.Close();
            fileCreator = XmlWriter.Create(synonymVerbFilName, setting);
            fileCreator.Close();
            fileCreator = XmlWriter.Create(synonymAdverbFilName, setting);
            fileCreator.Close();
            fileCreator = XmlWriter.Create(synonymAdjectFilName, setting);
            fileCreator.Close();
            fileCreator = XmlWriter.Create(sentenceVerbFilName, setting);
            fileCreator.Close();
            fileCreator = XmlWriter.Create(sentenceNounFilName, setting);
            fileCreator.Close();
            fileCreator = XmlWriter.Create(sentenceAdverbFilName, setting);
            fileCreator.Close();
            fileCreator = XmlWriter.Create(sentenceAdjectiveFilName, setting);
            fileCreator.Close();
            XDocument xdocbase = new XDocument(new XDeclaration("1.0", "UTF_8", "yes"), new XElement("BaseWords"));
            xdocbase.Save(baseWordFilName);
            XDocument xdocNoun = new XDocument(new XDeclaration("1.0", "UTF_8", "yes"), new XElement("Synonyms"));
            xdocNoun.Save(synonymNounFilName);
            XDocument xdocverb = new XDocument(new XDeclaration("1.0", "UTF_8", "yes"), new XElement("Synonyms"));
            xdocverb.Save(synonymVerbFilName);
            XDocument xdocadverb = new XDocument(new XDeclaration("1.0", "UTF_8", "yes"), new XElement("Synonyms"));
            xdocadverb.Save(synonymAdverbFilName);
            XDocument xdocadj = new XDocument(new XDeclaration("1.0", "UTF_8", "yes"), new XElement("Synonyms"));
            xdocadj.Save(synonymAdjectFilName);
            XDocument xdocSenVErb = new XDocument(new XDeclaration("1.0", "UTF_8", "yes"), new XElement("Sentence"));
            xdocSenVErb.Save(sentenceVerbFilName);
            XDocument xdocSenAdv = new XDocument(new XDeclaration("1.0", "UTF_8", "yes"), new XElement("Sentence"));
            xdocSenAdv.Save(sentenceAdverbFilName);
            XDocument xdocSenAdj = new XDocument(new XDeclaration("1.0", "UTF_8", "yes"), new XElement("Sentence"));
            xdocSenAdj.Save(sentenceAdjectiveFilName);
            XDocument xdocSenNoun = new XDocument(new XDeclaration("1.0", "UTF_8", "yes"), new XElement("Sentence"));
            xdocSenNoun.Save(sentenceNounFilName);
        }
        
        public void InsertBaseWord(string filename, int wordID, string text, List<string> listPOS)
        {
            insert.InsertBaseWord(filename, wordID, text, listPOS);
        }
        /// <summary>
        /// Insert section
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public int GetLastBaseID(string filename)
        {
            return reader.GetLastBaseID(filename);
        }
        public void InsertSynonym(string filename, int bID, int sID, string text)
        {
            insert.InsertSynonym(filename, bID, sID, text);
        }
        public int GetLastSynoID(string fileName)
        {
            return reader.GetLastSynoID(fileName);
        }
        public void InsertSentence(string filename, int bID, int senID, string text)
        {
            insert.InsertSentence(filename, bID, senID, text);
        }
        public int GetLastSenetnceID(string fileName)
        {
            return reader.GetLastSenetnceID(fileName);
        }
        //select section
        public void GetBaseWordInfo(ref int bID, ref List<string> posList, string text)
        {
             reader.GetBaseWordInfo(ref bID, ref posList, text);
        }
        public List<string> GetSynonym(int bID, string fileName, ref int sID)
        {
            return reader.GetSynonym(bID, fileName, ref sID);
        }
        public string GetSentence(int bID, string fileName)
        {
            return reader.GetSentence(bID, fileName);
        }
    }
}