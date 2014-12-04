using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
 using     System.Xml.Schema;
   using   System.Xml.Serialization;
 using     System.Xml.XPath ;
using System.Xml.Xsl;
namespace XML_deneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
       
        private void Form1_Load(object sender, EventArgs e)
        {
 XmlDocument myDoc = new XmlDocument();
        myDoc.Load(MapPath("DTDl2.xml"));
        XmlNodeList rankList = myDoc.SelectNodes("/fsm/states/state[@name='start']/transition/Rank");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlStateMachine fsm = new XmlStateMachine();
            fsm.StateTable = "DTDl2.xml";
            fsm.CurrentState = "start";
           

            XmlTextReader xmlReader = new XmlTextReader("DTDl2.xml");
            XmlNodeType myNodeType = xmlReader.NodeType;
            xmlReader.Read();
            while (xmlReader.Read())
            {
                string value = doc.XPathSelectElement("//requisitionData[2]/element1").Value;
             // textBox1.Text = xmlReader.GetType().ToString();
                //xmlReader.MoveToElement();
              /*if (xmlReader.Namespaces.ToString() == "start")
               {
                    //fsm.CurrentState = xmlReader.ReadString();
                    textBox1.Text =fsm.CurrentState;
               }*/
               if ((myNodeType == XmlNodeType.Text))
               {
                  textBox1.Text=  xmlReader.Name.ToString();
              }
              //  fsm.CurrentState = xmlReader.ReadString();
               // textBox1.Text = fsm.CurrentState;
            }
        }
    }
}
   
