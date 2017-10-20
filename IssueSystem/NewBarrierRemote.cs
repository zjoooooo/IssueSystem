using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IssueSystem
{
    public partial class NewBarrierRemote : Form
    {
        public NewBarrierRemote()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BarrierPage barrierform = new BarrierPage(A52_btn.Text);
            barrierform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BarrierPage barrierform = new BarrierPage(test_btn.Text);
            barrierform.Show();
        }

        private void NewBarrierRemote_Load(object sender, EventArgs e)
        {

        }
    }
}
