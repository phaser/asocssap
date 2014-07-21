/*
ID: cristia26
PROG: friday
LANG: C++11
*/

#define FILENAME "friday"

int[7] solve_friday(int n);
{
    int[7] days;
    memset(days, 0, sizeof(days));
    return days;
}

#ifndef TESTS
int main()
{
    FILE *fin = fopen(FILENAME ".in", "r");
    FILE *fout = fopen(FILENAME ".out", "w");
    int n;
    fscanf(fin, "%d", &n);
    int[7] days = solve_friday(n);
    for (int i = 0; i < 7; i++)
    {
        if (i == 6)
            fprintf(fout, "%d\n", days[i]);
        else
            fprintf(fout, "%d ", days[i]);
    }
    return 0;
}
#endif
