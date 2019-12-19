using System;
using System.Collections;

/*Из входной строки организовать последовательность слов, входящих в строку, отсортированных по длине.*/

namespace Laba5RT
{
    class fifth : IEnumerable
    {
        string str { get; set; }

        public fifth(string str)
        {
            this.str = str;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new GetWordEnumerator(this);
        }

        class GetWordEnumerator : IEnumerator
        {
            fifth s;
            readonly string[] item;
            int position = -1;

            public GetWordEnumerator(fifth c)
            {
                this.s = c;
                item = s.str.Split(' ', ',', '.', '!');
            }

            public string Current
            {
                get
                {
                    if (s == null) throw new InvalidOperationException();
                    return item[position];
                }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                position++;
                return (position < this.item.Length);
            }

            public void Reset()
            {
                position = -1;
            }
        }
    }

    class Program
    {
        public static IEnumerable GetWords(string str)
        {
            var words = str.Split(' ', ',', '.', '!', ';', '/');

// Regex
//var reg = new Regex()
//reg.Split(str,'[^a-z], [^0-9]')
            for (int i = 0; i < words.Length - 1; ++i)
            {
                for (int j = 0; j < words.Length - i - 1; ++j)
                {
                    if (words[j].Length > words[j + 1].Length)
                    {
                        string buf = words[j];
                        words[j] = words[j + 1];
                        words[j + 1] = buf;
                    }
                }
            }

            for (int i = 0; i < words.Length; i++)
            {
                yield return words[i];
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string: ");
            string p = Console.ReadLine();
            fifth test = new fifth(p);
            foreach (string x in test)
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("**********************************");

            var iter = GetWords(p);
            foreach (var x in iter)
            {
                Console.WriteLine(x);
            }
        }
    }
}