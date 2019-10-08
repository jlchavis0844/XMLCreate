namespace XMLCreate {
    partial class MedicalPlanCodeForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMedCancel = new System.Windows.Forms.Button();
            this.btnMedOK = new System.Windows.Forms.Button();
            this.dgvMedPlans = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedPlans)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMedCancel);
            this.panel1.Controls.Add(this.btnMedOK);
            this.panel1.Controls.Add(this.dgvMedPlans);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 542);
            this.panel1.TabIndex = 0;
            // 
            // btnMedCancel
            // 
            this.btnMedCancel.Location = new System.Drawing.Point(629, 507);
            this.btnMedCancel.Name = "btnMedCancel";
            this.btnMedCancel.Size = new System.Drawing.Size(159, 23);
            this.btnMedCancel.TabIndex = 2;
            this.btnMedCancel.Text = "Cancel and Exit";
            this.btnMedCancel.UseVisualStyleBackColor = true;
            this.btnMedCancel.Click += new System.EventHandler(this.BtnMedCancel_Click);
            // 
            // btnMedOK
            // 
            this.btnMedOK.Location = new System.Drawing.Point(28, 507);
            this.btnMedOK.Name = "btnMedOK";
            this.btnMedOK.Size = new System.Drawing.Size(159, 23);
            this.btnMedOK.TabIndex = 1;
            this.btnMedOK.Text = "Save and Exit";
            this.btnMedOK.UseVisualStyleBackColor = true;
            this.btnMedOK.Click += new System.EventHandler(this.BtnMedOK_Click);
            // 
            // dgvMedPlans
            // 
            this.dgvMedPlans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMedPlans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedPlans.Location = new System.Drawing.Point(0, 0);
            this.dgvMedPlans.Name = "dgvMedPlans";
            this.dgvMedPlans.Size = new System.Drawing.Size(800, 482);
            this.dgvMedPlans.TabIndex = 0;
            // 
            // MedicalPlanCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 542);
            this.Controls.Add(this.panel1);
            this.Name = "MedicalPlanCodeForm";
            this.Text = "MedicalPlanCodeForm";
            this.Load += new System.EventHandler(this.MedicalPlanCodeForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedPlans)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvMedPlans;
        private System.Windows.Forms.Button btnMedCancel;
        private System.Windows.Forms.Button btnMedOK;
    }
}