using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLCreate {
    class HEInfo {
        public string CalPERS_ID { set; get; }
        public string HEZip { set; get; }
        public string HEType { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string MedicalGroup { set; get; }

        public HEInfo(string CalPERS_ID, string FirstName, string LastName, string HEZip, 
            string HEType, string MedicalGroup) {
            this.CalPERS_ID = CalPERS_ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.HEZip = HEZip;
            this.HEType = HEType;
            this.MedicalGroup = MedicalGroup;
        }
    }
}
