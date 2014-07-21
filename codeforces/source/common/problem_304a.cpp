#include <cstdio>
#include <string.h>
#include <math.h>

#ifndef TESTS
int main()
{
    int n;
    scanf("%d", &n);
    int num = 0;
    for (int a = 1; a <= n; a++)
    for (int b = a+1; b <= n; b++)
    {
        int c2 = a*a + b*b;
        int c = (int)sqrt(c2);
        if (c*c == c2 && c <= n)
        {
            num++;
        }
    }
    
    printf ("%d", num);
    return 0;
}
#endif