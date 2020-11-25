using System.Collections.Generic;
using System.Web.Services;

namespace LexicalDataBase
{
    /// <summary>
    /// Summary description for MyService
    /// </summary>
    [WebService(Namespace = "http://www.BahriaUniversity.edu.pk/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MyService : System.Web.Services.WebService
    {
        XmlHandler xml = new XmlHandler();

        [WebMethod]
        public List<List<string>> GetData(string input)
        {
            List<List<string>> myList = new List<List<string>>();
            List<string> synoList = new List<string>();
            List<string> posList = new List<string>();
            List<string> sentenceList = new List<string>();
            int bID = 0;
            int sID = 0;
            string synoFileName, posType = null, sentenceFileName;
            List<string> listPOS = new List<string>();
            xml.GetBaseWordInfo(ref bID, ref listPOS, input);
            foreach (var itemPOS in listPOS)
            {
                synoFileName = GetSynoFileNameFromPOS(itemPOS, ref posType);
                sentenceFileName = GetSentanceFileNameFromPOS(itemPOS);
                myList.Add(xml.GetSynonym(bID, synoFileName, ref sID));
                // synoList.Add(xml.GetSynonym(bID, synoFileName, ref sID));
                sentenceList.Add(xml.GetSentence(bID, sentenceFileName));
                posList.Add(posType);
            }
            myList.Add(posList);
            myList.Add(sentenceList);
            return myList;
        }

        public string GetSynoFileNameFromPOS(string pos, ref string _posType)
        {
            if (pos == "Noun")
            {
                _posType = "Noun";
                return XmlHandler.synonymNounFilName;

            }
            else if (pos == "Verb")
            {
                _posType = "Verb";
                return XmlHandler.synonymVerbFilName;
            }
            else if (pos == "Adverb")
            {
                _posType = "Adverb";
                return XmlHandler.synonymAdverbFilName;
            }
            else if (pos == "Adjective")
            {
                _posType = "Adjective";
                return XmlHandler.synonymAdjectFilName;
            }
            return null;
        }
        public string GetSentanceFileNameFromPOS(string pos)
        {
            if (pos == "Noun")
            {
                return XmlHandler.sentenceNounFilName;
            }
            else if (pos == "Verb")
            {
                return XmlHandler.sentenceVerbFilName;
            }
            else if (pos == "Adverb")
            {
                return XmlHandler.sentenceAdverbFilName;
            }
            else if (pos == "Adjective")
            {
                return XmlHandler.sentenceAdjectiveFilName;
            }
            return null;
        }
    }
}
