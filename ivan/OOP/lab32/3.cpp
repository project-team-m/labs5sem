/*#include <iostream>

using namespace std;


class Class3 {
    static Class3*obj;

    Class3() {
        cout << "Constructor creation" << endl;
        count3++;
    }

    Class3(Class3 &) {
        cout << "Constructor copy" << endl;
    }

    ~Class3() {
        cout << "Destructor " << endl;
        count3--;
    }

public:
    friend Class3* NewObj();
    static int count3;
    friend void DestroyObj(Class3*);

};

Class3* NewObj() {
    Class3 *obj = new Class3;
    return obj;
}

void DestroyObj(Class3 *obj) {
    delete obj;
}

int Class3::count3;

int main() {
    Class3 *c1 = NewObj();
    Class3 *c2 = NewObj();
    cout << "Amount " << Class3::count3 << endl;
    DestroyObj(c1);
    cout << "Amount: " << Class3::count3 << endl;
    DestroyObj(c2);
    cout << "Amount: " << Class3::count3 << endl;
    return 0;
}
}*/