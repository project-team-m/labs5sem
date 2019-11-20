#include <iostream>

using namespace std;

class A {
    int x;
    void AA() {
        cout << "Private function AA of class А" << endl;
    }
    friend class B;
};

class B {
public:
    void BB(A* b) {
        cout << "Function BB of class B" << endl;
        b->AA();
    }
};

int main4() {
    A object_A;
    B object_B;
    object_B.BB(&object_A);
    return 0;
}