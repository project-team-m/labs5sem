package com.company;

public class class2 {
    public static int count = 0;
    private class2() {
        System.out.println("Constructor");
        count++;
    }
    private static class2 delele() {
        System.out.println("Destructor");
        count--;
        return null;
    }

    public static class2 create() {
        return new class2();
    }

    public class2 del() {
        return class2.delele();
    }

    public static void check() {
        System.out.println("Amount: " + count);
    }
}
