#include <iostream>

using namespace std;

class Test {
    int W;
    void Z() {
        cout << "This is a private function of the class Test" << endl;
    }

public:
    Test( int x = 1) {
        W = x;
    }
    friend void fun(Test*obj);
};

void fun(Test*obj) {
    cout << "W = " << obj->W << endl;
    obj->Z();
}

int main() {
    Test obj1;
    fun(&obj1);
    return 0;
}