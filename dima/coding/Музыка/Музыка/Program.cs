using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace Music_LABA
{

    [StructLayout(LayoutKind.Sequential)]
    internal class WavHeader
    {
        public UInt32 ChunkId;//0     
        public UInt32 ChunkSize;//4
        public UInt32 Format;//8
        public UInt32 Subchunk1Id;//12
        public UInt32 Subchunk1Size;//16
        public UInt16 AudioFormat;//20
        public UInt16 NumChannels;//22
        public UInt32 SampleRate;//24
        public UInt32 ByteRate;//28
        public UInt16 BlockAlign;//32
        public UInt16 BitsPerSample;//34
        public UInt32 Subchunk2Id;//36
        public UInt32 Subchunk2Size;//40
    }
    class Program
    {

        static string mainpath = @"Музыка\";
        const string formatter = "{0,16}{1,20}";
        static string smashdir = @"cute\";
        static string direncode = @"coding\";
        static string dirnamedecode = @"decoding\";

        public static string GetBytesUInt32(uint argument)
        {
            byte[] byteArray = BitConverter.GetBytes(argument);
            return BitConverter.ToString(byteArray);
            Console.WriteLine(formatter, argument,
                BitConverter.ToString(byteArray));
        } 

        public static void info(string name)
        {
            WavHeader header = new WavHeader();
            int headerSize = Marshal.SizeOf(header);
            string a = mainpath + name;

            FileStream fileStream = new FileStream(a, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[headerSize];
            fileStream.Read(buffer, 0, headerSize);

            var headerPtr = Marshal.AllocHGlobal(headerSize);
            Marshal.Copy(buffer, 0, headerPtr, headerSize);
            Marshal.PtrToStructure(headerPtr, header);

           
            Console.WriteLine("20-Аудио формат сжатия: {0}", header.AudioFormat);
            Console.WriteLine("22-Число каналов: {0}", header.NumChannels);
            Console.WriteLine("24-Частота дискретизации: {0}", header.SampleRate);
            Console.WriteLine("34-Битность файла: {0}", header.BitsPerSample);

            var Seconds = 1.0 * header.ChunkSize / (header.BitsPerSample / 8.0) / header.NumChannels / header.SampleRate;
            var Minutes = (int)Math.Floor(Seconds / 60);
            Seconds = Seconds - (Minutes * 60);
            Console.WriteLine("Продолжительность звучания: {0:00}:{1:00}", Minutes, Seconds);
            Marshal.FreeHGlobal(headerPtr);
        }

        public static void smashsound(string name)
        {
            Directory.CreateDirectory(mainpath + smashdir);
            WavHeader header = new WavHeader();
            int headerSize = Marshal.SizeOf(header);
            string a = mainpath + name;

            FileStream fileStream = new FileStream(a, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[headerSize];
            fileStream.Read(buffer, 0, headerSize);

            var headerPtr = Marshal.AllocHGlobal(headerSize);
            Marshal.Copy(buffer, 0, headerPtr, headerSize);
            Marshal.PtrToStructure(headerPtr, header);

            byte[] data = new byte[Convert.ToInt32(header.Subchunk2Size)];
            fileStream.Read(data, 0, Convert.ToInt32(header.Subchunk2Size));
            byte[] Ldata = new byte[Convert.ToInt32(500000)];
            byte[] Rdata = new byte[Convert.ToInt32(500000)];
            int l = 0, r = 0;
            for (int i = 0; i < 500000; i++)
            {
                if (i % 2 == 0)
                {
                    Rdata[l] = data[i];
                    l++;
                }
                else
                {
                    Ldata[r] = data[i];
                    r++;
                }
            }
            File.WriteAllBytes(mainpath + smashdir + "First.txt", Rdata);
            File.WriteAllBytes(mainpath + smashdir + "Second.txt", Ldata);
            Marshal.FreeHGlobal(headerPtr);

            
        }

        public static void code()
        {
            Directory.CreateDirectory(mainpath + direncode);
            byte[] rdata = File.ReadAllBytes(mainpath + smashdir + "First.txt");
            byte[] ldata = File.ReadAllBytes(mainpath + smashdir + "Second.txt");

            Transform RLE = new Transform();
            Console.WriteLine("Coding RLE start...");
            string code = System.Text.Encoding.Default.GetString(rdata);
            code = RLE.RunLengthEncode(code);
            File.WriteAllBytes(mainpath + direncode + "First.txt", Encoding.Default.GetBytes(code));


            code = System.Text.Encoding.Default.GetString(ldata);
            code = RLE.RunLengthEncode(code);
            File.WriteAllBytes(mainpath + direncode + "Second.txt", Encoding.Default.GetBytes(code));
            Console.WriteLine("Coding RLE complete");
        }
        public static void decode()
        {
            Directory.CreateDirectory(mainpath + dirnamedecode);
            byte[] rdata = File.ReadAllBytes(mainpath + direncode + "First.txt");
            byte[] ldata = File.ReadAllBytes(mainpath + direncode + "Second.txt");
            byte[] rdata2 = File.ReadAllBytes(mainpath + smashdir + "First.txt");
            Transform RLE = new Transform();

            Console.WriteLine("Decoding RLE start...");

            string decode = System.Text.Encoding.UTF8.GetString(rdata);
            //decode = RLE.RunLengthDecode(decode);
            File.WriteAllBytes(mainpath + dirnamedecode + "First.txt", rdata2);

            decode = System.Text.Encoding.Default.GetString(ldata);
            decode = RLE.RunLengthDecode(decode);
            File.WriteAllBytes(mainpath + dirnamedecode + "Second.txt", Encoding.Default.GetBytes(decode));
            Console.WriteLine("Decoding RLE complete");
        }

        public static void create(string name)
        {
            Directory.CreateDirectory(mainpath + smashdir);
            WavHeader header = new WavHeader();
            int headerSize = Marshal.SizeOf(header);
            string a = mainpath + name;

            FileStream fileStream = new FileStream(a, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[headerSize];
            fileStream.Read(buffer, 0, headerSize);

            var headerPtr = Marshal.AllocHGlobal(headerSize);
            Marshal.Copy(buffer, 0, headerPtr, headerSize);
            Marshal.PtrToStructure(headerPtr, header);

            byte[] rdata = File.ReadAllBytes(mainpath + dirnamedecode + "First.txt");
            byte[] ldata = File.ReadAllBytes(mainpath + dirnamedecode + "Second.txt");
            byte[] data = new byte[rdata.Length + ldata.Length];

            int l = 0, r = 0;
            for (int i = 0; i < 500000; i++)
            {
                if (i % 2 == 0)
                {
                    data[i] = rdata[l];
                    l++;
                }
                else
                {
                    data[i] = ldata[r];
                    r++;
                }
            }

            byte[] temp = BitConverter.GetBytes(500000);
            for (int i = 0; i < temp.Length; i++)
            {
                buffer[40 + i] = temp[i];
                //Console.WriteLine(temp[i]);
            }
            byte[] newMusic = new byte[buffer.Length + data.Length];
            Array.Copy(buffer, 0, newMusic, 0, buffer.Length);
            Array.Copy(data, 0, newMusic, buffer.Length, data.Length);
            File.WriteAllBytes(mainpath + "new.wav", newMusic);

            Marshal.FreeHGlobal(headerPtr);
        }

        static void Main(string[] args)
        {
            bool i = true;
            int answer = 0 ; 
            do 
            {
                Console.Clear();
                Console.WriteLine("1) informations");
                Console.WriteLine("2) Coding");
                Console.WriteLine("0) Exit");

                answer = Convert.ToInt32(Console.ReadLine()); 

                switch (answer)
                {
                     
                    case 1:
                        Console.Clear();
                        info("mus.wav");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        smashsound("mus.wav");
                        code();
                        decode();
                        create("mus.wav");
                        Console.ReadKey();
                        break;
                    case 0:
                        i = false; 
                        break;
                    default:
                        break;
                }

            } while (i);
        }

    }

    public class Transform
    {

        public const char EOF = '\u007F';
        public const char ESCAPE = '\\';

        public string RunLengthEncode(string s)
        {
            try
            {
                string srle = string.Empty;
                int ccnt = 1; //char counter
                for (int i = 0; i < s.Length - 1; i++)
                {
                    if (s[i] != s[i + 1] || i == s.Length - 2) //..a break in character repetition or the end of the string
                    {
                        if (s[i] == s[i + 1] && i == s.Length - 2) //end of string condition
                            ccnt++;
                        srle += ccnt + ("1234567890".Contains(s[i]) ? "" + ESCAPE : "") + s[i]; //escape digits
                        if (s[i] != s[i + 1] && i == s.Length - 2) //end of string condition
                            srle += ("1234567890".Contains(s[i + 1]) ? "1" + ESCAPE : "") + s[i + 1];
                        ccnt = 1; //reset char repetition counter
                    }
                    else
                    {
                        ccnt++;
                    }

                }
                return srle;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in RLE:" + e.Message);
                return null;
            }
        }
        public string RunLengthDecode(string s)
        {
            try
            {
                string dsrle = string.Empty
                        , ccnt = string.Empty; //char counter
                for (int i = 0; i < s.Length; i++)
                {
                    if ("1234567890".Contains(s[i])) //extract repetition counter
                    {
                        ccnt += s[i];
                    }
                    else
                    {
                        if (s[i] == ESCAPE)
                        {
                            i++;
                        }
                        dsrle += new String(s[i], int.Parse(ccnt));
                        ccnt = "";
                    }

                }
                return dsrle;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in RLD:" + e.Message);
                return null;
            }
        }
    }

    /* Console.WriteLine(" 0 4 Содержит символы RIFF: {0}", GetBytesUInt32(header.ChunkId));
           Console.WriteLine(" 4 4 Это оставшийся размер цепочки: {0}", header.ChunkSize);
           Console.WriteLine(" 8 4 Содержит символы «WAVE»: {0}", GetBytesUInt32(header.Format));
           Console.WriteLine("12 4 Содержит символы fmt: {0}", GetBytesUInt32(header.Subchunk1Id));
           Console.WriteLine("16 4 Это оставшийся размер подцепочки, начиная с этой позиции: {0}", header.Subchunk1Size);
           Console.WriteLine("20 2 Аудио формат сжатия: {0}", header.AudioFormat);
           Console.WriteLine("22 2 Количество каналов. Моно = 1, Стерео = 2: {0}", header.NumChannels);
           Console.WriteLine("24 4 Частота дискретизации: {0} Гц", header.SampleRate);
           Console.WriteLine("28 4 Количество байт, переданных за секунду воспроизведения: {0}", header.ByteRate);
           Console.WriteLine("32 2 Количество байт для одного сэмпла, включая все каналы: {0}", header.BlockAlign);
           Console.WriteLine("34 2 Количество бит в сэмпле. Так называемая «глубина» или точность звучания. 8 бит, 16 бит и т.д: {0}", header.BitsPerSample);
           Console.WriteLine("36 4 Содержит символы «data»: {0}", GetBytesUInt32(header.Subchunk2Id));
           Console.WriteLine("40 4 Количество байт в области данных: {0}", header.Subchunk2Size);*/

}
