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
    output.clear();
    std::vector<int> input3 = {0, 3, 0, 0, 0, 0};
    solve_1796(input3, 33, output);
    ASSERT_EQ(output.size(), 1);
    ASSERT_EQ(output[0], 4);
}

TEST_F(TimusProblemsTestClass, TestProblem_1005)  // NOLINT
{
    std::vector<int> input = {5, 8, 13, 27, 14};
    int diff = solve_1005(input);
    ASSERT_EQ(diff, 3);
    std::vector<int> input2 = {1, 2, 2, 2, 2, 2, 10};
    diff = solve_1005(input2);
    ASSERT_EQ(diff, 1);
    std::vector<int> input3 = {1, 2, 3, 4, 5, 6, 7, 8};
    diff = solve_1005(input3);
    ASSERT_EQ(diff, 0);
}