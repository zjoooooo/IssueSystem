namespace IssueSystem
{
    partial class BarrierOpenReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarrierOpenReport));
            this.remote_control_historyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SunparkCentralDataSet = new IssueSystem.SunparkCentralDataSet();
            this.Start_Date_picker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.End_date_picker = new System.Windows.Forms.DateTimePicker();
            this.batch_combo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.remote_control_historyTableAdapter = new IssueSystem.SunparkCentralDataSetTableAdapters.remote_control_historyTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.remote_control_historyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SunparkCentralDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // remote_control_historyBindingSource
            // 
            this.remote_control_historyBindingSource.DataMember = "remote_control_history";
            this.remote_control_historyBindingSource.DataSource = this.SunparkCentralDataSet;
            // 
            // SunparkCentralDataSet
            // 
            this.SunparkCentralDataSet.DataSetName = "SunparkCentralDataSet";
            this.SunparkCentralDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Start_Date_picker
            // 
            this.Start_Date_picker.CustomFormat = "yyyy-MM-dd";
            this.Start_Date_picker.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start_Date_picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Start_Date_picker.Location = new System.Drawing.Point(262, 31);
            this.Start_Date_picker.Name = "Start_Date_picker";
            this.Start_Date_picker.Size = new System.Drawing.Size(99, 23);
            this.Start_Date_picker.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(204, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(376, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // End_date_picker
            // 
            this.End_date_picker.CustomFormat = "yyyy-MM-dd";
            this.End_date_picker.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.End_date_picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.End_date_picker.Location = new System.Drawing.Point(406, 31);
            this.End_date_picker.Name = "End_date_picker";
            this.End_date_picker.Size = new System.Drawing.Size(99, 23);
            this.End_date_picker.TabIndex = 4;
            // 
            // batch_combo
            // 
            this.batch_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.batch_combo.FormattingEnabled = true;
            this.batch_combo.Items.AddRange(new object[] {
            "B26BBCL",
            "B28B30",
            "AMK",
            "HGJE"});
            this.batch_combo.Location = new System.Drawing.Point(77, 32);
            this.batch_combo.Name = "batch_combo";
            this.batch_combo.Size = new System.Drawing.Size(99, 21);
            this.batch_combo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(23, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Batch";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.remote_control_historyBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "IssueSystem.BarrierOpenReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 132);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1048, 504);
            this.reportViewer1.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(169)))), ((int)(((byte)(39)))));
            this.button1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(406, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 30);
            this.button1.TabIndex = 12;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(791, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(226, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // remote_control_historyTableAdapter
            // 
            this.remote_control_historyTableAdapter.ClearBeforeFill = true;
            // 
            // BarrierOpenReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(1048, 636);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.batch_combo);
            this.Controls.Add(this.End_date_picker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Start_Date_picker);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "BarrierOpenReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BarrierOpenReport";
            this.Load += new System.EventHandler(this.BarrierOpenReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.remote_control_historyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SunparkCentralDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker Start_Date_picker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker End_date_picker;
        private System.Windows.Forms.ComboBox batch_combo;
        private System.Windows.Forms.Label label3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource remote_control_historyBindingSource;
        private SunparkCentralDataSet SunparkCentralDataSet;
        private SunparkCentralDataSetTableAdapters.remote_control_historyTableAdapter remote_control_historyTableAdapter;
    }
}