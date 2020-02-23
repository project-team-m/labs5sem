package com.company;

import java.util.Arrays;
import java.io.*;
import java.io.File;
import java.io.IOException;

public class Main {

    public static void main(String[] args) {
        try (FileReader reader = new FileReader("smail.bmp")) {
            char[] buf = new char[1000];
            char c;
            reader.read(buf);
            System.out.print(buf);
        } catch (IOException ex) {

            System.out.println(ex.getMessage());
        }
    }
}
