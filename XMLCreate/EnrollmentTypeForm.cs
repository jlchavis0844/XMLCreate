using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace XMLCreate {
    public partial class EnrollmentTypeForm : Form {
        private static string prevHET;

        public EnrollmentTypeForm() {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Program.HEALTHEVENTTYPE2 = prevHET;
            this.Close();
        }

        private void EnrollmentTypeForm_Load(object sender, EventArgs e) {
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

        private void btnOK_Click(object sender, EventArgs e) {
            string choice = ((KeyValuePair<string, string>)cbEnroll.SelectedItem).Value;
            if (String.IsNullOrEmpty(choice)) {
                MessageBox.Show("Error, no choice made", "ERROR: No choice was made.\n Exiting");
                //this.Close();
                Application.Exit();
                //Environment.Exit(-1);
            }
                Program.HEALTHEVENTTYPE2 = choice;
            this.Close();
        }
    }
}
