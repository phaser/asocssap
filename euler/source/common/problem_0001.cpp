#include <problem_0001.h>
#include <algorithm>

uint64_t solve_problem()
{
    https://projecteuler.net/problem=1

    uint64_t sum = 0;
    for (uint64_t i = 3; i < 1000; i++)
    {
        if (i % 3 == 0 || i % 5 == 0)
        {
            sum += i;
        }
    }
    return sum;
}
