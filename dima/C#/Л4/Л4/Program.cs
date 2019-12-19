using System;
using System.Collections.Generic;

namespace Л4
{
    class Program
    {
        static void Main()
        {
            MotherBoard m = new MotherBoard();
            Printer p = new Printer(m,100,16,"HP 2035");
            p.Connect();
            p.Send();
        }
    }
    interface A
    {
        double MaxSpeed();
        byte Send();
    }
    interface B
    {
        double MaxSpeed();
        double Size();
        byte Send();
    }
    interface C
    {
        double MaxSpeed();
        byte Send();
    }

    class MotherBoard : A
    {
        private double maxspeed;
        public byte cashe;
        public List<string> Apply = new List<string>();
        public List<A> Inner = new List<A>();

        public MotherBoard(double x = 100, byte y = 1)
        {
            this.cashe = y;
            this.maxspeed = x;
        }
        public double MaxSpeed()
        {
            return maxspeed;
        }

        public byte Send()
        {
            return cashe;
        }

        public void show()
        {
            Console.WriteLine(" Список подключенных приборов : ");

            if (Apply.Count == 0)
            {
                Console.WriteLine(" Подключений нет ");
            }
            else
            {
                for (int i = 0; i < Apply.Count; i++)
                {
                    Console.WriteLine(" Подключен : " + Apply[i] + "  ");
                }
            }

        }
    }

    class HardDisk : B
    {
        private double maxspeed;
        private byte cashe;
        private string name;
        private double size;
        public MotherBoard obj;
        public HardDisk(MotherBoard obj, double x = 100, byte y = 0, string name = "HardDisk", double s = 0)
        {
            cashe = y;
            maxspeed = x;
            size = s;
            this.obj = obj;
            this.name = name;
        }
        public MotherBoard Connect()
        {
            obj.Apply.Add(this.name);
            try
            {
                obj.Inner.Add(this);
            }
            catch (Exception e) { Console.WriteLine("Нельзя занести,не наследует нужный интерфейс"); }
            return obj;
        }
        public double MaxSpeed()
        {
            return maxspeed;
        }

        public byte Send()
        {
            if (obj.Apply.Contains(this.name))
            {
                Connect().cashe = this.cashe;
                Console.WriteLine("Был отправлен байт: " + Connect().cashe);
                return Connect().cashe;
            }
            else
            {
                Console.WriteLine("Устройсво не подключено к материнке,байт не был отправлен ");
                return this.cashe;
            }

        }
    }
    class Printer : Bus
    {
        private double maxspeed;
        private byte cashe;
        private string name;
        public MotherBoard obj;
        public Printer(MotherBoard obj, double x = 100, byte y = 16, string name = "Printer")
        {
            this.cashe = y;
            this.maxspeed = x;
            this.obj = obj;
            this.name = name;
        }
        public MotherBoard Connect()
        {
            this.obj.Apply.Add(this.name);
            try
            {
                this.obj.Inner.Add(this);
            }
            catch (Exception e) { Console.WriteLine("Нельзя занести,не наследует нужный интерфейс"); }
            return obj;
        }
        public double MaxSpeed()
        {
            return maxspeed;
        }

        public byte Send()
        {
            if (obj.Apply.Contains(this.name))
            {
                Connect().cashe = this.cashe;
                Console.WriteLine("Был отправлен байт: " + Connect().cashe);
                return Connect().cashe;
            }
            else
            {
                Console.WriteLine("Устройсво не подключено к материнской плате, байт не был отправлен ");
                return this.cashe;
            }

        }
    }
}

