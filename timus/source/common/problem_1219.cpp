#include <cstdio>
#include <stdlib.h>
#define LIM 1000000
#define SZ 1000001
char txt[SZ];

/* The idea is that the requirements conform to a pseudorandom generator with
 * uniform distribution. So the catch is to observe this and then just 
 * generate 1000000 characters randomly! :)
 */
#ifndef TESTS
int main()
{
    for (int i = 0; i < LIM; i++)
    {
        txt[i] = rand() % 26 + 97;
    }
    txt[LIM] = '\0';
    printf("%s", txt);
    return 0;
}
#endif
