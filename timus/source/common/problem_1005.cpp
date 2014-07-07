#include <algorithm>
#include <vector>
#include <cmath>
#include <cstdio>

struct comparator
{
    bool operator() (int i, int j)
    {
        return (i > j);
    }
} mycompare;

int solve_1005(std::vector<int>& input)
{
    int diff = 0;
    std::sort(input.begin(), input.end(), mycompare);
    
    int queue[2] = {0, 0};
    queue[0] = input[0];
    queue[1] = 0;
    int p = 1;
    int cq = 1;
    size_t sz = input.size();
    diff = std::abs(static_cast<double>(queue[0] - queue[1]));
    while (p < sz)
    {
        int newdiff = std::abs(static_cast<double>(queue[cq] + input[p] - queue[(cq + 1) % 2]));
        if (newdiff < diff)
        {
            queue[cq] += input[p];
        } else
        {
            int newq[2];
            newq[0] = queue[0];
            newq[1] = queue[1];
            newq[0] += input[p];
            newq[1] += input[p];
            newq[0] = std::abs(static_cast<double>(newq[0] - queue[1]));
            newq[1] = std::abs(static_cast<double>(newq[1] - queue[0]));
            if (newq[0] <= newq[1])
            {
                queue[0] += input[p];
                cq = 1;
            } else
            {
                queue[1] += input[p];
                cq = 0;
            }
        }

        diff = std::abs(static_cast<double>(queue[0] - queue[1]));
        p++;
    }
    return diff;
}

#ifndef TESTS
int main()
{
    int n, a;
    scanf("%d", &n);
    std::vector<int> input;
    input.reserve(n);
    for (int i = 0; i < n; i++)
    {
        scanf("%d", &a);
        input.push_back(a);
    }
    printf("%d", solve_1005(input));
    return 0;
}
#endif
