using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class Human
    {
        // Поля класса Human
        private string name;
        private string gender;
        private int age;

        // Конструктор класса Human
        public Human(string name, string gender,int age)
        {
            this.name = name;
            this.gender = gender;
            this.SetAge(age);
        }
        
        // Метод для получения возраста, он возвращает поле age
        public int GetAge()
        {
            // ключевое слово this означает, что мы обращаемся именно к полю ЭТОГО класса
            return this.age;
        }

        // Метод для установки возраста
        public void SetAge(int age)
        {
            if (age > 0 && age < 100)
            {
                this.age = age;
            }
            else
            {
                this.age = 0;
            }
        }

        // Метод, который позволяет выводить объект в виде строки в консоль
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.name, this.gender , this.age);
        }

        // Метод, который позволяет сравнивать 2 объекта этого класса, возвращает true или false
        public override bool Equals(object obj)
        {
            Human temp = obj as Human;
            // Строчку можно записать в одну, а не в 3, так было записано для удобства отображения на экране
            return this.name == temp.name &&
                   this.gender == temp.gender &&
                   this.age == temp.age;
        }
    }
}
