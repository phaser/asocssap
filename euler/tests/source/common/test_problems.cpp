#include <gtest/gtest.h>
#include <problems.h>

class ProblemsTestClass : public testing::Test
{
};

TEST_F(ProblemsTestClass, TestProblem_0001)  // NOLINT
{
    ASSERT_EQ(problem_0001::solve_problem(), 233168);
}

TEST_F(ProblemsTestClass, TestProblem_0002)  // NOLINT
{
    ASSERT_EQ(problem_0002::solve_problem(), 4613732);
}

TEST_F(ProblemsTestClass, TestProblem_0019)  // NOLINT
{
    ASSERT_EQ(problem_0019::solve_problem(), 0);
}

