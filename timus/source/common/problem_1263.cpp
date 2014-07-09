#include <cstdio>
#include <vector>
#include <string.h>

#ifndef TESTS
int main()
{
    int nc, nv, vt;
    scanf("%d %d", &nc, &nv);
    int votes[10000];
    memset(votes, 0, sizeof(votes));
    for (int i = 0; i < nv; i++)
    {
        scanf("%d", &vt);
        vt -= 1;
        votes[vt] += 1;
    }
    for (int i = 0; i < nc; i++)
    {
        printf("%.2lf%c\n", (double)(votes[i] * 100.f) / (double)(nv), '%');
    }
    return 0;
}
#endif
