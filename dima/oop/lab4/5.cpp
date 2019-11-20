#include <iostream>

using namespace std;

class Complex {
    float Real_p;
    float Imaginary_p;
public:
    Complex(float x = 0, float y = 0)
    {
        Real_p = x; Imaginary_p = y;
    }

    Complex operator+(Complex right) {
        return Complex(Real_p + right.Real_p, Imaginary_p + right.Imaginary_p);
    }

    Complex operator-(Complex right) {
        return Complex(Real_p - right.Real_p, Imaginary_p - right.Imaginary_p);
    }



    friend ostream& operator<<(ostream&, Complex&);
    friend istream& operator>>(istream&, Complex&);
    friend Complex operator+(float, Complex);
    friend Complex operator-(float, Complex);
    //friend Complex& operator+(Complex&, float&);
    //friend Complex& operator-(Complex&, float&);

};



ostream& operator<<(ostream &out, Complex &c) {
    if (c.Imaginary_p < 0) return out << c.Real_p << c.Imaginary_p << "i" << endl;
    if (c.Imaginary_p == 0) return out << c.Real_p << endl;
    else return out << c.Real_p << "+"<< c.Imaginary_p << "i" << endl;
}

istream& operator>>(istream &in, Complex &c) {
    cout << "Enter a real part: ";
    in >> c.Real_p;
    cout << "Enter a imaginary part: ";
    in >> c.Imaginary_p;
    return in;
}


Complex operator+(float l, Complex r)
{
    return Complex(l + r.Real_p, r.Imaginary_p);
}

Complex operator-(float l, Complex r)
{
    return Complex(l - r.Real_p, -r.Imaginary_p);
}



int main5() {
    Complex X(5, 5);
    Complex Y(2, 8);
    Complex W;
    Complex D = X - Y;
    cout << D << endl;
    W = X - 9;
    cout << W << endl;
    Complex Z;
    cin >> Z;
    cout << Z << endl;
    return 0;
}