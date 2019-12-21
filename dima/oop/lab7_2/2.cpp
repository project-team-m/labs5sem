#include <iostream>

using namespace std;

class  MyClass
{
    int num;

public:
    MyClass(int tmp)
    {
        num = tmp;
    }

    MyClass()
    {
        num = 0;
    }

    int get_num() {
        return num;
    }

    bool operator >(MyClass tmp)
    {
        return this->num > tmp.num;
    }
};

const char* Max(const char* s1, const char* s2)
{
    cout << "fun" << endl;
    if (s1 >= s1) return s1;
    return s2;
}

template<typename T>
T Max(T x, T y)
{
    cout << "template" << endl;
    return x > y ? x : y;
}


int main()
{
    MyClass obj1(1), obj2(2);

    cout << Max('a', '1') << endl;

    cout << Max(0, 1) << endl;

    cout << Max("Hello", "World") << endl;

    cout << Max(obj1, obj2).get_num() << endl;

    return 0;
}