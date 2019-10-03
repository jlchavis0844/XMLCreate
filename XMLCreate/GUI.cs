using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace XMLCreate {
    public partial class GUI : Form {
        private static string prevHET;
        private static HealthEventReasonObject prevSubHET;

        public GUI() {
            InitializeComponent();
        }

        public void UpdateStatus(string msg) {
            ssInfo.Text = msg;
            this.Update();
        }

        private void GUI_Load(object sender, EventArgs e) {
            cbSchools.DataSource = new BindingSource(Schools.GetSchools(), null);
            cbSchools.DisplayMember = "Value";
            cbSchools.ValueMember = "Key";
            cbSchools.SelectedIndex = 0;
            cbSchools.ResetText();
            //to reset selected value
            cbSchools.SelectedIndex = -1;

            prevHET = Program.HEALTHEVENTTYPE2;

            Dictionary<string, string> hetItems = new Dictionary<string, string>();
            hetItems.Add("Add Dependent", HealthEventType.AddDependent);
            hetItems.Add("Delete Dependent", HealthEventType.DeleteDependent);
            hetItems.Add("Cancel Coverage", HealthEventType.CancelCoverage);
            hetItems.Add("Change Health Plan", HealthEventType.ChangeHealthPlan);
            hetItems.Add("Dependent Address Change", HealthEventType.DependentAddressChange);
            hetItems.Add("Change Premium Payment Method", HealthEventType.ChangePremiumPaymentMethod);
            hetItems.Add("New Enrollment", HealthEventType.NewEnrollment);
            hetItems.Add("Open Enrollment", HealthEventType.OpenEnrollment);
            hetItems.Add("Continued Enrollment", HealthEventType.ContinuedEnrollment);
            hetItems.Add("Update Enrollment", HealthEventType.UpdateEnrollment);
            hetItems.Add("COBRA New Enrollment", HealthEventType.COBRANewEnrollment);
            cbEnroll.DataSource = new BindingSource(hetItems, null);
            cbEnroll.DisplayMember = "Key";
            cbEnroll.ValueMember = "Value";
        }

        private void CbSchools_SelectedIndexChanged(object sender, EventArgs e) {
            if(cbSchools.SelectedIndex != -1) {
                var pick = (KeyValuePair<string, string>)cbSchools.SelectedItem;
                //School picked = (School)cbSchools.SelectedItem;
                ssInfo.Text = pick.Value + " selected. Press \"Load School\" button to continue...";
                btnConnect.Enabled = true;
            } else {
                ssInfo.Text = "Please select school";
                btnConnect.Enabled = false;
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e) {
            Program.school = new School((KeyValuePair<string, string>)cbSchools.SelectedItem);
            if(Program.ConnectToDB()) {
                btnLoadInput.Enabled = true;
            }
        }

        private void BtnLoadInput_Click(object sender, EventArgs e) {
            string returnStr = "ERROR";

            using(OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.InitialDirectory = KnownFolders.Downloads.Path;
                ofd.Filter = "CSV files (*.CSV)| *.CSV";
                ofd.FilterIndex = 1;

                if(ofd.ShowDialog() == DialogResult.OK) {
                    returnStr = ofd.FileName;
                } //else Environment.Exit(-1);
            }

            lblInput.Text = returnStr;

            if(string.IsNullOrEmpty(lblInput.Text)) {
                btnProcess.Enabled = false;
            } else {
                btnProcess.Enabled = true;
            }
        }

        private void BtnProcess_Click(object sender, EventArgs e) {
            XDocument doc = Program.Run(lblInput.Text);
            tbPreview.Text = doc.ToString();
        }

        private void CbEnroll_SelectedIndexChanged(object sender, EventArgs e) {
            var temp = (KeyValuePair<string, string>)cbEnroll.SelectedItem;
            Program.HEALTHEVENTTYPE2 = temp.Value;
               
            Dictionary<string, HealthEventReasonObject> items = new Dictionary<string, HealthEventReasonObject>();
            if(!string.IsNullOrEmpty(Program.HEALTHEVENTTYPE2)) {
                foreach(HealthEventReasonObject hero in HealthEventReasonObjects.GetAllObjects()) {
                    if(hero.HealthEventTypeField == Program.HEALTHEVENTTYPE2)
                        items.Add(hero.LongName, hero);
                }

                cbSubEnroll.DataSource = new BindingSource(items, null);
                cbSubEnroll.DisplayMember = "Key";
                cbSubEnroll.ValueMember = "Value";
            }
        }

        private void CbSubEnroll_SelectedIndexChanged(object sender, EventArgs e) {
            var temp = (KeyValuePair<string, HealthEventReasonObject>)cbSubEnroll.SelectedItem;
            Program.HEALTHEVENTREASON = temp.Value;
        }

        private void TbPreview_TextChanged(object sender, EventArgs e) {

        }
    }
}
