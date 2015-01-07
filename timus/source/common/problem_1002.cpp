#include <stdio.h>
#include <stdint.h>

int ltrs[] = {2, 2, 2, 3, 3, 3, 4, 4, 1, 1, 5, 5, 6, 6, 0, 7, 0, 7, 7, 8, 8, 8, 9, 9, 9, 0};
          /*  a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z */

#ifndef TESTS
int main()
{
    char *n = new char[101];
    scanf("%s", n);
    return 0;
}
#endif