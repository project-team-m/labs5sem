#include <iostream>
#include <vector>
#include <string>

using namespace std;

class A {
    int a = 10;
public:
    void Inc() { a++; }
    void tree() {
        cout << "Nonstatic method" << endl;;
    }
    void operator()() {
        cout << "Operator () " << endl;;
    }
};

template <typename T>
class Menu {
    struct item_menu {
        string name;
        T(*fun)();
    };

    vector <item_menu> menu;
public:


    void ShowMenu() {
        int a;
        while (true) {
            for (int i = 0; i < menu.size(); ++i)
                cout << i + 1 << ": " << menu[i].name << endl;
            cout << "0: Exit" << endl;
            cout << "Enter a point menu: ";
            cin >> a;
            if (!a) return;
            if (a > menu.size()) continue;
            menu[a - 1].fun();
        }
    }

    void PushItem(string name, T fun())
    {
        item_menu a = { name, fun };
        menu.push_back(a);
    }

    static void Two() {
        cout << "Function of class A" << endl;;
        A m;
        m.Inc();
    }
};

void one() {
    cout << "Function 1" << endl;;
};


template <typename T>
class Menu2 {
    struct item_menu {
        string name;
        void(T::*fun)();
    };
    A* obj = new A();
    vector <item_menu> menu;
public:
    void ShowMenu() {
        int a;
        while (true) {
            for (int i = 0; i < menu.size(); ++i)
                cout << i + 1 << ": " << menu[i].name << endl;
            cout << "0: Exit" << endl;
            cout << "Enter a point menu: ";
            cin >> a;
            if (!a) return;
            if (a > menu.size()) continue;
            (obj->*menu[a - 1].fun)();
        }
    }

    void PushItem(string name, void(T::*fun)())
    {
        item_menu a = { name, fun };
        menu.push_back(a);
    }

};

int main4() {

    Menu <void> m;
    m.PushItem("Function 1", one);
    m.PushItem("Function of class A", Menu<int>::Two);
    m.ShowMenu();

    //Menu2 <A> m2;
    //m2.PushItem("Nonstatic method", &A::tree);
    //m2.PushItem("Operator ()", &A::operator());
    //m2.ShowMenu();

    return 0;
};