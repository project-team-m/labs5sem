#include <iostream>
#include <vector>
#include <string>

using namespace std;

class A {
    int a = 10;
public:
    void Inc() { a++; }
    void tree() {
        cout << "Íåñòàòè÷åñêèé ìåòîä êëàññà\n";
    }
    void operator()() {
        cout << "Îïåðàòîð () êëàññà\n";
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
        while (1) {
            for (int i = 0; i < menu.size(); ++i)
                cout << i + 1 << ": " << menu[i].name << endl;
            cout << "0: Âûõîä" << endl;
            cout << "Âûáåðèòå ïóíêò ìåíþ: ";
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
        cout << "Âûçâàíà ôóíêöèÿ êëàññà A\n";
        A m;
        m.Inc();
    }
};

void one() {
    cout << "Âûçâàíà ôóíêöèÿ 1\n";
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
        while (1) {
            for (int i = 0; i < menu.size(); ++i)
                cout << i + 1 << ": " << menu[i].name << endl;
            cout << "0: Âûõîä" << endl;
            cout << "Âûáåðèòå ïóíêò ìåíþ: ";
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

int main5() {

    Menu <void> m;
    m.PushItem("Ôóíêöèÿ 1", one);
    m.PushItem("Ôóíêöèÿ êëàññà A", Menu<int>::Two);
    m.ShowMenu();

    //Menu2 <A> m2;
    //ñâÿçûûâàåì À ñ ìåòîäàìè tree (),íå èìåþùèõ ÿâíûõ àðãóìåíòîâ
    //÷òîáû âûçâàòü íåñòàòè÷ ìåòîä êëàññà íóæåí îáúåêò ýòîãî êëàññà
    //m2.PushItem("Íåñòàòè÷åñêèé ìåòîä", &A::tree);
    //m2.PushItem("Îïåðàòîð ()", &A::operator());
    //m2.ShowMenu();

    return 0;
};