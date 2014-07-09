#include <cstdio>
#include <vector>
#include <string.h>

#ifndef TESTS
int main()
{
    int nc, nv, vt;
    scanf("%d %d", &nc, &nv);
    int votes[10000];
    memset(votes, 0, sizeof(10000));
    for (int i = 0; i < nv; i++)
    {
        scanf("%d", &vt);
        votes[vt]++;
    }
    for (int i = 0; i < nc; i++)
    {
        if (votes[i+1] > 0)
        {
            printf("%.2lf%%\n", (double)(votes[i+1] * 100.f) / (double)(nv * 1.0f));
        }
    }
    return 0;
}
#endif
