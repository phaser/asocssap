/*
ID: cristia26
PROG: ariprog
LANG: C++11
*/
#include <cstdio>
#include <vector>
#include <algorithm>
#include <assert.h>

#define FILENAME "ariprog"

//#ifndef TESTS
int main()
{
    FILE *fin = fopen(FILENAME ".in", "r");
    FILE *fout = fopen(FILENAME ".out", "w");
    int n, m;
    fscanf(fin, "%d%d", &n, &m);
    for (int p = 0; p < m; p++)
    for (int q = p + 1; q < m; q++)
    {
        for (int r = 1; r < m; r++)
        {

        }
    }
    fclose(fin);
    fclose(fout);
    return 0;
}
//#endif