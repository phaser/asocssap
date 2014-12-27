#include <algorithm>
#include <vector>
#include <cmath>
#include <cstdio>
#include <stdint.h>

class MyBitSet
{
public:
    MyBitSet() : n_(0)
    {
    }

    MyBitSet& operator++()
    {
        n_ += 1;
        return *this;
    }

    uint64_t operator[] (size_t idx)
    {
        return n_ & (1 << idx);
    }
private:
    uint64_t n_;
};

uint64_t computeMinDist(std::vector<int>& input, MyBitSet& bs)
{
    int64_t mindst = 0;
    size_t sz = input.size();
    for (size_t i = 0; i < sz; i++)
    {
        mindst += (bs[i] == 0 ? input[i] : -input[i]);
    }
    return (mindst < 0 ? -mindst : mindst);
}

int solve_1005(std::vector<int>& input)
{
    uint64_t mindist = 0xFFFFFFFFFFFFFFFF;
    MyBitSet bs;
    uint64_t sz = 1 << input.size();
    for (int i = 0; i < sz; i++)
    {
        uint64_t localdst = computeMinDist(input, bs);
        if (localdst < mindist)
        {
            mindist = localdst;
        }
        ++bs;
    }
    return mindist;
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
