#include "fifth.h"

#include <iostream>
#include <stdlib.h>
#include <string.h>
using namespace std;

class queue {

    class nodeQueue {

    public:

        char* data;

        nodeQueue* next = nullptr;
    };

    nodeQueue* last;

    void del()
    {
        nodeQueue* help;
        while (last != nullptr)
        {
            help = last;
            last = last->next;
            delete help;
        }
    }

public:

    queue() :last(nullptr) {}
    ~queue()
    {
        del();
    }

    void push(const char* data)
    {
        if (last == nullptr)
        {
            last = new nodeQueue;
            last->data = new char[strlen(data) + 1];
            strcpy(last->data, data);
        }
        else
        {

            nodeQueue* ptr = new nodeQueue;
            ptr->data = new char[strlen(data) + 1];
            strcpy(ptr->data, data);

            nodeQueue* help = last;

            ptr->next = help;
            last = ptr;

            last = ptr;
        }
    }

    char* pop()
    {
        if (last == nullptr)
        {
            return nullptr;
        }
        else if (last->next == nullptr)
        {
            char* help = last->data;
            nodeQueue* ptr = last;
            last = nullptr;
            delete ptr;
            return help;
        }
        else
        {
            char* help1;
            nodeQueue* ptr = last;
            while (ptr->next->next != nullptr)
            {
                ptr = ptr->next;
            }
            nodeQueue* help = ptr;
            help->next = nullptr;
            help1 = ptr->data;
            ptr = ptr->next;
            delete ptr;
            return help1;
        }
    }

    char* peek()
    {
        if (last == nullptr)
        {
            return nullptr;
        }
        else
        {
            char* help;
            nodeQueue* ptr = last;
            while (ptr->next != nullptr)
            {
                ptr = ptr->next;
            }
            help = ptr->data;
            return help;
        }
    }

    bool isEmpty()
    {
        if (last == nullptr)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void show()
    {
        if (last == nullptr)
        {
            cout << "Queue is empty." << endl;
        }
        else
        {
            nodeQueue* ptr = last;
            while (ptr != nullptr)
            {
                cout << ptr->data << endl;
                ptr = ptr->next;
            }
        }
    }

};

class menu3 {

    queue obj;

public:

    void show()
    {
        int i = 0;
        int q;
        int key;
        char* help;
        string data;
        do {
            cout << "1. push element." << endl;
            cout << "2. pop element." << endl;
            cout << "3. show head." << endl;
            cout << "4. show queue." << endl;
            cout << "0. exit." << endl;

            cin >> q;

            switch (q)
            {
                case 1:
                    cout << "Enter a data: ";
                    cin >> data;
                    obj.push(data.c_str());
                    break;

                case 2:
                    help = obj.pop();
                    if (help != nullptr)
                    {
                        cout << help << endl;
                    }
                    else
                    {
                        cout << "Queue is empty." << endl;
                    }
                    break;

                case 3:
                    help = obj.peek();
                    if (help != nullptr)
                    {
                        cout << help << endl;
                    }
                    else
                    {
                        cout << "Queue is empty." << endl;
                    }
                    break;

                case 4:
                    cout << "Show queue: " << endl;
                    obj.show();
                    break;

                case 0:
                    i = 3;
                    break;
            }
        } while (i != 3);
    }
};

int main5()
{
    menu3 a;
    a.show();
    return 0;
}