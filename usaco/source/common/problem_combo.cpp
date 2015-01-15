#include <stdio.h>

#define FILENAME "combo"

int main()
{
    int n;
    FILE *fin = fopen(FILENAME ".in", "r");
    FILE *fout = fopen(FILENAME ".out", "w");
    int base;
    fscanf(fin, "%d", &base);
    int fjc[3];
    int mc[3];
    fscanf(fin, "%d%d%d%d%d%d", &fjc[0], &fjc[1], &fjc[2], &mc[0], &mc[1], &mc[2]);
    int fjc_min[3];
    int mc_min[3];
    fjc_min[0] = fjc[0] - 2; fjc_min[1] = fjc[1] - 2; fjc_min[2] = fjc[2] - 2;
    mc_min[0] = mc[0] - 2; mc_min[1] = mc[1] - 2; mc_min[2] = mc[2] - 2;
    fjc[0] = fjc[0] + 2; fjc[1] = fjc[1] + 2; fjc[2] = fjc[2] + 2;
    mc[0] = mc[0] + 2; mc[1] = mc[1] + 2; mc[2] = mc[2] + 2;
/*
    for (int i = 0; i < 3; i++)
    {
        int c = 0;
        if (mc_min[i] >= fjc_min[i] && mc_min[i] <= fjc[i])
        {
            c += 1;
        }
        if (mc[i] >= fjc_min[i] && mc[i] <= fjc[i])
        {
            c += 2;
        }
        switch (c)
        {
            case 1: mc_min[i] = fjc[i] + 1; break;
            case 2: mc[i] = fjc_min[i] - 1; break;
            case 3: {
                mc_min[i] = fjc_min[i];
                mc[i] = fjc[i];
                break;
            }
        }
    }
    */
    int fjc_f[3];
    int mc_f[3];
    for (int i = 0; i < 3; i++)
    {
        fjc_f[i] = fjc[i] - fjc_min[i];
        mc_f[i] = mc[i] - mc_min[i];
    }
    int ans = fjc_f[0] * fjc_f[1] * fjc_f[2] + mc_f[0] * mc_f[1] * mc_f[2];
    printf("sol: %d\n", ans);
    return 0;
}