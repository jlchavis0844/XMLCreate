using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace XMLCreate {
    public partial class EnrollmentEventReasonPicker : Form {
        private static HealthEventReasonObject prevValue;

        public EnrollmentEventReasonPicker() {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e) {
            HealthEventReasonObject choice = ((KeyValuePair<string, HealthEventReasonObject>)cbEnroll.SelectedItem).Value;
            if (String.IsNullOrEmpty(choice.ToString())) {
                MessageBox.Show("Error, no choice made", "ERROR: No choice was made.\nExiting");
                Application.Exit();
            }
            Program.HEALTHEVENTREASON = choice;
            this.Close();
        }

        private void EnrollmentEventReasonPicker_Load(object sender, EventArgs e) {
            prevValue = Program.HEALTHEVENTREASON;

            Dictionary<string, HealthEventReasonObject> items = new Dictionary<string, HealthEventReasonObject>();
            foreach(HealthEventReasonObject hero in HealthEventReasonObjects.GetAllObjects()) {
                if (hero.HealthEventTypeField == Program.HEALTHEVENTTYPE2)
                    items.Add(hero.LongName, hero);
            }

            cbEnroll.DataSource = new BindingSource(items, null);
            cbEnroll.DisplayMember = "Key";
            cbEnroll.ValueMember = "Value";
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Program.HEALTHEVENTREASON = prevValue;
            this.Close();
        }
    }
}
