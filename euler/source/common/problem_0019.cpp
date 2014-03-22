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
const uint32_t SUNDAY = 0;

bool isLeapYear(uint32_t year)
{
    return ((year % 400 == 0) || ((year % 4 == 0) && (year % 100 != 0)));
}

/* 1 Jan 1900 is Monday. + 366 days we get the 1 Jan 1901 which is not monday
   and then by adding the days in the month we get the subsequent 1 of every
   month. To verify if it is Sunday we just modulo the number by 7 and verify
   if it is 0 (SUNDAY)
 */
uint64_t solve_problem1()
{
    uint32_t hms = 0;
    struct solve
    {
        uint32_t& ihms;
        uint32_t days_passed = 366;
        solve(uint32_t& ihms) : ihms(ihms) {}
        void operator() (uint32_t year)
        {
            uint32_t sel = (isLeapYear(year) ? 1 : 0);    
            for (auto i = 0; i < 12; ++i)
            {
                days_passed += months[sel][i]; 
                if ((days_passed % 7) == SUNDAY)
                {
                    ++ihms;
                }
            }
        }
    } find_sundays(hms);
    range<1901, 2001> r;
    for_each(r.begin(), r.end(), find_sundays);
    return hms;
}
 
/* We have 2000 - 1901 + 1 years with 12 months per year, let's call it N
   this means we have N days that are 1. These are uniformly distributted
   in 7 groups (for each day of the week), so there are static_cast<int>(N / 7)
   Sundays that are also the first day of a month.
 */
uint64_t solve_problem2()
{
    return ((2000 - 1901 + 1) * 12) / 7;
}
}  // namespace problem_0019
