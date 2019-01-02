using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toLocb
{
    class Program
    {
        

        static void Main(string[] args)
        {
            string key;
            Random rnd = new Random();
            List<int> mas = new List<int>();
            do
            {
                Console.WriteLine("1 - Добавить элемент\n2 - Удалить элемент\n3 - Вывести элементы\n4 - Очистить весь массив\n5 - Поиск элемента по значению\n6 - добавить 1000000(МИЛЛИОН) элементов для проверки двоичного поиска\n8 - Закрыть");
                key = Console.ReadLine();

                switch (key)
                {
                    case "1":
                        {
                            Add1(mas);
                        }break;

                    case "2":
                        {
                            Remove(mas);
                        }
                        break;

                    case "3":
                        {
                            WriteAll(mas);
                        }
                        break;

                    case "4":
                        {
                            mas.Clear();
                            Console.WriteLine("Очищен!");
                        }break;

                    case "5":
                        {
                            int[] a = new int[mas.Count];
                            Console.WriteLine("Временный отсортированный массив:");
                            for(int i = 0; i < mas.Count; i++)
                            {
                                a[i] = mas[i];
                            }
                            Array.Sort(a);
                            for (int i = 0; i < mas.Count; i++){Console.Write(a[i] + "\t");}
                            Console.WriteLine("\nВведите значение элемента,которое нужно найти: ");
                            int num = Convert.ToInt32(Console.ReadLine());
                            int? result = BinarySearch(a, num);
                            if (result != null) { Console.WriteLine("Его индекс: " + result);}
                            else { Console.WriteLine("В массиве нет элемента с таким значением"); }
                        }break;

                    case "6":
                        {
                            for (int i = 0; i < 1000000; i++)
                            {
                                mas.Add(rnd.Next(-100000, 100000));
                            }
                        }
                        break;
                }
            } while (key != "8");

        }
        public static void Add1(List<int> mas)
        {
            Console.WriteLine("Через enter записывайте значения\nВведите 'STOP' , чтобы перестать записывать новые элементы");
            string input;
            do
            {
                input = Console.ReadLine();
                if (IsNumberContains(input)) { mas.Add(Convert.ToInt32(input)); }
                else if(input!="STOP") { Console.WriteLine("Ошибка,вы ввели не число"); }
            } while (input.ToUpper() != "STOP");
        }

        public static void WriteAll(List<int> mas)
        {
            foreach(int i in mas)
            {
                Console.Write(i + "  \t");
            }
            Console.WriteLine();
        }

        public static void Remove(List<int> mas)
        {
            Console.WriteLine("\n1 - Удаление по индексу\n2 - Удаление по значению\n");
            string input="",key;
            key = Console.ReadLine();
            Console.WriteLine("Введите 'STOP', когда пора остановиться\n");
            do
            {
                switch (key)
                {
                    case "1":
                        {
                            input = Console.ReadLine();
                            if (IsNumberContains(input)) { mas.RemoveAt(Convert.ToInt32(input)); }
                        }break;

                    case "2":
                        {
                            input = Console.ReadLine();
                            if (IsNumberContains(input)) { mas.Remove(Convert.ToInt32(input)); }
                        }
                        break;
                }
            } while (input != "STOP");
        }

        static bool IsNumberContains(string input)
        {
            foreach (char c in input)
                if (Char.IsNumber(c))
                    return true;
            return false;
        }

        private static int? BinarySearch(int[] a, int x)
        {
            
            if ((a.Length == 0) || (x < a[0]) || (x > a[a.Length - 1]))
                return null;

            int first = 0;
           
            int last = a.Length;

            while (first < last)
            {
                int mid = first + (last - first) / 2;

                if (x <= a[mid])
                    last = mid;
                else
                    first = mid + 1;
            }

            if (a[last] == x)
                return last;
            else
                return null;
        }
    }
}
