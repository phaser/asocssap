#include <fsort.h>
#include <vector>
#include <iostream>
#include <stdint.h>

uint16_t masks[] = {0x8000, 0x4000, 0x2000, 0x1000, 0x800, 0x400, 0x200, 0x100, 0x80, 0x40, 0x20, 0x10, 0x8, 0x4, 0x2, 0x1};

/*
 In-place Radix sort aka binary quick sort
 */
void sort_rec(uint16_t *v, uint16_t b, uint16_t e, int msk)
{
    if (msk > 15) return;
    if (b >= e) return;
    uint16_t lo = b;
    uint16_t hi = e;
    while (lo < hi)
    {
        if (((v[lo] & masks[msk]) != 0) && ((v[hi] & masks[msk]) == 0)) {
            uint16_t aux = v[lo];
            v[lo] = v[hi];
            v[hi] = aux;
        }
        if ((v[lo] & masks[msk]) == 0) lo++;
        if ((v[hi] & masks[msk]) != 0) hi--;
    }
    if (lo >= hi)
    {
        if ((v[lo] & masks[msk]) != 0) lo--;
        if ((v[hi] & masks[msk]) == 0) hi++;
        if (b < lo) sort_rec(v, b, lo, msk + 1);
        if (hi < e) sort_rec(v, hi, e, msk + 1);
    } else {
        if (b < e) sort_rec(v, b, e, msk + 1);
    }
}

