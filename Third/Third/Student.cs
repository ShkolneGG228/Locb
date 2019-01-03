using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Third
{
    class Student
    {
        string fam,group,etc;//фамилия,факультет,индивидуальная инф
        int age, number;//возраст,номер зачетки

        public Student(string Fam,string Group,int Age,int Number,string Etc)
        {
            fam = Fam;group = Group;etc = Etc;age = Age;number = Number;
        }
        public Student() { }

        public string Fam
        {
            set { fam = value; }
            get { return fam; }
        }
        public string Group
        {
            set { group = value; }
            get { return group; }
        }
        public string Etc
        {
            set { etc = value; }
            get { return etc; }
        }
        public int Age
        {
            set { age = value; }
            get { return age; }
        }
        public int Number
        {
            set { number = value; }
            get { return number; }
        }
        string s,subkey;
        public void AddStud()
        {
            Console.WriteLine("Фамилия:");
            s = Console.ReadLine();Fam = s;
            Console.WriteLine("Факультет:");
            s = Console.ReadLine(); Group = s;
            Console.WriteLine("Возраст:");
            s = Console.ReadLine(); Age = int.Parse(s);
            Console.WriteLine("Номер зачетки:");
            s = Console.ReadLine(); Number = int.Parse(s);
            Console.WriteLine("Нужно добавить доп информацию о студенте(+/-)");
            subkey = Console.ReadLine();
            if(subkey == "+") { s = Console.ReadLine();Etc = s; }
            else { Etc = "Отсутствует"; }
        }

        public void Edit()
        {
            Console.WriteLine("Что редактировать?\n1 - фамилию\n2 - факультет\n3 - возраст\n4 - номер зачетки\n5 - доп инф о студенте");
            s = Console.ReadLine();
            switch (s)
            {
                case "1":
                    {
                        Console.WriteLine("Новая фамилия:");
                        Fam = Console.ReadLine();
                    }break;

                case "2":
                    {
                        Console.WriteLine("Новый факультет:");
                        Group = Console.ReadLine();
                    }
                    break;

                case "3":
                    {
                        Console.WriteLine("Возраст: ");
                        Age = int.Parse(Console.ReadLine());
                    }
                    break;

                case "4":
                    {
                        Console.WriteLine("Номер зачетки: ");
                        Number = int.Parse(Console.ReadLine());
                    }
                    break;
                case "5":
                    {
                        Console.WriteLine("Доп информация: ");
                        Etc = Console.ReadLine();
                    }
                    break;

            }

        }


        public void Show()
        {
            Console.WriteLine("\nФамилия: {0}", Fam);
            Console.WriteLine("Факультет: {0},{1} лет", Group, Age);
            Console.WriteLine("Зачетка: {0}", Number);
            Console.WriteLine("Доп информация:\n{0}\n", Etc);
            Console.WriteLine("-------------------------------------------");
        }
    }
}
