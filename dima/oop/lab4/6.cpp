#include <iostream>

using namespace std;

class Array {
    int* arr;
    int n;
public:
    Array() {
        arr = NULL; n = 0;
    };
    
    ~Array() {
        delete[] arr;
    };
    
    int size() {
        return n;
    };
    
    void str() {
        if (!n) {
            cout << "Empty" << endl;
            return;
        }
        for (int i = 0; i < n; i++) cout << arr[i] << " ";
    };

    int & operator [] (int i) {
        if ((i >= 0) && (i < n)) return arr[i];
        throw 0;
    }

    void operator >>(int val) {
        n++;
        int *tmp = new int[n];
        for (int i = 0; i < n - 1; i++)
            tmp[i] = arr[i];
        delete[] arr;
        tmp[n - 1] = val;
        arr = tmp;
    }

    void operator <<(int index) {
        if (index<0 || index>n) {
            cout << "Index out of range" << endl;
            return;
        }
        while (index < n - 1) {
            arr[index] = arr[index + 1];
            index++;
        }
        n--;
    }
};

int main6() {
    Array mas;
    mas.str();
    mas >> 1;
    mas >> 2;
    mas >> 3;
    mas >> 4;
    mas >> 5;
    try {
        cout << mas[30] <<endl;
    } catch(int) {
        cout << "out of range" << endl;
    }
    mas.str();
    cout << endl << mas[0] << endl;
    mas << 0;
    mas.str();
    cout << endl;
    mas << 1;
    mas.str();
    cout << endl;
    return 0;
}