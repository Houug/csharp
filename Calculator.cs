using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class Calculator
    {
        private int first_number;
        private int second_number;

        public Calculator() { }

        public int Sum()
        {
            return first_number + second_number;
        }

        public int Subtract()
        {
            return first_number - second_number;
        }
        public int Multiply()
        {
            return first_number * second_number;
        }

        public int Divide()
        {
            return first_number / second_number;
        }

        public int FirstNumber
        { 
            get { return first_number; }
            set { first_number = value; }
        }
        public int SecondNumber
        {
            get { return second_number;} 
            set { second_number = value; }
        }
    }
}
