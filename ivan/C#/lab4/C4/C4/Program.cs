using System;
using System.Collections.Generic;

namespace С4
{
    public interface IElectricSource
    {
        double Voltage();
        double MaxPower();
    }

   /* public interface IElectricAppliance
    {
        double Voltage();
        double MaxPower();
    }

    public interface IElectricWire
    {
        double Voltage();
        double MaxPower();
    }*/

    class PowerSocket :IElectricSource
    {
        private double voltage;
        private double maxpower;
        public List<string> appli = new List<string>();

        public PowerSocket(double x = 220, double y = 300)
        {
            voltage = x;
            maxpower = y;
        }

        public double Voltage()
        {
            return voltage;
        }
        
        public double MaxPower()
        {
            return maxpower;
        }

        public void output()
        {
            Console.WriteLine("Список подключенных приборов: ");

            if (appli.Count == 0)
            {
                Console.WriteLine("Подключений нет ");
            }
            else
            {
                for (int i = 0; i < appli.Count; i++)
                {
                    Console.WriteLine("Подключен: " + appli[i] + " ");
                }
            }
        }
    }

    class  Wire: IElectricSource
    {
        private double voltage;
        private double maxpower;
        public PowerSocket obj;

        public Wire(PowerSocket obj, double x = 220, double y = 300)
        {
            voltage = x;
            maxpower = y;
            this.obj = obj;
        }
        
        public double Voltage()
        {
            return voltage;
        }
        
        public double MaxPower()
        {
            return maxpower;
        }

        public delegate void off();
        public delegate void on();

        public event off TO_OFF;
        public event on TO_ON;

        public void ON()
        {
            TO_ON();
        }

        public void OFF()
        {
            TO_OFF();
        }
        
        public void output()
        {
            Console.WriteLine("Список подключенных приборов: ");

            if (obj.appli.Count == 0)
            {
                Console.WriteLine("Подключений нет ");
            }
            else
            {
                for (int i = 0; i < obj.appli.Count; i++)
                {
                    Console.WriteLine("Подключен: " + obj.appli[i] + " ");
                }
            }
        }

    }

    class NetBook: IElectricSource
    {
        private double voltage;
        private double maxpower;
        private string model;
        private PowerSocket obj;

        public NetBook(PowerSocket obj, double x = 200, double y = 300, string model = "NetBook")
        {
            voltage = x;
            maxpower = y;
            this.model = model;
            this.obj = obj;
        }
        
        public double Voltage()
        {
            return voltage;
        }

        public double MaxPower()
        {
            return maxpower;
        }

        public void on() 
        {
            obj.appli.Add(model);
        }

        public void off() 
        {
            obj.appli.Remove(model);
        }

        public void output() 
        {
            Console.WriteLine(model);
        }
        
    }

    class Kettle: IElectricSource
    {
        private double voltage;
        private double maxpower;
        private string model;
        private PowerSocket obj;

        public Kettle(PowerSocket obj, double x = 220, double y = 300, string model = "Kettle")
        {
            voltage = x;
            maxpower = y;
            this.model = model;
            this.obj = obj;
        }
        
        public double Voltage()
        {
            return voltage;
        }

        public double MaxPower()
        {
            return maxpower;
        }

        public void on() 
        {
            obj.appli.Add(model);
        }

        public void off() 
        {
            obj.appli.Remove(model);
        }

        public void output() 
        {
            Console.WriteLine(model);
        } 
    }

    class Refigerator :IElectricSource
    {
        private double voltage;
        private double maxpower;
        private string model;
        private PowerSocket obj;

        public Refigerator(PowerSocket obj, double x = 220, double y = 300, string model = "Refigerator2000")
        {
            voltage = x;
            maxpower = y;
            this.obj = obj;
            this.model = model;
        }
        
        public double Voltage()
        {
            return voltage;
        }

        public double MaxPower()
        {
            return maxpower;
        }

        public void on() 
        {
            obj.appli.Add(model);
        }

        public void off() 
        {
            obj.appli.Remove(model);
        }

        public void output() 
        {
            Console.WriteLine(model);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PowerSocket ps = new PowerSocket();
            Wire w = new Wire(ps);
            NetBook nb = new NetBook(ps);
            Kettle kt = new Kettle(ps);
            Refigerator r = new Refigerator(ps);

            w.TO_ON += nb.on;
            w.TO_OFF += nb.off;

            w.TO_ON += kt.on;
            w.TO_OFF += kt.off;

            w.TO_ON += r.on;
            w.TO_OFF += r.off;
            
            w.ON();
            w.output();
            Console.WriteLine();
            w.OFF();
            w.output();
            
            
        }
    }
}