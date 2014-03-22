#include <problems.h>
#include <utils.h>

namespace problem_0002
{
uint64_t solve_problem()
{
    uint64_t f1 = 1;
    uint64_t f2 = 2;
    uint64_t sum = 0;
    while (f2 < 4000000)
    {
        if (f2 % 2 == 0) sum += f2;
        uint64_t tmp = f2;
        f2 += f1;
        f1 = tmp;
    }
    return sum;
}
}  // namespace problem_0002
