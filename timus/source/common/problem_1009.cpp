#include <math.h>
#include <stdio.h>

int solve_1009(int n, int k)
{
    int result = pow(k, n) - 1;
    result -= pow(k, n-1) - 1;
    int r = n - 3;
    if (r > 0)
    {
        result -= (k - 1) * (pow(k, r) - 1);
        r -= 2;
    }
    return result;
}

#ifndef TESTS
int main()
{
    int n, k;
    scanf("%d %d", &n, &k);
    printf("%d", solve_1009(n, k));
    return 0;
}
#endif