#include <gtest/gtest.h>
#include <timus_include.h>

class TimusProblemsTestClass : public testing::Test
{
};

TEST_F(TimusProblemsTestClass, TestProblem_1796)  // NOLINT
{
    std::vector<int> input = {0, 2, 0, 0, 0, 0};
    std::vector<int> output;
    solve_1796(input, 10, output);
    ASSERT_EQ(output.size(), 5);
    for (int i = 6; i <= 10; i++) ASSERT_EQ(output[i-6], i);
    output.clear();
    std::vector<int> input2 = {1, 2, 0, 0, 0, 0};
    solve_1796(input2, 10, output);
    ASSERT_EQ(output.size(), 1);
    ASSERT_EQ(output[0], 11);
}
