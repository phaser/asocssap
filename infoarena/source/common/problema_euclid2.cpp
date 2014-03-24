#ifdef TESTS
#include <problems_ia.h>
#else
#include <cstdio>
#endif
#include <cstdint>

#define FILE_NAME "euclid2"

namespace problema_euclid2
{
int32_t gcd(int32_t a, int32_t b)
{
    http://www.infoarena.ro/problema/euclid2
    int32_t c;
    if (b > a)
    {
        c = a;
        a = b;
        b = c;
    }

    while (b > 0)
    {
       c = a % b;
       a = b;
       b = c;
    }
    return a;
}
}  // namespace problema_euclid2

#ifndef TESTS
int main()
{
    FILE* f = fopen(FILE_NAME ".in", "rt"); 
    FILE* fout = fopen(FILE_NAME ".out", "wt");
    int32_t T, a, b;
    fscanf(f, "%d", &T);
    for (auto i = 0; i < T; i++)
    {
        fscanf(f, "%d%d", &a, &b);
        printf ("%d %d\n", a, b);
        int32_t gcd = problema_euclid2::gcd(a, b);
        fprintf(fout, "%d\n", gcd);
    }
    fclose(f);
    fclose(fout);
    return 0;
}
#endif
