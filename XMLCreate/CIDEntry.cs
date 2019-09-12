using System;

namespace XMLCreate {
    public class CIDEntry {
        public string EID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Relationship { set; get; }
        public DateTime BirthDate { set; get; }
        public string BirthDateStr;
        public string CalPERSID { set; get; }
        private bool BirthDateSet;

        public CIDEntry(string EID, string FirstName, string LastName, string Relationship,
            string BirthDate, string CalPERSID) {
            this.EID = EID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Relationship = Relationship;
            this.CalPERSID = CalPERSID;
            BirthDateStr = BirthDate.Split(' ')[0];
            DateTime tempDT;
            BirthDateSet = DateTime.TryParse(BirthDate, out tempDT);
            this.BirthDate = tempDT;

        }

        public bool IsBirthDateSet() {
            return BirthDateSet;
        }

        public override string ToString() {
            return EID + "\t" + FirstName + "\t" + LastName + "\t" + Relationship
                 + "\t" + BirthDateStr + "\t" + CalPERSID;
        }

        public string GetDepKey() {
            string retStr = FirstName.Substring(0, 1) + LastName.Substring(0, 1) +
                BirthDate.ToString("MMddyyyy");
            return retStr;
        }

    }
}