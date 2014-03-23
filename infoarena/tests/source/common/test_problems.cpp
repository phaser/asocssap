#include <gtest/gtest.h>
#include <problems_ia.h>

class ProblemsTestClass : public testing::Test
{
};

TEST_F(ProblemsTestClass, TestProblem_adunare)  // NOLINT
{
    ASSERT_EQ(problema_adunare::solve_problem(100, 100), 200);
}
