#include "seventh.h"

#include <iostream>
#include <stdlib.h>
#include <string.h>
using namespace std;

class tree {

    class nodeTree {
    public:
        int key;
        char* data;
        nodeTree* left = nullptr;
        nodeTree * right = nullptr;
    };

public:

    nodeTree* root;

    tree() :root(nullptr) {}


    void add(int key, const char* data)
    {
        if (root == nullptr)
        {
            root = new nodeTree;
            root->key = key;
            root->data = new char[strlen(data) + 1];
            strcpy(root->data, data);
        }
        else
        {
            nodeTree* ptr = new nodeTree;
            ptr->key = key;
            ptr->data = new char[strlen(data) + 1];
            strcpy(ptr->data, data);

            nodeTree* help = root;

            while (help != nullptr)
            {
                if (key == help->key) break;
                else if (key > help->key)
                {
                    if (help->right == nullptr)
                    {
                        help->right = ptr;
                        break;
                    }
                    else
                    {
                        help = help->right;
                    }
                }
                else if (key < help->key)
                {
                    if (help->left == nullptr)
                    {
                        help->left = ptr;
                        break;
                    }
                    else
                    {
                        help = help->left;
                    }
                }
            }

        }
    }

    void find(int key)
    {
        if (root != nullptr)
        {

            nodeTree* ptr = root;
            while (ptr != nullptr)
            {
                if (key == ptr->key)
                {
                    cout << "Key found: " << endl;
                    cout << ptr->key << " : " << ptr->data << endl;
                    break;
                }
                else if (key > ptr->key)
                {
                    ptr = ptr->right;
                }
                else if (key < ptr->key)
                {
                    ptr = ptr->left;
                }
            }
            if (ptr == nullptr) cout << "Key not found." << endl;
        }
        else cout << "Tree is empty." << endl;

    }

    nodeTree* find_ld(nodeTree* p) {
        if (p == nullptr) {
            return nullptr;
        }
        if (p->left != nullptr) {
            return find_ld(p->left);
        }
        return p;
    }

    nodeTree* parent(nodeTree* p, nodeTree* del_p, int key) {
        if (p == nullptr) {
            return nullptr;
        }
        if (p->left == del_p || p->right == del_p || p == del_p) {
            return p;
        }

        if (key < p->key) {
            return parent(p->left, del_p, key);
        }
        else {
            return parent(p->right, del_p, key);
        }
    }
    nodeTree* search(nodeTree* p, int key) {
        if (p == nullptr) {
            return nullptr;
        }

        if (key == p->key) {
            return p;
        }
        else if (key < p->key) {
            return search(p->left, key);
        }
        else {
            return search(p->right, key);
        }
    }

    nodeTree* find_pred(int key, nodeTree* ptr, nodeTree* pred) {
        if (key == ptr->key) {
            nodeTree* a[2] = {pred, ptr};
            return *a;
        } else {
            if (key < ptr->key) {
                return find_pred(key, ptr->left, ptr);
            } else {
                return find_pred(key, ptr->right, ptr);
            }
        }
    }

    nodeTree* del(int key) {
        if (root == nullptr) {
            cout << "Tree is empty" << endl;
            return nullptr;
        } else {
            if (root->key == key) {
                nodeTree* save = root;
                delete root;
                return save;
            } else {
                nodeTree* pred = &find_pred(key, root, root)[0];
                nodeTree* ptr = &find_pred(key, root, root)[1];
                cout << pred->data << endl;
                cout << ptr->data << endl;
            }
        }
    }

    nodeTree* dele(int key) {
        if (root->left == nullptr && root->right == nullptr) {
            delete root;
            return nullptr;
        }

        nodeTree* root_ = root;

        nodeTree* del_p = search(root, key);
        nodeTree* pd = parent(root, del_p, key);

        nodeTree* ld = find_ld(del_p->right);

        if (ld == nullptr) {
            if (pd->left == del_p) {
                pd->left = del_p->left;
            }
            else {
                pd->right = del_p->right;
            }

            delete del_p;
            return root;
        }
        nodeTree* pld = parent(root, ld, ld->key);

        if (pd == del_p) {
            pd = ld;
            root_ = nullptr;
        }
        else if (pd->left == del_p) {
            pd->left = ld;
        }
        else {
            pd->right = ld;
        }

        if (pld->left == ld) {
            pld->left = ld->right;
            ld->left = del_p->left;
            ld->right = del_p->right;
        }
        else {
            pld->right = ld->right;
            ld->left = del_p->left;
        }

        delete del_p;
        return (root_ == nullptr) ? pd : root_;
    }


    void show(nodeTree* t, int u)
    {
        if (t == nullptr) return;
        else
        {
            show(t->left, ++u);
            for (int i = 0; i < u; ++i) cout << "\t";
            cout << t->key << endl;
            u--;
            show(t->right, ++u);
        }
    }

};

class menu5 {

    tree obj;

public:

    void show()
    {
        int i = 0;
        int  q, key;
        string data;
        do {
            cout << "1. Добавить элемент." << endl;
            cout << "2. Удалить элемент." << endl;
            cout << "3. Найти элемент. " << endl;
            cout << "4. Показать дерево. " << endl;
            cout << "0. Закрыть. " << endl;
            cin >> q;

            switch (q)
            {
                case 1:
                    cout << "Введите ключ: ";
                    cin >> key;
                    cout << "Введите значение: ";
                    cin >> data;
                    obj.add(key, data.c_str());
                    break;

                case 2:
                    cout << "Введите ключ: ";
                    cin >> key;
                    obj.del(key);
                    break;

                case 3:
                    if (obj.root != nullptr)
                    {
                        cout << "Введите ключ: " << endl;
                        cin >> key;
                        system("cls");
                        obj.find(key);
                    }
                    else
                    {
                        cout << "Пустое дерево." << endl;
                    }
                    break;
                case 4:
                    cout << "Элементы дерева: " << endl;
                    obj.show(obj.root, 0);
                    break;

                case 0:
                    i = 3;
                    break;
            }
        } while (i != 3);
    }
};

int main()
{
    menu5 a;
    a.show();
    return 0;
}
