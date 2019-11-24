﻿using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Xml.XPath;

 namespace ConsoleApplication1 {
    class Program {
        public class Workplace {
            public Employee human;
            public Workplace()
            {
                this.human = new Employee();
            }
            public Workplace(Employee human) {
                this.human = human;
            }
            public void PrintSpecialization()
            {
                human.PrintSpecialization();
            }
        }
        
        public class Cabinet
        {
            public List<Workplace> per = new List<Workplace>();
            public Cabinet() {
            }
            public Cabinet(Workplace per) {
                this.per.Add(per);
            }
            public void PrintAll() {
                for(int i; i < this.per.Count; i++)
                {
                    Console.Write("Type: " + this.per[i].ToString());
                }
            }
        }

        public class Human {
            public string name;
            public Human() {
            }
            public Human(string name) {
                this.name = name;
            }
            public void PrintName() {
                Console.WriteLine("Name: " + this.name);
            }
        }

        public class Employees {
            public List<Employee> a1;
            public Employees(List<Employee> a1)
            {
                this.a1 = a1;
            }
            public Employees()
            {
                this.a1 = new List<Employee>();
            }

            public void add_emp(Employee a1)
            {
                this.a1.Add(a1);
            }
            public Employees(Employee a1)
            {
                this.add_emp(a1);
            }
            
            public virtual void PrintPosition() {
                foreach (Employee i in this.a1)
                {
                    i.PrintSpecialization();
                }
            }
        }

        public class Employee {
            public string specialization;
            public Employee() {
            }
            public Employee(string specialization) {
                this.specialization = specialization;
            }
            public void PrintSpecialization() {
                Console.WriteLine("Specialization: " + this.specialization);
            }
        }
        public class Worker : Human {
            public string type;
            public Worker() : base(null, null) {
            }
            public Worker(string name, string position, string type) : base(name, position) {
                this.type = type;
            }
            public void PrintType() {
                Console.WriteLine("Type: " + this.type);
            }
        }
        public class Student : Human {
            public string group;
            public Student() : base(null) {
            }
            public Student(string name, string group) : base(name) {
                this.group = group;
            }
            public void PrintGroup() {
                Console.WriteLine("Group: " + this.group);
            }
        }
        public class Librarian : Employees {
            public string address;
            public Librarian():base(null, null) {
            }
            public Librarian(string name, string position, string address):base(name, position) {
                this.address = address;
            }
            public void PrintAddress() {
                Console.WriteLine("Address: " + this.address);
            }
        }
        public class Director : Employees {
            public int age;
            public Director() : base(null, null) {
            }
            public Director(string name, string position, int age) : base(name, position) {
                this.age = age;
            }
            public void PrintAge() {
                Console.WriteLine("Age: " + this.age);
            }
        }
        public class Security : Employees {
            public int access_level;
            public Security() : base(null, null) {
            }
            public Security(string name, string position, int access_level) : base(name, position) {
                this.access_level = access_level;
            }
            public void PrintAccessLevel() {
                Console.WriteLine("Access level: " + this.access_level);
            }
        }
        public class Cashier : Employees {
            public int cashbox_number;
            public Cashier() : base(null, null) {
            }
            public Cashier(string name, string position, int cashbox_number) : base(name, position) {
                this.cashbox_number = cashbox_number;
            }
            public void PrintCashboxNumber() {
                Console.WriteLine("Cashbox Number: " + this.cashbox_number);
            }
        }
        private static void Main(string[] args) {
            Console.WriteLine();
            Console.WriteLine("Cabinet: ");
            var cabinet = new Cabinet("Meeting room", "Meet");
            cabinet.PrintType();
            cabinet.PrintName();
            
            Console.WriteLine();
            Console.WriteLine("Employees: ");
            var employee = new Employee("Dasha", "Translator", "Meeting");
            employee.PrintName();
            employee.PrintPosition();
            employee.PrintSpecialization();
            
            Console.WriteLine();
            Console.WriteLine("Workers: ");
            var worker = new Worker("Vasya", "plant", "carpenter");
            worker.PrintName();
            worker.PrintPosition();
            worker.PrintType();
            
            Console.WriteLine();
            Console.WriteLine("Students: ");
            var student = new Student("Ivan", "VPR31");
            student.PrintName();
            student.PrintGroup();
            
            Console.WriteLine();
            Console.WriteLine("Librarians: ");
            var librarian = new Librarian("Zoya", "librarian", "Tekycheva 1");
            librarian.PrintName();
            librarian.PrintPosition();
            librarian.PrintAddress();
            
            Console.WriteLine();
            Console.WriteLine("Directors: ");
            var director = new Director("Genyadiy", "GenDir", 56);
            director.PrintName();
            director.PrintPosition();
            director.PrintAge();
            
            Console.WriteLine();
            Console.WriteLine("Securities: ");
            var security = new Security("Petya", "Security", 0);
            security.PrintName();
            security.PrintPosition();
            security.PrintAccessLevel();
            
            Console.WriteLine();
            Console.WriteLine("Cashiers: ");
            var cashier = new Cashier("Tanya", "Cashier", 12);
            cashier.PrintName();
            cashier.PrintPosition();
            cashier.PrintCashboxNumber();
           
        }
    }
}