using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETlab3
{
    class Mn
    {
        public List<int> mas;
        public Mn()
        {
            mas = new List<int>();
        }
        public Mn(int[] a)
        {
            int kol = 0;
            mas = new List<int>();
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < mas.Count; j++)
                    if (a[i] != mas[j])
                        kol++;
                if (kol == mas.Count) mas.Add(a[i]);
                kol = 0;
            }

        }
        static public implicit operator Mn(int a) { return new Mn(new int[] { a }); }
        static public Mn operator +(Mn a, Mn b)
        {
            Mn mn3 = a;
            foreach (int x in b.mas) if (mn3.mas.IndexOf(x) == -1) mn3.mas.Add(x);
            return mn3;
        }
        static public Mn operator *(Mn a, Mn b)
        {
            Mn mn3 = new Mn();
            foreach (int x in a.mas) if (b.mas.IndexOf(x) != -1) mn3.mas.Add(x);
            return mn3;
        }
        static public Mn operator -(Mn a, Mn b)
        {
            Mn mn3 = new Mn();
            foreach (int x in a.mas) if (b.mas.IndexOf(x) == -1) mn3.mas.Add(x);
            return mn3;
        }
        static public bool operator ==(Mn a, Mn b)
        {
            if (a.mas.Count == b.mas.Count)
            {
                int kol = 0;
                foreach (int x in a.mas) if (b.mas.IndexOf(x) != -1) kol++;
                if (kol == a.mas.Count) return true;
                else return false;
            }
            else return false;
        }
        static public bool operator !=(Mn a, Mn b)
        {
            if (a.mas.Count == b.mas.Count)
            {
                int kol = 0;
                foreach (int x in a.mas) if (b.mas.IndexOf(x) != -1) kol++;
                if (kol == a.mas.Count) return false;
                else return true;
            }
            else return true;
        }
        static public bool operator <(Mn a, Mn b)
        {
            if (a != b)
            {
                if (a.mas.Count >= b.mas.Count)
                {
                    int kol = 0;
                    foreach(int x in b.mas) if (a.mas.IndexOf(x) != -1) kol++;
                    if (kol == b.mas.Count) return true;
                    else return false;
                }
                else return false;
            }
            else return true;
        }
        static public bool operator >(Mn a, Mn b)
        {
            if (a != b)
            {
                if (b.mas.Count >= a.mas.Count)
                {
                    int kol = 0;
                    foreach (int x in a.mas) if (b.mas.IndexOf(x) != -1) kol++;
                    if (kol == a.mas.Count) return true;
                    else return false;
                }
                else return false;
            }
            else return true;
        }
        public bool Add(int a)
        {
            int i = mas.IndexOf(a);
            if (i == -1)
            {
                mas.Add(a);
                return true;
            }
            else return false;
        }
        public bool Del(int a)
        {
            if (mas.IndexOf(a) != -1)
            {
                mas.Remove(a);
                return true;
            }
            else return false;
        }
        public void Print()
        {
            foreach (int a in mas)
                Console.Write($"{a} ");
        }
    }

    class Program
    {
        static Mn mn1 = new Mn();
        static Mn mn2 = new Mn();
        static void MnOpt(Mn mno)
        {
            ConsoleKeyInfo c;
            do
            {
                Console.Write("Множество: ");
                mno.Print();
                Console.WriteLine();
                Console.WriteLine("1. Добавить элемент в множество");
                Console.WriteLine("2. Удалить элемент из массива");
                Console.WriteLine();
                Console.WriteLine("0. Выход");
                c = Console.ReadKey();
                Console.Clear();
                if (c.Key == ConsoleKey.D1)
                {
                    Console.Write("Введиете добавляемый элемент: ");
                    int a;
                    a = Convert.ToInt32(Console.ReadLine());
                    if (mno.Add(a) == true)
                        Console.WriteLine("Элемент добавлен");
                    else Console.WriteLine("Данный элемент уже находится во множестве");
                    Console.ReadLine();
                    Console.Clear();
                }
                if (c.Key == ConsoleKey.D2)
                {
                    Console.Write("Введите удаляемый элемент: ");
                    int a;
                    a = Convert.ToInt32(Console.ReadLine());
                    if (mno.Del(a) == true)
                        Console.WriteLine("Элемент удален");
                    else Console.WriteLine("Данный элемент во множестве не найден");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (c.Key != ConsoleKey.D0);
        }
        static void Menu()
        {
            ConsoleKeyInfo c;
            do
            {
                Console.WriteLine("1. Первое множество");
                Console.WriteLine("2. Второе множество");
                Console.WriteLine("3. Объединение");
                Console.WriteLine("4. Пересечение");
                Console.WriteLine("5. Разность первого и второго");
                Console.WriteLine("6. Разность второго и первого");
                Console.WriteLine("7. Равенство множеств");
                Console.WriteLine("8. Включение первого множества во второе");
                Console.WriteLine("9. Включение второго множества в первое");
                Console.WriteLine();
                Console.WriteLine("0. Выход");
                c = Console.ReadKey();
                Console.Clear();
                if (c.Key == ConsoleKey.D1)
                    MnOpt(mn1);
                if (c.Key == ConsoleKey.D2)
                    MnOpt(mn2);
                if (c.Key == ConsoleKey.D3)
                {
                    Console.Write("Первое множество: ");
                    mn1.Print();
                    Console.WriteLine();
                    Console.Write("Второе множество: ");
                    mn2.Print();
                    Console.WriteLine();
                    Console.Write("Объединение: ");
                    (mn1 + mn2).Print();
                    Console.ReadLine();
                    Console.Clear();
                }
                if (c.Key == ConsoleKey.D4)
                {
                    Console.Write("Первое множество: ");
                    mn1.Print();
                    Console.WriteLine();
                    Console.Write("Второе множество: ");
                    mn2.Print();
                    Console.WriteLine();
                    Console.Write("Персечение: ");
                    (mn1 * mn2).Print();
                    Console.ReadLine();
                    Console.Clear();
                }
                if (c.Key == ConsoleKey.D5)
                {
                    Console.Write("Первое множество: ");
                    mn1.Print();
                    Console.WriteLine();
                    Console.Write("Второе множество: ");
                    mn2.Print();
                    Console.WriteLine();
                    Console.Write("Разность первого и второго: ");
                    (mn1 - mn2).Print();
                    Console.ReadLine();
                    Console.Clear();
                }
                if (c.Key == ConsoleKey.D6)
                {
                    Console.Write("Первое множество: ");
                    mn1.Print();
                    Console.WriteLine();
                    Console.Write("Второе множество: ");
                    mn2.Print();
                    Console.WriteLine();
                    Console.Write("Разность второго и первого: ");
                    (mn2 - mn1).Print();
                    Console.ReadLine();
                    Console.Clear();
                }
                if (c.Key == ConsoleKey.D7)
                {
                    Console.Write("Первое множество: ");
                    mn1.Print();
                    Console.WriteLine();
                    Console.Write("Второе множество: ");
                    mn2.Print();
                    Console.WriteLine();
                    Console.Write("Равенство: ");
                    Console.WriteLine(mn1 == mn2);
                    Console.ReadLine();
                    Console.Clear();
                }
                if (c.Key == ConsoleKey.D8)
                {
                    Console.Write("Первое множество: ");
                    mn1.Print();
                    Console.WriteLine();
                    Console.Write("Второе множество: ");
                    mn2.Print();
                    Console.WriteLine();
                    Console.Write("Включение первого во второе: ");
                    Console.WriteLine(mn1 > mn2);
                    Console.ReadLine();
                    Console.Clear();
                }
                if (c.Key == ConsoleKey.D9)
                {
                    Console.Write("Первое множество: ");
                    mn1.Print();
                    Console.WriteLine();
                    Console.Write("Второе множество: ");
                    mn2.Print();
                    Console.WriteLine();
                    Console.Write("Включение второго в первое: ");
                    Console.WriteLine(mn1 < mn2);
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (c.Key != ConsoleKey.D0);
        }

        static void Main(string[] args)
        {
            Menu();
        }

    }
}
