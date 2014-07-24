#include <gtest/gtest.h>
#include <codeforces_include.h>

class CodeForcesProblemsTestClass : public testing::Test
{
};

TEST_F(CodeForcesProblemsTestClass, TestProblem_1a)  // NOLINT
{
    ASSERT_EQ(solve_1a(6, 6, 4), 4);
}

TEST_F(CodeForcesProblemsTestClass, TestProblem_81b)  // NOLINT
{
    std::string result = solve_81b("1,2 ,3,...,     10");
    ASSERT_EQ(result, "1, 2, 3, ..., 10");
    result = solve_81b("1,,,4...5......6");
    ASSERT_EQ(result, "1, , , 4 ...5 ... ...6");
    result = solve_81b("...,1,2,3,...");
    ASSERT_EQ(result, "..., 1, 2, 3, ...");
    result = solve_81b(",,,,,,,,,,,,,");
    ASSERT_EQ(result, ", , , , , , , , , , , , ,");
}