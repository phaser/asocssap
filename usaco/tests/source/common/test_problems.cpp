#include <gtest/gtest.h>
#include <usaco_include.h>
#include <string.h>
struct interval
{
    int s, e;
};

class UsacoProblemsTestClass : public testing::Test
{
};

TEST_F(UsacoProblemsTestClass, TestProblem_ride)  // NOLINT
{
    const char* result = solve_ride("COMETQ", "HVNGAT");
    ASSERT_EQ(strcmp(result, "GO"), 0);
    result = solve_ride("ABSTAR", "USACO");
    ASSERT_EQ(strcmp(result, "STAY"), 0);
}

TEST_F(UsacoProblemsTestClass, TestProblem_friday)  // NOLINT
{
    int* days;
    days = solve_friday(20);
    ASSERT_EQ(days[0], 34);
    ASSERT_EQ(days[1], 33);
    ASSERT_EQ(days[2], 35);
    ASSERT_EQ(days[3], 35);
    ASSERT_EQ(days[4], 34);
    ASSERT_EQ(days[5], 36);
    ASSERT_EQ(days[6], 33);
    delete [] days;
}

TEST_F(UsacoProblemsTestClass, TestProblem_beads)  // NOLINT
{
    ASSERT_EQ(solve_beads(29, "wwwbbrwrbrbrrbrbrwrwwrbwrwrrb"), 11);
    ASSERT_EQ(solve_beads(3, "rrr"), 3);
    ASSERT_EQ(solve_beads(8, "rrwwwwbb"), 8);
}

TEST_F(UsacoProblemsTestClass, TestProblem_milk2)  // NOLINT
{
    std::vector<struct interval> intervale = {{300, 1000}, {700, 1200}, {1500, 2100}};
    int mt, it;
    solve_milk2(intervale, &mt, &it);
    ASSERT_EQ(mt, 900);
    ASSERT_EQ(it, 300);
    std::vector<struct interval> intervale2 = {{2, 3}, {4, 5}, {6, 7}, {8, 9}
                                             , {10, 11}, {12, 13}, {14, 15}, {16, 17}, {18, 19}, {1, 20}};
    solve_milk2(intervale2, &mt, &it);
    ASSERT_EQ(mt, 19);
    ASSERT_EQ(it, 0);
}
