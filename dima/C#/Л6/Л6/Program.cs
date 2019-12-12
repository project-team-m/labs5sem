using System;
using System.Text;
using System.IO;

namespace Л6
{
    class Program
    {
        private static void RecodeFile(string filePath, Encoding from, Encoding to)
        {
            File.WriteAllText(filePath, File.ReadAllText(filePath, from), to);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите 3 аргумента: путь к файлу, начальную кодировку, конечную кодировку Например: \nD:\\Desktop\\1.txt\nutf-8\nwindows-1251");
            string p = Console.ReadLine();
            string o = Console.ReadLine();
            string n = Console.ReadLine();
            var from = Encoding.GetEncoding(o);
            var to = Encoding.GetEncoding(n);

            RecodeFile(p, from, to);
        }
        
    }
}