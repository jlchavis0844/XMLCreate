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
        public static List<CensusRow> rows;
        public static List<EnrollData> uniqueEIDs;

        [STAThread]
        static void Main(string[] args) {
            //Console.WriteLine(FilePicker());
            fileLocation = FilePicker(); //returns path of chosen file
            if (fileLocation == "ERROR")//check if file picker was cancelled redundant
                Environment.Exit(0);

            //read in CSV
            using (var reader = new StreamReader(fileLocation)) {
                var csv = new CsvReader(reader);
                csv.Configuration.HeaderValidated = null;
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.RegisterClassMap<CensusRowClassMap>();

                var records = csv.GetRecords<CensusRow>().ToList<CensusRow>();//load all records
                
                //group by EID with list of rows, no waived plans
                var eidList = records.Where(rec => rec.CoverageDetails != "Waived" &&
                rec.PlanType == "Medical" && DateTime.Parse(rec.PlanEffectiveEndDate) >= DateTime.Now)
                    .GroupBy(rec => rec.EID)
                    .Select(grouped => new {
                        EID = grouped.Key,
                        rows = grouped.ToList()
                    });
                uniqueEIDs = new List<EnrollData>();
                //print EID and names by plan
                foreach (var item in eidList) {
                    Console.WriteLine(item.EID);
                    var enrollData = new EnrollData(item.EID, item.rows);
                    foreach(var row in item.rows) {
                        Console.WriteLine("\t" + row.FirstName + 
                            " " + row.LastName + "\t" + row.PlanType + 
                            "\t" + row.PlanAdminName + "\t" + DateTime.Parse(row.PlanEffectiveEndDate));
                    }
                }

            }

            
            Console.ReadLine();
        }

        /// <summary>
        /// Returns a RetirementHealthEnrollmentType which holds all transactions
        /// and is the only body element. Acts as transaction wrapper/list
        /// </summary>
        /// <param name="list"> The census enrollments to convert to transactions wrapped in RetirementHealthEnrollmentType</param>
        /// <returns>RetirementHealthEnrollmentType</returns>
        public static RetirementHealthEnrollmentType BuildBody(List<EnrollData> list) {
            RetirementHealthEnrollmentType retirementHealthEnrollmentType = new RetirementHealthEnrollmentType();
            List<TransactionType> transactions = new List<TransactionType>();
            foreach(var item in list) {
                CensusRow emp = item.Rows.Where(row => row.RelationshipCode == "0").ToList()[0];
                List<CensusRow> deps = item.Rows.Where(row => row.RelationshipCode != "0").ToList();

                TransactionType transaction = BuildTransaction(emp, deps);
                transactions.Add(transaction);
            }

            retirementHealthEnrollmentType.Transaction = transactions.ToArray();
            return retirementHealthEnrollmentType;
        } 


        public static string FilePicker(){
            string returnStr = "ERROR";

            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.InitialDirectory = KnownFolders.Downloads.Path;
                ofd.Filter = "csv files (*.csv)| *.csv";
                ofd.FilterIndex = 1;

                if (ofd.ShowDialog() == DialogResult.OK) {
                    returnStr = ofd.FileName;
                } else Environment.Exit(-1);
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
