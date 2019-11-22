using System;

namespace lub2
{
    class Program
    {
        public class Animals
        {
            public string Name;
            public Animals(string name)
            {
                Name = name;
            }
            public void PrintName()
            {
                Console.Write("Name :");
                Console.WriteLine(Name);
            }
            
        }

        public class Mammals : Animals
        {
            public string Color;
            public Mammals(string name, string color) : base(name)
            {
                 Color = color;
            }

            public virtual void PrintColor()
            {
                Console.Write("Color :");
                Console.WriteLine(Color);
            }
        }

        public class Horses : Mammals
        {
            public int Year;
            public Horses(string name, string color, int year) : base(name, color)
            {
                Year = year;
            }
            public void PrintYear()
            {
                Console.Write("Age :");
                Console.WriteLine(Year);
            }
        }
        public class Fish : Animals
        {
            public string WhereLive;
            public Fish(string name, string live) : base(name)
            {
                WhereLive = live;
            }
            public void PrintWhereLive()
            {
                Console.Write("Habitat:");
                Console.WriteLine(WhereLive);
            }
        }
        public class Spiders : Animals
        {
            public string Markwool;
            public Spiders(string name, string mark) : base(name)
            {
                Markwool = mark;
            }
            public void PrintMarkwool()
            {
                Console.Write("Silkiness :");
                Console.WriteLine(Markwool);
            }
        }
        public class Dogs : Mammals
        {
            public string Breed;
            public Dogs(string name,string color, string breed) : base(name, color)
            {
                Breed = breed;
            }
            public Dogs(string name,string breed):base(name,"None")
            {
                Breed = breed;
            }
            
            public override void PrintColor()
            {
                Console.Write("Usualy Color Breed :");
                Console.WriteLine(Color);
            }
            public void PrintBreed()
            {
                Console.Write("Breed :");
                Console.WriteLine(Breed);
            }
        }
        public class Crocodile : Animals
        {
            public int Tooth;
            public Crocodile(string name, int tooth) : base(name)
            {
                Tooth = tooth;
            }
            
            public void PrintTooth()
            {
                Console.Write("Number of teeth:");
                Console.WriteLine(Tooth);
            }
        }
        private static void Main(string[] args)
        {
            Console.WriteLine(("").PadRight(24, '_'));
            Console.WriteLine("Dogs : ");
            var Dogs = new Dogs("Pit", "ovcharka");
            Dogs.PrintName();
            Dogs.PrintColor();
            Dogs.PrintBreed();
            Console.WriteLine(("").PadRight(24, '_'));
            var Dogs1 = new Dogs("Spi", "Red","Pikingese");
            Dogs1.PrintName();
            Dogs1.PrintColor();
            Dogs1.PrintBreed();
            Console.WriteLine(("").PadRight(24, '_'));
            Console.WriteLine("Crocodile : ");
            var Crocodile = new Crocodile("Amega", 40);
            Crocodile.PrintName();
            Crocodile.PrintTooth();
            Console.WriteLine(("").PadRight(24, '_'));
            Console.WriteLine("Horses : ");
            var Horses = new Horses("Plotva", "grey", 10);
            Horses.PrintName();
            Horses.PrintColor();
            Horses.PrintYear();
            Console.WriteLine(("").PadRight(24, '_'));
            Console.WriteLine("Spiders : ");
            var Spiders = new Spiders("Load", "small");
            Spiders.PrintName();
            Spiders.PrintMarkwool();
            Console.WriteLine(("").PadRight(24, '_'));
            Console.WriteLine("Fish : ");
            var Fish = new Fish("Piranha", "Brazil");
            Fish.PrintName();
            Fish.PrintWhereLive();
            Console.WriteLine(("").PadRight(24, '_'));
           
            Console.ReadKey();
        }
    }
}