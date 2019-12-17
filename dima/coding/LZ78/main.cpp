#include <stdlib.h>
#include <iostream>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace LZ78
{
    class Program
    {
        public static int pos = 0;
        public static string[] dict = new string[0];
        public static string input,
        dir1 = @"C:\lab\Input.txt",
        dir2 = @"C:\lab\Coded.txt",
        dir3 = @"C:\lab\Decoded.txt";
        public static void Write(string dir, string s)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream(dir, FileMode.Create, FileAccess.Write)))
            {
                sw.WriteLine(s);
            }
        }
        public static string Read(string dir)
        {
            string fromfile;
            using (StreamReader sr = new StreamReader(dir))
                return fromfile = sr.ReadLine();
        }
        public static bool Match(string x)
        {
            bool b = false;
            for (int j = 0; j < dict.Length; j++)
            {
                if (x == dict[j])
                {
                    b = true;
                    pos = j;
                    break;
                }
            }
            return b;
        }
        public static void LZ78()
        {
            string input = Read(dir1);
            string coded = "";
            for (int i = 0; i < input.Length; i++)
            {
                int j = i;
                string x = Convert.ToString(input[i]);
                while (Match(x) && i < input.Length - 1)
                    x += input[++i];
                Array.Resize(ref dict, dict.Length + 1);
                dict[dict.Length - 1] = Convert.ToString(x);
                if (j == i)
                    coded += $"0{input[i]}";
                else
                    coded += $"{pos + 1}{input[i]}";
            }
            //Console.WriteLine(coded);
            dict = new string[0];
            Write(dir2,coded);
        }
        public static void Decode()
        {
            string coded = Read(dir2);
            string outp = "";
            string buf = "";
            for (int i = 0; i < coded.Length - 1; i++)
            {

                if (Convert.ToString(coded[i]) == "0")
                {
                    Array.Resize(ref dict, dict.Length + 1);
                    dict[dict.Length - 1] = Convert.ToString(coded[i + 1]);
                    outp += dict[dict.Length - 1];
                }
                else if (Convert.ToString(coded[i]) != "0" && !char.IsLetter(coded[i]) && !char.IsSeparator(coded[i]))
                {
                    while (!char.IsLetter(coded[i]) && !char.IsSeparator(coded[i]))
                    {
                        buf += coded[i];
                        i++;
                    }
                    Array.Resize(ref dict, dict.Length + 1);
                    dict[dict.Length - 1] = String.Concat(dict[int.Parse(buf) - 1], coded[i]);
                    outp += dict[dict.Length - 1];
                }
                buf = "";
            }
            Write(dir3, outp);
        }

        static void Main(string[] args)
        {
            LZ78();
            Console.WriteLine("Su!");

            Decode();
            Console.WriteLine("Выполнено декодирование!");

            Console.ReadKey();
        }
    }
}