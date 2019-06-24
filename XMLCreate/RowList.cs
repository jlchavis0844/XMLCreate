using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLCreate {
    class EnrollData {
        public List<CensusRow> Rows { get; set; }
        public string EID;

        public EnrollData(string EID) {
            this.EID = EID;
        }

        public EnrollData() {
        }

        public EnrollData(string EID, List<CensusRow> rows) {
            this.EID = EID;
            this.Rows = rows;
        }

    }
}
