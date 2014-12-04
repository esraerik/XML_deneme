using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Diagnostics;

namespace XML_deneme
{
    class XmlStateMachine
    {

        private XmlTextReader tableParser;
        private string stateCurrent;
        private string stateTable;
        private string action;
        public XmlStateMachine() {
            tableParser = null;
            stateCurrent = String.Empty;
			stateTable = String.Empty;
			action = String.Empty;
		}
        public string CurrentState
        {
            get
            {
                return stateCurrent;
            }
            set
            {
                stateCurrent = value;
            }
        }
        public string Action
        {
            get
            {
                return action;
            }
        }

        public string StateTable
        {
            get
            {
                return stateTable;
            }
            set
            {
                stateTable = value;
            }
        }
        public string Next(string inputArg)
        {
            string nextState = String.Empty;

            if (CurrentState != String.Empty)
            {
                try
                {
                     tableParser = new XmlTextReader(StateTable);

                    while (true == tableParser.Read())
                    {
                        if (XmlNodeType.Element == tableParser.NodeType)
                        {
                            if (true == tableParser.HasAttributes)
                            {
                                string state = tableParser.GetAttribute("name");
                                if (state == CurrentState)
                                {
                                    // Get transition data
                                    while (true == tableParser.Read())
                                    {
                                        if ((XmlNodeType.Element == tableParser.NodeType) && ("transition" == tableParser.Name))
                                        {
                                            if (true == tableParser.HasAttributes)
                                            {
                                                string input = tableParser.GetAttribute("input");
                                                if (input == inputArg)
                                                {
                                                    CurrentState = tableParser.GetAttribute("next");
                                                    nextState = CurrentState;
                                                    action = tableParser.GetAttribute("action");
                                                    return nextState;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (XmlException e)
                {
                    // Eliminate default trace listener
                    Trace.Listeners.RemoveAt(0);
                    // Add console trace listener
                    TextWriterTraceListener myWriter = new TextWriterTraceListener(System.Console.Out);
                    Trace.Listeners.Add(myWriter);
                    Trace.WriteLine("[XMLStateMachine] Could not load state table definition.");
                    Trace.Indent();
                    Trace.WriteLine(e.Message);
                    Trace.Unindent();
                    // 	Clean up object
                    tableParser.Close();
                    tableParser = null;
                    stateCurrent = String.Empty;
                    action = String.Empty;
                }
            }

            return nextState;
        }

     
    }
}
