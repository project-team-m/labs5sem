#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <vector>
#include <string>

using namespace std;


template <typename T>
T Sum(T x, T y) {
    if (typeid(x) != typeid(int) && typeid(x) != typeid(float) && typeid(x) != typeid(double)) {
        cout << "礤 囵梏戾蜩麇耜桢 蜩稃 " << endl;
        return 0;
    }
    return x + y;
}

template <typename T>
T Sum(T* x, T* y) {
    if (typeid(x[0]) != typeid(int) && typeid(x[0]) != typeid(float) && typeid(x[0]) != typeid(double)) {
        cout << "礤 爨耨桠� 屐屙蝾� 囵梏戾蜩麇耜桴 蜩镱�" << endl;
        return 0;
    }
    long double res = 0;
    return	res = x[0] + y[0];
}


void main()
{
    setlocale(LC_ALL, "Russian");
    int a = 1, b = 3;
    int aaa[] = { 1,2,3 }, bbb[] = { 4,5,6 };
    char aa = 'a', bb = 'b';
    Sum(a,b);
    Sum(aa, bb);
    Sum(aaa, bbb);
    system("pause");
}