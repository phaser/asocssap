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
    std::vector<int> q1;
    std::vector<int> q2;
    q1.reserve(input.size());
    q2.reserve(input.size());
    size_t sz = input.size();
    int sum1 = 0;
    int sum2 = 0;
    for (size_t i = 0; i < sz; i += 2)
    {
        q1.push_back(input[i]);
        sum1 += input[i];
        if (i + 1 < sz)
        {
            q2.push_back(input[i+1]);
            sum2 += input[i+1];
        }
    }
    diff = static_cast<int>(std::abs(static_cast<float>(sum1 - sum2)));
    sz = q1.size();
    for (size_t i = 0; i < sz; i++)
    {
        int ns1 = sum1 - q1[i];
        int ns2 = sum2 + q1[i];
        int nd = static_cast<int>(std::abs(static_cast<float>(ns1 - ns2)));
        if (nd < diff)
        {
            q2.push_back(q1[i]);
            sum1 = ns1;
            sum2 = ns2;
            diff = nd;
        }
    }

    sz = q2.size();
    for (size_t i = 0; i < sz; i++)
    {
        int ns1 = sum1 + q2[i];
        int ns2 = sum2 - q2[i];
        int nd = static_cast<int>(std::abs(static_cast<float>(ns1 - ns2)));
        if (nd < diff)
        {
            q1.push_back(q2[i]);
            sum1 = ns1;
            sum2 = ns2;
            diff = nd;
        }
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
