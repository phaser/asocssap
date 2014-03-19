#include <gtest/gtest.h>
#include <problem_0001.h>


class ProblemsTestClass : public testing::Test
{
};

TEST_F(ProblemsTestClass, TestProblem_0001)  // NOLINT
{
    ASSERT_EQ(solve_problem(), 233168);
}
