#include <cstdio>
#include <vector>
#include <set>

int computeScore(std::set<int>& ke, std::vector<int>& elems)
{
    int result = 0;
    for (auto it = elems.begin(); it != elems.end(); it++)
    {
        if (ke.find(*it) != ke.end()) result++;
    }
    return result;
}

int solve_1875(std::vector<int>& p)
{
    std::set<int> afp;
    std::vector<std::vector<int>> lists;
    std::vector<int> list;
    int m = 2;
    for (int i = 0; i < 5; i++)
    {
        for (int j = i+1; j < 5; j++)
        {
            double a = (double)(p[2 * j + 1] * p[2 * i] - p[2 * j] * p[2 * i + 1]) / (double)(p[2 * j] * p[2 * i] * (p[2 * j] - p[2 * i]));
            double b = (double)(p[2 * i + 1] - a * p[2 * i] * p[2 * i]) / (double)p[2 * i];
            list.clear();
            list.push_back(i);
            list.push_back(j);
            for (int k = 0; k < 5; k++)
            {
                if (k != i && k != j)
                {
                    if (a * p[2 * k] * p[2 * k] + b * p[2 * k] - p[2 * k + 1] < 0.000001)
                    {
                        list.push_back(k);
                    }
                }
            }
            lists.push_back(list);
        }
    }
    int nocurves = 0;
    while (afp.size() < 5)
    {
        size_t sz = lists.size();
        int max = 0;
        int sc_max = computeScore(afp, lists[max]);
        int sc_aux;
        for (size_t i = 1; i < sz; i++)
        {
            if ((sc_aux = computeScore(afp, lists[i])) > sc_max)
            {
                max = i;
                sc_max = sc_aux;
            }
            if (sc_aux == 5)
            {
                return 1;
            }
        }
        nocurves++;
        for (auto it = lists[max].begin(); it != lists[max].end(); it++)
        {
            afp.insert(*it);
        }
        if (afp.size() == 4)
        {
            return nocurves + 1;
        }
    }
    return nocurves;
}

#ifndef TESTS
int main()
{
    int a, b;
    std::vector<int> elems;
    for (int i = 0; i < 5; i++)
    {
        scanf("%d %d", &a, &b);
        elems.push_back(a);
        elems.push_back(b);
    }
    printf("%d\n", solve_1875(elems));
    return 0;
}
#endif