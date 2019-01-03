using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Third
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] st = new Student[10];
            st[0] = new Student("Иванов", "физ-мат",21,5171,"есть долги");
            st[1] = new Student("Петров", "филолог", 22, 5141, "сдал");
            st[2] = new Student("Сидоров", "физ-мат", 21, 1488, "есть долги");
            st[3] = new Student("Дабдабдабович", "мех-мат", 20, 1355, "олимпиадник");
            for(int i = 4; i < 10; i++)
            {
                st[i] = new Student();
            }
            int length = 3;
            string key, key2, s;
            int n;
            do
            {
                Console.WriteLine("1 - Добавить нового студента");
                Console.WriteLine("2 - Удалить студента по номеру зачетки");
                Console.WriteLine("3 - Редактировать информацию по номеру зачетки");
                Console.WriteLine("4 - Вывод всех студентов");
                Console.WriteLine("5 - Поиск информации о студентах по факультету");
                Console.WriteLine("8 - Выход");
                key = Console.ReadLine();

                switch (key)
                {
                    case "1":
                        {
                            do
                            {
                                length++;
                                st[length].AddStud();
                                Console.WriteLine("Добавить еще(+/-)");
                                key2 = Console.ReadLine();

                            } while (key2 == "+");
                        }break;

                    case "2":
                        {
                            Console.WriteLine("Введите номер зачетки:");
                            n = Convert.ToInt32(Console.ReadLine());
                            int numrem = 0;
                            bool check = false;
                            for(int i = 0; i <= length; i++)
                            {
                                if(st[i].Number == n) { numrem = i;check = true; }
                            }
                            if (check)
                            {
                                List<Student> hopa1488 = new List<Student>(st);
                                hopa1488.RemoveAt(numrem);
                                st = hopa1488.ToArray();
                                length--;
                            }
                        }break;

                    case "3":
                        {
                            Console.WriteLine("Введите номер зачетки: ");
                            n = Convert.ToInt32(Console.ReadLine());
                            int numrem=0;
                            bool check = false;
                            for (int i = 0; i <= length; i++)
                            {
                                if (st[i].Number == n) { numrem = i; check = true; }
                            }
                            if (check) { st[numrem].Edit(); }
                        }
                        break;

                    case "4":
                        {
                            for(int i = 0; i <=length; i++)
                            {
                                st[i].Show();
                            }
                        }break;

                    case "5":
                        {
                            Console.WriteLine("Введите название факультета:");
                            s = Console.ReadLine();
                            for(int i = 0; i <= length; i++)
                            {
                                if(st[i].Group == s) { st[i].Show(); }
                            }
                        }break;
                }

            } while (key != "8");
        }
    }
}
