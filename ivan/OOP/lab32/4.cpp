/*#include <iostream>

using namespace std;


class Singleton {
private:
    Singleton() {
        cout << "Constructor creation" << endl;
    }
    ~Singleton() {
        cout << "Destructor " << endl;
    }
public:
    static Singleton &init() {
        static Singleton obj;
        return obj;
    }
};

Singleton &n = Singleton::init();

int main4() {
    Singleton &n = Singleton::init();
    cout << &n << endl;
    Singleton &n1 = Singleton::init();
    cout << &n1 << endl;
    Singleton &n2 = Singleton::init();
    cout << &n2 << endl;

    return 0;
}*/