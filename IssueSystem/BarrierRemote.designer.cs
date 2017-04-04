using System.Windows.Forms;
namespace IssueSystem
{
    partial class BarrierRemote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarrierRemote));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.ENTRY5 = new System.Windows.Forms.CheckBox();
            this.ENTRY6 = new System.Windows.Forms.CheckBox();
            this.ENTRY7 = new System.Windows.Forms.CheckBox();
            this.ENTRY8 = new System.Windows.Forms.CheckBox();
            this.EXIT5 = new System.Windows.Forms.CheckBox();
            this.EXIT6 = new System.Windows.Forms.CheckBox();
            this.EXIT7 = new System.Windows.Forms.CheckBox();
            this.EXIT8 = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ENTRY3 = new System.Windows.Forms.CheckBox();
            this.ENTRY4 = new System.Windows.Forms.CheckBox();
            this.EXIT2 = new System.Windows.Forms.CheckBox();
            this.EXIT3 = new System.Windows.Forms.CheckBox();
            this.EXIT4 = new System.Windows.Forms.CheckBox();
            this.ENTRY1 = new System.Windows.Forms.CheckBox();
            this.ENTRY2 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.LBENTRY2 = new System.Windows.Forms.CheckBox();
            this.LBENTRY1 = new System.Windows.Forms.CheckBox();
            this.LBENTRY3 = new System.Windows.Forms.CheckBox();
            this.SENTRY = new System.Windows.Forms.CheckBox();
            this.LBEXIT1 = new System.Windows.Forms.CheckBox();
            this.LBEXIT2 = new System.Windows.Forms.CheckBox();
            this.LBEXIT3 = new System.Windows.Forms.CheckBox();
            this.SEXIT = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.EXIT1 = new System.Windows.Forms.CheckBox();
            this.SEXIT2 = new System.Windows.Forms.CheckBox();
            this.SENTRY2 = new System.Windows.Forms.CheckBox();
            this.SEXIT3 = new System.Windows.Forms.CheckBox();
            this.SENTRY3 = new System.Windows.Forms.CheckBox();
            this.SEXIT4 = new System.Windows.Forms.CheckBox();
            this.SENTRY4 = new System.Windows.Forms.CheckBox();
            this.SEXIT5 = new System.Windows.Forms.CheckBox();
            this.SENTRY5 = new System.Windows.Forms.CheckBox();
            this.SEXIT6 = new System.Windows.Forms.CheckBox();
            this.SENTRY6 = new System.Windows.Forms.CheckBox();
            this.SEXIT7 = new System.Windows.Forms.CheckBox();
            this.SENTRY7 = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(352, 122);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(198, 147);
            this.listBox1.TabIndex = 75;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // ENTRY5
            // 
            this.ENTRY5.AutoSize = true;
            this.ENTRY5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ENTRY5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ENTRY5.Location = new System.Drawing.Point(188, 315);
            this.ENTRY5.Name = "ENTRY5";
            this.ENTRY5.Size = new System.Drawing.Size(68, 18);
            this.ENTRY5.TabIndex = 59;
            this.ENTRY5.Text = "ENTRY5";
            this.ENTRY5.UseVisualStyleBackColor = true;
            this.ENTRY5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Set_ENTRY5);
            // 
            // ENTRY6
            // 
            this.ENTRY6.AutoSize = true;
            this.ENTRY6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ENTRY6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ENTRY6.Location = new System.Drawing.Point(326, 315);
            this.ENTRY6.Name = "ENTRY6";
            this.ENTRY6.Size = new System.Drawing.Size(68, 18);
            this.ENTRY6.TabIndex = 60;
            this.ENTRY6.Text = "ENTRY6";
            this.ENTRY6.UseVisualStyleBackColor = true;
            this.ENTRY6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Set_ENTRY6);
            // 
            // ENTRY7
            // 
            this.ENTRY7.AutoSize = true;
            this.ENTRY7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ENTRY7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ENTRY7.Location = new System.Drawing.Point(464, 315);
            this.ENTRY7.Name = "ENTRY7";
            this.ENTRY7.Size = new System.Drawing.Size(68, 18);
            this.ENTRY7.TabIndex = 61;
            this.ENTRY7.Text = "ENTRY7";
            this.ENTRY7.UseVisualStyleBackColor = true;
            this.ENTRY7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Set_ENTRY7);
            // 
            // ENTRY8
            // 
            this.ENTRY8.AutoSize = true;
            this.ENTRY8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ENTRY8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ENTRY8.Location = new System.Drawing.Point(464, 339);
            this.ENTRY8.Name = "ENTRY8";
            this.ENTRY8.Size = new System.Drawing.Size(68, 18);
            this.ENTRY8.TabIndex = 62;
            this.ENTRY8.Text = "ENTRY8";
            this.ENTRY8.UseVisualStyleBackColor = true;
            this.ENTRY8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Set_ENTRY8);
            // 
            // EXIT5
            // 
            this.EXIT5.AutoSize = true;
            this.EXIT5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EXIT5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.EXIT5.Location = new System.Drawing.Point(259, 315);
            this.EXIT5.Name = "EXIT5";
            this.EXIT5.Size = new System.Drawing.Size(61, 18);
            this.EXIT5.TabIndex = 69;
            this.EXIT5.Text = "EXIT5";
            this.EXIT5.UseVisualStyleBackColor = true;
            this.EXIT5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Set_EXIT5);
            // 
            // EXIT6
            // 
            this.EXIT6.AutoSize = true;
            this.EXIT6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EXIT6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.EXIT6.Location = new System.Drawing.Point(397, 315);
            this.EXIT6.Name = "EXIT6";
            this.EXIT6.Size = new System.Drawing.Size(61, 18);
            this.EXIT6.TabIndex = 70;
            this.EXIT6.Text = "EXIT6";
            this.EXIT6.UseVisualStyleBackColor = true;
            this.EXIT6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Set_EXIT6);
            // 
            // EXIT7
            // 
            this.EXIT7.AutoSize = true;
            this.EXIT7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EXIT7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.EXIT7.Location = new System.Drawing.Point(538, 315);
            this.EXIT7.Name = "EXIT7";
            this.EXIT7.Size = new System.Drawing.Size(61, 18);
            this.EXIT7.TabIndex = 71;
            this.EXIT7.Text = "EXIT7";
            this.EXIT7.UseVisualStyleBackColor = true;
            this.EXIT7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Set_EXIT7);
            // 
            // EXIT8
            // 
            this.EXIT8.AutoSize = true;
            this.EXIT8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EXIT8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.EXIT8.Location = new System.Drawing.Point(538, 339);
            this.EXIT8.Name = "EXIT8";
            this.EXIT8.Size = new System.Drawing.Size(61, 18);
            this.EXIT8.TabIndex = 72;
            this.EXIT8.Text = "EXIT8";
            this.EXIT8.UseVisualStyleBackColor = true;
            this.EXIT8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Set_EXIT8);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 561);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(691, 24);
            this.statusStrip1.TabIndex = 98;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(554, 19);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(122, 19);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(350, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 99;
            this.label1.Text = "CarPark List";
            // 
            // listBox2
            // 
            this.listBox2.ForeColor = System.Drawing.Color.Red;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(49, 121);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(279, 147);
            this.listBox2.TabIndex = 100;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(46, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 15);
            this.label2.TabIndex = 101;
            this.label2.Text = "Barrier Status OverView Window";
            // 
            // ENTRY3
            // 
            this.ENTRY3.AutoSize = true;
            this.ENTRY3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ENTRY3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ENTRY3.Location = new System.Drawing.Point(326, 291);
            this.ENTRY3.Name = "ENTRY3";
            this.ENTRY3.Size = new System.Drawing.Size(68, 18);
            this.ENTRY3.TabIndex = 57;
            this.ENTRY3.Text = "ENTRY3";
            this.ENTRY3.UseVisualStyleBackColor = true;
            this.ENTRY3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Set_ENTRY3);
            // 
            // ENTRY4
            // 
            this.ENTRY4.AutoSize = true;
            this.ENTRY4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ENTRY4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ENTRY4.Location = new System.Drawing.Point(464, 291);
            this.ENTRY4.Name = "ENTRY4";
            this.ENTRY4.Size = new System.Drawing.Size(68, 18);
            this.ENTRY4.TabIndex = 58;
            this.ENTRY4.Text = "ENTRY4";
            this.ENTRY4.UseVisualStyleBackColor = true;
            this.ENTRY4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Set_ENTRY4);
            // 
            // EXIT2
            // 
            this.EXIT2.AutoSize = true;
            this.EXIT2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EXIT2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.EXIT2.Location = new System.Drawing.Point(259, 291);
            this.EXIT2.Name = "EXIT2";
            this.EXIT2.Size = new System.Drawing.Size(61, 18);
            this.EXIT2.TabIndex = 66;
            this.EXIT2.Text = "EXIT2";
            this.EXIT2.UseVisualStyleBackColor = true;
            this.EXIT2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Set_EXIT2);
            // 
            // EXIT3
            // 
            this.EXIT3.AutoSize = true;
            this.EXIT3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EXIT3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.EXIT3.Location = new System.Drawing.Point(397, 291);
            this.EXIT3.Name = "EXIT3";
            this.EXIT3.Size = new System.Drawing.Size(61, 18);
            this.EXIT3.TabIndex = 67;
            this.EXIT3.Text = "EXIT3";
            this.EXIT3.UseVisualStyleBackColor = true;
            this.EXIT3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Set_EXIT3);
            // 
            // EXIT4
            // 
            this.EXIT4.AutoSize = true;
            this.EXIT4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EXIT4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.EXIT4.Location = new System.Drawing.Point(538, 291);
            this.EXIT4.Name = "EXIT4";
            this.EXIT4.Size = new System.Drawing.Size(61, 18);
            this.EXIT4.TabIndex = 68;
            this.EXIT4.Text = "EXIT4";
            this.EXIT4.UseVisualStyleBackColor = true;
            this.EXIT4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Set_EXIT4);
            // 
            // ENTRY1
            // 
            this.ENTRY1.AutoSize = true;
            this.ENTRY1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ENTRY1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ENTRY1.Location = new System.Drawing.Point(50, 291);
            this.ENTRY1.Name = "ENTRY1";
            this.ENTRY1.Size = new System.Drawing.Size(68, 18);
            this.ENTRY1.TabIndex = 55;
            this.ENTRY1.Text = "ENTRY1";
            this.ENTRY1.UseVisualStyleBackColor = true;
            this.ENTRY1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Set_ENTRY1);
            // 
            // ENTRY2
            // 
            this.ENTRY2.AutoSize = true;
            this.ENTRY2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ENTRY2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ENTRY2.Location = new System.Drawing.Point(188, 291);
            this.ENTRY2.Name = "ENTRY2";
            this.ENTRY2.Size = new System.Drawing.Size(68, 18);
            this.ENTRY2.TabIndex = 56;
            this.ENTRY2.Text = "ENTRY2";
            this.ENTRY2.UseVisualStyleBackColor = true;
            this.ENTRY2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Set_ENTRY2);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(169)))), ((int)(((byte)(39)))));
            this.button3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(555, 121);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 23);
            this.button3.TabIndex = 104;
            this.button3.Text = "Add";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(169)))), ((int)(((byte)(39)))));
            this.button4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button4.Location = new System.Drawing.Point(555, 246);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(64, 23);
            this.button4.TabIndex = 105;
            this.button4.Text = "Delete";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // LBENTRY2
            // 
            this.LBENTRY2.AutoSize = true;
            this.LBENTRY2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBENTRY2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LBENTRY2.Location = new System.Drawing.Point(49, 435);
            this.LBENTRY2.Name = "LBENTRY2";
            this.LBENTRY2.Size = new System.Drawing.Size(82, 18);
            this.LBENTRY2.TabIndex = 106;
            this.LBENTRY2.Text = "LBENTRY2";
            this.LBENTRY2.UseVisualStyleBackColor = true;
            this.LBENTRY2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LBENTRY2_KeyDown);
            // 
            // LBENTRY1
            // 
            this.LBENTRY1.AutoSize = true;
            this.LBENTRY1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBENTRY1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LBENTRY1.Location = new System.Drawing.Point(49, 411);
            this.LBENTRY1.Name = "LBENTRY1";
            this.LBENTRY1.Size = new System.Drawing.Size(82, 18);
            this.LBENTRY1.TabIndex = 107;
            this.LBENTRY1.Text = "LBENTRY1";
            this.LBENTRY1.UseVisualStyleBackColor = true;
            this.LBENTRY1.Visible = false;
            this.LBENTRY1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LBENTRY1_KeyDown);
            // 
            // LBENTRY3
            // 
            this.LBENTRY3.AutoSize = true;
            this.LBENTRY3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBENTRY3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LBENTRY3.Location = new System.Drawing.Point(213, 435);
            this.LBENTRY3.Name = "LBENTRY3";
            this.LBENTRY3.Size = new System.Drawing.Size(82, 18);
            this.LBENTRY3.TabIndex = 108;
            this.LBENTRY3.Text = "LBENTRY3";
            this.LBENTRY3.UseVisualStyleBackColor = true;
            this.LBENTRY3.Visible = false;
            this.LBENTRY3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LBENTRY3_KeyDown);
            // 
            // SENTRY
            // 
            this.SENTRY.AutoSize = true;
            this.SENTRY.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SENTRY.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SENTRY.Location = new System.Drawing.Point(50, 315);
            this.SENTRY.Name = "SENTRY";
            this.SENTRY.Size = new System.Drawing.Size(68, 18);
            this.SENTRY.TabIndex = 109;
            this.SENTRY.Text = "SENTRY";
            this.SENTRY.UseVisualStyleBackColor = true;
            this.SENTRY.Visible = false;
            this.SENTRY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Set_SENTRY);
            // 
            // LBEXIT1
            // 
            this.LBEXIT1.AutoSize = true;
            this.LBEXIT1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBEXIT1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LBEXIT1.Location = new System.Drawing.Point(132, 411);
            this.LBEXIT1.Name = "LBEXIT1";
            this.LBEXIT1.Size = new System.Drawing.Size(75, 18);
            this.LBEXIT1.TabIndex = 110;
            this.LBEXIT1.Text = "LBEXIT1";
            this.LBEXIT1.UseVisualStyleBackColor = true;
            this.LBEXIT1.Visible = false;
            this.LBEXIT1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LBEXIT1_KeyDown);
            // 
            // LBEXIT2
            // 
            this.LBEXIT2.AutoSize = true;
            this.LBEXIT2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBEXIT2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LBEXIT2.Location = new System.Drawing.Point(132, 435);
            this.LBEXIT2.Name = "LBEXIT2";
            this.LBEXIT2.Size = new System.Drawing.Size(75, 18);
            this.LBEXIT2.TabIndex = 111;
            this.LBEXIT2.Text = "LBEXIT2";
            this.LBEXIT2.UseVisualStyleBackColor = true;
            this.LBEXIT2.Visible = false;
            this.LBEXIT2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LBEXIT2_KeyDown);
            // 
            // LBEXIT3
            // 
            this.LBEXIT3.AutoSize = true;
            this.LBEXIT3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBEXIT3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LBEXIT3.Location = new System.Drawing.Point(301, 435);
            this.LBEXIT3.Name = "LBEXIT3";
            this.LBEXIT3.Size = new System.Drawing.Size(75, 18);
            this.LBEXIT3.TabIndex = 112;
            this.LBEXIT3.Text = "LBEXIT3";
            this.LBEXIT3.UseVisualStyleBackColor = true;
            this.LBEXIT3.Visible = false;
            this.LBEXIT3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LBEXIT3_KeyDown);
            // 
            // SEXIT
            // 
            this.SEXIT.AutoSize = true;
            this.SEXIT.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SEXIT.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SEXIT.Location = new System.Drawing.Point(121, 315);
            this.SEXIT.Name = "SEXIT";
            this.SEXIT.Size = new System.Drawing.Size(61, 18);
            this.SEXIT.TabIndex = 113;
            this.SEXIT.Text = "SEXIT";
            this.SEXIT.UseVisualStyleBackColor = true;
            this.SEXIT.Visible = false;
            this.SEXIT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SEXIT_KeyDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(169)))), ((int)(((byte)(39)))));
            this.button1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(49, 475);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 36);
            this.button1.TabIndex = 114;
            this.button1.Text = "Open Barrier";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(169)))), ((int)(((byte)(39)))));
            this.button2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(453, 475);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 36);
            this.button2.TabIndex = 115;
            this.button2.Text = "Close Barrier";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(555, 33);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(97, 45);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 116;
            this.pictureBox3.TabStop = false;
            // 
            // EXIT1
            // 
            this.EXIT1.AutoSize = true;
            this.EXIT1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EXIT1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.EXIT1.Location = new System.Drawing.Point(121, 291);
            this.EXIT1.Name = "EXIT1";
            this.EXIT1.Size = new System.Drawing.Size(61, 18);
            this.EXIT1.TabIndex = 117;
            this.EXIT1.Text = "EXIT1";
            this.EXIT1.UseVisualStyleBackColor = true;
            this.EXIT1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EXIT1_KeyDown);
            // 
            // SEXIT2
            // 
            this.SEXIT2.AutoSize = true;
            this.SEXIT2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SEXIT2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SEXIT2.Location = new System.Drawing.Point(121, 339);
            this.SEXIT2.Name = "SEXIT2";
            this.SEXIT2.Size = new System.Drawing.Size(68, 18);
            this.SEXIT2.TabIndex = 119;
            this.SEXIT2.Text = "SEXIT2";
            this.SEXIT2.UseVisualStyleBackColor = true;
            this.SEXIT2.Visible = false;
            this.SEXIT2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SEXIT2_KeyDown);
            // 
            // SENTRY2
            // 
            this.SENTRY2.AutoSize = true;
            this.SENTRY2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SENTRY2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SENTRY2.Location = new System.Drawing.Point(49, 339);
            this.SENTRY2.Name = "SENTRY2";
            this.SENTRY2.Size = new System.Drawing.Size(75, 18);
            this.SENTRY2.TabIndex = 118;
            this.SENTRY2.Text = "SENTRY2";
            this.SENTRY2.UseVisualStyleBackColor = true;
            this.SENTRY2.Visible = false;
            this.SENTRY2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SENTRY2_KeyDown);
            // 
            // SEXIT3
            // 
            this.SEXIT3.AutoSize = true;
            this.SEXIT3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SEXIT3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SEXIT3.Location = new System.Drawing.Point(260, 339);
            this.SEXIT3.Name = "SEXIT3";
            this.SEXIT3.Size = new System.Drawing.Size(68, 18);
            this.SEXIT3.TabIndex = 121;
            this.SEXIT3.Text = "SEXIT3";
            this.SEXIT3.UseVisualStyleBackColor = true;
            this.SEXIT3.Visible = false;
            this.SEXIT3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SEXIT3_KeyDown);
            // 
            // SENTRY3
            // 
            this.SENTRY3.AutoSize = true;
            this.SENTRY3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SENTRY3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SENTRY3.Location = new System.Drawing.Point(188, 339);
            this.SENTRY3.Name = "SENTRY3";
            this.SENTRY3.Size = new System.Drawing.Size(75, 18);
            this.SENTRY3.TabIndex = 120;
            this.SENTRY3.Text = "SENTRY3";
            this.SENTRY3.UseVisualStyleBackColor = true;
            this.SENTRY3.Visible = false;
            this.SENTRY3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SENTRY3_KeyDown);
            // 
            // SEXIT4
            // 
            this.SEXIT4.AutoSize = true;
            this.SEXIT4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SEXIT4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SEXIT4.Location = new System.Drawing.Point(121, 363);
            this.SEXIT4.Name = "SEXIT4";
            this.SEXIT4.Size = new System.Drawing.Size(68, 18);
            this.SEXIT4.TabIndex = 123;
            this.SEXIT4.Text = "SEXIT4";
            this.SEXIT4.UseVisualStyleBackColor = true;
            this.SEXIT4.Visible = false;
            this.SEXIT4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SEXIT4_KeyDown);
            // 
            // SENTRY4
            // 
            this.SENTRY4.AutoSize = true;
            this.SENTRY4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SENTRY4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SENTRY4.Location = new System.Drawing.Point(49, 363);
            this.SENTRY4.Name = "SENTRY4";
            this.SENTRY4.Size = new System.Drawing.Size(75, 18);
            this.SENTRY4.TabIndex = 122;
            this.SENTRY4.Text = "SENTRY4";
            this.SENTRY4.UseVisualStyleBackColor = true;
            this.SENTRY4.Visible = false;
            this.SENTRY4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SENTRY4_KeyDown);
            // 
            // SEXIT5
            // 
            this.SEXIT5.AutoSize = true;
            this.SEXIT5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SEXIT5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SEXIT5.Location = new System.Drawing.Point(260, 364);
            this.SEXIT5.Name = "SEXIT5";
            this.SEXIT5.Size = new System.Drawing.Size(68, 18);
            this.SEXIT5.TabIndex = 125;
            this.SEXIT5.Text = "SEXIT5";
            this.SEXIT5.UseVisualStyleBackColor = true;
            this.SEXIT5.Visible = false;
            this.SEXIT5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SEXIT5_KeyDown);
            // 
            // SENTRY5
            // 
            this.SENTRY5.AutoSize = true;
            this.SENTRY5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SENTRY5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SENTRY5.Location = new System.Drawing.Point(188, 364);
            this.SENTRY5.Name = "SENTRY5";
            this.SENTRY5.Size = new System.Drawing.Size(75, 18);
            this.SENTRY5.TabIndex = 124;
            this.SENTRY5.Text = "SENTRY5";
            this.SENTRY5.UseVisualStyleBackColor = true;
            this.SENTRY5.Visible = false;
            this.SENTRY5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SENTRY5_KeyDown);
            // 
            // SEXIT6
            // 
            this.SEXIT6.AutoSize = true;
            this.SEXIT6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SEXIT6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SEXIT6.Location = new System.Drawing.Point(121, 387);
            this.SEXIT6.Name = "SEXIT6";
            this.SEXIT6.Size = new System.Drawing.Size(68, 18);
            this.SEXIT6.TabIndex = 127;
            this.SEXIT6.Text = "SEXIT6";
            this.SEXIT6.UseVisualStyleBackColor = true;
            this.SEXIT6.Visible = false;
            this.SEXIT6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SEXIT6_KeyDown);
            // 
            // SENTRY6
            // 
            this.SENTRY6.AutoSize = true;
            this.SENTRY6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SENTRY6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SENTRY6.Location = new System.Drawing.Point(49, 387);
            this.SENTRY6.Name = "SENTRY6";
            this.SENTRY6.Size = new System.Drawing.Size(75, 18);
            this.SENTRY6.TabIndex = 126;
            this.SENTRY6.Text = "SENTRY6";
            this.SENTRY6.UseVisualStyleBackColor = true;
            this.SENTRY6.Visible = false;
            this.SENTRY6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SENTRY6_KeyDown);
            // 
            // SEXIT7
            // 
            this.SEXIT7.AutoSize = true;
            this.SEXIT7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SEXIT7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SEXIT7.Location = new System.Drawing.Point(259, 388);
            this.SEXIT7.Name = "SEXIT7";
            this.SEXIT7.Size = new System.Drawing.Size(68, 18);
            this.SEXIT7.TabIndex = 129;
            this.SEXIT7.Text = "SEXIT7";
            this.SEXIT7.UseVisualStyleBackColor = true;
            this.SEXIT7.Visible = false;
            this.SEXIT7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SEXIT7_KeyDown);
            // 
            // SENTRY7
            // 
            this.SENTRY7.AutoSize = true;
            this.SENTRY7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SENTRY7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SENTRY7.Location = new System.Drawing.Point(188, 387);
            this.SENTRY7.Name = "SENTRY7";
            this.SENTRY7.Size = new System.Drawing.Size(75, 18);
            this.SENTRY7.TabIndex = 128;
            this.SENTRY7.Text = "SENTRY7";
            this.SENTRY7.UseVisualStyleBackColor = true;
            this.SENTRY7.Visible = false;
            this.SENTRY7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SENTRY7_KeyDown);
            // 
            // BarrierRemote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(691, 585);
            this.Controls.Add(this.SEXIT7);
            this.Controls.Add(this.SENTRY7);
            this.Controls.Add(this.SEXIT6);
            this.Controls.Add(this.SENTRY6);
            this.Controls.Add(this.SEXIT5);
            this.Controls.Add(this.SENTRY5);
            this.Controls.Add(this.SEXIT4);
            this.Controls.Add(this.SENTRY4);
            this.Controls.Add(this.SEXIT3);
            this.Controls.Add(this.SENTRY3);
            this.Controls.Add(this.SEXIT2);
            this.Controls.Add(this.SENTRY2);
            this.Controls.Add(this.EXIT1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SEXIT);
            this.Controls.Add(this.LBEXIT3);
            this.Controls.Add(this.LBEXIT2);
            this.Controls.Add(this.LBEXIT1);
            this.Controls.Add(this.SENTRY);
            this.Controls.Add(this.LBENTRY3);
            this.Controls.Add(this.LBENTRY1);
            this.Controls.Add(this.LBENTRY2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.EXIT8);
            this.Controls.Add(this.EXIT7);
            this.Controls.Add(this.ENTRY2);
            this.Controls.Add(this.EXIT6);
            this.Controls.Add(this.EXIT5);
            this.Controls.Add(this.ENTRY1);
            this.Controls.Add(this.ENTRY8);
            this.Controls.Add(this.ENTRY7);
            this.Controls.Add(this.EXIT4);
            this.Controls.Add(this.ENTRY6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ENTRY5);
            this.Controls.Add(this.EXIT3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.EXIT2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ENTRY4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ENTRY3);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BarrierRemote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barrier Remote System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox listBox1;
        private CheckBox ENTRY5;
        private CheckBox ENTRY6;
        private CheckBox ENTRY7;
        private CheckBox ENTRY8;
        private CheckBox EXIT5;
        private CheckBox EXIT6;
        private CheckBox EXIT7;
        private CheckBox EXIT8;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Timer timer1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private Label label1;
        private ListBox listBox2;
        private Label label2;
        private CheckBox ENTRY3;
        private CheckBox ENTRY4;
        private CheckBox EXIT2;
        private CheckBox EXIT3;
        private CheckBox EXIT4;
        private CheckBox ENTRY1;
        private CheckBox ENTRY2;
        private Button button3;
        private Button button4;
        private CheckBox LBENTRY2;
        private CheckBox LBENTRY1;
        private CheckBox LBENTRY3;
        private CheckBox SENTRY;
        private CheckBox LBEXIT1;
        private CheckBox LBEXIT2;
        private CheckBox LBEXIT3;
        private CheckBox SEXIT;
        private Button button1;
        private Button button2;
        private PictureBox pictureBox3;
        private CheckBox EXIT1;
        private CheckBox SEXIT2;
        private CheckBox SENTRY2;
        private CheckBox SEXIT3;
        private CheckBox SENTRY3;
        private CheckBox SEXIT4;
        private CheckBox SENTRY4;
        private CheckBox SEXIT5;
        private CheckBox SENTRY5;
        private CheckBox SEXIT6;
        private CheckBox SENTRY6;
        private CheckBox SEXIT7;
        private CheckBox SENTRY7;

        public Keys ENTRY1_KeyUp { get; set; }
     

    } 
}

