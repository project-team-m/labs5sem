﻿using System;

namespace ConsoleApplication1 {
    class Program {
        public class Workplace {
            public string type;
            public Workplace() {
            }
            public Workplace(string type) {
                this.type = type;
            }
            public void PrintType()
            {
                Console.WriteLine("Type: " + this.type);
            }
        }
        
        public class Cabinet : Workplace {
            public string name;
            public Cabinet() : base(null) {
            }
            public Cabinet(string type, string name) : base(type) {
                this.name = name;
            }
            public void PrintName() {
                Console.WriteLine("Name: " + this.name);
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

        public class Employees : Human {
            public string position;
            public Employees() : base(null) {
            }
            public Employees(string name, string position) : base(name) {
                 this.position = position;
            }
            
            public virtual void PrintPosition() {
                Console.WriteLine("Position: " + this.position);
            }
        }

        public class Employee : Employees {
            public string specialization;
            public Employee() : base(null, null) {
            }
            public Employee(string name, string position, string specialization) : base(name, position) {
                this.specialization = specialization;
            }
            public Employee(string name, string specialization) : base(name, null) {
                this.specialization = specialization;
            }
            public override void PrintPosition() {
                Console.WriteLine("Position override: " + base.Position);
            }
            public void PrintSpecialization() {
                Console.WriteLine("Specialization: " + this.specialization);
            }
        }
        public class Worker : Employees {
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