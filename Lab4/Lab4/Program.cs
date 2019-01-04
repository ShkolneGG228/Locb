using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Worker
    {
        string fullname, address, post, birthday,gender,phonenumber;
        int number, salary;int age;
        string highedic;

        public Worker(string Fullname,string Gender,string Address,string Phonenumber,int Number,string Post,int Salary,string Highedic,string Birthday)
        {
            fullname = Fullname;gender = Gender;address = Address;phonenumber = Phonenumber;number = Number;
            post = Post;salary = Salary;highedic = Highedic;birthday = Birthday;
        }
        public Worker() { }

        public string Fullname
        {
            set { fullname = value; }
            get { return fullname; }
        }

        public int Age
        {
            set { age = value; }
            get { return age; }
        }

        public string Gender
        {
            set { gender = value; }
            get { return gender; }
        }

        public string Birthday
        {
            set { birthday = value; }
            get { return birthday; }
        }

        public string Address
        {
            set { address = value; }
            get { return address; }
        }

        public string Phonenumber
        {
            set { phonenumber = value; }
            get { return phonenumber; }
        }

        public int Number
        {
            set { number = value; }
            get { return number; }
        }

        public int Salary
        {
            set { salary = value; }
            get { return salary; }
        }

        public string Post
        {
            set { post = value; }
            get { return post; }
        }

        public string Highedic
        {
            set { highedic = value; }
            get { return highedic; }
        }


        string s;bool ch = false;
        public void AddWorker()
        {
            Console.WriteLine("ФИО:");
            Fullname = Console.ReadLine();

            Console.WriteLine("Пол:\n1 - Мужчина\n2 - Женщина");
            do
            {
                ch = false;
                s = Console.ReadLine();
                switch (s)
                {
                    case "1":
                        {
                            Gender = "Мужчина";
                            ch = true;
                        }
                        break;

                    case "2":
                        {
                            Gender = "Женщина";
                            ch = true;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Ввели неверно");
                        }
                        break;
                }
            } while (ch != true);

            Console.WriteLine("Дата рождения");
            do
            {
                string day="", month="", year="", result="";
                ch = true;
                Console.WriteLine("День :");
                s = Console.ReadLine();
                if (IsNumberContains(s)) { if (Convert.ToInt32(s) > 31 || Convert.ToInt32(s) < 1) { ch = false;} day = s; }else { ch = false; }
                Console.WriteLine("Месяц:(1 , 9 , 12)");
                s = Console.ReadLine();
                if (IsNumberContains(s)) { if (Convert.ToInt32(s) > 12 || Convert.ToInt32(s)<1) { ch = false; } month = s; }else { ch = false; }
                Console.WriteLine("Год:(1976 , 1988 , 1965)");
                s = Console.ReadLine();
                if (IsNumberContains(s)) { if (Convert.ToInt32(s) < 1950 || Convert.ToInt32(s) > 2000) { ch = false;} year = s; age = 2018 - Convert.ToInt32(year); }else { ch = false; }
                result = day + "." + month + "." + year;
            } while (ch != true);

            Console.WriteLine("Адресс: ");
            Address = Console.ReadLine();

            Console.WriteLine("Номер телефона: ");
            Phonenumber = Console.ReadLine();

            Console.WriteLine("Табличный номер: ");
            do
            {
                ch = false;
                s = Console.ReadLine();
                if (IsNumberContains(s)) { Number = Convert.ToInt32(s);ch = true; }
                else { Console.WriteLine("вы ввели не число");}
            } while (ch != true);

            Console.WriteLine("Ваша должность: ");
            Post = Console.ReadLine();

            Console.WriteLine("Введите ваш оклад: ");
            do
            {
                ch = false;
                s = Console.ReadLine();
                if (IsNumberContains(s)) { Salary = Convert.ToInt32(s);ch = true; }
            } while (ch != true);

            Console.WriteLine("У вас есть высшее образование: 1 - Есть,2 - Нет");
            do
            {
                ch = false;
                s = Console.ReadLine();
                switch (s)
                {
                    case "1":
                        {
                            Console.WriteLine("Какое?");
                            Highedic = Console.ReadLine();ch = true;
                        }break;

                    case "2":
                        {
                            Highedic = "Нет высшего образования";ch = true;
                        }break;

                    default:
                        {
                            Console.WriteLine("Ввели неверно");
                        }break;
                }
            } while (ch != true);

        }

        public void Show()
        {
            Console.WriteLine(Fullname);
            Console.WriteLine("Таб номер: " + Number);
            Console.WriteLine(Post + ", " + Salary + "руб.");
            Console.WriteLine("Возраст: " + Age);
            Console.WriteLine("------------------------------\n");
        }

        static bool IsNumberContains(string input)
        {
            foreach (char c in input)
                if (Char.IsNumber(c))
                    return true;
            return false;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Worker[] wk = new Worker[50];
             
            string key;int length=0;
            for(int i = length; i < 50; i++)
            {
                wk[i] = new Worker();
            }
            int mennum=0, womennume=0,womenage=0;

            do
            {
                mennum = 0; womennume = 0; womenage = 0;
                Console.WriteLine("1 - Добавить сотрудника\n2 - Вывести информацию о сотрудниках,чья зарплата больше 10000\n3 - Вывести бухгалтеров с вышкой\n4 - Вывести информацию о всех\n8 - Выйти");
                key = Console.ReadLine();
                switch (key)
                {
                    case "1":
                        {
                            wk[length].AddWorker();
                            length++;
                        }break;

                    case "2":
                        {
                            foreach(Worker i in wk)
                            {
                                if (i.Salary >=10000 ) { i.Show();mennum+=MenWorker(i); womennume += WomenWorker(i);womenage += WomenWorkerAge(i);  }
                            }
                            Workers(mennum, womennume, womenage);
                        }
                        break;

                    case "3":
                        {
                            foreach (Worker i in wk)
                            {
                                if (i.Post == "бухгалтер" && i.Highedic!= "Нет высшего образования") { i.Show(); mennum += MenWorker(i); womennume += WomenWorker(i); womenage += WomenWorkerAge(i); }
                            }
                            Workers(mennum, womennume, womenage);
                        }
                        break;

                    case "4":
                        {
                            foreach(Worker i in wk)
                            {
                                if (i.Fullname != null) { i.Show(); mennum += MenWorker(i); womennume += WomenWorker(i); womenage += WomenWorkerAge(i); }
                            }
                            Workers(mennum, womennume, womenage);
                        }break;
                }
            } while (key != "8");

        }

        public static int MenWorker(Worker wk)
        {
            if (wk.Gender == "Мужчина" && wk.Age > 50) { return 1; }
            else return 0;
        }
        public static int WomenWorker(Worker wk)
        {
            if (wk.Gender == "Женщина") { return 1; }
            else return 0;
        }
        public static int WomenWorkerAge(Worker wk)
        {
            if (wk.Gender == "Женщина") { return wk.Age; }
            else return 0;
        }

        public static void Workers(int mennum ,int womennun,int womenage)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            if (mennum > 0)
            {
                Console.WriteLine("Количество мужчин,возраст которых более 50 лет: " + mennum);
            }else
            {
                Console.WriteLine("Нет мужчин старше 50 лет");
            }
            if (womennun > 0) { Console.WriteLine("Средний возраст женщин: " + (womenage / womennun)); }
            else { Console.WriteLine("Нет женщин"); }
            Console.ResetColor();
        }
    }
}
