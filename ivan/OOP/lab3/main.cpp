#include <iostream>

using namespace std;

class Class1 {
    static int count;
public:
    Class1() {
        cout << "Constructor creation" << endl;
        count++;
    }

    Class1(Class1 &) {
        cout << "Constructor copy" << endl;
        count++;
    }

    static int get_count() {
        return count;
    }

    ~Class1() {
        cout << "Destructor" << endl;
        --count;
    }
};

/*int main() {
    Class1 c1, c2;
    Class1 *c3 = new Class1;
    cout << "Amount objects: " << Class1::get_count() << "\n" << endl;
    c1.~Class1();
    cout << "Amount objects: " << Class1::get_count() << "\n" << endl;
    c2.~Class1();
    cout << "Amount objects: " << Class1::get_count() << "\n" << endl;
    delete c3;
    cout << "Amount objects: " << Class1::get_count() << "\n" << endl;
    return 0;
}*/

class Class2 {
    Class2() {
        cout << "Constructor creation" << endl;
        count2++;
    }

    Class2(Class2 &) {
        cout << "Constructor copy" << endl;
    }

    ~Class2() {
        cout << "Destructor " << endl;
        count2--;
    }

public:
    static int count2;

    static Class2 *Ini() {
        cout << "External creation" << endl;
        Class2 *obj = new Class2;
        return obj;
    }

    static void Destr(Class2 *obj) {
        cout << "External destructor " << endl;
        delete obj;
    }

};

/*int main() {
    Class2 *n1 = Class2::Ini();
    Class2 *n2 = Class2::Ini();
    cout << "Amount: " << Class2::count2 << endl;
    Class2::Destr(n1);
    cout << "Amount: " << Class2::count2 << endl;
    Class2::Destr(n2);
    cout << "Amount: " << Class2::count2 << endl;
    return 0;
}*/

class Class3 {
    static Class3*obj;

    Class3() {
        cout << "Constructor creation" << endl;
        count++;
    }

    Class3(Class3 &) {
        cout << "Constructor copy" << endl;
    }

    ~Class3() {
        cout << "Destructor " << endl;
        count--;
    }

public:
    friend Class3* NewObj();

    friend void DestroyObj(Class3*);

    static int count;
};

Class3* NewObj() {
    Class3 *obj = new Class3;
    return obj;
}

void DestroyObj(Class3 *obj) {
    delete obj;
}

int Class3::count;

/*int main() {
    Class3 *c1 = NewObj();
    Class3 *c2 = NewObj();
    cout << "Amount " << Class3::count << endl;
    DestroyObj(c1);
    cout << "Amount: " << Class3::count << endl;
    DestroyObj(c2);
    cout << "Amount: " << Class3::count << endl;
}*/

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

/*int main() {
    Singleton &n = Singleton::init();
    cout << &n << endl;
    Singleton &n1 = Singleton::init();
    cout << &n1 << endl;
    Singleton &n2 = Singleton::init();
    cout << &n2 << endl;

    return 0;
}*/


class singleton2
{
    static singleton2* ptr;

    singleton2()
    {
        cout << "const" << endl;
    }

    singleton2(int x)
    {
        cout << "const" << endl;
        s = x;
    }

    singleton2(singleton2& obj)
    {
        cout << "const" << endl;
    }

    singleton2 operator= (singleton2);

    ~singleton2() {}

public:
    static singleton2* getInstance(int n)
    {
        // Если не существует, то создается новый обьект instance
        // Иначе возвращается указатель на старый обьект instance
        if (ptr == nullptr)
        {
            ptr = new singleton2(n);
        }
        return ptr;
    }

    void del()
    {
        // Если сущестует, то удаление обьекта instance
        if (ptr != nullptr)
        {
            cout << "Удаление обьекта " << endl;
            delete ptr;
            ptr = nullptr;
        }
        else { cout << "Обьект  не существует" << endl; }
    }
    int s;
};

singleton2* singleton2::ptr = nullptr;


int main()
{
    singleton2* a = singleton2::getInstance(10);
    cout << a->s << endl;

    singleton2* b = singleton2::getInstance(11);
    cout << b->s << endl;
}