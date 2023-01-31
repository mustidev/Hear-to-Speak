using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HearTS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 kelimeOgren = new Form2();
            kelimeOgren.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 dinlemeTest = new Form3();
            dinlemeTest.Show();
            this.Hide();
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 konus = new Form4();
            konus.Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult answ;
            answ=MessageBox.Show("Çıkmak istiyor musunuz", "HearTS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answ == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/mustidev");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/mustafa8demir/");
        }
    }
   
}
