using System;
using System.Collections;
using System.Collections.Generic;


namespace lab5
{
    class Program
    {
        public class Number
        {
            public Number(int N)
            {
                Num = N;
            }

            private int Num { get;}

            public int getNum()
            {
                return Num;
            }
            

            public class Fib_range: IEnumerable
            {
                private List<Number> Simpl_range = new List<Number>();

                public Fib_range(List<Number> S_r)
                {
                    Simpl_range = S_r;
                }

                public Fib_range(Number Num)
                {
                    Simpl_range = SetS_r(Num.getNum());
                }


                private List<Number> SetS_r(int number)
                {
                    List<Number> S_r = new List<Number>();

                    int sum;
                    int perv = 1;
                    int vtor = 2;
                    S_r.Add(new Number(perv));
                    S_r.Add(new Number(vtor));
                    for (int i = 0; i < number - 2; i++)
                    {
                        sum = perv + vtor;
                        S_r.Add(new Number(sum));
                        perv = vtor;
                        vtor = sum;
                    }
                            

                    return S_r;
                }

                public IEnumerator GetEnumerator()
                {
                    foreach (var Number in Simpl_range)
                        yield return Number.getNum();
                }
            }


            static void Main()
            {
                Console.WriteLine("Введите кол-во ряда Фибоначи");
                int n = Convert.ToInt32(Console.ReadLine());
                Number Foo = new Number(n);
                Fib_range FOO = new Fib_range(Foo);
                Console.WriteLine("Ряд Фибоначи:");
                foreach (var Number in FOO)
                {
                    Console.Write("{0} ", Number);
                }
            }
        }
    }
}