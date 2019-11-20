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
            cout << "象耱�" << endl;
            return;
        }
        for (int i = 0; i < n; i++) cout << arr[i] << "  ";
    };

    int & operator [] (int i) {
        if ((i >= 0) && (i < n)) return arr[i];
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
            cout << "软溴犟 恹� 玎 镳邃咫� 爨耨桠�" << endl;
            return;
        }
        while (index < n - 1) {
            arr[index] = arr[index + 1];
            index++;
        }
        n--;
    }
};

int main() {
    Array mas;
    mas.str();
    mas >> 1;
    mas >> 2;
    mas >> 3;
    mas >> 4;
    mas >> 5;
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