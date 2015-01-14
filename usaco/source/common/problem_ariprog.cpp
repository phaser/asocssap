/*
ID: cristia26
PROG: ariprog
LANG: C++11
*/
#include <cstdio>
#include <vector>
#include <algorithm>
#include <assert.h>
#include <set>

#define FILENAME "ariprog"

#ifndef TESTS
int main()
{
    FILE *fin = fopen(FILENAME ".in", "r");
    FILE *fout = fopen(FILENAME ".out", "w");
    int n, m;
    fscanf(fin, "%d%d", &n, &m);
    std::set<int> bi_squares;
    for (int p = 0; p <= m; p++)
    for (int q = 0; q <= m; q++)
    {
        bi_squares.insert(p*p + q*q);
    }
    int mm = m*m;
    bool hassol = false;
    for (int r = 1; r <= mm; r++)
    {
        for (auto i : bi_squares)
        {
            int count = 1;
            int cn = i;
            bool found = true;
            while (count < n)
            {
                if (bi_squares.find(cn + r) == bi_squares.end())
                {
                    found = false;
                    break;
                }
                count++;
                cn = cn + r;
            }
            if (found)
            {
                fprintf(fout, "%d %d\n", i, r);
                hassol = true;
            }
        }
    }
    if (!hassol)
    {
        fprintf(fout, "NONE\n");
    }
    fclose(fin);
    fclose(fout);
    return 0;
}
#endif