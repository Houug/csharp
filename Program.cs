using System;

namespace ConsoleApp1
{
    internal class Program
    {
        // Точка входа в программу
        static void Main(string[] args)
        {
            Console.WriteLine("Вывод текста в консоль и переносим строку");
            // 2 строки выводятся без переноса
            Console.Write("Вывод текста в консоль и переносим");
            Console.Write(" текст на той же строке");

            // Читаем из консоли строку и помещаем ее в переменную str_1_val
            string str_1_val = Console.ReadLine();
            // Выводим в консоль строку str_1_val
            Console.WriteLine(str_1_val);

            // Читаем из консоли строку и помещаем ее в переменную str_2_val
            string str_2_val = Console.ReadLine();
            // Вытаскиваем из строки str_2_val число и помещаем его в int_1_val
            Int32 int_1_val = Int32.Parse(str_2_val);

            // Создаем новую перменную и оставляем ее пустой (пока)
            Int32 int_2_val;
            // ПЫТАЕМСЯ ватащить из введеной в консоль строки  число и помещаем ее в переменную int_2_val,
            // если удалось вытащить чилсло функция возвращает значние true, иначе false
            bool bool_val = Int32.TryParse(Console.ReadLine(), out int_2_val);


            // Условия (такие же как в JavaScript)
            if (bool_val  == true)
            {
                // если true
                Console.WriteLine(int_2_val);
            }
            else
            {
                // если false
                Console.WriteLine("Введенное значение не число");
            }
            
            // Сборка строки при помощи string.Format(<здесь строка>, <здесь>, <значения которые>, <будем вставлять в строку>)
            // Первое значение после строки помещается в каждое {0}, второе помещается в каждое {1} и так далее...
            // (нумерация как в массиве - начинается с нуля)
            string str_3_val = string.Format("Слово1 Слово2 {0} {1}кг", int_1_val, 10);
            Console.WriteLine(str_3_val);

            // Ожидание ввода любой клавиши (нужно чтобы консоль не закрывалась сразу после отработки программы)
            Console.ReadKey();
            
        }
    }
}
