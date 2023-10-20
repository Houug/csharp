using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            label3.Text = String.Format("Привет, {0} {1}!", name, surname);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            float oldSize = label3.Font.Size;
            float newSize = oldSize - 0.25f;
            label3.Font = new Font(label3.Font.FontFamily, newSize);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            float oldSize = label3.Font.Size;
            float newSize = oldSize + 0.25f;
            label3.Font = new Font(label3.Font.FontFamily, newSize);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button2.Visible = false;
                button3.Visible = false;
            }
            else
            {
                button2.Visible = true;
                button3.Visible = true;
            }
        }
    }
}
