#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <vector>
#include <string>

using namespace std;

void Function() {
    cout << "function" << endl;
}
class Test {
public:
    Test() { }
    void Not_Static_method() {
        cout << "Не static" << endl;
    }
    static void Static_method() {
        cout << "static" << endl;
    }
    void operator()() {
        cout << "operator()" << endl;
    }
};

template< typename T >
class Menu {
private:
    vector<string> array_of_string;
    vector <T> array_of_fun;
public:
    Menu() { };
    int AddMenuItem(string new_str, T new_fun) {
        array_of_string.push_back(new_str);
        array_of_fun.push_back(new_fun);
        return array_of_string.size();
    }
    void ProcessMenu() {
        int a;
        if (array_of_string.size() == 0) return;
        while (1) {
            system("cls");
            for (int i = 0; i < array_of_string.size(); ++i)
                cout << i + 1 << " - " << array_of_string[i] << endl;
            cout << array_of_string.size() + 1 << " - Выход" << endl;
            cin >> a;
            if (a == array_of_string.size() + 1) return;
            if (a >= 1 && a <= array_of_string.size()) { array_of_fun[a - 1](); system("pause"); }
        }
    }
};

template< typename T>
class Menu2 {
private:
    vector<string> array_of_string;
    vector <void(T::*)()> array_of_fun;
    Test *obj = new Test();
public:
    Menu2(T* o) :obj(o) { };
    int AddMenuItem(string new_str, void(T::* new_fun)()) {
        array_of_string.push_back(new_str);
        array_of_fun.push_back(new_fun);
        return array_of_string.size();
    }

    void ProcessMenu() {
        int a;
        if (array_of_string.size() == 0) return;
        while (1) {
            system("cls");
            for (int i = 0; i < array_of_string.size(); ++i)
                cout << i + 1 << " - " << array_of_string[i] << endl;
            cout << array_of_string.size() + 1 << " - Выход" << endl;
            cin >> a;
            if (a == array_of_string.size() + 1) return;
            if (a >= 1 && a <= array_of_string.size()) {
                (obj->*array_of_fun[a - 1])();
                system("pause");
            }
        }
    }
};

int main() {
    setlocale(LC_ALL, "Russian");
    Test* test = new Test();
    Test test1;
    Test* test2 = &test1;
    void(Test:: *mfPtr)();
    mfPtr = &Test::Not_Static_method;
    Menu<void(*)()>* t1 = new Menu<void(*)()>();
    Menu2<Test>* t2 = new Menu2<Test>(test);
    t1->AddMenuItem("Вызвать Function", Function);
    t1->AddMenuItem("Вызвать Static", Test::Static_method);
    //(--------------------------------------------------------)
    t2->AddMenuItem("Вызвать Not Static", &Test::Not_Static_method);
    t2->AddMenuItem("Вызвать Object operator", &Test::operator());
    //t1->ProcessMenu();
    t2->ProcessMenu();
    system("pause");
    return 0;
}