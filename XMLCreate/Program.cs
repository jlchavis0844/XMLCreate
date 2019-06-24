using CsvHelper;
using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Linq;

namespace XMLCreate {
    class Program {
        public static string fileLocation;

        [STAThread]
        static void Main(string[] args) {
            //Console.WriteLine(FilePicker());
            fileLocation = FilePicker();
            if (fileLocation == "ERROR")
                Environment.Exit(0);

            using (var reader = new StreamReader(fileLocation)) {
                var csv = new CsvReader(reader);
                csv.Configuration.HeaderValidated = null;
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.RegisterClassMap<CensusRowClassMap>();

                var records = csv.GetRecords<CensusRow>();
                List<CensusRow> rows = records.ToList();

                foreach(CensusRow record in rows.GroupBy(r => r.EID ).ToList()){
                    Console.WriteLine(record.FirstName);
                }
            }
            Console.ReadLine();
        }

        public static string FilePicker(){
            string returnStr = "ERROR";

            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.InitialDirectory = KnownFolders.Downloads.Path;
                ofd.Filter = "csv files (*.csv)| *.csv";
                ofd.FilterIndex = 1;

                if(ofd.ShowDialog() == DialogResult.OK) {
                    returnStr = ofd.FileName;
                }
            }

            return returnStr;
        }

        public static XmlElement SerializeToXmlElement(object o) {
            XmlDocument doc = new XmlDocument();
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("cuns", "http://calpers.ca.gov/PSR/CommonUtilitiesV1");
            namespaces.Add("n1", "http://calpers.ca.gov/PSR/RetirementHealthTransactionsV1");
            namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            //namespaces.Add("schemaLocation", "http://calpers.ca.gov/PSR/RetirementHealthTransactionsV1 RetirementHealthTransactionsV1.xsd");

            using (XmlWriter writer = doc.CreateNavigator().AppendChild()) {
                new XmlSerializer(o.GetType()).Serialize(writer, o, namespaces);
            }

            return doc.DocumentElement;
        }

        public static XmlDocument SerializeToXmlDocument(object o) {
            XmlDocument doc = new XmlDocument();
            XPathNavigator nav = doc.CreateNavigator();
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("soap", "http://schemas.xmlsoap.org/soap/envelope/");
            namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            namespaces.Add("schemaLocation", "http://schemas.xmlsoap.org/soap/envelope/ SoapEnvelope.xsd");
            namespaces.Add("cuns", "http://calpers.ca.gov/PSR/CommonUtilitiesV1");


            using (XmlWriter w = nav.AppendChild()){
                XmlSerializer ser = new XmlSerializer(o.GetType());
                ser.Serialize(w, o, namespaces);
            }
            return doc;
        }

        public static string PrettyPrintXML(string xml) {
            string result = "ERROR";

            MemoryStream mStream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);
            XmlDocument document = new XmlDocument();

            try {
                document.LoadXml(xml);
                writer.Formatting = Formatting.Indented;
                document.WriteContentTo(writer);

                writer.Flush();
                mStream.Flush();
                mStream.Position = 0;

                StreamReader sReader = new StreamReader(mStream);
                string formattedXml = sReader.ReadToEnd();

                result = formattedXml;

            } catch (Exception e1) {
                Console.WriteLine(e1);
            } finally {
                mStream.Dispose();
                //writer.Dispose();
                Console.WriteLine(result);
            }


            return result;
        }
    }
}
