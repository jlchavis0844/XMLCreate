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

            foreach(DataColumn col in Program.MedPlans.Columns) {
                col.ReadOnly = false;
            }

            dgvMedPlans.DataSource = Program.MedPlans;
            dgvMedPlans.Refresh();
        }

        private void BtnMedCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void BtnMedOK_Click(object sender, EventArgs e) {
            string filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\CalPERSPlanData.csv"));
            DataTable dataTable = (DataTable)dgvMedPlans.DataSource;
            using(var writer = new StreamWriter(filePath, false, Encoding.UTF8)) {
                try {
                    using(var csvWriter = new CsvWriter(writer)) {

                        foreach(DataColumn column in dataTable.Columns) {
                            csvWriter.WriteField(column.ColumnName);
                        }

                        csvWriter.NextRecord();

                        foreach(DataRow row in dataTable.Rows) {
                            for(var i = 0; i < dataTable.Columns.Count; i++) {
                                csvWriter.WriteField(row[i]);
                            }
                            csvWriter.NextRecord();
                        }
                    }
                    Program.MedPlans = dataTable;
                } catch(Exception e2) {
                    Console.WriteLine(e2);
                    Program.log.Error(e2.Message);
                }
            }
            this.Close();
        }
    }
}
