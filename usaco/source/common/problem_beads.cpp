/*
ID: cristia26
PROG: beads
LANG: C++11
*/
#include <string.h>
#include <cstdio>
#include <vector>
#include <string>
#include <algorithm>
#define FILENAME "beads"

int solve_beads(int sz, const char* str)
{
    for (int i = 0; i < sz; i++)
    {
        
    }
    return 0;
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
    printf("%d\n%s", sz, word);
    fprintf(fout, "%d\n", solve_beads(sz, word));
    return 0;
}
#endif
