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
using log4net;
using System.Reflection;
using System.Xml.Linq;
using System.Data.OleDb;

namespace XMLCreate {
    class Program {
        public static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static string CAMPBELLCALPERSID = "6490246026";
        public static string HEALTHEVENTTYPE2;
        public static HealthEventReasonObject HEALTHEVENTREASON;
        public static string fileLocation;
        public static List<CensusRow> rows;
        public static List<EnrollData> uniqueEIDs;
        public static List<KeyValuePair<string, string>> transactionIds = new List<KeyValuePair<string, string>>();
        static readonly string DbConnString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source='\\\\nas3\\Shared\\RALIM\\TDSGroup-Kronos\\Campbell\\Campbell.accdb';Persist Security Info=False;";
        public static List<CIDEntry> cidList = new List<CIDEntry>();
        public static List<string> Unreped = new List<string>();


        [STAThread]
        static void Main(string[] args) {
            log.Info("Connecting to Access DB...");
            using(OleDbConnection conn = new OleDbConnection(DbConnString)) {
                OleDbCommand command = new OleDbCommand("SELECT * FROM CalPERS_ID_Dep", conn);

                try {
                    conn.Open();
                    log.Info("Connected to DB");
                    using(OleDbDataReader reader = command.ExecuteReader()) {
                        Console.WriteLine("------------DATA--------------");
                        log.Info("CalPERS_ID_Dep data loaded");
                        while(reader.Read()) {
                            CIDEntry tempCIDE = new CIDEntry(
                                        reader["EID"].ToString(),
                                        reader["First Name"].ToString(),
                                        reader["Last Name"].ToString(),
                                        reader["Relationship"].ToString(),
                                        reader["Birth Date"].ToString(),
                                        reader["CalPERS ID"].ToString());
                            cidList.Add(tempCIDE);
                            log.Info(tempCIDE.ToString());
                        }
                    }

                    try {
                        command = new OleDbCommand("SELECT * FROM CalPERS_ID_Unrep", conn);
                        using(OleDbDataReader reader = command.ExecuteReader()) {
                            Console.WriteLine("------------DATA--------------");
                            log.Info("CalPERS_ID_Unrep data loaded");
                            while(reader.Read()) {
                                string tempStr = reader["CalPERS_ID"].ToString();
                                Unreped.Add(tempStr);
                                log.Info(tempStr);
                            }
                            log.Info("Finished loading Unreps: " + Unreped.Count);
                        }
                    } catch(Exception e1) {
                        Console.WriteLine(e1.Message);
                        log.Error(e1.Message);
                    }
                } catch(Exception e) {
                    Console.WriteLine(e.Message);
                    log.Error(e.Message);
                }
            }

            log.Info("Starting file loading at " + DateTime.Now);
            //Console.WriteLine(FilePicker());
            fileLocation = FilePicker("csv"); //returns path of chosen file
            if (fileLocation == "ERROR")//check if file picker was cancelled redundant
                Environment.Exit(0);


            uniqueEIDs = new List<EnrollData>();
            //read in CSV
            using (var reader = new StreamReader(fileLocation)) {
                var csv = new CsvReader(reader);
                csv.Configuration.HeaderValidated = null;
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.RegisterClassMap<CensusRowClassMap>();

                var records = csv.GetRecords<CensusRow>().ToList<CensusRow>();//load all records
                
                //group by EID with list of rows, no waived plans
                var eidList = records.Where(rec => 
                rec.CoverageDetails != "Waived" &&
                rec.CoverageDetails != "Terminated" &&
                rec.PlanType == "Medical" && 
                DateTime.Parse(rec.PlanEffectiveEndDate) >= DateTime.Now)
                    .GroupBy(rec => rec.EID)
                    .Select(grouped => new {
                        EID = grouped.Key,
                        rows = grouped.ToList()
                    });
                
                //print EID and names by plan
                foreach (var item in eidList) {
                    Console.WriteLine(item.EID);
                    var enrollData = new EnrollData(item.EID, item.rows);
                    uniqueEIDs.Add(enrollData);
                    foreach (var row in item.rows) {
                        Console.WriteLine("\t" + row.FirstName + 
                            " " + row.LastName + "\t" + row.PlanType + 
                            "\t" + row.PlanAdminName + "\t" + DateTime.Parse(row.PlanEffectiveEndDate).ToShortDateString());
                    }
                }

                Envelope envelope = new Envelope();
                HeaderInfoType headerInfoType = new HeaderInfoType();
                Header header = new Header();
                headerInfoType.InterfaceTypeId = 50031;
                headerInfoType.BusinessPartnerId = CAMPBELLCALPERSID;
                headerInfoType.SchemaVersion = 1.0M;
                headerInfoType.DateTime = DateTime.Now;
                headerInfoType.ContactEmail = "TDSep@TDSGroup.org";
                header.HeaderInfo = headerInfoType;
                envelope.Header = header;

                Body body = new Body();
                //body.Any = xmls;
                body.Any = new []{ SerializeToXmlElement(BuildBody(uniqueEIDs))};
                envelope.Body = body;

                XmlDocument doc = SerializeToXmlDocument(envelope);
                

                XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.InsertBefore(docNode, doc.FirstChild);

                //doc.Save(FilePicker("xml"));
                string defName = DateTime.Now.ToString("yyyyMMddHHmmss_fff_") + "50031";
                XDocument xdoc = XDocument.Parse(doc.OuterXml);
                xdoc.Descendants().Where(e => string.IsNullOrEmpty(e.Value)).Remove();
                //xdoc.Save(GetSaveFile(CAMPBELLCALPERSID + "_XDoc.xml", "XML File | *.xml"));
                //doc.Save(GetSaveFile(CAMPBELLCALPERSID + ".xml", "XML File | *.xml"));
                //xdoc.Save(GetSaveFile(defName + "_xdoc.xml", "XML File | *.xml"));
                doc.Save(GetSaveFile(defName + ".xml", "XML File | *.xml"));

                WriteCSVGUID(GetSaveFile(defName + "_UIDs.csv", "CSV File | *.csv"));
                //prettyPrintXML(doc.InnerXml);
            }
            //end main
        }

