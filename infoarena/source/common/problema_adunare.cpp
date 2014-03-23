#ifdef TESTS
#include <problems_ia.h>
#else
#include <cstdio>
#endif

#define FILE_NAME "adunare"

namespace problema_adunare
{
int solve_problem(int a, int b)
{
    http://www.infoarena.ro/problema/adunare
    return a + b;   
}
}  // namespace problema_adunare

#ifndef TESTS
int main()
{
    FILE* f = fopen(FILE_NAME ".in", "rt"); 
    int a, b;
    fscanf(f, "%d%d", &a, &b);
    fclose(f);
    f = fopen(FILE_NAME ".out", "wt");
    fprintf(f, "%d\n", problema_adunare::solve_problem(a, b));
    fclose(f);
    return 0;
}
#endif
