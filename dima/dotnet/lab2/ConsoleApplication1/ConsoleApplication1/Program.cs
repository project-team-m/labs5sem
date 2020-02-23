﻿using System;
 using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        public class Cabinet
        {
            public string num;
            public Cabinet(string num)
            {
               
                this.num = num;
            }
            public void PrintName()
            {
                Console.WriteLine("Name : " + this.num);
            }
        }

        public class Workplace : Cabinet
        {
            public string table;
            public string chair;
            public Workplace(string num, string table, string chair) : base(num)
            {
                this.table = table;
                this.chair = chair;
            }
            
            public virtual void PrintInfo()
            {
                Console.WriteLine("Name table : " + this.table + "\nName chair : " + this.chair);
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
                Console.WriteLine("Name : " + this.Name);
            }
        }

        public class Employee : Employees
        {
            public string position;
            public Employee(string name, string position) : base(name, )
            {
                 this.position = position;
            }
            
            public virtual void PrintColor()
            {
                Console.WriteLine("Position : " + this.position);
            }
        }

        public class Employees : Human
        {
            public List<Human> list_employee;
            public Employees(string name, Employee obj) : base(name)
            {
                this.list_employee.Add(Human(name));
            }
            public virtual void PrintList()
            {
                foreach (var i in this.list_employee)
                {
                    Console.WriteLine(i);
                }
            }
        }
        public class Worker : Human
        {
            public int amount_fingers;
            public Worker(string name, int amount) : base(name)
            {
                this.amount_fingers = amount;
            }
            public void Printfing()
            {
                Console.WriteLine("Amount fingers : " + this.amount_fingers);
            }
        }
        public class Student : Human
        {
            public int Amount_duty;
            public Student(string name, int amount) : base(name)
            {
                this.Amount_duty = amount;
            }
            public void Printduty()
            {
                Console.WriteLine("Amount duty :" + this.Amount_duty);
            }
        }
        public class Librarian : Human
        {
            public string Breed;
            public Dogs(string name,string color, string breed) : base(name, color)
            {
                this.Breed = breed;
            }
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
           
            Console.ReadKey();
        }
    }
}