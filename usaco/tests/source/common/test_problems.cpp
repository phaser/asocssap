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
