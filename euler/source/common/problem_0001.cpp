#include <problems.h>
#include <algorithm>
#include <utils.h>

namespace problem_0001
{
struct do_sum
{
    uint64_t& sum;
    do_sum(uint64_t& sum) : sum(sum) {}
    void operator() (uint64_t y)
    {
        if (y % 3 == 0 || y % 5 == 0) sum += y;
    }
};

uint64_t solve_problem()
{
    https://projecteuler.net/problem=1
    uint64_t mysum = 0;
    struct do_sum sum(mysum);
    range<0, 1000> r;
    std::for_each(r.begin(), r.end(), sum);
    return mysum;
}
}  // namespace problem_0001
