using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LexicalDataBase
{
    public class ReadHandler
    {
        public int GetLastBaseID(string fileName)
        {
            int id = 0;
            XDocument xdoc = XDocument.Load(fileName);
            var elemnets = xdoc.Element("BaseWords").Elements();
            if (elemnets.Count()<=0)
            {
                return 0;
            }
            var lastElemnt = elemnets.Last<XElement>();
            if (lastElemnt.Name=="Tree")
            {
                foreach (var childNodes in lastElemnt.Elements())
                {
                    if (childNodes.Name=="ID")
                    {
                        id = Convert.ToInt32(childNodes.Value);
                    }
                }
            }
            return id;
        }
        public int GetLastSynoID(string fileName)
        {
            int id = 0;
            XDocument xdoc = XDocument.Load(fileName);
            var elemnets = xdoc.Element("Synonyms").Elements();
            if (elemnets.Count<XElement>()>0)
            {
                var lastElement = elemnets.Last<XElement>();
                if (lastElement.Name == "Node")
                {
                    foreach (var childNodes in lastElement.Elements())
                    {
                        if (childNodes.Name == "SID")
                        {
                            id = Convert.ToInt32(childNodes.Value);
                        }
                    }
                }
            }
            
            return id;
        }
        public int GetLastSenetnceID(string fileName)
        {
            int id = 0;
            XDocument xdoc = XDocument.Load(fileName);
            var elemnets = xdoc.Element("Sentence").Elements();
            if (elemnets.Count<XElement>() > 0)
            {
                var lastElement = elemnets.Last<XElement>();
                if (lastElement.Name == "Node")
                {
                    foreach (var childNodes in lastElement.Elements())
                    {
                        if (childNodes.Name == "Sen_ID")
                        {
                            id = Convert.ToInt32(childNodes.Value);
                        }
                    }
                }
            }

            return id;
        }
        public void GetBaseWordInfo(ref int bID, ref List<string> posList, string text)
        {
            XDocument xdoc = XDocument.Load(XmlHandler.baseWordFilName);
            var tree = xdoc.Descendants("Tree");
            var setectedTree = (from trees in tree
                                where trees.Element("Word").Value == text
                                select trees.Elements()).ToList();
            foreach (var item in setectedTree)
            {
                foreach (var item1 in item)
                {
                    if (item1.Name=="ID")
                    {
                        bID = Convert.ToInt32(item1.Value);
                    }
                    if (item1.Name=="POS")
                    {
                        posList.Add(item1.Value);
                    }
                }
            }
        }
        public List<string> GetSynonym(int bID, string fileName, ref int sID)
        {
            List<string> result = new List<string>();
            XDocument xdoc = XDocument.Load(fileName);
            var tree = xdoc.Descendants("Node");
            var setectedTree = (from trees in tree
                                where trees.Element("BID").Value == bID.ToString()
                                select trees.Elements()).ToList();
            foreach (var item in setectedTree)
            {
                foreach (var item1 in item)
                {
                    if (item1.Name == "SID")
                    {
                        sID = Convert.ToInt32(item1.Value);
                    }
                    if (item1.Name == "Synonym")
                    {
                        result.Add(item1.Value);
                    }
                }
            }
            return result;
        }
        public string GetSentence(int bID,string fileName)
        {
            string sentenceWord = null;
            XDocument xdoc = XDocument.Load(fileName);
            var tree = xdoc.Descendants("Node");
            var setectedTree = (from trees in tree
                                where trees.Element("BID").Value == bID.ToString()
                                select trees.Elements()).ToList();
            foreach (var item in setectedTree)
            {
                foreach (var item1 in item)
                {
                    if (item1.Name == "Senetence")
                    {
                        sentenceWord = item1.Value;
                    }
                }
            }
            return sentenceWord;
        }
    }
}
