using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace Hoffman
{
    class Program
    {
        public static Dictionary<char, int> table_info(string str)
        {
            Dictionary<char, int> table = new Dictionary<char, int>();
            HashSet<char> help = new HashSet<char>();

            foreach (var i in str)
            {
                help.Add(i);
            }

            int count = 0;

            foreach (var i in help)
            {
                count = 0;
                foreach (var j in str) { if (i == j) count++; }
                table.Add(i, count);
            }
            return table;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Считаная информация : ");
            FileStream f1 = new FileStream("1.txt", FileMode.Open);
            StreamReader read = new StreamReader(f1);
            HuffmanTree huffmanTree = new HuffmanTree();
            string tmp = read.ReadToEnd();
            Console.WriteLine(tmp);
            f1.Close();
            //-----------------------------------------------
            HashSet<Char> tmpChar = new HashSet<char>();
            foreach (var i in tmp) { tmpChar.Add(i); }
            //------------------------------------------------
            // Строительство дерева Хоффмана
            huffmanTree.Build(tmp);

            // Кодировка
            BitArray encoded = huffmanTree.Encode(tmp);
            Console.Write("Кодировка: ");
            string tmpBit = "";
            foreach (bool bit in encoded)
            {
                Console.Write((bit ? 1 : 0) + "");
                tmpBit += (bit ? 1 : 0).ToString();
            }
            Console.WriteLine();
            Dictionary<char, int> table = table_info(tmp);
            //wtite in the file 
            FileStream f2 = new FileStream("2.txt", FileMode.Create); //создаем файловый поток
            StreamWriter writer = new StreamWriter(f2); //создаем «потоковый писатель» и связываем его с файловым потоком
            foreach (var i in table) { writer.Write(i); } //записываем в файл
            writer.WriteLine();
            writer.Write(tmpBit);
            writer.Close(); //закрываем поток. Не закрыв поток, в файл ничего не запишется
            // Декодировка
            string decoded = huffmanTree.Decode(encoded);
            Console.WriteLine("Декодировка: " + decoded);
            Console.ReadLine();
        }
    }
}
