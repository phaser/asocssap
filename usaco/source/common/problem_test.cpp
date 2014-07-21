/*
ID: cristia26
PROG: test
LANG: C++11
*/
#include <cstdio>
#define FILENAME "test"

#ifndef TESTS
int main()
{
    FILE *fin = fopen(FILENAME ".in", "r");
    FILE *fout = fopen(FILENAME ".out", "w");
    int a, b;
    fscanf(fin, "%d %d", &a, &b);
    fprintf(fout, "%d\n", a+b);
    return 0;
}
#endif
