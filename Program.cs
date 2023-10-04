using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiply_files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = Int32.Parse(Console.ReadLine());
            int num2 = Int32.Parse(Console.ReadLine());
            string oper = Console.ReadLine();
            double result;
            switch (oper)
            {
                case "+":
                    result = Utils.Sum(num1, num2);
                    break;
                case "-":
                    result = Utils.Subtract(num1, num2);
                    break;
                case "*":
                    result = Utils.Multiply(num1, num2);
                    break;
                case "/":
                    result = Utils.Divide(num1, num2);
                    break;
                default:
                    result = 0;
                    break;
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
