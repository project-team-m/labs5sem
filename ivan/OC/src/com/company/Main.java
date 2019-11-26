package com.company;



class OC {
    int[][] ram = {{3, 0},{1, 1},{1, 2},{1, 3},{1, 4},{1, 5},{1, 6},{1, 7}};
    int[][] rom = {{1, 8},{1, 9},{1, 10},{1, 11},{1, 12},{1, 13},{1, 14},{1, 15}};
    int[][] vir = {{1, 0},{1, 1},{1, 2},{1, 3},{1, 4},{1, 5},{1, 6},{1, 7}, {1, 8},{1, 9},{1, 10},{1, 11},{1, 12},{1, 13},{1, 14},{1, 15}};

    public void cd(int ind) {
        int[] save = ram[search(ind)[1]];
        int[][] ram_new = new int[8][2];
        int sc = 7;
        for (int i = 7; i >=  0; i--) {
            if(ram[i][1] != ind) {
                ram_new[sc] = ram[i];
                sc--;
            }

        }
        ram_new[0] = save;
        ram = ram_new;
    }

    public void swap(int num) {
        int[] tmp = search(num);
        cd(ram[7][1]);
        int[] save = ram[0];
        ram[0] = rom[tmp[1]];
        rom[tmp[1]] = save;
    }

    void read(int num) {
        int[] tmp = search(num);
        if (tmp[0] == 0) {
            swap(num);
        } else {
            cd(tmp[1]);
        }
        System.out.println("В позиции " + num + " находится " + ram[0][0]);
    }

    int[] search(int pos) {
        for (int i = 0; i < ram.length; i++) {
            if (pos == ram[i][1]) {
                int[] konch = {1, i};
                return konch;
            }
        }
        for (int i = 0; i < rom.length; i++) {
            if (pos == rom[i][1]) {
                int[] konch = {0, i};
                return konch;
            }
        }
        return null;
    }

    void write(int num, int digit) {
        int[] tmp = search(num);
        if (tmp[0] == 0) {
            System.out.println(33333 + " " + tmp[1]);
            swap(num);
            System.out.println(44444 + " " + tmp[1]);
        } else {
            cd(num);
        }
        int[] konch = {digit, ram[0][1]};
        ram[0] = konch;
        vir[ram[0][1]] = konch;
        System.out.println("-----------------------------------");
        output();
        System.out.println("-----------------------------------");
        System.out.println("Позиция " + num + " Число " + digit);
        System.out.println("Готово!");
        System.out.println("-----------------------------------");
    }
    void output() {
        System.out.print("RAM: ");
        for (int i = 0; i < 8; i++) {
            System.out.print("(" + ram[i][0] + ", " + ram[i][1] + "); ");
        }
        System.out.println();
        System.out.print("HDD: ");
        for (int i = 0; i < 8; i++) {
            System.out.print("(" + rom[i][0] + ", " + rom[i][1] + "); ");
        }
        System.out.println();

        System.out.print("VIR: ");
        for (int i = 0; i < vir.length; i++) {
            System.out.print("(" + vir[i][0] + ", " + vir[i][1] + "); ");
        }
        System.out.println();
    }


}

public class Main {

    public static void main(String[] args) {
        OC a = new OC();
        a.output();
        a.write(1, 1);
        a.output();
        a.write(2, 2);
        a.output();
        a.write(3, 3);
        a.output();
        a.write(4, 4);
        a.output();
        a.write(5, 5);
        a.output();
        a.write(6, 6);
        a.output();
        a.write(7, 7);
        a.output();
        a.write(8, 8);
        a.output();
        a.write(9, 9);
        a.output();
        a.write(10, 10);
        a.output();
        a.write(11, 11);
        a.output();
        a.write(12, 12);
        a.output();
        a.write(13, 13);
        a.output();
        a.write(14, 14);
        a.output();
        a.write(15, 15);
        a.output();
        a.read(0);
        a.output();
    }
}
