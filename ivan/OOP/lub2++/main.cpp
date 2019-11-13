#include <iostream>

using namespace std;

class Student {

public:
    Student() {
        cout << "Constructor created" << endl;
    }

    Student(Student &) {
        cout << "Constructor copy" << endl;
    }


    ~Student() {
        cout << "DeConstructor" << endl;
    }
};

Student test(Student s) {
    return s;
}

int main() {

    Student a;
    test(a);
    return 0;
}