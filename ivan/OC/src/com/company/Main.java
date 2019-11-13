package com.company;



class OC {
    int[] ram = {1, 2, 3, 4, 5, 6, 7, 8};
    int[] rom = {9, 10, 11, 12, 13, 14, 15, 16};

    public int[] cd(int ind) {
        int save = ram[ind];
        int[] ram_new = new int[8];
        int sc = 0;
        for (int i = 0; i < 8; i++) {
            if(i != ind) {
                ram_new[sc] = ram[i];
                sc++;
            }
        }
        ram_new[7] = save;
        return ram_new;
    }

    public void swap(int num) {
        rom[num] = rom[num] + ram[0];
        ram[0] = rom[num] - ram[0];
        rom[num] = rom[num] - ram[0];
        ram = cd(0);
    }

    void read(int num) {
        if (num / 8 > 0) {
            num = num % 8;
            swap(num % 8);
            System.out.println("В позиции " + num + " находится " + ram[7]);
        } else {
            ram = cd(num);
            System.out.println("В позиции " + num + " находится " + ram[7]);
        }
    }

    void write(int num, int digit) {
        if (num / 8 > 0) {
            num = num % 8;
            swap(num % 8);
        } else {
            ram = cd(num);
        }
        ram[7] = digit;
        System.out.println("Готово!");
    }

    void output() {
        System.out.print("RAM: ");
        for (int i = 0; i < 8; i++) {
            System.out.print(ram[i] + " ");
        }
        System.out.println();
        System.out.print("ROM: ");
        for (int i = 0; i < 8; i++) {
            System.out.print(rom[i] + " ");
        }
        System.out.println();
    }
}

public class Main {

    public static void main(String[] args) {
        OC a = new OC();
        a.read(13);
        a.output();
        a.write(1,27);
        a.output();

    }
}