        /// <summary>
        /// Write CSV GUIDs to csv file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool WriteCSVGUID(string filePath) {
            //string filePath = FilePicker("csv");
            //string filePath = GetSaveFile(CAMPBELLCALPERSID + "_UIDs.csv", "CSV Files | *.csv");
            //if (filePath == "ERROR") {
            //    Environment.Exit(-1);
            //}
            using (var writer = new StreamWriter(filePath, false, Encoding.UTF8)) {
                try {
                    var csv = new CsvWriter(writer);
                    csv.WriteRecords(transactionIds);
                    return true;
                } catch(Exception e) {
                    Console.WriteLine(e);
                    return false;
                }
            }
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
                PrettyPrintXML(SerializeToXmlDocument(transaction).OuterXml);
                transactions.Add(transaction);
            }

            retirementHealthEnrollmentType.Transaction = transactions.ToArray();
            return retirementHealthEnrollmentType;
        }

        /// <summary>
        /// Returns a transactions which holds the employee and depenedednt records
        /// </summary>
        /// <param name="emp">CensusRow of the Employee Info</param>
        /// <param name="deps">List of CensusRows that hold dependent data</param>
        /// <returns></returns>
        public static TransactionType BuildTransaction(CensusRow emp, List<CensusRow> deps) {
            TransactionType transactionType = new TransactionType();

            EnrollmentTypeForm form = new EnrollmentTypeForm();
            form.ShowDialog();
            transactionType.TransactionType1 = HEALTHEVENTTYPE2;
            EnrollmentEventReasonPicker form2 = new EnrollmentEventReasonPicker();
            form2.ShowDialog();


            Guid guid = Guid.NewGuid();
            transactionIds.Add(new KeyValuePair<string, string>(emp.EID, guid.ToString()));
            transactionType.UniqueTransactionId = guid.ToString();

            transactionType.RescindIndicator = false;
            transactionType.RescindIndicatorSpecified = true;

            IdentifierType identifierType = new IdentifierType();
            if (!String.IsNullOrEmpty(emp.CalPERS_ID)) {
                identifierType.ItemElementName = ItemChoiceType.CalPERSId;
                identifierType.Item = emp.CalPERS_ID;
            } else {
                identifierType.ItemElementName = ItemChoiceType.SSN;
                if (emp.SSN != null) {
                    identifierType.Item = emp.CalPERS_ID;
                } else identifierType.Item = "";
            }

            PersonInfoType personInfoType = new PersonInfoType();
            personInfoType.PersonId = identifierType;

            if (identifierType.ItemElementName == ItemChoiceType.SSN) {
                personInfoType.PersonIdType = IdentificationType.SocialSecurityNumber;
            } else personInfoType.PersonIdType = IdentificationType.CalPERSIndetification;

            personInfoType.FirstName = emp.FirstName;
            personInfoType.MiddleName = emp.MiddleName;
            personInfoType.LastName = emp.LastName;

            DateTime bDate;
            if (DateTime.TryParse(emp.BirthDate, out bDate)) {
                personInfoType.BirthDate = bDate;
                personInfoType.BirthDateSpecified = true;
            } else personInfoType.BirthDateSpecified = false;

            personInfoType.Gender = emp.Gender.Substring(0,1);

            AddressInfoType addressInfoType = new AddressInfoType();
            addressInfoType.AddressType = AddressType.PhysicalAddress;
            addressInfoType.AddressLine = new string[] { emp.Address1.Trim(), emp.Address2.Trim() };
            addressInfoType.City = emp.City;

            if(emp.State == "California")
                addressInfoType.State = StateCode.California;

            addressInfoType.ZipCode5 = emp.Zip;
            addressInfoType.Country = CountryCodes.UnitedStates;

            TransactionTypeDemographics transactionTypeDemographics = new TransactionTypeDemographics();
            transactionTypeDemographics.PersonInfo = personInfoType;
            transactionTypeDemographics.AddressInfo = addressInfoType;
            transactionType.Demographics = transactionTypeDemographics;

            TransactionTypeAppointment transactionTypeAppointment = new TransactionTypeAppointment();

            EmployerInfoType employerInfoType = new EmployerInfoType();
            employerInfoType.EmployerCalPERSId = CAMPBELLCALPERSID;
            employerInfoType.County = CountyCodes.SantaClara;
            transactionTypeAppointment.EmployerInfo = employerInfoType;


            //TODO: MISSING CBU (Collective Bargaining Unit) codes.
            //The collective bargaining unit (CBU) the employee is associated with.
            EmploymentInfoType employmentInfo = new EmploymentInfoType();
            //employmentInfo.CBU = "R03";
            CollectiveBargainingUnit cbu = CollectiveBargainingUnits.GetCollectiveBargainingUnit(emp);
            employmentInfo.CBU = cbu.GroupNumber;
            transactionTypeAppointment.EmploymentInfo = employmentInfo;

            transactionTypeAppointment.JobPositionInfo = new JobPositionInfoType(); //leave empty?
            transactionType.Appointment = transactionTypeAppointment;

            TransactionTypeHealthEnrollment transactionTypeHealthEnrollment = new TransactionTypeHealthEnrollment();
            //transactionTypeHealthEnrollment.HealthEventReason = HealthEventReasonObjects.OpenEnrollmentEmployeesNewEnrollment.CodeValue.ToString();
            transactionTypeHealthEnrollment.HealthEventReason = HEALTHEVENTREASON.CodeValue.ToString();

            transactionTypeHealthEnrollment.EventDateSpecified = true;
            transactionTypeHealthEnrollment.EventDate = DateTime.Parse(emp.EffectiveDate);

            transactionTypeHealthEnrollment.ReceivedDateSpecified = true;
            if (emp.E_SignDate != null && emp.E_SignDate != ""){
                transactionTypeHealthEnrollment.ReceivedDate = DateTime.Parse(emp.E_SignDate);
            } else {
                transactionTypeHealthEnrollment.ReceivedDate = DateTime.Parse(emp.LastModifiedDate);
            } 

            SubscriberInfoType subscriberInfoType = new SubscriberInfoType();
            subscriberInfoType.ApplyChangeToMedicalPlan = true;
            subscriberInfoType.ApplyChangeToDentalPlan = false;
            subscriberInfoType.ApplyChangeToVisionPlan = false;
            //subscriberInfoType.DomesticPartnershipIndicator = false;

            //hard coded as Employer zip
            subscriberInfoType.HealthEligibilityZipCodeType = "Employer";
            subscriberInfoType.HealthEligibilityZipCode = "95008";
            subscriberInfoType.HealthEligibilityCounty = CountyCodes.SanFrancisco;
            subscriberInfoType.MedicalPlanSelection = MedicalPlanCodes.Plans.Where(
                c => c.EaseID == emp.PlanImportID).First().PlanCode;

            transactionTypeHealthEnrollment.SubscriberInfo = subscriberInfoType;
            transactionType.HealthEnrollment = transactionTypeHealthEnrollment;

            List<DependentInfoType> dependents = new List<DependentInfoType>();

            foreach (CensusRow depRow in deps) {
                DependentInfoType dep = new DependentInfoType();
                DependentPersonInfoType depInfo = new DependentPersonInfoType();
                IdentifierType depInfoIdent = new IdentifierType();

                //depInfoIdent.ItemElementName = ItemChoiceType.SSN;
                //depInfoIdent.Item = depRow.SSN;
                //depInfo.PersonId = depInfoIdent;
                //depInfo.PersonIdType = IdentificationType.SocialSecurityNumber;

                depInfo.FirstName = depRow.FirstName;
                depInfo.LastName = depRow.LastName;
                depInfo.BirthDate = DateTime.Parse(depRow.BirthDate);

                string tempDepKey = depInfo.FirstName.Substring(0, 1) +
                                    depInfo.LastName.Substring(0, 1) +
                                    depInfo.BirthDate.ToString("MMddyyyy");

                var tempCID = cidList.Where(d => d.GetDepKey() == tempDepKey).
                    ToList();

                String tempCIDStr = tempCID.First().CalPERSID;
                if(!String.IsNullOrEmpty(tempCIDStr)) {
                    depInfoIdent.ItemElementName = ItemChoiceType.CalPERSId;
                    depInfoIdent.Item = tempCIDStr;
                    depInfo.PersonId = depInfoIdent;
                    depInfo.PersonIdType = IdentificationType.CalPERSIndetification;
                } else {
                    depInfoIdent.ItemElementName = ItemChoiceType.SSN;
                    depInfoIdent.Item = depRow.SSN;
                    depInfo.PersonId = depInfoIdent;
                    depInfo.PersonIdType = IdentificationType.SocialSecurityNumber;
                }

                if(depRow.Gender == null || depRow.Gender == "") {
                    depInfo.Gender = Gender.Unknown;
                } else depInfo.Gender = depRow.Gender.Substring(0,1);

                dep.DependentPersonInfo = depInfo;
                dep.Relationship = GetCalPERSRelationship(depRow.Relationship);

                if (depRow.MaritalDate != null && depRow.MaritalDate != "") {
                    dep.DateOfPartnership = DateTime.Parse(depRow.MaritalDate);
                }

                dep.AddressSameAsPrimarySubscriber = true;
                dep.DependentType = GetCalPERSDependentType(depRow.Relationship);
                dep.DisabilityIndicator = false;
                dep.ApplyToMedical = true;
                dep.ApplyToDental = false;
                dep.ApplyToVision = false;

                if(depRow.Disabled is null || depRow.Disabled == "") {
                    dep.DisabilityConfirmIndicator = false;
                } else if(depRow.Disabled == "No") {
                    dep.DisabilityIndicator = false;
                    dep.DisabilityIndicatorSpecified = true;
                } else {
                    dep.DisabilityIndicator = true;
                    dep.DisabilityIndicatorSpecified = true;
                }

                //dep.DependentAcquiredDate = new DateTime(2018, 10, 31);
                dep.AddressSameAsPrimarySubscriberSpecified = true;
                dep.ApplyToDentalSpecified = false;
                dep.ApplyToMedicalSpecified = true;
                dep.ApplyToVisionSpecified = false;

                dependents.Add(dep);
            }

            transactionTypeHealthEnrollment.DependentInfo = dependents.ToArray();
            transactionType.HealthEnrollment = transactionTypeHealthEnrollment;
            return transactionType;
        }

        public static string GetCalPERSDependentType(string easeRelationship) {
            switch (easeRelationship) {
                case "Spouse":
                    return DependentType.Spouse;

                case "Child":
                    return DependentType.DependentNaturalBornChild;

                case "Child-Domestic Partner":
                    return DependentType.DomesticPartnerChild;

                case "Child-Adopted":
                    return DependentType.DependentAdoptedChild;

                case "Child-Foster":
                    return DependentType.EconomicallyDependentChild;

                case "Child-Grandchild":
                    return DependentType.EconomicallyDependentChild;

                case "Child-Step":
                    return DependentType.StepChild;

                case "Child-Legal Guardian":
                    return DependentType.EconomicallyDependentChild;

                case "Domestic Partner":
                    return DependentType.DomesticPartner;

                default:
                    return "";
            }
        }

        /// <summary>
        /// Input ease relationship, get the CalPERS Dependent relationship
        /// </summary>
        /// <param name="easeRelationship"></param>
        /// <returns>string of the CalPERS dependent relationship
        /// Defaults to OtherPerson</returns>
        public static string GetCalPERSRelationship(string easeRelationship) {

            switch (easeRelationship) {
                case "Spouse":
                    return DependentRelationship.Spouse;

                case "Child":
                    return DependentRelationship.Child;

                case "Child-Domestic Partner":
                    return DependentRelationship.DomesticPartnerChild;

                case "Child-Adopted":
                    return DependentRelationship.AdoptedChild;

                case "Child-Foster":
                    return DependentRelationship.OtherPerson;

                case "Child-Grandchild":
                    return DependentRelationship.Grandchild;

                case "Child-Step":
                    return DependentRelationship.StepChild;

                case "Child-Legal Guardian":
                    return DependentRelationship.OtherPerson;

                case "Domestic Partner":
                    return DependentRelationship.DomesticPartner;

                default:
                    return DependentRelationship.OtherPerson;
            }
        }

        /// <summary>
        /// Opens Dialog to choose CSV file to be loaded. Writes to Global fileLocation
        /// </summary>
        /// <returns>void, data stored in global fileLocation</returns>
        public static string FilePicker(string type){
            string returnStr = "ERROR";

            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.InitialDirectory = KnownFolders.Downloads.Path;
                ofd.Filter = type + " files (*." + type + ")| *." + type;
                ofd.FilterIndex = 1;

                if (ofd.ShowDialog() == DialogResult.OK) {
                    returnStr = ofd.FileName;
                } //else Environment.Exit(-1);
            }

            return returnStr;
        }

        public static string GetSaveFile(string defaultFileName, string fileTypes) {
            string retStr = "ERROR";

            using(SaveFileDialog sfd = new SaveFileDialog()) {
                sfd.Filter = fileTypes;
                sfd.RestoreDirectory = true;
                sfd.FileName = defaultFileName;
                var result = sfd.ShowDialog();

                if (String.IsNullOrEmpty(sfd.FileName)) {
                    return retStr;
                } else return sfd.FileName;
            }
        }

        /// <summary>
        /// Returns the XMLElement for the RetirementHealthEnrollmentType
        /// </summary>
        /// <param name="o">The Object to be converted to XmlElement</param>
        /// <returns></returns>
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


        /// <summary>
        /// Returns XMLDocument when given the envelope
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Prints a formatted XML
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
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
