/*
 ID: cristia26
 PROG: crypt1
 LANG: C++11
 */
#include <cstdio>
#include <string.h>
#include <set>
#define FILENAME "crypt1"
#define MAX_NUM_WIDTH 5

bool isValid(std::set<int>& vs, int num)
{
    while (num > 0)
    {
        int digit = num % 10;
        if (vs.find(digit) == vs.end())
        {
            return false;
        }
        num /= 10;
    }
    return true;
}

int solve_cript1(std::set<int>& num)
{
    int solutions = 0;
    for (int i = 100; i < 999; i++)
    for (int j = 10; j < 99; j++)
    {
        int n1 = i * (j % 10);
        int n2 = i * (j / 10);
        int n = n1 + n2 * 10;
        if (n < 10000
         && n1 < 1000
         && n2 < 1000
         && isValid(num, i)
         && isValid(num, j)
         && isValid(num, n1)
         && isValid(num, n2)
         && isValid(num, n))
        {
            solutions++;
        }
    }
    return solutions;
}

#ifndef TESTS
int main()
{
    FILE *fin = fopen(FILENAME ".in", "r");
    FILE *fout = fopen(FILENAME ".out", "w");
    int n, aux;
    std::set<int> vs;
    fscanf(fin, "%d", &n);
    for (int i = 0; i < n; i++)
    {
        fscanf(fin, "%d", &aux);
        vs.insert(aux);
    }
    fprintf(fout, "%d\n", solve_cript1(vs));
    fclose(fin);
    fclose(fout);
    return 0;
}
#endif