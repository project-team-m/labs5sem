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
            //p.Connect();
            p.Send();
            Console.Read();
        }
    }
    interface IUSBBus
    {
        double MaxSpeed();
        byte Send();
    }
    interface ISata
    {
        double MaxSpeed();
        byte Send();
    }
    interface INetwork
    {
        double MaxSpeed();
        byte Send();
    }
    interface IInnerBus
    {
        double MaxSpeed();
        byte Send();
    }

    class MotherBoard : IInnerBus, ISata, INetwork
    {
        private double maxspeed;
        public byte byteforsend;
        public List<string> Apply = new List<string>();
        public List<IInnerBus> Inner = new List<IInnerBus>();

        public MotherBoard(double x = 100, byte y = 1)
        {
            this.byteforsend = y;
            this.maxspeed = x;
        }
        public double MaxSpeed()
        {
            return maxspeed;
        }

        public byte Send()
        {
            return byteforsend;
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

    class HardDisk : IInnerBus, IUSBBus
    {
        private double maxspeed;
        private byte byteforsend;
        private string name;
        public MotherBoard obj;
        public HardDisk(MotherBoard obj, double x = 100, byte y = 0, string name = "HardDisk")
        {
            this.byteforsend = y;
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
                Connect().byteforsend = this.byteforsend;
                Console.WriteLine("Был отправлен байт: " + Connect().byteforsend);
                return Connect().byteforsend;
            }
            else
            {
                Console.WriteLine("Устройсво не подключено к материнке,байт не был отправлен ");
                return this.byteforsend;
            }

        }
    }

    class Printer : IInnerBus, IUSBBus, INetwork
    {
        private double maxspeed;
        private byte byteforsend;
        private string name;
        public MotherBoard obj;
        public Printer(MotherBoard obj, double x = 100, byte y = 16, string name = "Printer")
        {
            this.byteforsend = y;
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
                Connect().byteforsend = this.byteforsend;
                Console.WriteLine("Был отправлен байт: " + Connect().byteforsend);
                return Connect().byteforsend;
            }
            else
            {
                Console.WriteLine("Устройсво не подключено к материнской плате, байт не был отправлен ");
                return this.byteforsend;
            }

        }
    }
}

