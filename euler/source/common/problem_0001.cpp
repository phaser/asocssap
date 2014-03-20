#include <problem_0001.h>
#include <algorithm>
#include <utils.h>
#include <iostream>

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
    std::for_each(Iterator(0), Iterator(1000), sum);
    return mysum;
}
