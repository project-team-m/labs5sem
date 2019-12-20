#include <iomanip>
#include <string>
#include <iostream>
#include <type_traits>

using namespace std;

template <typename T>
T Sum(T x, T y) {
    if (is_arithmetic <T>::value) {
        cout << x + y << endl;
        return x + y;
    } cout << "Ïåðåìåííàÿ íåäîïóñòèìîãî òèïà!\n";
}

template <typename T>
T Sum(T* x, T* y)
{
    if (is_pointer <T*>::value == true) {
        cout << x[0] + y[0] << endl;
        return x[0] + y[0];
    }
}

int main3() {
    double x = 1.25, y = 1.75, z;
    z = Sum(x, y);

    int a = 2, b = 5, c;
    c = (int)Sum(a, b);

    float m = 5.32, n = 5.1, k;
    k = Sum(m, n);

    char c1 = 'a', c2 = 'b', c3;
    c3 = Sum(c1, c2);

    int A[] = { 5,6,3 };
    int B[] = { 2,7,8 }, C;
    C = Sum(A, B);

    return 0;
}
