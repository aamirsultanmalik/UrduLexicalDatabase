using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ServiceReference1.MyServiceSoapClient client = new ServiceReference1.MyServiceSoapClient();
            string input = Searchtxtbox.Text;
            List<List<string>> list = new List<List<string>>(client.GetData(input));

            var synonym = list[0];
            var pos = list[1];
            var sentence = list[2];
            

            StringBuilder str = new StringBuilder();

            str.Append("Word");
            str.Append(Environment.NewLine + input + Environment.NewLine);

            foreach (var item in pos)
            {
                str.Append(Environment.NewLine + " Part of Speech" + Environment.NewLine + item + Environment.NewLine);
            }
            str.Append(Environment.NewLine + "Synonyms" + Environment.NewLine);

            foreach (var item in synonym)
            {
                    str.Append(" , " + item);
            }
            str.Append(Environment.NewLine);
            str.Append(Environment.NewLine + "Example Sentence" + Environment.NewLine);
            foreach (var item in sentence)
            {
                str.Append(Environment.NewLine + item + Environment.NewLine);
            }
            

            TextBox1.Text = str.ToString();
        }
    }
}