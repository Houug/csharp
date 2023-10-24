using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private string first_number = "";
        private string second_number = "";
        private bool isFirst = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isFirst)
            {
                first_number = first_number + "1";
            } 
            else
            {
                second_number = second_number + "1";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (isFirst)
            {
                first_number = first_number + "6";
            }
            else
            {
                second_number = second_number + "6";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isFirst)
            {
                first_number = first_number + "2";
            }
            else
            {
                second_number = second_number + "2";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isFirst)
            {
                first_number = first_number + "3";
            }
            else
            {
                second_number = second_number + "3";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (isFirst)
            {
                first_number = first_number + "4";
            }
            else
            {
                second_number = second_number + "4";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (isFirst)
            {
                first_number = first_number + "5";
            }
            else
            {
                second_number = second_number + "5";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (isFirst)
            {
                first_number = first_number + "7";
            }
            else
            {
                second_number = second_number + "7";
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (isFirst)
            {
                first_number = first_number + "8";
            }
            else
            {
                second_number = second_number + "8";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (isFirst)
            {
                first_number = first_number + "9";
            }
            else
            {
                second_number = second_number + "9";
            }
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (isFirst)
            {
                first_number = first_number + "0";
            }
            else
            {
                second_number = second_number + "0";
            }
        }
        private string operator_sign = "";

        private void buttonplus_Click(object sender, EventArgs e)
        {
            operator_sign = "+";
            isFirst = false;
        }

        private void buttonminus_Click(object sender, EventArgs e)
        {
            operator_sign = "-";
            isFirst = false;
        }

        private void buttonslash_Click(object sender, EventArgs e)
        {
            operator_sign = "/";
            isFirst = false;
        }

        private void buttonstar_Click(object sender, EventArgs e)
        {
            operator_sign = "*";
            isFirst = false;
        }

        private void buttonequals_Click(object sender, EventArgs e)
        {
            Calculator calculator = new Calculator();

            calculator.FirstNumber = int.Parse(first_number);
            calculator.SecondNumber = int.Parse(second_number);

            if (operator_sign == "+")
            {
                result.Text = calculator.Sum().ToString();
            }
            if (operator_sign == "-")
            {
                result.Text = calculator.Subtract().ToString();
            }
            if (operator_sign == "*")
            {
                result.Text = calculator.Multiply().ToString();
            }
            if (operator_sign == "/")
            {
                result.Text = calculator.Divide().ToString();
            }

            isFirst = true;
        }
    }
}
