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

    nodeTree* f_p(nodeTree* p, int key, nodeTree* pred = nullptr) {
        if (p == nullptr) {
            return nullptr;
        } else {
            if (key == p->key) {
                return pred;
            } else {
                if (key > p->key) {
                    f_p(p->right, key, p);
                } else {
                    f_p(p->left, key, p);
                }
            }

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

    void del(nodeTree *p, int key) {
        if (root == nullptr) {
            cout << "Tree is empty" << endl;
        } else {
            nodeTree *n = search(p, key);
            nodeTree *pred = f_p(p, key);
            if (n->left == nullptr && n->right == nullptr) {
                if (pred->right == n) {
                    pred->right = nullptr;
                    delete n;
                } else {
                    pred->left = nullptr;
                    delete n;
                }
            } else {
                if (n->left == nullptr) {
                    if (pred->right == n) {
                        pred->right = n->right;
                        delete n;
                    } else {
                        pred->left = n->right;
                        delete n;
                    }
                } else  if (n->right == nullptr){
                    if (pred->right == n) {
                        pred->right = n->left;
                        delete n;
                    } else {
                        pred->left = n->left;
                        delete n;
                    }
                } else {
                    if (pred->right == n) {
                        pred->right = n->right;
                        nodeTree* el = n;
                        while (el->left) {
                            el = el->left;
                        }
                        el = n->left;
                        delete n;
                    } else {
                        pred->left = n->right;
                        nodeTree* el = n->right;
                        while (el->left) {
                            el = el->left;
                        }
                        el->left = n->left;
                        delete n;
                    }
                }
            }
        }
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
            cout << "1. Add element." << endl;
            cout << "2. Delete element." << endl;
            cout << "3. Find element. " << endl;
            cout << "4. Show tree. " << endl;
            cout << "0. Exit. " << endl;
            cin >> q;

            switch (q)
            {
                case 1:
                    cout << "Enter a key: ";
                    cin >> key;
                    cout << "Enter a data: ";
                    cin >> data;
                    obj.add(key, data.c_str());
                    break;

                case 2:
                    cout << "Enter a key: ";
                    cin >> key;
                    obj.del(obj.root, key);
                    break;

                case 3:
                    if (obj.root != nullptr)
                    {
                        cout << "Enter a key: " << endl;
                        cin >> key;
                        obj.find(key);
                    }
                    else
                    {
                        cout << "Tree is empty." << endl;
                    }
                    break;
                case 4:
                    cout << "Tree: " << endl;
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
