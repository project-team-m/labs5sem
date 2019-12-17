package com.company;

class Singleton2 {
    private static Singleton2 instance = new Singleton2();
    private Singleton2(){
        System.out.println("S2");
    }
    public static Singleton2 getInstance(){
        return instance;
    }
    static {
        Singleton2.getInstance();
    }
}

public class Main {
    Singleton2 s = Singleton2.getInstance();
    public static void main(String[] args) {
        //Singleton2.getInstance();
        System.out.println("program start");
        Singleton a = Singleton.getInstance();
        a.check();
        Singleton b = Singleton.getInstance();
        b.check();
        Singleton.delete();
        a.check();
        b.check();
        a = Singleton.getInstance();
        b.check();

        System.out.println();

        Singleton2 aa = Singleton2.getInstance();
        System.out.println(aa);
        Singleton2 bb = Singleton2.getInstance();
        System.out.println(bb);
    }
    /*
    public static void main(String[] args) {
        class2 a = class2.create();
        class2.check();
        class2 b = class2.create();
        class2.check();
        a = a.del();
        class2.check();
        b = b.del();
        class2.check();
    }*/
}
