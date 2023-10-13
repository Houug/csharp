using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем объект класса Human
            // после new в Human() в скобках пишем начальные значения
            // эту функцию нужно описать САМОМУ в классе
            Human h1 = new Human("Artem","М",1000);
            Human h2 = new Human("Ольга","Ж",33);

            // вызываем метод SetAge, что означает усановка значения возраста
            h1.SetAge(101);
            h2.SetAge(10);

            // выводим строку, которая формируется в методе ToString() класса объекта
            Console.WriteLine(h1);
            Console.WriteLine(h2);

            // сравниваем один объект с другим
            Console.WriteLine(h1.Equals(h2));
            
            Console.ReadKey();
        }
    }
}
