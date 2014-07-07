#include <algorithm>
#include <vector>

int solve_1005(std::vector<int>& input)
{
    int diff = 0;
    int sum = 0;
    size_t sz = input.size();
    std::sort(input.begin(), input.end());
    for (int i = 1; i < sz; i++)
    {
        sum += input[i] - input[i-1];
    }
    diff = sum / sz;
    return diff;
}

#ifndef TESTS
int main()
{
    return 0;
}
#endif
