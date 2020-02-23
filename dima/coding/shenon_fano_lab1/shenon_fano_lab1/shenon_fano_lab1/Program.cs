using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shenon_fano_lab1
{
    class Program
    {
        public static char[] alph = new char[0];
        public static double[] ch = new double[0];
        public static double schet1 = 0;
        public static double schet2 = 0;
        public static string[] res = new string[0];
        public static int m;


        public static void Chance(string input)
        {
            bool b;
            int x;
            for (int i = 0; i < input.Length; i++)
            {
                b = true;
                for (int j = 0; j < alph.Length; j++)
                {
                    if (input[i] == alph[j])
                    {
                        b = false;
                        break;
                    }
                }
                if (b)
                {
                    Array.Resize(ref alph, alph.Length + 1);
                    alph[alph.Length - 1] = input[i];
                }
            }
            Array.Resize(ref ch, alph.Length);
            Array.Resize(ref res, alph.Length);
            for (int i = 0; i < alph.Length; i++)
            {
                x = 0;
                for (int j = 0; j < input.Length; j++)
                {
                    if (alph[i] == input[j])
                    {
                        x++;
                        ch[i] = Convert.ToDouble(x) / input.Length;
                    }
                }
            }
            char alphmin;
            double min;
            int k;
            for (int i = 1; i < ch.Length; i++)
            {
                min = ch[i];
                alphmin = alph[i];
                k = i;
                while (k > 0 && min > ch[k - 1])
                {
                    ch[k] = ch[k - 1];
                    alph[k] = alph[k - 1];
                    k--;
                }
                ch[k] = min;
                alph[k] = alphmin;
            }
        }
        public static int Tree(int L, int R)
        {
            schet1 = 0;
            for (int i = L; i <= R - 1; i++)
            {
                schet1 = schet1 + ch[i];
            }
            schet2 = ch[R];
            m = R;
            while (schet1 >= schet2)
            {
                schet1 = schet1 - ch[m];
                schet2 = schet2 + ch[m];
                m = m - 1;
            }
            return m;
        }
        public static void ShannonFano(int L, int R)
        {
            int n;
            if (L < R)
            {
                n = Tree(L, R);


                for (int i = L; i <= R; i++)
                {
                    if (i <= n)
                    {
                        res[i] += Convert.ToByte(0);
                    }
                    else
                    {
                        res[i] += Convert.ToByte(1);
                    }
                }
                ShannonFano(L, n);
                ShannonFano(n + 1, R);
            }
        }
        static public void coding()
        {
            string[] RF = File.ReadAllLines("D:\\Text.txt");

            foreach (string str in RF)
            {
                Chance(str);
            }
            
            ShannonFano(0, alph.Length - 1);
            string coded = "";

         
            foreach (string str in RF)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    for (int j = 0; j < alph.Length; j++)
                    {
                        if (str[i] == alph[j])
                        {
                            coded += res[j];
                        }
                    }
                }
            }
            
            StreamWriter DW = new StreamWriter(new FileStream("D:\\Code.txt", FileMode.Create, FileAccess.Write));
            for (int i = 0; i < alph.Length; i++)
            {
                if (alph[i] == ' ')
                {
                    alph[i] = '_';
                }
                DW.Write(alph[i]);
                DW.Write(string.Format("{0:0.000}", ch[i]));
            }
          DW.Write(' '+coded);
          DW.Close();
        }

        public static void decoding()
        {
            string[] RC = File.ReadAllLines("D:\\Code.txt");

            int indexOfChar = RC[0].IndexOf(' ');
            string text = RC[0].Substring(0, indexOfChar);
            RC[0] = RC[0].Substring(indexOfChar+1);
            Array.Resize(ref alph, 0);
            Array.Resize(ref ch, 0);
            Array.Resize(ref res, 0);

            for (int i = 0; i < text.Length; i=i+6)
            {
                Array.Resize(ref alph, alph.Length + 1);
                alph[alph.Length - 1] = text[i];
                Array.Resize(ref ch, ch.Length + 1);
                ch[ch.Length - 1] = Convert.ToDouble(String.Concat(text[i + 1], text[i + 2], text[i + 3], text[i + 4],text[i+5]));
            }

            for (int i = 0; i < alph.Length; i++)
            {
                if (alph[i] == '_')
                {
                    alph[i] = ' ';
                }
            }

            Array.Resize(ref res, alph.Length);

            ShannonFano(0, alph.Length - 1);

            string decode = "";
            foreach (string str in RC)
            {
                int max = 0;
                for (int i = 0; i < alph.Length; i++)
                {
                    if (res[i].Length > max)
                        max = res[i].Length;
                }

                for (int i = 0; i < str.Length; i++)
                {
                    bool b = false;
                    int k = 0;
                    string buf = "";
                    while (buf.Length <= max && b == false)
                    {
                        buf += str[i + k];
                        for (int j = 0; j < alph.Length; j++)
                        {
                            if (buf == res[j])
                            {
                                decode += alph[j];
                                i += buf.Length - 1;
                                b = true;
                            }
                        }
                        k++;
                    }
                }
            }
            StreamWriter DW = new StreamWriter(new FileStream("D:\\Decode.txt", FileMode.Create, FileAccess.Write));
            DW.Write(decode);
            DW.Close();
        }

        static void Main(string[] args)
        {
            coding();
            Console.WriteLine("Выполнено кодирование!");

            decoding();
            Console.WriteLine("Выполнено декодирование!");
        }
    }
}
