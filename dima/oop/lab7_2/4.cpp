#include <iostream>
#include <iomanip>

using namespace std;

template <typename T>

class Matrix
{
    int n;
    int m;
    T** A;

public:
    Matrix(int _m, int _n)
    {
        this->n = _n;
        this->m = _m;
        A = (T**) new T * [m];

        for (int i = 0; i < m; i++)	A[i] = (T*)new T[n];

        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
            {
                if (is_integral<T>::value == true) A[i][j] = 0 + rand() % 50;
                if (is_floating_point<T>::value == true) A[i][j] = (20.00 * rand()) / RAND_MAX;
            }
    }

    Matrix operator+ (Matrix& right)
    {
        if (m != right.m or n != right.n) cout << "Only matrices of the same size can be folded" << endl;
        else
        {
            Matrix B(m, n);
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    B.A[i][j] = this->A[i][j] + right.A[i][j];
            return (B);
        }
    }

    Matrix operator- (Matrix& right)
    {
        if (m != right.m or n != right.n) cout << "Only matrices of the same size can be subtracted" << endl;
        else
        {
            Matrix B(m, n);
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    B.A[i][j] = this->A[i][j] - right.A[i][j];
            return (B);
        }
    }

    friend ostream& operator<<(ostream& out, Matrix C)
    {
        for (int i = 0; i < C.m; i++)
        {
            for (int j = 0; j < C.n; j++) cout << setw(5) << setprecision(2) << C.A[i][j];
            cout << endl;
        }
        return out << endl;
    };
};


int main3() {

    cout << "First matrix: " << endl;
    Matrix <int> M(3, 3);
    cout << M << endl;

    cout << "Second matrix: " << endl;
    Matrix <int> M2(3, 3);
    cout << M2 << endl;

    cout << "Add matrix: " << endl;
    Matrix <int> M3 = M + M2;
    cout << M3 << endl;

    cout << "Subtracted matrix: " << endl;
    Matrix <int> M6 = M - M2;
    cout << M6 << endl;

    cout << "Matrix Float: " << endl;
    Matrix <float> M4(4, 4);
    cout << M4 << endl;

    return 0;
}