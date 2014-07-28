/*
ID: cristia26
PROG: milk2
LANG: C++11
*/
#include <cstdio>
#include <vector>
#include <math.h>
#include <algorithm>
#define FILENAME "milk2"

struct interval
{
    int s, e;
};

int min(int a, int b)
{
    if (a < b) return a;
    return b;
}

int max (int a, int b)
{
    if (a > b) return a;
    return b;
}

struct comparator
{
    bool operator () (struct interval a, struct interval b)
    {
        return (a.s <= b.s && a.e <= b.e);
    }
} comparator;

struct comparator_begin
{
    bool operator () (struct interval a, struct interval b)
    {
        return (a.s < b.s);
    }
} comparator_begin;

void solve_milk2(std::vector<struct interval> intervals, int* maxm, int* maxi)
{
    std::sort(intervals.begin(), intervals.end(), comparator_begin);
    std::vector<struct interval> ni;
    size_t sz = intervals.size();
    for (size_t i = 0; i < sz; i++)
    {
        bool used = false;
        for (auto it = ni.begin(); it != ni.end(); it++)
        {
            if ((it->s <= intervals[i].e && it->s >= intervals[i].e)
             || (intervals[i].s <= it->e && intervals[i].s >= it->s))
            {
                it->s = min(it->s, intervals[i].s);
                it->e = max(it->e, intervals[i].e);
                used = true;
                break;
            }
        }
        if (!used)
        {
            ni.push_back(intervals[i]);
        }
    }
    intervals.clear();
    *maxm = 0;
    *maxi = -1;
    for (auto it = ni.begin(); it != ni.end(); it++)
    {
        int cm = it->e - it->s;
        if (cm > *maxm) *maxm = cm;
        if (it != ni.begin())
        {
            int ci = it->s - (it - 1)->e;
            if (*maxi == -1)
                *maxi = ci;
            else if (ci > *maxi)
                *maxi = ci;
        }
    }
    if (*maxi == -1) *maxi = 0;
}

#ifndef TESTS
int main()
{
    FILE *fin = fopen(FILENAME ".in", "r");
    FILE *fout = fopen(FILENAME ".out", "w");
    int n;
    std::vector<struct interval> intervals;
    fscanf(fin, "%d", &n);
    for (int i = 0; i < n; i++)
    {
        struct interval itvl;
        fscanf(fin, "%d %d", &itvl.s, &itvl.e);
        intervals.push_back(itvl);
    }
    int mm, mi;
    solve_milk2(intervals, &mm, &mi);
    fprintf(fout, "%d %d\n", mm, mi);
    fclose(fin);
    fclose(fout);
    return 0;
}
#endif
