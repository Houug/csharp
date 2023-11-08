using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        public Form1 parent;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 form)
        {
            parent = form;

            InitializeComponent();
        }

        // Отправить
        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;

            parent.GetLabel().Text = text;
            button1.DialogResult = DialogResult.OK;
            this.Close();
        }
        // Отмена
        private void button2_Click(object sender, EventArgs e)
        {
            button1.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
