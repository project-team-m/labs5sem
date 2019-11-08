#include <iostream>
using namespace std;

class Class1 {
    static int count;
public:
    Class1() {
        cout << "Constructor creation" << endl;
        count++;
    }

    Class1(Class1 &) {
        cout << "Constructor copy" << endl;
        count++;
    }

    static int get_count() {
        return count;
    }

    ~Class1() {
        cout << "Destructor" << endl;
        --count;
    }
};

/*int main() {
    Class1 c1, c2;
    Class1 *c3 = new Class1;
    cout << "Amount objects: " << Class1::get_count() << "\n" << endl;
    c1.~Class1();
    cout << "Amount objects: " << Class1::get_count() << "\n" << endl;
    c2.~Class1();
    cout << "Amount objects: " << Class1::get_count() << "\n" << endl;
    delete c3;
    cout << "Amount objects: " << Class1::get_count() << "\n" << endl;
    return 0;
}*/

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



int main() {
    Class2 *n1 = Class2::Ini();
    Class2 *n2 = Class2::Ini();
    cout << "Amount: " << Class2::count2 << endl;
    Class2::Destr(n1);
    cout << "Amount: " << Class2::count2 << endl;
    Class2::Destr(n2);
    cout << "Amount: " << Class2::count2 << endl;
    return 0;
}