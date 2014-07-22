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

int solve_beads_naive(int sz, const char* str)
{
    std::vector<int> bscore;
    int cc = 1;
    int max = 0;
    for (int i = 1; i < sz; i++)
    {
        if (str[i] != str[i-1])
        {
            bscore.push_back(cc);
            if (max < cc) max = cc;
            cc = 1;
        } else
        {
            cc++;
        }
    }
    if (str[0] == str[sz-1])
    {
        int pnm = bscore[0] + *(bscore.end() - 1);
        if (max < pnm) max = pnm;
    }
    return max;
}

int solve_beads(int sz, const char* str)
{
    std::string str1 = str;
    std::string str2 = str;
    printf("s1: %s\n", str1.c_str());
    printf("s2: %s\n", str2.c_str());
    replace(str1.begin(), str1.end(), 'w', 'b');
    replace(str2.begin(), str2.end(), 'w', 'r');
    int m1 = solve_beads_naive(sz, str1.c_str());
    int m2 = solve_beads_naive(sz, str2.c_str());
    return (m1 > m2 ? m1 : m2);
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
