package com.company;

import java.util.Scanner;

class List {
    public int data;
    public List next;
    public List pred;
}

class TURN {
    private List head;
    private List tail;

    private int IsEmpty() {
        if (head == null) {
            return 0;
        } else {
            return 1;
        }
    }

    public void push(int data) {
        List a = new List();
        a.data = data;
        if (head == null) {
            head = a;
            tail = a;
        } else {
            a.pred = tail;
            tail.next = a;
            tail = a;
        }
    }

    public void pop() {
        List t = head;
        if (head == tail) {
            System.out.println(t.data);
        } else {
            if (IsEmpty() == 0) {
                System.out.println("Turn is Empty");
            } else {
                t = head.next;
                t.pred = null; // tut
                tail.next = tail;
            }
        }
    }

    public void peek() {
        if (IsEmpty() == 0) {
            System.out.println("Turn is Empty");
        } else {
            System.out.println(head.data);
        }
    }

    public void clear() {
        head = null;
        tail = null;
    }

    public void out() {
        if (head == null) {
            System.out.println("Turn is Empty");
        } else {
            List t = head;
            while (t != null) {
                System.out.print(t.data + " ");
                t = t.next;
            }
            System.out.println();
        }
    }
}

public class Main {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        TURN a = new TURN();
        int num = -1;
        while (num != 0) {
            System.out.print("1 Create new TURN. \n2 Push\n3 Pop\n4 Peek\n5 Print");
            System.out.println();
            num = sc.nextInt();
            if (num == 1) {
                a.clear();
            }
            if (num == 2) {
                System.out.println("Enter a digit");
                num = sc.nextInt();
                a.push(num);
                num = 2;
            }
            if (num == 3) {
                a.pop();
            }
            if (num == 4) {
                a.peek();
            }
            if (num == 5) {
                a.out();
            }
        }
    }
}
