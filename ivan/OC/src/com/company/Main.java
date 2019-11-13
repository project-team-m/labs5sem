package com.company;


class OC {
    void ini(int[] ram, int[] rom) {
        for (int i = 0; i < 8; i++) {
            ram[i] = 0;
        }
        for (int i = 0; i < 8; i++) {
            rom[i] = 0;
        }
    }

    void swap(int[] ram, int[] rom, int num) {
        if (num % 8 != 0) {
            rom[num] = ram[0];
            ram[0] = rom[num];
        }
    }

    void read(int num, int[] ram) {
        if (num / 8 != 0) {
            num = num % 8;
        }
        System.out.println("В позиции " + num + " находится " + ram[num]);
    }

    void zap(int[] ram, int[] rom, int num, int digit) {
        if (num / 8 != 0) {
            swap(ram, rom, num % 8);
            num = num % 8;
        }
        ram[num] = digit;
    }

    void output(int[] ram, int[] rom) {
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
        int[] ram = new int[8];
        int[] rom = new int[8];
        OC a = new OC();
        a.ini(ram, rom);
        a.zap(ram, rom, 0, 1);
        a.zap(ram, rom, 1, 2);
        a.zap(ram, rom, 2, 3);
        a.zap(ram, rom, 3, 4);
        a.zap(ram, rom, 4, 5);
        a.zap(ram, rom, 5, 6);
        a.zap(ram, rom, 6, 7);
        a.zap(ram, rom, 7, 8);
        //a.zap(ram, rom, 9, 200);
        a.output(ram, rom);
        a.read(3, ram);
    }
}
