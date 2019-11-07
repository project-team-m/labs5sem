﻿using System;

namespace ConsoleApp2
{
    class Program
    {
        public class Cabinet
        {
            public string Name;
            public Cabinet(string name)
            {
                this.Name = name;
            }
            public void PrintName()
            {
                Console.Write("Name :" + this.Name);
            }
        }
        
        public class Workplace: Cabinet
        {
            public string Name;
            public Workplace(string name, string type) : base(name)
            {
                this.Name = name;
            }
            public void PrintName()
            {
                Console.Write("Name :" + this.Name);
            }
        }
        
        public class Human
        {
            public string Name;
            public Human(string name)
            {
                this.Name = name;
            }
            public void PrintName()
            {
                Console.Write("Name :" + this.Name);
            }
        }

        public class Employees : Human
        {
            public string Position;
            public Employees(string name, string position) : base(name)
            {
                 this.Position = position;
            }
            
            public virtual void PrintColor()
            {
                Console.Write("Position :" + this.Position);
            }
        }

        public class Worker : Employees
        {
            public int Year;
            public Worker(string name, string color, int year) : base(name, color)
            {
                this.Year = year;
            }
            public void PrintYear()
            {
                Console.Write("Age :" + this.Year);
            }
        }
        public class Fish : Animals
        {
            public string WhereLive;
            public Fish(string name, string live) : base(name)
            {
                this.WhereLive = live;
            }
            public void PrintWhereLive()
            {
                Console.Write("Habitat:");
                Console.WriteLine(this.WhereLive);
            }
        }
        public class Spiders : Animals
        {
            public string Markwool;
            public Spiders(string name, string mark) : base(name)
            {
                this.Markwool = mark;
            }
            public void PrintMarkwool()
            {
                Console.Write("Silkiness :");
                Console.WriteLine(this.Markwool);
            }
        }
        public class Dogs : Mammals
        {
            public string Breed;
            
            public Dogs(string name,string breed):base(name,"null")
            {
                this.Breed = breed;
            
            }
            
            public override void PrintColor()
            {
                Console.Write("Usualy Color Breed :");
                Console.WriteLine(base.Color);
            }
            public void PrintBreed()
            {
                Console.Write("Breed :");
                Console.WriteLine(this.Breed);
            }
        }
        public class Crocodile : Animals
        {
            public int Tooth;
            public Crocodile(string name, int tooth) : base(name)
            {
                this.Tooth = tooth;
            }
            public void PrintTooth()
            {
                Console.Write("Number of teeth:");
                Console.WriteLine(this.Tooth);
            }
        }
        private static void Main(string[] args)
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("Dogs : ");
            var Dogs = new Dogs("Reks", "ovcharka");
            Dogs.PrintName();
            Dogs.PrintColor();
            Dogs.PrintBreed();
            Console.WriteLine("--------------------------");
            Console.WriteLine("Crocodile : ");
            var Crocodile = new Crocodile("Dasha", 40);
            Crocodile.PrintName();
            Crocodile.PrintTooth();
            Console.WriteLine("--------------------------");
            Console.WriteLine("Horses : ");
            var Horses = new Horses("Veter", "grey", 10);
            Horses.PrintName();
            Horses.PrintColor();
            Horses.PrintYear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("Spiders : ");
            var Spiders = new Spiders("Neo", "small");
            Spiders.PrintName();
            Spiders.PrintMarkwool();
            Console.WriteLine("--------------------------");
            Console.WriteLine("Fish : ");
            var Fish = new Fish("Dark Dragon", "Brazil");
            Fish.PrintName();
            Fish.PrintWhereLive();
            Console.WriteLine("--------------------------");
           
        }
    }
}