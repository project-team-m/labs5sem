#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <stdlib.h>
#include <time.h>
#include <complex>
#include <vector>

using namespace std;

template <typename T>
class Matrix {
private:
    T** mat;
public:
    int x;
    int y;
    Matrix(int x, int y, T z) {
        this->y = y;
        this->x = x;
        mat = new T * [x];
        for (int i = 0; i < x; i++) {
            mat[i] = new T[y];
            for (int j = 0; j < y; j++)
                mat[i][j] = z;
        }
    }
    Matrix operator+(Matrix s) {
        if (s.x == this->x && s.y == this->y) {
            Matrix<T> res(x, y, 0);
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    res.mat[i][j] = this->mat[i][j] + s.mat[i][j];
            return res;
        }
        cout << "湾耦怙噤屙桢 疣珈屦钼" << endl;
    }
    Matrix operator-(Matrix s) {
        if (s.x == this->x && s.y == this->y) {
            Matrix<T> res(x, y, 0);
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    res.mat[i][j] = this->mat[i][j] - s.mat[i][j];
            return res;
        }
        cout << "湾耦怙噤屙桢 疣珈屦钼" << endl;
    }
    friend ostream& operator<<(ostream& out, const Matrix<T>& s) {
        for (int i = 0; i < s.x; i++) {
            for (int j = 0; j < s.y; j++)
                out << s.mat[i][j] << ' ';
            out << endl;
        }
        return out;
    }
};


void main()
{
    setlocale(LC_ALL, "Russian");
    Matrix<float> a1(2, 2, 1.333);
    Matrix<float> a2(2, 2, 4.111);
    cout << a1 << endl;
    cout << a2 << endl;
    a1 = a1 + a2;
    cout << a1 << endl;
    system("pause");
}