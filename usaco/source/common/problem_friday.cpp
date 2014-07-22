/*
ID: cristia26
PROG: friday
LANG: C++11
*/
#include <string.h>
#include <cstdio>
#define FILENAME "friday"

int months[12] = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
int* solve_friday(int n)
{
    int* days = new int[7];
    memset(days, 0, sizeof(int) * 7);
    int day = 0;
    for (int i = 0; i < n; i++)
    {
        int year = 1900 + i;
        day = day % 7;
        if ((year % 4 == 0 && year % 100 != 0) || (year % 100 == 0 && year % 400 == 0))
        {
            months[1] = 29;
        }
        else
        {
            months[1] = 28;
        }
        
        for (int j = 0; j < 12; j++)
        {
            days[(day + 12) % 7]++;
            day = day + months[j];
        }
    }

    return days;
}

#ifndef TESTS
int main()
{
    FILE *fin = fopen(FILENAME ".in", "r");
    FILE *fout = fopen(FILENAME ".out", "w");
    int n;
    fscanf(fin, "%d", &n);
    int* days = solve_friday(n);
    for (int i = 0; i < 7; i++)
    {
        if (i == 6)
            fprintf(fout, "%d\n", days[(i + 5) % 7]);
        else
            fprintf(fout, "%d ", days[(i + 5) % 7]);
    }
    delete [] days;
    return 0;
}
#endif
