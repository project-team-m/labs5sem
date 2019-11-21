/*#include <iostream>

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
int Class1::count = 0;


int main1() {
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
}

*/