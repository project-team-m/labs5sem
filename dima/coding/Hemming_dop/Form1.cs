using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hemming
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int[] StrMas(string s)
        {
            int[] tmp = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                tmp[i] = s[i] == '0' ? 0 : 1;
            }

            return tmp;
        }

        private byte MasIntToByte(int[] mas)
        {
            byte b = 0b00000000;
            for (int i = 0; i < mas.Length; i++)
            {
                b ^= (byte) (mas[i] << (7 - i));
            }

            return b;
        }

        private void PrintDecode(string[] s)
        {
            for (int i = 0; i < 2; i++)
            {
                textBox3.Text += Convert.ToChar(MasIntToByte(StrMas(s[i]))).ToString();
            }
        }

        private string[] BinToString(char[] c)
        {
            string[] s = new string[textBox1.Text.Length];


            string tmp = "";

            int count = 0;
            for (int i = 0; i < c.Length; i++)
            {
                tmp += c[i];
                if (tmp.Length == 8)
                {
                    s[count] = tmp;
                    count++;
                    tmp = "";
                }
            }


            return s;
        }

        private char[] DelBit(string s)
        {
            char[] c = new char[s.Length - 5];

            for (int i = 0, j = 0; i < s.Length; i++)
            {
                if (i != 0 && i != 1 && i != 3 && i != 7 && i != 15)
                {
                    c[j] = s[i];
                    j++;
                }
            }

            return c;
        }

        private int[] Checkeder(string s, int index)
        {
            int[] mas = new int[2];
            if (textBox2.Text.Length / (textBox1.Text.Length / 2) != 21)
            {
                mas[0] = -2;
                return mas;
            }
            else
            {
                int count1 = 0, pos1 = -1;
                int[] sin = new int[21];
                for (int i = index * 21, j = 0; j < s.Length; i++, j++)
                {
                    if (s[j] != textBox2.Text[i])
                    {
                        count1++;
                        pos1 = i;
                    }
                }

                foreach (var VARIABLE in sin)
                {
                    Console.Write(VARIABLE);
                }
                Console.WriteLine();

                if (count1 > 1)
                {
                    mas[0] = -3;
                    return mas;
                }

                else
                {
                    if (pos1 == -1)
                    {
                        mas[0] = -1;
                        return mas;
                    }
                    else
                    {
                        mas[0] = 1;
                        mas[1] = pos1;
                        return mas;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";

            string[] array = new string[this.array.Count];
            array = this.array.ToArray();


            int[] check = new int[2];

            for (int s = 0; s < array.Length; s++)
            {
                check = Checkeder(array[s], s);


                if (check[0] == -1)
                {
                    foreach (var i in array)
                    {
                        char[] new_mas = new char[i.Length - 5];

                        string[] MasSymbol = new string[textBox1.Text.Length];

                        new_mas = DelBit(i);

                        MasSymbol = BinToString(new_mas);
                        if (textBox3.Text.Length < textBox1.Text.Length) PrintDecode(MasSymbol);
                    }
                }
                else if (check[0] == 1)
                {
                    //Console.Out.WriteLine(check[1]);
                    MessageBox.Show($" Был изменен  {check[1]} бит  ");

                    foreach (var i in this.array)
                    {
                        char[] new_mas = new char[i.Length - 5];

                        string[] MasSymbol = new string[textBox1.Text.Length];

                        new_mas = DelBit(i);


                        MasSymbol = BinToString(new_mas);

                        if (textBox3.Text.Length < textBox1.Text.Length) PrintDecode(MasSymbol);
                    }
                }
                else if (check[0] == -2)
                {
                    MessageBox.Show(" Некоррекоктная  длина ");
                    break;
                }
                else if (check[0] == -3)
                {
                    MessageBox.Show(" Получиная информация не корректна , было утеренно больше одного бита ");
                    break;
                }
            }


            textBox2.Text = old_str;
        }

        private string AddNeed0(string s)
        {
            string tmp = "";
            string result = "";
            if (s.Length == 8) return s;
            else
            {
                for (int i = s.Length, j = 0; i < 8; i++, j++) tmp += "0";
                result += tmp + s;

                return result;
            }
        }

        private char count(string s, int index)
        {
            int count = 0, c = index + 1;

            for (int i = index; i < s.Length;)
            {
                if (c != 0)
                {
                    if (s[i] == '1') count++;
                    i++;
                    c--;
                }
                else
                {
                    c = index + 1;
                    i += c;
                }
            }

            if (count % 2 == 0) return '0';
            else return '1';
        }

        string old_str = "";

        List<string> array = new List<string>();

        private string Hemming_code(string binary_code)
        {
            char[] code = new char[21];

            for (int i = 0; i < 5; i++)
            {
                code[Convert.ToInt32((Math.Pow(2, i) - 1))] = '0';
            }

            for (int i = 0, j = 0; i < code.Length; i++)
            {
                if (code[i] != '0')
                {
                    code[i] = binary_code[j];
                    j++;
                }
            }

            string coder = "";

            foreach (var i in code)
            {
                coder += i;
            }

            char[] change_code = new char[5];

            int[] indexs_mas = new int[] {0, 1, 3, 7, 15};

            int k = 0;

            foreach (var i in indexs_mas)
            {
                change_code[k] = count(coder, i);
                k++;
            }

            for (int i = 0, j = 0; i < 5; i++, j++)
            {
                code[Convert.ToInt32((Math.Pow(2, i) - 1))] = change_code[j];
            }


            coder = "";

            foreach (var i in code)
            {
                coder += i;
            }
            //Console.WriteLine(coder);
            return coder;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            array.Clear();
            textBox2.Text = "";
            string[] words = new string[textBox1.Text.Length / 2];
            string[] tmp = new string[textBox1.Text.Length];

            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                tmp[i] = Convert.ToString(Convert.ToInt32(textBox1.Text[i]), 2);
            }

            for (int i = 0, j = 0, s = 0; s < words.Length;)
            {
                if (j < 2)
                {
                    words[s] += AddNeed0(tmp[i]);
                    j++;
                    i++;
                }
                else
                {
                    s++;
                    j = 0;
                }
            }

            string[] what = new string[words.Length];

            int r = 0;

            foreach (var i in words)
            {
                what[r] = Hemming_code(i);
                r++;
            }

            foreach (var i in what)
            {
                array.Add(i);
            }

            for (int i = 0; i < what.Length; i++)
            {
                textBox2.Text += what[i].ToString();
            }

            old_str = textBox2.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox3.MaxLength = textBox1.Text.Length;
        }
    }
}