/*
ID: cristia26
PROG: gift1
LANG: C++11
*/
#include <cstdio>
#include <string>
#include <stdint.h>
#include <map>
#include <vector>
#define FILENAME "gift1"

#ifndef TESTS
int main()
{
    FILE *fin = fopen(FILENAME ".in", "r");
    FILE *fout = fopen(FILENAME ".out", "w");
    std::map<std::string, int> group;
    std::vector<std::string> names;
    int n;
    char name[15];
    fscanf(fin, "%d", &n);
    for (int i = 0; i < n; i++)
    {
        fscanf(fin, "%s", &name);
        group[name] = 0;
        names.push_back(name);
    }
    
    for (int i = 0; i < n; i++)
    {
        fscanf(fin, "%s", &name);
        int amount, nof;
        fscanf(fin, "%d %d", &amount, &nof);
        if (nof == 0 || amount == 0) continue;
        int amg = amount / nof;
        for (int j = 0; j < nof; j++)
        {
            char sname[15];
            fscanf(fin, "%s", &sname);
            int sa = group[sname];
            sa += amg;
            group[sname] = sa;
            sa = group[name];
            sa -= amg;
            group[name] = sa;
        }
    }
    
    for (auto it = names.begin(); it != names.end(); it++)
    {
        fprintf(fout, "%s %d\n", it->c_str(), group[*it]);
    }
    return 0;
}
#endif
