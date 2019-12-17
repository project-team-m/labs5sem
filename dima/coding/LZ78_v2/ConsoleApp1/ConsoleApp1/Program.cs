﻿using System.IO;

namespace ConsoleApp1
{
    class Program
    {

        static void ToRGB()
        {
            FileStream input = new FileStream("hide1.bmp", FileMode.Open);
            FileStream f1 = new FileStream("1.bmp", FileMode.Create);
            FileStream f2 = new FileStream("2.bmp", FileMode.Create);
            FileStream f3 = new FileStream("3.bmp", FileMode.Create);
            input.CopyTo(f1);
            input.Seek(0, SeekOrigin.Begin);
            input.CopyTo(f2);
            input.Seek(0, SeekOrigin.Begin);
            input.CopyTo(f3);
            BinaryReader read = new BinaryReader(input);
            input.Seek(10, SeekOrigin.Begin);
            int sm = read.ReadInt32();
            int size = (int)input.Length - sm;

            f1.Seek(sm, SeekOrigin.Begin);
            f2.Seek(sm, SeekOrigin.Begin);
            f3.Seek(sm, SeekOrigin.Begin);
            for (int i = 0; i < size; i++)
            {
                if (i % 3 == 0) f1.Seek(1, SeekOrigin.Current);
                else
                    f1.WriteByte(0);
                if (i % 3 == 1) f2.Seek(1, SeekOrigin.Current);
                else
                    f2.WriteByte(0);

                if (i % 3 == 2) f3.Seek(1, SeekOrigin.Current);
                else
                    f3.WriteByte(0);
            }
        }


        public static void Coding()
        {
            FileStream input = new FileStream("hide2.bmp", FileMode.Open);
            FileStream output = new FileStream("code.bmp", FileMode.Create);
            int integer, width, height;
            BinaryReader reader = new BinaryReader(input);
            BinaryWriter writer = new BinaryWriter(output);
            input.Seek(10, SeekOrigin.Begin);
            integer = reader.ReadInt32();
            byte[] str = new byte[integer];
            input.Seek(0, SeekOrigin.Begin);
            input.Read(str, 0, str.Length);
            output.Write(str, 0, str.Length);
            output.Seek(30, SeekOrigin.Begin);
            writer.Write(1);

            input.Seek(18, SeekOrigin.Begin);
            width = reader.ReadInt32();
            height = reader.ReadInt32();

            byte[] all_text = new byte[input.Length - integer];
            input.Seek(integer, SeekOrigin.Begin);
            output.Seek(integer, SeekOrigin.Begin);
            input.Read(all_text, 0, all_text.Length);
            byte count = 1;

            for (int i = 0; i < height; i++)
            {
                byte ch = all_text[i * width];
                count = 0;
                for (int j = 0; j < width; j++)
                {
                    if (all_text[i * width + j] == ch && count < 255)
                        count++;
                    else
                    {
                        output.WriteByte(count);
                        output.WriteByte(ch);
                        ch = all_text[i * width + j];
                        count = 1;
                    }
                }

                output.WriteByte(count);
                output.WriteByte(ch);
                output.WriteByte(0);
                output.WriteByte(0);

            }
            output.WriteByte(0);
            output.WriteByte(1);
            input.Dispose();
            output.Dispose();
        }

        public static void Decoding()
        {
            FileStream input = new FileStream("code.bmp", FileMode.Open);
            FileStream output = new FileStream("decode.bmp", FileMode.Create);
            int integer;
            BinaryReader reader = new BinaryReader(input);
            BinaryWriter writer = new BinaryWriter(output);
            input.Seek(10, SeekOrigin.Begin);
            integer = reader.ReadInt32();
            byte[] str = new byte[integer];
            input.Seek(0, SeekOrigin.Begin);
            input.Read(str, 0, str.Length);
            output.Write(str, 0, str.Length);
            output.Seek(30, SeekOrigin.Begin);
            writer.Write(0);
            byte[] all_text = new byte[input.Length - integer];
            input.Seek(integer, SeekOrigin.Begin);
            output.Seek(integer, SeekOrigin.Begin);
            input.Read(all_text, 0, all_text.Length);

            for (int i = 0; i < all_text.Length; i += 2)
            {
                if (all_text[i] == 0 && all_text[i + 1] == 0) continue;
                for (int j = 0; j < all_text[i]; j++)
                {
                    output.WriteByte(all_text[i + 1]);
                }
            }
            input.Dispose();
            output.Dispose();
        }

        static void Main(string[] args)
        {
            //ToRGB();
            Coding();
            Decoding();  
        }
    }
}