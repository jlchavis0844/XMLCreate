using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLCreate {
    public partial class MedicalPlanCodeForm : Form {
        public MedicalPlanCodeForm() {
            InitializeComponent();
        }

        private void MedicalPlanCodeForm_Load(object sender, EventArgs e) {
            var here = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\CalPERSPlanData.csv"));
            using(var reader = new StreamReader(here)) {
                using(var csv = new CsvReader(reader)) {
                    csv.Configuration.HeaderValidated = null;
                    csv.Configuration.HasHeaderRecord = true;

                    using(var dr = new CsvDataReader(csv)) {
                        var dt = new DataTable();
                        dt.Load(dr);
                        dgvMedPlans.DataSource = dt;
                        dgvMedPlans.Refresh();
                    }
                }
            }
        }
    }
}
