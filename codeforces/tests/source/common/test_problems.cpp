#include <gtest/gtest.h>
#include <codeforces_include.h>

class CodeForcesProblemsTestClass : public testing::Test
{
};

TEST_F(CodeForcesProblemsTestClass, TestProblem_1a)  // NOLINT
{
    ASSERT_EQ(solve_1a(6, 6, 4), 4);
}
