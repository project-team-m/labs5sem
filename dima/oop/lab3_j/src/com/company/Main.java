package com.company;

public class Main {

    /*public static void main(String[] args) {
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
    }*/

    public static void main(String[] args) {
        class2 a = class2.create();
        class2.check();
        class2 b = class2.create();
        class2.check();
        a = a.del();
        class2.check();
        b = b.del();
        class2.check();
    }
}
