namespace IssueSystem
{
    partial class ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            this.comboSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtOldpwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtNewpwd = new System.Windows.Forms.TextBox();
            this.TxtcfNewpwd = new System.Windows.Forms.TextBox();
            this.ComboCancel = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // comboSave
            // 
            this.comboSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(169)))), ((int)(((byte)(39)))));
            this.comboSave.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboSave.Location = new System.Drawing.Point(69, 194);
            this.comboSave.Name = "comboSave";
            this.comboSave.Size = new System.Drawing.Size(75, 23);
            this.comboSave.TabIndex = 0;
            this.comboSave.Text = "Save";
            this.comboSave.UseVisualStyleBackColor = false;
            this.comboSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(66, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Old Password";
            // 
            // TxtOldpwd
            // 
            this.TxtOldpwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOldpwd.Location = new System.Drawing.Point(173, 60);
            this.TxtOldpwd.Name = "TxtOldpwd";
            this.TxtOldpwd.PasswordChar = '*';
            this.TxtOldpwd.Size = new System.Drawing.Size(100, 22);
            this.TxtOldpwd.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(66, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "New Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(10, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Confirm New Password";
            // 
            // TxtNewpwd
            // 
            this.TxtNewpwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNewpwd.Location = new System.Drawing.Point(173, 98);
            this.TxtNewpwd.Name = "TxtNewpwd";
            this.TxtNewpwd.PasswordChar = '*';
            this.TxtNewpwd.Size = new System.Drawing.Size(100, 22);
            this.TxtNewpwd.TabIndex = 5;
            // 
            // TxtcfNewpwd
            // 
            this.TxtcfNewpwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtcfNewpwd.Location = new System.Drawing.Point(173, 134);
            this.TxtcfNewpwd.Name = "TxtcfNewpwd";
            this.TxtcfNewpwd.PasswordChar = '*';
            this.TxtcfNewpwd.Size = new System.Drawing.Size(100, 22);
            this.TxtcfNewpwd.TabIndex = 6;
            // 
            // ComboCancel
            // 
            this.ComboCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(169)))), ((int)(((byte)(39)))));
            this.ComboCancel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ComboCancel.Location = new System.Drawing.Point(266, 194);
            this.ComboCancel.Name = "ComboCancel";
            this.ComboCancel.Size = new System.Drawing.Size(75, 23);
            this.ComboCancel.TabIndex = 7;
            this.ComboCancel.Text = "Cancel";
            this.ComboCancel.UseVisualStyleBackColor = false;
            this.ComboCancel.Click += new System.EventHandler(this.ComboCancel_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(285, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(97, 45);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 107;
            this.pictureBox3.TabStop = false;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(405, 241);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.ComboCancel);
            this.Controls.Add(this.TxtcfNewpwd);
            this.Controls.Add(this.TxtNewpwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtOldpwd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePassword";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button comboSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtOldpwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtNewpwd;
        private System.Windows.Forms.TextBox TxtcfNewpwd;
        private System.Windows.Forms.Button ComboCancel;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}