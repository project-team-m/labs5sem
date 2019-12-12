using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace l4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private BitArray InBit(byte b)
        {
            BitArray bitArray = new BitArray(8);
            bool rez = false;
            for (int i = 0; i < 8; i++)
            {
                if ((b >> i & 1) == 1)
                {
                    rez = true;
                }
                else rez = false;
                bitArray[i] = rez;
            }
            return bitArray;
        }
 
        private byte InByte(BitArray masbit)
        {
            byte b = 0;
            for (int i = 0; i < masbit.Count; i++)
                if (masbit[i] == true)
                    b += (byte)Math.Pow(2, i);
            return b;               
        }

        private bool isEncryption(Bitmap pic)
        {
            byte[] rez = new byte[1];
            Color color = pic.GetPixel(0, 0);
            BitArray colorArray = InBit(color.R); 
            BitArray messageArray = InBit(color.R); ;
            messageArray[0] = colorArray[0];
            messageArray[1] = colorArray[1];

            colorArray = InBit(color.G);//получаем байт цвета и преобразуем в массив бит
            messageArray[2] = colorArray[0];
            messageArray[3] = colorArray[1];
            messageArray[4] = colorArray[2];

            colorArray = InBit(color.B);//получаем байт цвета и преобразуем в массив бит
            messageArray[5] = colorArray[0];
            messageArray[6] = colorArray[1];
            messageArray[7] = colorArray[2];

            rez[0] = InByte(messageArray); //получаем байт символа, записанного в 1 пикселе
            string m = Encoding.GetEncoding(1251).GetString(rez);
            if (m == "/")
            {
                return true;
            }
            else return false;
        }
 
        private void WriteCountText(int count, Bitmap pic)
        {
            byte[] CountSymbols = Encoding.GetEncoding(1251).GetBytes(count.ToString());
            for (int i = 0; i < CountSymbols.Length; i++)
            {
                BitArray bitCount = InBit(CountSymbols[i]); //биты количества символов
                Color pColor = pic.GetPixel(0, i + 1); //1, 2, 3 пикселы
                BitArray bitsCurColor = InBit(pColor.R); //бит цветов текущего пикселя
                bitsCurColor[0] = bitCount[0];
                bitsCurColor[1] = bitCount[1];
                byte nR = InByte(bitsCurColor); //новый бит цвета пиксея

                bitsCurColor = InBit(pColor.G);//бит бит цветов текущего пикселя
                bitsCurColor[0] = bitCount[2];
                bitsCurColor[1] = bitCount[3];
                bitsCurColor[2] = bitCount[4];
                byte nG = InByte(bitsCurColor);//новый цвет пиксея

                bitsCurColor = InBit(pColor.B);//бит бит цветов текущего пикселя
                bitsCurColor[0] = bitCount[5];
                bitsCurColor[1] = bitCount[6];
                bitsCurColor[2] = bitCount[7];
                byte nB = InByte(bitsCurColor);//новый цвет пиксея

                Color nColor = Color.FromArgb(nR, nG, nB); //новый цвет из полученных битов
                pic.SetPixel(0, i + 1, nColor); //записали полученный цвет в картинку
            }
        }

        //Чтение количества символов из первых бит картинки
        private int ReadCountText(Bitmap pic)
        {
            byte[] rez = new byte[5]; //массив на 2 элемента, 
            for (int i = 0; i < 5; i++)
            {
                Color color = pic.GetPixel(0, i + 1); //цвет 1, 2 пикселей 
                BitArray colorArray = InBit(color.R); //биты цвета
                BitArray bitCount = InBit(color.R); ; //инициализация результирующего массива бит
                bitCount[0] = colorArray[0];
                bitCount[1] = colorArray[1];

                colorArray = InBit(color.G);
                bitCount[2] = colorArray[0];
                bitCount[3] = colorArray[1];
                bitCount[4] = colorArray[2];

                colorArray = InBit(color.B);
                bitCount[5] = colorArray[0];
                bitCount[6] = colorArray[1];
                bitCount[7] = colorArray[2];
                rez[i] = InByte(bitCount);
            }
            string m = Encoding.GetEncoding(1251).GetString(rez);
            return Convert.ToInt32(m, 10);
        }

        //Открытие файла для шифрования

        private void button1_Click_1(object sender, System.EventArgs e)
        {
            Bitmap bPic = new Bitmap("hide3.bmp");
            string t = textBox1.Text;

            if (t != "")
            {
                FileStream rText;
                try
                {
                    rText = new FileStream(textBox1.Text,FileMode.Open);
                }
                catch (IOException)
                {
                    MessageBox.Show("Ошибка открытия файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                BinaryReader bText = new BinaryReader(rText, Encoding.ASCII);

                List<byte> bList = new List<byte>();
                while (bText.PeekChar() != -1)
                { //считали весь текстовый файл д
                    bList.Add(bText.ReadByte());
                }
                int CountText = bList.Count; // в CountText - количество в байтах текста, который нужно закодировать
               
                bText.Close();
                rText.Close();

                //проверяем, поместиться ли исходный текст в картинке
                if (CountText > ((bPic.Width * bPic.Height)) - 4)
                {
                    MessageBox.Show("Выбранная картинка мала для размещения выбранного текста", "Информация", MessageBoxButtons.OK);
                    return;
                }

                //проверяем, может быть картинка уже зашифрована
                if (isEncryption(bPic))
                {
                    MessageBox.Show("Файл уже зашифрован", "Информация", MessageBoxButtons.OK);
                    return;
                }

                byte[] Symbol = Encoding.GetEncoding(1251).GetBytes("/");
                BitArray ArrBeginSymbol = InBit(Symbol[0]);
                Color curColor = bPic.GetPixel(0, 0);
                BitArray tempArray = InBit(curColor.R);
                tempArray[0] = ArrBeginSymbol[0];
                tempArray[1] = ArrBeginSymbol[1];
                byte nR = InByte(tempArray);

                tempArray = InBit(curColor.G);
                tempArray[0] = ArrBeginSymbol[2];
                tempArray[1] = ArrBeginSymbol[3];
                tempArray[2] = ArrBeginSymbol[4];
                byte nG = InByte(tempArray);

                tempArray = InBit(curColor.B);
                tempArray[0] = ArrBeginSymbol[5];
                tempArray[1] = ArrBeginSymbol[6];
                tempArray[2] = ArrBeginSymbol[7];
                byte nB = InByte(tempArray);

                Color nColor = Color.FromArgb(nR, nG, nB);
                bPic.SetPixel(0, 0, nColor);
                //то есть в первом пикселе будет символ /, который говорит о том, что картика зашифрована
                WriteCountText(CountText, bPic); //записываем количество символов для шифрования

                int index = 0;
                bool st = false;
                for (int i = 4; i < bPic.Width; i++)
                {
                    for (int j = 0; j < bPic.Height; j++)
                    {
                        Color pixelColor = bPic.GetPixel(i, j);
                        if (index == bList.Count)
                        {
                            st = true;
                            break;
                        }
                        BitArray colorArray = InBit(pixelColor.R);
                        BitArray messageArray = InBit(bList[index]);
                        colorArray[0] = messageArray[0]; //меняем
                        colorArray[1] = messageArray[1]; // в нашем цвете биты
                        byte newR = InByte(colorArray);

                        colorArray = InBit(pixelColor.G);
                        colorArray[0] = messageArray[2];
                        colorArray[1] = messageArray[3];
                        colorArray[2] = messageArray[4];
                        byte newG = InByte(colorArray);

                        colorArray = InBit(pixelColor.B);
                        colorArray[0] = messageArray[5];
                        colorArray[1] = messageArray[6];
                        colorArray[2] = messageArray[7];
                        byte newB = InByte(colorArray);

                        Color newColor = Color.FromArgb(newR, newG, newB);
                        bPic.SetPixel(i, j, newColor);
                        index++;
                    }
                    if (st)
                    {
                        break;
                    }

                }

                String sFilePic = "hide3_1.bmp";
                
                
                
                FileStream wFile;

                try
                {
                    wFile = new FileStream(sFilePic, FileMode.Create ); //открываем поток на запись результатов
                }
                catch (IOException)
                {
                    MessageBox.Show("Ошибка открытия файла на запись", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bPic.Save(wFile, System.Drawing.Imaging.ImageFormat.Bmp);
               
                wFile.Close(); //закрываем поток

                textBox1.Text = "";
                MessageBox.Show("Текст внедрен в картинку", "Информация", MessageBoxButtons.OK);
            }
            else MessageBox.Show("Введите сообщение!");
        }

        /*Открыть файл для дешифрования */

        private void button2_Click_1(object sender, System.EventArgs e)
        {            
            string FilePic = "hide3_1.bmp";
            FileStream rFile;

            try
            {
                rFile = new FileStream(FilePic, FileMode.Open); //открываем поток
            }
            catch (IOException)
            {
                MessageBox.Show("Ошибка открытия файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Bitmap bPic = new Bitmap(rFile);
            if (!isEncryption(bPic))
            {
                MessageBox.Show("В файле нет зашифрованной информации", "Информация", MessageBoxButtons.OK);
                return;
            }

            int countSymbol = ReadCountText(bPic); //считали количество зашифрованных символов
            byte[] message = new byte[countSymbol];
            int index = 0;
            bool st = false;
            for (int i = 4; i < bPic.Width; i++)
            {
                for (int j = 0; j < bPic.Height; j++)
                {
                    Color pixelColor = bPic.GetPixel(i, j);
                    if (index == message.Length)
                    {
                        st = true;
                        break;
                    }
                    BitArray colorArray = InBit(pixelColor.R);
                    BitArray messageArray = InBit(pixelColor.R); ;
                    messageArray[0] = colorArray[0];
                    messageArray[1] = colorArray[1];

                    colorArray = InBit(pixelColor.G);
                    messageArray[2] = colorArray[0];
                    messageArray[3] = colorArray[1];
                    messageArray[4] = colorArray[2];

                    colorArray = InBit(pixelColor.B);
                    messageArray[5] = colorArray[0];
                    messageArray[6] = colorArray[1];
                    messageArray[7] = colorArray[2];
                    message[index] = InByte(messageArray);
                    index++;
                }
                if (st)
                {
                    break;
                }
            }

            
            string strMessage = Encoding.GetEncoding(1251).GetString(message);
            string sFileText = "text_1.txt";

            FileStream wFile;
            try
            {
                wFile = new FileStream(sFileText, FileMode.Create); //открываем поток на запись результатов
            }
            catch (IOException)
            {
                MessageBox.Show("Ошибка открытия файла на запись", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            StreamWriter wText = new StreamWriter(wFile, Encoding.Default);
            wText.Write(strMessage);
            wText.Close();
            
            
            string fileRName = "text_1.txt";  
            wFile.Close();
            rFile.Close();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            Bitmap image1 = new Bitmap("hide3.bmp");
            pictureBox1.Image = image1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            textBox1.Text = openFileDialog1.FileName;
        }
    }
}
