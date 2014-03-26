#include <gtest/gtest.h>
#include <problems_ia.h>
#include <vector>

class ProblemsTestClass : public testing::Test
{
};

TEST_F(ProblemsTestClass, TestProblem_adunare)  // NOLINT
{
    ASSERT_EQ(problema_adunare::solve_problem(100, 100), 200);
}

TEST_F(ProblemsTestClass, TestProblem_euclid2)  // NOLINT
{
    ASSERT_EQ(problema_euclid2::gcd(12, 42), 6);
    ASSERT_EQ(problema_euclid2::gcd(21, 7), 7);
    ASSERT_EQ(problema_euclid2::gcd(9, 10), 1);
}

TEST_F(ProblemsTestClass, TestProblem_cautbin)  // NOLINT
{
    std::vector<int> a{1, 3, 3, 3, 5};
    ASSERT_EQ(problema_cautbin::binary_find(a, 0, a.size(), 5), 4);
    ASSERT_EQ(problema_cautbin::binary_find(a, 0, a.size(), 7), -1);
}
