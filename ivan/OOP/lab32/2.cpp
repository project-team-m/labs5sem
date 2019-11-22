/*#include <iostream>

using namespace std;

class Class2 {
    Class2() {
        cout << "Constructor creation" << endl;
        count2++;
    }

    Class2(Class2 &) {
        cout << "Constructor copy" << endl;
    }

    ~Class2() {
        cout << "Destructor " << endl;
        count2--;
    }

public:
    static int count2;

    static Class2 *Ini() {
        cout << "External creation" << endl;
        Class2 *obj = new Class2;
        return obj;
    }

    static void Destr(Class2 *obj) {
        cout << "External destructor " << endl;
        delete obj;
    }

};
int Class2::count2 = 0;

int main2() {
    Class2 *n1 = Class2::Ini();
    Class2 *n2 = Class2::Ini();
    cout << "Amount: " << Class2::count2 << endl;
    Class2::Destr(n1);
    cout << "Amount: " << Class2::count2 << endl;
    Class2::Destr(n2);
    cout << "Amount: " << Class2::count2 << endl;
    return 0;
}*/