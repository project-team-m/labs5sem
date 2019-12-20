#include <cstdlib>
#include <iomanip>
#include <stdlib.h>
#include <iostream>
#include <string>

using namespace std;

template <typename T>
class Matric {
    int n;
    int m;
    T** A;

public:
    Matric(int _m, int _n) {
        this->n = _n;
        this->m = _m;

        A = (T**) new T * [m];

        for (int i = 0; i < m; i++)
            A[i] = (T*)new T[n];

        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++) {
                if (is_integral<T>::value == true) A[i][j] = 0 + rand() % 50;
                if (is_floating_point<T>::value == true) A[i][j] = (20.00 * rand()) / RAND_MAX;
            }
    }

    Matric operator+ (Matric& right) {
        if (m != right.m or n != right.n) {
            cout << "Ñëîæèòü âîçìîæíî òîëüêî ìàòðèöû îäèíàêîâîãî ðàçìåðà!\n";
        }
        else {
            Matric B(m, n);
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    B.A[i][j] = this->A[i][j] + right.A[i][j];
            return (B);
        }
    }

    Matric operator- (Matric& right) {
        if (m != right.m or n != right.n) {
            cout << "Ðàçíîñòü ìàòðèö âîçìîæíî íàéòè òîëüêî ïðè èõ îäèíàêîâîì ðàçìåðå!\n";
        }
        else {
            Matric B(m, n);
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    B.A[i][j] = this->A[i][j] - right.A[i][j];
            return (B);
        }
    }

    friend ostream& operator<<(ostream& out, Matric C) {
        for (int i = 0; i < C.m; i++)
        {
            for (int j = 0; j < C.n; j++)
                cout << setw(5) << setprecision(2) << C.A[i][j];
            cout << endl;
        }
        return out << endl;
    };
};


int main4() {

    cout << "Ïåðâàÿ ìàòðèöà: " << endl;
    Matric <int> M(3, 3);
    cout << M << endl;

    cout << "Âòîðàÿ ìàòðèöà: " << endl;
    Matric <int> M2(3, 3);
    cout << M2 << endl;

    cout << "Ñóììà ìàòðèö: " << endl;
    Matric <int> M3 = M + M2;
    cout << M3 << endl;

    cout << "Ðàçíèöà ìàòðèö: " << endl;
    Matric <int> M6 = M - M2;
    cout << M6 << endl;

    cout << "Ìàòðèöà Float: " << endl;
    Matric <float> M4(4, 4);
    cout << M4 << endl;

    return 0;
}