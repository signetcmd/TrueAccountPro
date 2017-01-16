using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BLL
{

    

    public class xmlConfigOpr

    {
        xmlConfigInfo myXmlConfigInfo = new xmlConfigInfo();
        string myXmlFilePath = Application.StartupPath + "\\settings.xml";
        XmlDocument myXml = new XmlDocument();

        XmlDocument xml = new XmlDocument();

        public string getXmlSettings(string node, string child)
        {
            try
            {
                xml.Load(myXmlFilePath);

                return xml.SelectSingleNode("//" + node + "/" + child).InnerText;
            }
            catch (Exception ex)
            {
                return "s";
            }



        }

        public void  updateXmlSettings(string node, string child,string value)
        {
            xml.Load(myXmlFilePath);

            xml.SelectSingleNode("//" + node + "/" + child).InnerText = value;
            xml.Save(myXmlFilePath);

        }

    }
}
