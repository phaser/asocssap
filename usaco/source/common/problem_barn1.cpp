/*
ID: cristia26
PROG: barn1
LANG: C++11
*/
#include <cstdio>
#include <vector>
#include <algorithm>
#include <assert.h>

#define FILENAME "barn1"
struct barn
{
    // begin, end, cost
    int b, e, c;
};

int solve_barn1(int n, std::vector<int>& c)
{
    std::sort(c.begin(), c.end());
    std::vector<struct barn> barns;
    struct barn fb;
    fb.b = 0;
    fb.e = c.size() - 1;
    fb.c = c[fb.e] - c[fb.b] + 1;
    barns.push_back(fb);
    int min = fb.c;
    while (barns.size() < n)
    {
        int max = -1;
        int bi = -1;
        int pi = -1;
        for (auto it = barns.begin(); it != barns.end(); it++)
        {
            if (it->b == it->e)
                continue;
            
            for (int i = it->b; i < it->e; i++)
            {
                if ((c[i+1] - c[i] - 1) > max)
                {
                    max = (c[i+1] - c[i] -1);
                    bi = it - barns.begin();
                    pi = i+1;
                }
            }
        }
        if (max == -1 || max == 0)
        {
            break;
        } else
        {
            fb.b = pi;
            fb.e = barns[bi].e;
            fb.c = c[fb.e] - c[fb.b] + 1;
            barns[bi].e = pi - 1;
            barns[bi].c = c[barns[bi].e] - c[barns[bi].b] + 1;
            barns.push_back(fb);
            min -= max;
        }
    }
    return min;
}

#ifndef TESTS
int main()
{
    fprintf(stderr, "Program started!\n");
    FILE *fin = fopen(FILENAME ".in", "r");
    fprintf(stderr, "Opened files...\n");
    assert(fin != 0);
    std::vector<int> input;
    int n, s, c;
    fscanf(fin, "%d %d %d", &n, &s, &c);
    fprintf(stderr, "n: %d s: %d c: %d\n", n, s, c);
    for (int i = 0; i < c; i++)
    {
        int val;
        fscanf(fin, "%d", &val);
        input.push_back(val);
        fprintf(stderr, "%d\n", val);
    }
    fclose(fin);
    FILE *fout = fopen(FILENAME ".out", "w");
    assert(fout != 0);
    fprintf(stderr, "end.\n");
    int result = solve_barn1(n, input);
    fprintf(stderr, "end.\n");
    fprintf(fout, "%d\n", result);
    fprintf(stderr, "end.\n");
    fclose(fout);
    return 0;
}
#endif
