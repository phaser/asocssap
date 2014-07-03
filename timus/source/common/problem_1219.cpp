#include <cstdio>
#include <stdlib.h>
#define LIM 1000000
#define SZ 1000001
char txt[SZ];
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
