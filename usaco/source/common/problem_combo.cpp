#include <stdio.h>

#define FILENAME "combo"

struct ModuloNumber
{
    ModuloNumber() : v(0) {}
    ModuloNumber(int v) : v(v) {}
    static int modulo;
    int v;
    ModuloNumber& operator-(const ModuloNumber& rhs, const ModuloNumber& lhs);
    ModuloNumber& operator+(const ModuloNumber& rhs, const ModuloNumber& lhs);
};

int ModuloNumber::modulo = 10;

ModuloNumber operator-(const ModuloNumber& rhs, const ModuloNumber& lhs)
{
    return ModuloNumber(((rhs.v + ModuloNumber::modulo - lhs.v) % ModuloNumber::modulo));
}

ModuloNumber operator+(const ModuloNumber& rhs, const ModuloNumber& lhs)
{
    return ModuloNumber(((rhs.v + lhs.v) % ModuloNumber::modulo));
}

int main()
{
    int n;
    FILE *fin = fopen(FILENAME ".in", "r");
    FILE *fout = fopen(FILENAME ".out", "w");
    fscanf(fin, "%d", &ModuloNumber::modulo);
    ModuloNumber fjc[3];
    ModuloNumber mc[3];
    return 0;
}