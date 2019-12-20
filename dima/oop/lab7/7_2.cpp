#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <vector>
#include <string>

using namespace std;
class  MyClass
{
public:
    int num;
    MyClass(int _num){
        num = _num;
    }
    MyClass() {
        num = 0;
    }
    bool operator >(MyClass _obj) {
        if (this->num > _obj.num)
            return true;
        return false;
    }
};

const char* Max(const char* s1, const char* s2) {
    cout << "蔓玮囗 耧弼. 趔黻鲨" << endl;
    if (strcmp(s1, s2) >= 0) return s1;
    return s2;
}

template<typename T>
T Max(T x, T y) {
    cout << "蔓玮囗 钺睇� 犭铐" << endl;
    return x > y ? x : y;
}


void main()
{
    setlocale(LC_ALL, "Russian");
    MyClass obj1(1), obj2(2), obj3;
    char x = Max('a','1');
    int y = Max(0, 1);
    const char* z = Max("Hello", "World");
    obj3 = Max(obj1, obj2);
    system("pause");
}