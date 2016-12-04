/*
ID: cristia26
PROG: combo
LANG: C++11
*/
#include <stdio.h>
#include <set>

#define FILENAME "combo"

int getVal(int base, int value, int offset)
{
    int result = value + offset;
    result = (result < 1 ? (base + result) % base : result);
    result = (result > base ? result % base : result);
    result = (result == 0 ? base : result);
    return result;
}

int main()
{
    FILE *fin = fopen(FILENAME ".in", "r");
    FILE *fout = fopen(FILENAME ".out", "w");
    int base;
    fscanf(fin, "%d", &base);
    int fjc[3];
    int mc[3];
    fscanf(fin, "%d%d%d%d%d%d", &fjc[0], &fjc[1], &fjc[2], &mc[0], &mc[1], &mc[2]);

    // printf("%d\n%d %d %d\n%d %d %d", base, fjc[0], fjc[1], fjc[2], mc[0], mc[1], mc[2]);

    std::set<int> dialsfjc[3];
    std::set<int> dialsmc[3];
    std::set<int> dialsol[3];
    for (int i = 0; i < 3; i++)
    {
        dialsfjc[i].insert(fjc[i]);
        dialsfjc[i].insert(getVal(base, fjc[i], -1));
        dialsfjc[i].insert(getVal(base, fjc[i], -2));
        dialsfjc[i].insert(getVal(base, fjc[i], 1));
        dialsfjc[i].insert(getVal(base, fjc[i], 2));
        dialsmc[i].insert(mc[i]);
        dialsmc[i].insert(getVal(base, mc[i], -1));
        dialsmc[i].insert(getVal(base, mc[i], -2));
        dialsmc[i].insert(getVal(base, mc[i], 1));
        dialsmc[i].insert(getVal(base, mc[i], 2));
    }

    for (int i = 0; i < 3; i++)
    {
        for (std::set<int>::iterator it = dialsfjc[i].begin(); it != dialsfjc[i].end(); it++)
        {
            if (dialsmc[i].find(*it) != dialsmc[i].end())
            {
                dialsol[i].insert(*it);
            }
            // printf("%d ", *it);
        }
        // printf("\n");
    }

    int fjcount = dialsfjc[0].size() * dialsfjc[1].size() * dialsfjc[2].size();
    int mccount = dialsmc[0].size() * dialsmc[1].size() * dialsmc[2].size();
    int olcount = dialsol[0].size() * dialsol[1].size() * dialsol[2].size();

    fprintf(fout, "%d\n", fjcount + mccount - olcount);
    return 0;
}
