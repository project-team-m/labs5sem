#include <iostream>
#include <fstream>
#include <stdlib.h>
#include <math.h>
#include <string>

using namespace std;

template<typename T>
void f(T x, T y) { cout << "x=" << x << "\ty=" << y << endl; }

void f(double x, double y) { cout << "x=" << x << "\ty=" << y << endl; }

template<typename T>
void f(double x, double y) { cout << "x=" << x << "\ty=" << y << endl; }

int main() {
    int a = 5;
    double d = 1.5;
    f(a, d);
    return 0;
}
