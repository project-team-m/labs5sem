#include <iostream>
#include <fstream>
#include <stdlib.h>
#include <math.h>
#include <string>

using namespace std;

class Shape
{
protected:

    int x, y;
    int colour;

public:
    virtual void show() = 0;
    virtual void show_file(const char* file_name) = 0;
    virtual void file_recording(const char* file_name) = 0;
};

class Line :public Shape
{

protected:

    int lenght;

public:

    Line(int xl = 25, int yl = 50, int ll = 30, int coll = 1) {
        x = xl;
        y = yl;
        lenght = ll;
        colour = coll;
    }
    virtual void show() {
        cout << "LINE: ( (" << x << ',' << y << ')' << ',' << lenght << ',' << colour << ')' << endl;
    }



    virtual void file_recording(const char* file_name) {
        ofstream f(file_name);
        if (!f.is_open()) {
            cout << "File is not open" << endl;
            return;
        }
        f << "LINE: ( (" << x << ',' << y << ')' << ',' << lenght << ',' << colour << ')' << endl;
        f.close();
    }

    virtual void show_file(const char* file_name) {
        string s;
        ifstream file(file_name);

        while (getline(file, s)) {
            cout << "Show FILE:    " << s << endl;
        }
        cout << endl;
        file.close();
    }

};

class Quadrangle :public Shape
{

protected:

    int width, height;

public:

    Quadrangle(int xx = 50, int yy = 100, int wr = 50, int hr = 25, int colr = 0) {
        x = xx;
        y = yy;
        width = wr;
        height = hr;
        colour = colr;
    }
    virtual void show() {
        cout << "Quadrangle: ( (" << x << ',' << y << ')' << ',' << width << ',' << height << ',' << colour << ')' << endl;
    }

    virtual void file_recording(const char* file_name) {
        ofstream f(file_name);
        if (!f.is_open()) {
            cout << "File is not open" << endl;
            return;
        }
        f << "Quadrangle: ( (" << x << ',' << y << ')' << ',' << width << ',' << height << ',' << colour << ')' << endl;
        f.close();
    }
    virtual void show_file(const char* file_name) {
        string s;
        ifstream file(file_name);

        while (getline(file, s)) {
            cout << "Show FILE:    " << s << endl;
        }
        cout << endl;
        file.close();
    }

};

class Oval :public Shape
{

protected:

    int rad, vrad;

public:

    Oval(int xo = 20, int yo = 20, int r = 60, int vr = 30, int colo = 3)
    {
        x = xo;
        y = yo;
        rad = r;
        vrad = vr;
        colour = colo;
    }
    virtual void show()
    {
        cout << "OVAL: ( (" << x << ',' << y << ')' << ',' << rad << ',' << vrad << ',' << colour << ')' << endl;
    }

    virtual void file_recording(const char* file_name) {
        ofstream f(file_name);
        if (!f.is_open()) {
            cout << "File is not open" << endl;
            return;
        }
        f << "OVAL: ( (" << x << ',' << y << ')' << ',' << rad << ',' << vrad << ',' << colour << ')' << endl;
        f.close();
    }
    virtual void show_file(const char* file_name) {
        string s;
        ifstream file(file_name);

        while (getline(file, s)) {
            cout << "Show FILE:    " << s << endl;
        }
        cout << endl;
        file.close();
    }
};


class Picture :public Shape
{
public:
    Shape* pictures[3] = { new Quadrangle(120,120,40,30,2),new Line(10, 30, 4,1),new Oval(10,40, 70,0) };

    Picture()
    {

    }

    virtual void show()
    {
        for (int i = 0; i < 3; i++) {
            pictures[i]->show();
        }
    }

    virtual void file_recording(const char* file_name) {
        for (int i = 0; i < 3; i++) {
            pictures[i]->file_recording("picture.txt");
        }
    }

    virtual void show_file(const char* file_name) {
        for (int i = 0; i < 3; i++) {
            pictures[i]->show_file("picture.txt");
        }
    }
};

int main() {
    Line L;
    L.show();
    L.file_recording("line.txt");
    L.show_file("line.txt");

    Quadrangle R;
    R.show();
    R.file_recording("rectangle.txt");
    R.show_file("rectangle.txt");


    Oval O;
    O.show();
    O.file_recording("oval.txt");
    O.show_file("oval.txt");
    Picture P;
    P.show();
    return 0;
}

