namespace XMLCreate {
    partial class GUI {
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
            this.cbSchools = new System.Windows.Forms.ComboBox();
            this.lblSchool = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSubReason = new System.Windows.Forms.Label();
            this.cbSubEnroll = new System.Windows.Forms.ComboBox();
            this.cbEnrollReason = new System.Windows.Forms.Label();
            this.cbEnroll = new System.Windows.Forms.ComboBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.tbPreview = new System.Windows.Forms.TextBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.btnLoadInput = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ssInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.btnMedPlans = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbSchools
            // 
            this.cbSchools.FormattingEnabled = true;
            this.cbSchools.Location = new System.Drawing.Point(113, 4);
            this.cbSchools.Name = "cbSchools";
            this.cbSchools.Size = new System.Drawing.Size(235, 21);
            this.cbSchools.TabIndex = 0;
            this.cbSchools.SelectedIndexChanged += new System.EventHandler(this.CbSchools_SelectedIndexChanged);
            // 
            // lblSchool
            // 
            this.lblSchool.AutoSize = true;
            this.lblSchool.Location = new System.Drawing.Point(8, 8);
            this.lblSchool.Name = "lblSchool";
            this.lblSchool.Size = new System.Drawing.Size(79, 13);
            this.lblSchool.TabIndex = 1;
            this.lblSchool.Text = "Choose School";
            // 
            // btnConnect
            // 
            this.btnConnect.Enabled = false;
            this.btnConnect.Location = new System.Drawing.Point(374, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(115, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Load School";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMedPlans);
            this.panel1.Controls.Add(this.lblSubReason);
            this.panel1.Controls.Add(this.cbSubEnroll);
            this.panel1.Controls.Add(this.cbEnrollReason);
            this.panel1.Controls.Add(this.cbEnroll);
            this.panel1.Controls.Add(this.btnProcess);
            this.panel1.Controls.Add(this.tbPreview);
            this.panel1.Controls.Add(this.lblInput);
            this.panel1.Controls.Add(this.btnLoadInput);
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Controls.Add(this.cbSchools);
            this.panel1.Controls.Add(this.lblSchool);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 833);
            this.panel1.TabIndex = 3;
            // 
            // lblSubReason
            // 
            this.lblSubReason.AutoSize = true;
            this.lblSubReason.Location = new System.Drawing.Point(8, 118);
            this.lblSubReason.Name = "lblSubReason";
            this.lblSubReason.Size = new System.Drawing.Size(66, 13);
            this.lblSubReason.TabIndex = 10;
            this.lblSubReason.Text = "Sub Reason";
            // 
            // cbSubEnroll
            // 
            this.cbSubEnroll.FormattingEnabled = true;
            this.cbSubEnroll.Location = new System.Drawing.Point(113, 114);
            this.cbSubEnroll.Name = "cbSubEnroll";
            this.cbSubEnroll.Size = new System.Drawing.Size(235, 21);
            this.cbSubEnroll.TabIndex = 9;
            this.cbSubEnroll.SelectedIndexChanged += new System.EventHandler(this.CbSubEnroll_SelectedIndexChanged);
            // 
            // cbEnrollReason
            // 
            this.cbEnrollReason.AutoSize = true;
            this.cbEnrollReason.Location = new System.Drawing.Point(8, 79);
            this.cbEnrollReason.Name = "cbEnrollReason";
            this.cbEnrollReason.Size = new System.Drawing.Size(93, 13);
            this.cbEnrollReason.TabIndex = 8;
            this.cbEnrollReason.Text = "Enollment Reason";
            // 
            // cbEnroll
            // 
            this.cbEnroll.FormattingEnabled = true;
            this.cbEnroll.Location = new System.Drawing.Point(113, 75);
            this.cbEnroll.Name = "cbEnroll";
            this.cbEnroll.Size = new System.Drawing.Size(235, 21);
            this.cbEnroll.TabIndex = 7;
            this.cbEnroll.SelectedIndexChanged += new System.EventHandler(this.CbEnroll_SelectedIndexChanged);
            // 
            // btnProcess
            // 
            this.btnProcess.Enabled = false;
            this.btnProcess.Location = new System.Drawing.Point(11, 154);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(115, 23);
            this.btnProcess.TabIndex = 6;
            this.btnProcess.Text = "Process File";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.BtnProcess_Click);
            // 
            // tbPreview
            // 
            this.tbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPreview.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPreview.Location = new System.Drawing.Point(11, 183);
            this.tbPreview.Multiline = true;
            this.tbPreview.Name = "tbPreview";
            this.tbPreview.ReadOnly = true;
            this.tbPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbPreview.Size = new System.Drawing.Size(928, 647);
            this.tbPreview.TabIndex = 5;
            this.tbPreview.TextChanged += new System.EventHandler(this.TbPreview_TextChanged);
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(8, 47);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(74, 13);
            this.lblInput.TabIndex = 4;
            this.lblInput.Text = "Waiting for file";
            // 
            // btnLoadInput
            // 
            this.btnLoadInput.Enabled = false;
            this.btnLoadInput.Location = new System.Drawing.Point(374, 42);
            this.btnLoadInput.Name = "btnLoadInput";
            this.btnLoadInput.Size = new System.Drawing.Size(115, 23);
            this.btnLoadInput.TabIndex = 3;
            this.btnLoadInput.Text = "Load Input File";
            this.btnLoadInput.UseVisualStyleBackColor = true;
            this.btnLoadInput.Click += new System.EventHandler(this.BtnLoadInput_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(974, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ssInfo
            // 
            this.ssInfo.BackColor = System.Drawing.SystemColors.Control;
            this.ssInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ssInfo.Name = "ssInfo";
            this.ssInfo.Size = new System.Drawing.Size(130, 17);
            this.ssInfo.Text = "toolStripStatusLabel1";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(974, 848);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(974, 870);
            this.toolStripContainer1.TabIndex = 5;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // btnMedPlans
            // 
            this.btnMedPlans.Location = new System.Drawing.Point(183, 154);
            this.btnMedPlans.Name = "btnMedPlans";
            this.btnMedPlans.Size = new System.Drawing.Size(165, 23);
            this.btnMedPlans.TabIndex = 11;
            this.btnMedPlans.Text = "View/Edit Medical Plans";
            this.btnMedPlans.UseVisualStyleBackColor = true;
            this.btnMedPlans.Click += new System.EventHandler(this.BtnMedPlans_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 870);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "GUI";
            this.Text = "GUI";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSchools;
        private System.Windows.Forms.Label lblSchool;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ssInfo;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Button btnLoadInput;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TextBox tbPreview;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label cbEnrollReason;
        private System.Windows.Forms.ComboBox cbEnroll;
        private System.Windows.Forms.Label lblSubReason;
        private System.Windows.Forms.ComboBox cbSubEnroll;
        private System.Windows.Forms.Button btnMedPlans;
    }
}