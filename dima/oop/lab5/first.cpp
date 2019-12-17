#include "first.h"


#include <iostream>
#include <stdlib.h>
#include <string.h>
using namespace std;

class list {

    class nodelist {
    public:
        int key;
        char* data;
        nodelist* prev = nullptr;
        nodelist* next = nullptr;
    };

    nodelist* first;

    nodelist* findNode(int key)
    {
        nodelist* ptr = first;
        while (ptr != nullptr)
        {
            if (ptr->key == key)
            {
                return ptr;
            }
            ptr = ptr->next;
        }
        return nullptr;
    }

    void del()
    {
        nodelist* ptr = first;
        first = nullptr;
        nodelist* help;
        while (ptr != nullptr)
        {
            help = ptr;
            ptr = ptr->next;
            delete help;
        }
    }

public:
    list() : first(nullptr) {}
    ~list()
    {
        del();
    }

    bool isEmpty()
    {
        return first == nullptr;
    }

    void push(int key, const char* data)
    {
        if (first == nullptr)
        {
            first = new nodelist;
            first->key = key;
            first->data = new char[strlen(data) + 1];
            strcpy(first->data, data);
        }
        else
        {
            nodelist* help = new nodelist;
            help->key = key;
            help->data = new char[strlen(data) + 1];
            strcpy(help->data, data);

            nodelist* ptr = first;
            while (ptr->next != nullptr)
            {
                ptr = ptr->next;
            }

            ptr->next = help;
            help->prev = ptr;
        }
    }

    void pop(int key)
    {
        nodelist* ptr = findNode(key);

        if (ptr == nullptr) cout << "This key isn't in list " << endl;

        else
        {
            if (ptr->next == nullptr && ptr->prev != nullptr)
            {
                ptr->prev->next = nullptr;

                delete ptr;
            }
            else if (ptr->next != nullptr && ptr->prev != nullptr)
            {
                ptr->prev->next = ptr->next;
                ptr->next->prev = ptr->prev;

                delete ptr;
            }
            else
            {
                if (first->next == nullptr)
                {
                    first = nullptr;
                    delete ptr;
                }
                else
                {
                    first = ptr->next;
                    ptr->next->prev = nullptr;
                    delete ptr;
                }
            }
        }
    }

    const char* findData(int key)
    {
        nodelist* ptr = findNode(key);

        if (ptr != nullptr) return ptr->data;

        else return "This element isn't in list";
    }

    void show()
    {
        if (first == nullptr)
        {
            cout << "list is empty" << endl;
        }
        else
        {
            nodelist* ptr = first;
            while (ptr != nullptr)
            {
                cout << ptr->key << " " << ptr->data << endl;
                ptr = ptr->next;
            }
        }
    }

};

class menu {

    list obj;

public:

    void show()
    {
        int i = 0;
        int q;
        char s;
        int key;
        string data;
        string help;
        do {
            cout << "1. push element." << endl;
            cout << "2. pop element." << endl;
            cout << "3. find element." << endl;
            cout << "4. show list. " << endl;
            cout << "0. exit. " << endl;

            cin >> q;

            switch (q)
            {
                case 1:
                    cout << "Enter a key: ";
                    cin >> key;
                    cout << "Enter a data: ";
                    cin >> data;
                    obj.push(key, data.c_str());
                    break;
                case 2:
                    cout << "Enter a key: ";
                    cin >> key;
                    obj.pop(key);
                    break;

                case 3:
                    cout << "Enter a key: ";
                    cin >> key;
                    help = obj.findData(key);
                    cout << help << endl;
                    break;

                case 4:
                    cout << "List: " << endl;
                    obj.show();
                    break;

                case 0:
                    i = 3;
                    break;

            }
        } while (i != 3);
    }
};

int main1()
{
    menu a;
    a.show();
    return 0;
}