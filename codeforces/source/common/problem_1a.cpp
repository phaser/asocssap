#include <cstdio>
#include <stdint.h>

uint64_t solve_1a(uint32_t n, uint32_t m, uint32_t a)
{
    uint64_t nl = n / a;
    if (n % a != 0) nl++;
    uint64_t ml = m / a;
    if (m % a != 0) ml++;
    return nl * ml;
}

#ifndef TESTS
int main()
{
    uint32_t n, m, a;
    scanf("%u%u%u", &n, &m, &a);
    printf("%llu", solve_1a(n, m, a));
    return 0;
}
#endif