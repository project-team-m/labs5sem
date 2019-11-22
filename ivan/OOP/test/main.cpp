#include <iostream>

using namespace std;

class Class3 {
    static Class3*obj;
    static int count;

    Class3() {
        cout << "Constructor creation" << endl;
        count++;
    }

    Class3(Class3 &) {
        cout << "Constructor copy" << endl;
    }

    ~Class3() {
        cout << "Destructor " << endl;
        count--;
    }

public:
    friend Class3* NewObj();

    friend void DestroyObj(Class3*);

};

Class3* NewObj() {
    Class3 *obj = new Class3;
    return obj;
}

void DestroyObj(Class3 *obj) {
    delete obj;
}

int Class3::count;

int main() {
    Class3 *c1 = NewObj();
    Class3 *c2 = NewObj();
    cout << "Amount " << Class3::count << endl;
    DestroyObj(c1);
    cout << "Amount: " << Class3::count << endl;
    DestroyObj(c2);
    cout << "Amount: " << Class3::count << endl;
}