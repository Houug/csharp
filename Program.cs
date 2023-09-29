using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace functions
{
    internal class Program
    {
        // Определение функции. static обязателен! в скобках указывает параметры, которые мы передаем
        // при вызове и можем использовать внутри функции
        static int Question(
            string question,
            List<string> answerList,
            int indexRightAnswer
        )
        {
            Console.WriteLine(question);
            for (int i = 0; i < answerList.Count; i++)
            {
                Console.WriteLine(string.Format("{0}) {1}",i ,answerList[i]));
            }

            int my_answer;
            bool isRightAnswer = Int32.TryParse(Console.ReadLine(), out my_answer);

            // Восклицательный знак - логическое НЕ, то есть (НЕ true = false), а (НЕ false = true)
            if (!isRightAnswer)
            {
                return 0;
            }

            if (my_answer == indexRightAnswer)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        static void Main(string[] args)
        {
            int point1 = Question(
                "Что из этого фрукт?",
                new List<string>{ "Вишня" , "Яблоко", "Молоко", "Тыква"},
                1);

            Console.WriteLine(string.Format("Вы набрали {0} очка(ов)",point1));
            
            Console.ReadKey();
        }
    }
}
