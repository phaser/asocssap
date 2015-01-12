#include "fsort.h"
#include <vector>
#include <iostream>
#include <stdint.h>

uint16_t masks[] = {0x8000, 0x4000, 0x2000, 0x1000, 0x800, 0x400, 0x200, 0x100, 0x80, 0x40, 0x20, 0x10, 0x8, 0x4, 0x2, 0x1};
void printBinary(uint16_t n)
{
    for (int i = 15; i >= 0; i--)
    {
        if (((1 << i) & n) != 0)
            std::cout << "1";
        else
            std::cout << "0";
    }
    std::cout << " :" << n;
    std::cout << std::endl;
}

void sort(std::vector<uint16_t>& v, uint16_t b, uint16_t e, int msk)
{
    printf("sort: b: %d e: %d msk: %d\n", b, e, msk);
    if (msk > 15) return;
    if (b >= e) return;
    uint16_t lo = b;
    uint16_t hi = e;
    bool changed = false;
    while (lo < hi)
    {
        int exchange = 0;
        while (lo < hi) {
            if ((v[lo] & masks[msk]) != 0) {
                exchange++;
                break;
            }
            lo++;
        }
        while (lo < hi)
        {
            if ((v[hi] & masks[msk]) == 0) {
                exchange++;
                break;
            }
            hi--;
        }
        if (exchange == 2)
        {
            printBinary(masks[msk]);
            printBinary(v[lo]);
            printBinary(v[hi]);
            printf("lo: %d hi: %d\n", lo, hi);
            uint16_t aux = v[lo];
            v[lo] = v[hi];
            v[hi] = aux;
            changed = true;
        }
    }
    while ((v[lo] & masks[msk]) != 0) lo--;
    if (changed)
    {
        sort(v, b, lo, msk+1);
        if (lo+1 < e)
            sort(v, lo+1, e, msk+1);
    } else {
        sort(v, b, e, msk + 1);
    }
}

#ifdef TESTS
int main ()
{
    #define NOINTS 11
    #if 0
    uint16_t *myints = new uint16_t[NOINTS];
    for (int i = 0; i < NOINTS; i++)
    {
        myints[i] = rand();
        std::cout << myints[i] << " ";
    }
    std::cout << std::endl;
    #endif
    uint16_t myints[] = {16807, 15089, 44249, 3114, 46978, 56008, 36568, 2558, 12099, 1101, 39064};
    std::vector<uint16_t> vector(myints, myints + NOINTS);
    std::vector<uint16_t> vector1(myints, myints + NOINTS);
    for (auto e : vector1)
    {
        std::cout << e << " ";
    }
    std::cout << std::endl;
    std::sort(vector1.begin(), vector1.end());
    for (auto e : vector1)
    {
        std::cout << e << " ";
    }
    std::cout << std::endl;
    sort (vector, 0, 10, 0);
    for (auto e : vector)
    {
        std::cout << e << " ";
    }
    std::cout << std::endl;
    return 0;
}
#endif