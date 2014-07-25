/*
ID: cristia26
PROG: beads
LANG: C++11
*/
#include <string.h>
#include <math.h>
#include <cstdio>
#include <vector>
#include <string>
#include <algorithm>
#define FILENAME "beads"

int solve_beads(int sz, const char* str)
{
    int max = 0;
    for (int i = 0; i < sz; i++)
    {
        int count = 2;
        int ps = i - 1;
        if (ps < 0) ps += sz;
        char cl = str[ps];
        char cr = str[i];
        int abs_count = 0;
        bool scr = true;
        bool scl = true;
        int posr = 2;
        int posl = 0;
        while (++abs_count < sz && (fabs(posr - posl) > 1) && (scr == true || scl == true))
        {
            if (scr)
            {
                posr = (i + abs_count) % sz;
                if (str[posr] != 'w')
                {
                    if (cr == 'w')
                    {
                        cr = str[posr];
                        count++;
                    } else
                    if (str[posr] != cr)
                    {
                        scr = false;
                    } else
                    {
                        count++;
                    }
                } else
                {
                    count++;
                }
            }
            if (scl)
            {
                posl = ps - abs_count;
                if (posl < 0) posl += sz;
                if (posl == posr)
                {
                    scl = false;
                    scr = false;
                } else
                if (str[posl] != 'w')
                {
                    if (cl == 'w')
                    {
                        cl = str[posl];
                        count++;
                    } else
                    if (str[posl] != cl)
                    {
                        scl = false;
                    } else
                    {
                        count++;
                    }
                } else
                {
                    count++;
                }
            }
        }
        if (count > max) max = count;
    }
    return max;
}

#ifndef TESTS
int main()
{
    FILE *fin = fopen(FILENAME ".in", "r");
    FILE *fout = fopen(FILENAME ".out", "w");
    int sz;
    char word[351];
    fscanf(fin, "%d", &sz);
    fscanf(fin, "%s", &word);
    fprintf(fout, "%d\n", solve_beads(sz, word));
    return 0;
}
#endif
