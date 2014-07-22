#include <gtest/gtest.h>
#include <usaco_include.h>
#include <string.h>

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
}