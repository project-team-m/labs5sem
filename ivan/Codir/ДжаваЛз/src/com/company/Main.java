package com.company;


import java.util.ArrayList;

class Lz77 {

    static char[] mas = new char[3];

    static String Kod(String text) {

        int wat = 0;
        int count = 0;
        String out = "";
        ArrayList<Integer> list = new ArrayList<Integer>();
        ArrayList<Integer> list1 = new ArrayList<Integer>();
        ArrayList<Character> list2 = new ArrayList<Character>();
        String st = "";
        String st2 = "";
        mas[0] = text[0];
        mas[1] = text[1];
        mas[2] = text[2];
        int n = 3;
        st += mas[0];

        do {
            if ((st2.indexOf(st, st2.length()) == -1)| st2.length()==text.length()-1){
                for (int i = 0; i < mas.length - 1; i++){
                    mas[i] = mas[i+1];
                }
                if (n < text.length()){
                    mas[mas.length - 1] = text[n];
                }
                n++;
                list.add(wat);
                list1.add(count);
                list2.add(st[0]);

            }

        } while (st2 != text);
    }
}

public class Main {

    public static void main(String[] args) {
        // write your code here
    }
}
