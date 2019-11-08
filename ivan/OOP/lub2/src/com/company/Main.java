package com.company;

class Student {
    String Name;
    String Patronymic;
    String Surname;
    int year_of_birth;
    String Group;
    //struct все поля public, in class all поля private

    public void setName(String n) {
        this.Name = n;
    }

    public String getName() {
        return this.Name;
    }

    public void setPatronymic(String n) {
        this.Patronymic = n;
    }

    public String getPatronymic() {
        return this.Patronymic;
    }

    public void setSurname(String n) {
        this.Surname = n;
    }

    public String getSurname() {
        return this.Surname;
    }

    public void setGroup(String n) {
        this.Group = n;
    }

    public String getGroup() {
        return this.Group;
    }

    public void setYear_of_birth(int n) {
        this.year_of_birth = n;
    }

    public int getYear_of_birth() {
        return this.year_of_birth;
    }

    Student() {
        Name = "NoName";
        Patronymic = "NoPatronymic";
        Surname = "NoSurname";
        year_of_birth = 0;
        Group = "0";
    }

    Student(String N, String P, String S, int Y, String G) {
        setName(N);
        setPatronymic(P);
        setSurname(S);
        setYear_of_birth(Y);
        setGroup(G);
    }

    Student(Student a) {
        System.out.println("COP");
        this.Name = a.Name;
        this.Patronymic = a.Patronymic;
        this.Surname = a.Surname;
        this.year_of_birth = a.year_of_birth;
        this.Group = a.Group;
    }

    public void getinfo() {
        System.out.println("Surname " + getSurname());
        System.out.println("Name " + getName());
        System.out.println("Patronymic " + getPatronymic());
        System.out.println("Birth " + getYear_of_birth());
        System.out.println("Group " + getGroup());
        System.out.println();
    }

    public Student del() {
        System.out.println("del");
        return null;
    }
}


public class Main {

    public static void main(String[] args) {
        Student a = new Student("Ivan", "Sergey", "Nedomerkov", 5, "VPR-31");
        a.getinfo();
        Student b = new Student(a);
        b.getinfo();
        a = a.del();
        a.getinfo();
    }
}
