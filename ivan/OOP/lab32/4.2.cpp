/*#include <iostream>

using namespace std;

class Singleton2
{
    static Singleton2* ptr;

    Singleton2()
    {
        cout << "const" << endl;
    }

    Singleton2(int x)
    {
        cout << "const" << endl;
        s = x;
    }

    Singleton2(Singleton2& obj)
    {
        cout << "const" << endl;
    }

    Singleton2 operator= (Singleton2);

    ~Singleton2() {
        cout << "Destructor" << endl;
    }

public:
    static Singleton2* getInstance(int n)
    {
        // Если не существует, то создается новый обьект instance
        // Иначе возвращается указатель на старый обьект instance
        if (ptr == nullptr)
        {
            ptr = new Singleton2(n);
        }
        return ptr;
    }

    void del()
    {
        // Если сущестует, то удаление обьекта instance
        if (ptr != nullptr)
        {
            cout << "Delete obj " << endl;
            delete ptr;
            ptr = nullptr;
        }
        else { cout << "Object does not exist" << endl; }
    }
    int s;
};

Singleton2* Singleton2::ptr = nullptr;


int main42()
{
    Singleton2* a = Singleton2::getInstance(10);
    cout << a->s << endl;
    a->del();
    Singleton2* b = Singleton2::getInstance(11);
    cout << b->s << endl;
    Singleton2 * d = Singleton2::getInstance(13);
    cout << d->s << endl;
}*/