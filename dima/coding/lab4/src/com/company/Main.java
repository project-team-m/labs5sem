package com.company;

class hemming {

    char[] convert_to_byte(char old) {
        char[] tmp = Integer.toBinaryString((int) old).toCharArray();
        char[] res = new char[8];

        for (int i = 0; i < 8 - tmp.length; i++) {
            res[i] = '0';
        }

        int c = 0;
        for (int i = 8 - tmp.length; i < res.length; i++) {
            res[i] = tmp[c];
            c++;
        }

        return res;
    }

    char[] ob_mass(char[] f, char[] s) {
        char[] res = new char[16];
        for (int i = 0; i < 8; i++) {
            res[i] = f[i];
        }
        for (int i = 8; i < 16; i++) {
            res[i] = s[i - 8];
        }
        return Hemming(res)[0];
    }

    char[] convert_to_words(String s) {
        char[] code = new char[(21 * (s.length() / 2)) + (21 * (s.length() % 2))];

        for (int i = 0; i < s.length() / 2; i++) {
            char[] res = ob_mass(convert_to_byte(s.charAt(i * 2)), convert_to_byte(s.charAt(i * 2 + 1)));

            for (int j = i * 21; j < i * 21 + 21; j++) {
                code[j] = res[j - i * 21];
            }
        }

        if (code.length != (s.length() / 2) * 21) {
            char[] tmp = new char[8];
            for (int i = 0; i < 8; i++) {
                tmp[i] = '0';
            }

            char[] res = ob_mass(convert_to_byte(s.charAt(s.length() - 1)), tmp);

            for (int i = (s.length() / 2) * 21; i < (s.length() / 2) * 21 + 21; i++) {
                code[i] = res[i - (s.length() / 2) * 21];
            }
        }

        return code;
    }

    int convert_from_byte(char[] b) {
        String a = new String(b);
        return Integer.parseInt(a, 2);
    }

    String convert_from_word(char[] hem) {
        for (int i = 0; i < hem.length / 21; i++) {
            char[] word = new char[];

            for (int j = i * 21; j < i * 21 + 21; j++) {

            }
        }
    }

    char[][] think_hemming(char[] str) {
        char[] r1 = {'1', '0', '1', '0', '1', '0', '1', '0', '1', '0', '1', '0', '1', '0', '1', '0', '1', '0', '1', '0', '1', '0'};
        char[] r2 = {'0', '1', '1', '0', '0', '1', '1', '0', '0', '1', '1', '0', '0', '1', '1', '0', '0', '1', '1', '0', '0', '0'};
        char[] r3 = {'0', '0', '0', '1', '1', '1', '1', '0', '0', '0', '0', '1', '1', '1', '1', '0', '0', '0', '0', '1', '1', '0'};
        char[] r4 = {'0', '0', '0', '0', '0', '0', '0', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '0'};
        char[] r5 = {'0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '1', '1', '1', '1', '1', '0'};
        char[][] hem_code = {
                str,
                r1,
                r2,
                r3,
                r4,
                r5
        };

        int[] r = new int[5];

        for (int i = 1; i < hem_code.length; i++) {
            for (int j = 0; j < hem_code[i].length - 1; j++) {
                if (hem_code[i][j] == '1' && hem_code[0][j] == '1' && hem_code[i][j] == hem_code[0][j]) {
                    r[i - 1]++;
                }
            }
        }

        for (int i = 0; i < r.length; i++) {
            if (r[i] % 2 == 0) {
                hem_code[i + 1][21] = '0';
            } else {
                hem_code[i + 1][21] = '1';
            }
        }
        hem_code[0][0] = hem_code[1][21];
        hem_code[0][1] = hem_code[1][21];
        hem_code[0][3] = hem_code[1][21];
        hem_code[0][7] = hem_code[1][21];
        hem_code[0][15] = hem_code[1][21];

        return hem_code;
    }

    char[][] Hemming(char[] str) {
        int l = 5;
        char[] new_str = new char[21];
        new_str[0] = '0';
        new_str[1] = '0';
        new_str[3] = '0';
        new_str[7] = '0';
        new_str[15] = '0';
        int c = 0;
        for (int i = 0; i < new_str.length; i++) {
            if (new_str[i] == (int) 0) {
                new_str[i] = str[c];
                c++;
            }
        }
        return think_hemming(new_str);
    }

    void prov(char[] s) {
        if (think_hemming(s)[1][21] != '0' || think_hemming(s)[2][21] != '0' || think_hemming(s)[3][21] != '0' ||
                think_hemming(s)[4][21] != '0' || think_hemming(s)[5][21] != '0') {

        }
    }

    char[] back_hemming(char[][] hem_code) {
        char[] back_hem_code = new char[16];

        int c = 0;
        for (int i = 0; i < hem_code[0].length; i++) {
            if (i != 0 && i != 1 && i != 3 && i != 7 && i != 15) {
                back_hem_code[c] = hem_code[0][i];
                c++;
                //System.out.println('2');
            }
        }
        return back_hem_code;
    }
}

public class Main {

    public static void main(String[] args) {
        hemming a = new hemming();
        /*char[] st = {'0', '1', '0', '0', '0', '1', '0', '0', '0', '0', '1', '1', '1', '1', '0', '1'};
        for (int i = 0; i < a.Hemming(st).length; i++) {
            for (int j = 0; j < a.Hemming(st)[i].length; j++) {
                System.out.print(a.Hemming(st)[i][j] + " ");
            }
            System.out.println();
        }

        System.out.println();

        char[] st2 = {'1', '0', '0', '1', '1', '0', '0', '0', '0', '1', '0', '0', '0', '0', '1', '0', '1', '1', '1', '0', '1'};

        for (int i = 0; i < a.think_hemming(st2).length; i++) {
            for (int j = 0; j < a.think_hemming(st2)[i].length; j++) {
                System.out.print(a.think_hemming(st2)[i][j] + " ");
            }
            System.out.println();
        }

        for (int i = 0; i < a.back_hemming(a.think_hemming(st2)).length; i++) {
            System.out.print(a.back_hemming(a.think_hemming(st2))[i]);
        }

        char[] st = {'0', '1', '0', '0', '0', '1', '0', '0'};

        System.out.print(a.convert_from_byte(st));*/

        for (int i = 0; i < a.convert_to_words("abcd").length; i++) {
            System.out.print(a.convert_to_words("abcd")[i]);
        }

    }
}
