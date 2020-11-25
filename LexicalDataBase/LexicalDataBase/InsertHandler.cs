using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LexicalDataBase
{
    /// <summary>
    /// this class is handling insert operations
    /// </summary>
    public class InsertHandler
    {
        /// <summary>
        /// this method woul be used to fill base word entries in the baseWords.xml file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="wordID"></param>
        /// <param name="text"></param>
        /// <param name="listPOS"></param>
        ///<summary>
        public void InsertBaseWord(string filename, int wordID, string text, List<string> listPOS)
        {
            XDocument xdoc = XDocument.Load(filename);
            XElement element = xdoc.Element("BaseWords");//loading 
            List<XElement> elementList = new List<XElement>();//generate new tage/ tree
            foreach (var item in listPOS)
            {
                var el = new XElement("POS", item);
                elementList.Add(el);
            }
            XElement myel = new XElement("Tree", (new XElement("ID", wordID)), new XElement("Word", text), elementList);
            element.Add(myel);
            xdoc.Save(XmlHandler.baseWordFilName);
        }

        public void InsertSynonym(string filename,int bID,int sID,string text)
        {
            XDocument xdoc = XDocument.Load(filename);
            XElement element = xdoc.Element("Synonyms");
            XElement newElement = new XElement(new XElement("Node", new XElement("SID", sID), new XElement("BID", bID), new XElement("Synonym", text)));
            element.Add(newElement);
            xdoc.Save(filename);
        }
        public void InsertSentence(string filename, int bID, int senID, string text)
        {
            XDocument xdoc = XDocument.Load(filename);
            XElement element = xdoc.Element("Sentence");
            XElement newElement = new XElement(new XElement("Node", new XElement("Sen_ID", senID), new XElement("BID", bID), new XElement("Senetence", text)));
            element.Add(newElement);
            xdoc.Save(filename);
        }
    }
}
