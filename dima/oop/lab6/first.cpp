#include <iostream>
#include <vector>
#include <string>

using namespace std;

class List {
protected:class nodelist {
    public:
        int key;
        int data;
        nodelist *prev = nullptr;
        nodelist *next = nullptr;
    };

    void del() {

        nodelist *tmp = first;

        while (first) {
            tmp = first;
            first = first->next;
            delete[] tmp;
        }
    }

    nodelist *first;
public:

    ~List() {
        del();
    }

    bool isEmpty() {

        return first == nullptr;
    }

    int count() {

        int count = 1;

        if (isEmpty()) count = -1;

        nodelist *tmp = first;

        while (tmp != nullptr) {
            count++;
            tmp = tmp->next;
        }
        return count;
    }

    int findData(int key) {

        if (isEmpty()) {

            return NULL;
        }
        nodelist *tmp = findNode(key);

        if (tmp != nullptr)return tmp->data;

        return NULL;
    }

    void pop(int key) {

        if (isEmpty()) {

            cout << "List is empty" << endl;

            return;
        }

        nodelist *tmp = findNode(key);

        if (tmp == nullptr) {
            cout << "Element out of list  " << endl;
            return;
        }
        if (tmp->next == nullptr && tmp->prev != nullptr) {
            nodelist *help = tmp->prev;
            help->next = nullptr;
            delete tmp;
            cout << "Deleted" << endl;
        } else if (tmp == first) {
            if (tmp->next == nullptr) {
                first = nullptr;
                delete tmp;
                cout << " Deleted " << endl;
            } else {
                nodelist *help = tmp->next;
                help->prev = nullptr;
                first = help;
                delete tmp;
                cout << "Deleted " << endl;
                while (help) {
                    help->key--;
                    help = help->next;
                }
            }
        } else {
            nodelist *help_1 = tmp->prev;
            nodelist *help_2 = tmp->next;
            help_1->next = help_2;
            help_2->prev = help_1;

            delete tmp;
            cout << "Deleted " << endl;

            while (help_2) {
                help_2->key--;
                help_2 = help_2->next;
            }
        }
    }

    void push(int data) {

        if (isEmpty()) {
            nodelist *tmp = new nodelist();
            tmp->key = 1;
            tmp->data = data;
            tmp->next = nullptr;
            tmp->prev = nullptr;
            first = tmp;

        } else {
            nodelist *help = first;

            while (help->next) help = help->next;

            nodelist *tmp = new nodelist();

            tmp->key = count();
            tmp->data = data;
            tmp->next = nullptr;
            tmp->prev = help;
            help->next = tmp;

        }
    }

    void show() {

        if (isEmpty()) {
            cout << "List is empty" << endl;
            return;
        }

        nodelist *tmp = first;
        while (tmp != nullptr) {
            cout << tmp->data << endl;
            tmp = tmp->next;
        }
    }

private:
    void addBefore(int key, int data) {

        nodelist *ptr = findNode(key);

        if (!ptr) cout << "Key not found " << endl;

        else if (!ptr->prev) {
            nodelist *tmp = new nodelist;
            tmp->data = data;
            tmp->key = ptr->key;

            while (ptr) {
                ptr->key = ptr->key + 1;
                ptr = ptr->next;
            }
            tmp->next = first;
            first = tmp;
        } else {
            nodelist *f = first;
            while (f->next != ptr) f = f->next;
            nodelist *tmp = new nodelist;
            tmp->data = data;
            tmp->key = ptr->key;

            tmp->next = ptr;
            tmp->prev = f;
            f->next = tmp;
            while (ptr) {
                ptr->key = ptr->key + 1;
                ptr = ptr->next;
            }
        }
    }

    nodelist *findNode(int key) {
        nodelist *tmp = first;
        while (tmp->key != key && tmp->next != nullptr) {
            tmp = tmp->next;
        }
        if (tmp->next == nullptr && tmp->key != key) return nullptr;
        return tmp;
    }
};

class Queue1 {
    List objList;

public:
    bool isEmpty() {
        return objList.isEmpty();
    }

    void show() {
        objList.show();
    }

    void push(int data) {
        objList.push(data);
    }

    int pop() {
        int n = objList.findData(1);
        objList.pop(1);
        return n;
    }
}

class Queue2 : private List {
    nodelist *first;
public:
    using List::isEmpty;
    using List::push;
    using List::show;

    int pop() {
        int n;
        nodelist *tmp = first;
        n = tmp->data;
        first = tmp->next;
        first->prev = nullptr;
        delete tmp;
        return n;
    }
};

class Menu {
public:
    vector <string> menu_item;

    Menu() {
        menu_item.push_back("Show");
        menu_item.push_back("Add elem");
        menu_item.push_back("Del elem");
        menu_item.push_back("Exit");
    }

    void ProcessMenu() {
        while (true) {
            for (int i = 0; i < menu_item.size(); i++) {
                cout << i + 1 << ". " << menu_item.at(i).c_str() << endl;
            }

            int number;
            cin >> number;
            if (number == menu_item.size()) return;
            if (number > menu_item.size() || number <= 0) continue;
            ProcessMenuItem(number);
        }
    }

    int AddMenuItem(std::string name) {
        menu_item.back() = name;
        menu_item.push_back("Exit");
        return menu_item.size() - 1;
    }

    virtual void ProcessMenuItem(int number) = 0;
};

class ListMenu : private Menu {
    List objList;
public:
    using Menu::ProcessMenu;

    void ProcessMenuItem(int number) {

        switch (number) {

            case 1:
                objList.show();
                break;
            case 2:
                int data;
                cout << "Enter data: " << endl;
                cin >> data;
                objList.push(data);
                break;
            case 3:
                int num;
                cout << "Enter number element: " << endl;
                cin >> num;
                objList.pop(num);
                break;
        }
    }
};

class QueueMenu : public Menu {
    Queue1 objQueue;
public:
    void ProcessMenuItem(int number) {

        switch (number) {
            case 1:
                objQueue.show();
                break;
            case 2:
                int data;
                cout << "Enter data: " << endl;
                cin >> data;
                objQueue.push(data);
                break;

            case 3:
                cout << objQueue.pop() << endl;
                break;


            case 0:
                return;
        }
    }

};

int main3() {

    ListMenu M;
    M.ProcessMenu();

    //QueueMenu m;
    //m.ProcessMenu();

    return 0;
}