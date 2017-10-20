namespace IssueSystem
{
    partial class NewBarrierRemote
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
            this.B26_tabControl = new System.Windows.Forms.TabControl();
            this.B26_tabPage = new System.Windows.Forms.TabPage();
            this.test_btn = new System.Windows.Forms.Button();
            this.A37_btn = new System.Windows.Forms.Button();
            this.A52_btn = new System.Windows.Forms.Button();
            this.B28_tabPage = new System.Windows.Forms.TabPage();
            this.B26_tabControl.SuspendLayout();
            this.B26_tabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // B26_tabControl
            // 
            this.B26_tabControl.Controls.Add(this.B26_tabPage);
            this.B26_tabControl.Controls.Add(this.B28_tabPage);
            this.B26_tabControl.ItemSize = new System.Drawing.Size(42, 18);
            this.B26_tabControl.Location = new System.Drawing.Point(12, 99);
            this.B26_tabControl.Name = "B26_tabControl";
            this.B26_tabControl.SelectedIndex = 0;
            this.B26_tabControl.Size = new System.Drawing.Size(1107, 531);
            this.B26_tabControl.TabIndex = 0;
            // 
            // B26_tabPage
            // 
            this.B26_tabPage.Controls.Add(this.test_btn);
            this.B26_tabPage.Controls.Add(this.A37_btn);
            this.B26_tabPage.Controls.Add(this.A52_btn);
            this.B26_tabPage.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B26_tabPage.Location = new System.Drawing.Point(4, 22);
            this.B26_tabPage.Name = "B26_tabPage";
            this.B26_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.B26_tabPage.Size = new System.Drawing.Size(1099, 505);
            this.B26_tabPage.TabIndex = 0;
            this.B26_tabPage.Text = "B26";
            this.B26_tabPage.UseVisualStyleBackColor = true;
            // 
            // test_btn
            // 
            this.test_btn.Location = new System.Drawing.Point(316, 43);
            this.test_btn.Name = "test_btn";
            this.test_btn.Size = new System.Drawing.Size(87, 48);
            this.test_btn.TabIndex = 9;
            this.test_btn.Text = "test";
            this.test_btn.UseVisualStyleBackColor = true;
            this.test_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // A37_btn
            // 
            this.A37_btn.Location = new System.Drawing.Point(174, 43);
            this.A37_btn.Name = "A37_btn";
            this.A37_btn.Size = new System.Drawing.Size(87, 48);
            this.A37_btn.TabIndex = 8;
            this.A37_btn.Text = "A37";
            this.A37_btn.UseVisualStyleBackColor = true;
            // 
            // A52_btn
            // 
            this.A52_btn.Location = new System.Drawing.Point(37, 43);
            this.A52_btn.Name = "A52_btn";
            this.A52_btn.Size = new System.Drawing.Size(87, 48);
            this.A52_btn.TabIndex = 7;
            this.A52_btn.Text = "A52";
            this.A52_btn.UseVisualStyleBackColor = true;
            this.A52_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // B28_tabPage
            // 
            this.B28_tabPage.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B28_tabPage.Location = new System.Drawing.Point(4, 22);
            this.B28_tabPage.Name = "B28_tabPage";
            this.B28_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.B28_tabPage.Size = new System.Drawing.Size(1099, 505);
            this.B28_tabPage.TabIndex = 1;
            this.B28_tabPage.Text = "B28";
            this.B28_tabPage.UseVisualStyleBackColor = true;
            // 
            // NewBarrierRemote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(1133, 706);
            this.Controls.Add(this.B26_tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NewBarrierRemote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NewBarrierRemote";
            this.Load += new System.EventHandler(this.NewBarrierRemote_Load);
            this.B26_tabControl.ResumeLayout(false);
            this.B26_tabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl B26_tabControl;
        private System.Windows.Forms.TabPage B26_tabPage;
        private System.Windows.Forms.TabPage B28_tabPage;
        private System.Windows.Forms.Button A52_btn;
        private System.Windows.Forms.Button test_btn;
        private System.Windows.Forms.Button A37_btn;
    }
}