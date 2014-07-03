#include <gtest/gtest.h>
#include <timus_include.h>

class TimusProblemsTestClass : public testing::Test
{
};

TEST_F(TimusProblemsTestClass, TestProblem_1796)  // NOLINT
{
    std::vector<int> input = {0, 2, 0, 0, 0};
    std::vector<int> output;
    solve_1796(input, 10, output);
    ASSERT_EQ(output.size(), 5);
}
