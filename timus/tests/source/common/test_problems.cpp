#include <gtest/gtest.h>
#include <timus_include.h>

struct Point
{
    int64_t x, y;
};
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

TEST_F(TimusProblemsTestClass, TestProblem_1875)  // NOLINT
{
    return;
    std::vector<struct Point> input {{1, 5}, {2, 8}, {3, 9}, {4, 8}, {5, 5}};
    int result = solve_1875(input);
    ASSERT_EQ(result, 1);
    std::vector<struct Point> input3 {{1, 999}, {2, 999}, {3, 0}, {4, 1}, {5, 2}};
    result = solve_1875(input3);
    ASSERT_EQ(result, 3);
    std::vector<struct Point> input4 {{1, 10000}, {2, 10000}, {3, 10000}, {4, 10000}, {5, 10000}};
    result = solve_1875(input4);
    ASSERT_EQ(result, 3);
    std::vector<struct Point> input5 {{1, 1}, {2, 1}, {3, 1}, {4, 1}, {5, 1}};
    result = solve_1875(input5);
    ASSERT_EQ(result, 3);
    std::vector<struct Point> input6 {{1, 1}, {1, 2}, {1, 3}, {1, 4}, {1, 5}};
    result = solve_1875(input6);
    ASSERT_EQ(result, 5);
    std::vector<struct Point> input7 {{1, 5}, {2, 8}, {3, 10}, {4, 8}, {5, 5}};
    result = solve_1875(input7);
    ASSERT_EQ(result, 2);
    std::vector<struct Point> input8 {{1, 1}, {2, 4}, {3, 9}, {4, 8}, {5, 5}};
    result = solve_1875(input8);
    ASSERT_EQ(result, 3);
    std::vector<struct Point> input9 {{1, 1}, {2, 4}, {3, 9}, {4, 16}, {5, 25}};
    result = solve_1875(input9);
    ASSERT_EQ(result, 5);
    std::vector<struct Point> input10 {{4, 0}, {3, 9}, {4, 8}, {5, 5}, {1, 1}};
    result = solve_1875(input10);
    ASSERT_EQ(result, 2);
}

TEST_F(TimusProblemsTestClass, TestProblem_1185)  // NOLINT
{
    std::vector<struct Point> input {{200, 400}, {300, 400}, {300, 300}, {400, 300}
                                   , {400, 400}, {500, 400}, {500, 200}, {350, 200}
                                   , {200, 200}};
    int result = solve_1185(input, 100);
    ASSERT_EQ(result, 1628);
}