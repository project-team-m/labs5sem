#include "third.h"

#include <iostream>
#include <stdlib.h>
#include <string.h>
using namespace std;

class stack {

    class nodeStack {

    public:
        char* data;
        nodeStack* next = nullptr;
    };

    nodeStack* head;

    void del()
    {
        nodeStack* ptr = head;
        nodeStack* help;
        head = nullptr;
        while (ptr != nullptr)
        {
            help = ptr;
            ptr = ptr->next;
            delete help;
        }
    }

public:

    stack() :head(nullptr) {}
    ~stack()
    {
        del();
    }

    void push(const char* data)
    {
        if (head == nullptr)
        {
            head = new nodeStack;
            head->data = new char[strlen(data) + 1];
            strcpy(head->data, data);
        }
        else
        {
            nodeStack* ptr = new nodeStack;
            ptr->data = new char[strlen(data) + 1];
            strcpy(ptr->data, data);
            ptr->next = head;
            head = ptr;
        }
    }

    char* pop()
    {
        if (head == nullptr)
        {
            return nullptr;
        }
        else
        {
            nodeStack* ptr = head;
            head = head->next;
            char* help = ptr->data;

            delete ptr;
            return help;
        }
    }

    char* top()
    {
        if (head == nullptr)
        {
            return nullptr;
        }
        else
        {
            return head->data;
        }
    }

    bool isEmpty()
    {
        return (head == nullptr);
    }

    void show()
    {
        if (head == nullptr)
        {
            cout << "Stack is empty." << endl;
        }
        else
        {
            nodeStack* ptr = head;
            while (ptr != nullptr)
            {
                cout << ptr->data << endl;
                ptr = ptr->next;
            }
        }
    }

};

class menu2 {

    stack obj;

public:

    void show()
    {
        int i = 0;
        int	q;
        int key;
        char* help;
        string data;
        do {
            cout << "1. push element." << endl;
            cout << "2. pop element." << endl;
            cout << "3. show head stack." << endl;
            cout << "4. show stack. " << endl;
            cout << "0. exit. " << endl;

            cin >> q;
            switch (q)
            {
                case 1:
                    cout << "Enter data: " << endl;
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
                        cout << "Stack is empty." << endl;
                    }
                    break;

                case 3:
                    if (obj.top() != nullptr)
                    {
                        cout << obj.top() << endl;
                    }
                    else
                    {
                        cout << "Stack is empty." << endl;
                    }
                    break;

                case 4:
                    cout << "Stack:" << endl;
                    obj.show();
                    break;

                case 0:
                    i = 3;
                    break;
            }


        } while (i != 3);
    }
};

int main3()
{
    menu2 a;
    a.show();
    return 0;
}