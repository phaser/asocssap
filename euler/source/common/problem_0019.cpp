#include <problems.h>
#include <utils.h>
#include <algorithm>

namespace problem_0019
{
const uint32_t NORM_YEAR = 365;
const uint32_t LEAP_YEAR = 366;
const uint32_t months[2][12] = {
      { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31}
    , { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31}};
const uint32_t SUNDAY = 6;

bool isLeapYear(uint32_t year)
{
    if (year % 100 == 0 && year % 400 == 0)
    {
        return true;
    }
    if (year % 100 != 0 && year % 4 == 0)
    {
        return true;
    }
    return false;
}

uint64_t solve_problem()
{
    uint32_t hms = 0;
    uint32_t fd = 0;
    struct solve
    {
        uint32_t& ihms;
        uint32_t& fd;
        solve(uint32_t& ihms, uint32_t& fd) : ihms(ihms), fd(fd) {}
        void operator() (uint32_t year)
        {
            uint32_t sel = (isLeapYear(year) ? 1 : 0);    
            for (auto i = 0; i < 12; ++i)
            {
                fd = (months[sel][i] % 7 + fd) % 7;
                if (fd == SUNDAY)
                {
                    ++ihms;
                }
            }
        }
    } find_sundays(hms, fd);
    range<1901, 2001> r;
    for_each(r.begin(), r.end(), find_sundays);
    return hms;
}
}  // namespace problem_0019
