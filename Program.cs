using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Инициализация массива numbers
            List<int> numbers = new List<int> { 1, 2, 3 };

            // Добавлить в массив элемент
            numbers.Add(153);

            // Инициализация массива numbers2
            List<int> numbers2 = new List<int> { -1, -2, -3 };

            // Добавляем значения из одного массива в другой
            numbers.AddRange(numbers2);

            // Цикл for
            // Вывод массива
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine(numbers[i]);
            }
            // Создаем строку путем присоединения элементов массива друг к другу,
            // разделяя символом " " (т.е. пробелом. Соответственно если нужно вывести
            // через запятую используем ","
            string str_numbers = String.Join(" ", numbers);

            Console.WriteLine(str_numbers);

            // Создаем объект random
            Random random = new Random();
            int a = random.Next(); // Положительное число
            int b = random.Next(10); // Положительное число до 10
            int c = random.Next(10, 100); // Положительное число от 10 для 100
            double d = random.NextDouble(); // Число с плавающей запятой от 0 до 1

            Console.WriteLine(String.Format("{0} {1} {2} {3}", a, b, c, d));

            // Создаем новый ПУСТОЙ массив
            List<int> random_numbers = new List<int>();
            int count; // переменная для ввода размера массива

            bool isNumber = int.TryParse(Console.ReadLine(), out count);
            // Если у нас не получилось вытащить число из введенной строки isNumber содержит false
            // Восклицательный знак означает отрицание, то есть НЕ true => false или НЕ false => true
            if (!isNumber)
            {
                // Напомню, что return заканчивает выполнение функции, и может возвращать некое значение
                // в данном случае заканчиваем выполнение функции Main, при ее завершении - программа
                // тоже прикращает работу (можно сказать, что Main это и есть наша программа)
                return;
            }
            
            // Создаем массив из случайных чисел
            for (int i = 0; i < count; i++)
            {
                random_numbers.Add(random.Next(20));
            }
            
            // Собираем строку из массива и печатем ее сразу
            Console.WriteLine(String.Join(" ", random_numbers));

            // Чтобы у нас не было
            Console.ReadKey();
        }
    }
}
