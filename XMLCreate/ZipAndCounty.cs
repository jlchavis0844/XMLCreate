using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLCreate {
    public class ZipAndCounty {
        public readonly string Zip;
        public readonly string CountyName;
        public readonly string CountyCode;

        public ZipAndCounty(string Zip, string CountyName, string CountyCode) {
            this.Zip = Zip;
            this.CountyName = CountyName;
            this.CountyCode = CountyCode;
        }
    }
}
