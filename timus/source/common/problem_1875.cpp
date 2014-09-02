#include <cstdio>
#include <vector>
#include <set>
#include <stdint.h>
#include <math.h>
#include <algorithm>
#include <string.h>

struct Point
{
    int64_t x, y;
};

struct comparator
{
    bool operator() (const struct Point& p1, const struct Point& p2)
    {
        return (p1.x < p2.x);
    }
};
double solve_1875_a(std::vector<struct Point>& p)
{
    struct comparator comp;
    std::sort(p.begin(), p.end(), comp);
    int szz = p.size();
    int result = 0;
    bool erase = false;
    int i = 0;
    while (i < szz)
    {
        int j = i + 1;
        erase = false;
        while (j < szz)
        {
            erase = false;
            int64_t k = p[i].x * p[j].x * (p[j].x - p[i].x);
            int64_t a = p[j].y * p[i].x - p[i].y * p[j].x;
            int64_t b = p[i].y * p[j].x * (p[j].x - p[i].x) - a * p[i].x;
            if (k == 0)
            {
                j++;
                continue;
            }
            if (p[i].x == p[j].x)
            {
                j++;
                continue;
            }
            if (b == 0)
            {
                j++;
                continue;
            }
            if (!((a >= 0 && k < 0) || (k >= 0 && a < 0)))
            {
                j++;
                continue;
            }
            int sz = szz;
            for (int d = 0; d < sz; d++)
            {
                if (p[d].y * k  == a * p[d].x * p[d].x + b * p[d].x)
                {
                    p.erase(p.begin() + d);
                    d--; sz--;
                    erase = true;
                }
            }
            result++;
            if (!erase) j++;
            szz = p.size();
            if (szz <= 1)
                break;
        }
        if (!erase) i++;
        if (szz <= 1)
            break;
    }
    if (szz > 0) result += szz;
    return result;
}

int getMax(const int p[25])
{
    int max = 0;
    for (size_t i = 0; i < 25; i++)
    {
        if (p[i] > p[max]) max = i;
    }
    return max;
}

int solve_1875(std::vector<struct Point>& p)
{
    int curves[25];
    int result;
    memset(curves, 0, 25 * sizeof(int));
    for (int i = 0; i < 5; i++)
    for (int j = i+1; j < 5; j++)
    {
        int64_t k = p[i].x * p[j].x * (p[j].x - p[i].x);
        int64_t a = p[j].y * p[i].x - p[i].y * p[j].x;
        int64_t b = p[i].y * p[j].x * (p[j].x - p[i].x) - a * p[i].x;
        if (k == 0)
        {
            continue;
        }
        if (p[i].x == p[j].x)
        {
            continue;
        }
        if (b == 0)
        {
            continue;
        }
        if (!((a >= 0 && k < 0) || (k >= 0 && a < 0)))
        {
            continue;
        }
        for (int d = 0; d < 5; d++)
        {
            if (p[d].y * k  == a * p[d].x * p[d].x + b * p[d].x)
            {
                curves[i * 5 + j]++;
            }
        }
    }
    int max = getMax(curves);
    if (curves[max] == 5)
        return 1;
    else if (curves[max] == 4)
        return 2;
    else if (curves[max] == 2)
        return 3;
    else if (curves[max] == 0)
        return 5;
    else if (curves[max] == 3)
    {
        return solve_1875_a(p);
    }
    return 3;
}

#ifndef TESTS
int main()
{
    int a, b;
    std::vector<struct Point> elems;
    for (int i = 0; i < 5; i++)
    {
        scanf("%d %d", &a, &b);
        struct Point p;
        p.x = a; p.y = b;
        elems.push_back(p);
    }
    printf("%d\n", solve_1875(elems));
    return 0;
}
#endif