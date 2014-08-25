#include <gtest/gtest.h>
#include <usaco_include.h>
#include <string.h>
struct interval
{
    int s, e;
};

class UsacoProblemsTestClass : public testing::Test
{
};

TEST_F(UsacoProblemsTestClass, TestProblem_ride)  // NOLINT
{
    const char* result = solve_ride("COMETQ", "HVNGAT");
    ASSERT_EQ(strcmp(result, "GO"), 0);
    result = solve_ride("ABSTAR", "USACO");
    ASSERT_EQ(strcmp(result, "STAY"), 0);
}

TEST_F(UsacoProblemsTestClass, TestProblem_friday)  // NOLINT
{
    int* days;
    days = solve_friday(20);
    ASSERT_EQ(days[0], 34);
    ASSERT_EQ(days[1], 33);
    ASSERT_EQ(days[2], 35);
    ASSERT_EQ(days[3], 35);
    ASSERT_EQ(days[4], 34);
    ASSERT_EQ(days[5], 36);
    ASSERT_EQ(days[6], 33);
    delete [] days;
}

TEST_F(UsacoProblemsTestClass, TestProblem_beads)  // NOLINT
{
    ASSERT_EQ(solve_beads(29, "wwwbbrwrbrbrrbrbrwrwwrbwrwrrb"), 11);
    ASSERT_EQ(solve_beads(3, "rrr"), 3);
    ASSERT_EQ(solve_beads(8, "rrwwwwbb"), 8);
}

TEST_F(UsacoProblemsTestClass, TestProblem_milk2)  // NOLINT
{
    std::vector<struct interval> intervale = {{300, 1000}, {700, 1200}, {1500, 2100}};
    int mt, it;
    solve_milk2(intervale, &mt, &it);
    ASSERT_EQ(mt, 900);
    ASSERT_EQ(it, 300);
    std::vector<struct interval> intervale2 = {{2, 3}, {4, 5}, {6, 7}, {8, 9}
                                             , {10, 11}, {12, 13}, {14, 15}, {16, 17}, {18, 19}, {1, 20}};
    solve_milk2(intervale2, &mt, &it);
    ASSERT_EQ(mt, 19);
    ASSERT_EQ(it, 0);
}

TEST_F(UsacoProblemsTestClass, TestProblem_transform)  // NOLINT
{
    char* m1 = new char[9]{'@','-','@'
                          ,'-','-','-'
                          ,'@','@','-'};
    char* m2 = new char[9]{'@','-','@'
                          ,'@','-','-'
                          ,'-','-','@'};

    int result = solve_transform(3, m1, m2);
    ASSERT_EQ(result, 1);

    delete [] m1;
    delete [] m2;
    m1 = new char[9]{'@','-','@'
                     ,'-','-','-'
                    ,'@','@','-'};
    m2 = new char[9]{'-','@','@'
                    ,'-','-','-'
                    ,'@','-','@'};
    
    result = solve_transform(3, m1, m2);
    ASSERT_EQ(result, 2);
    
    delete [] m1;
    delete [] m2;
    m1 = new char[9]{'@','-','@'
                    ,'-','-','-'
                    ,'@','@','-'};
    m2 = new char[9]{'@','-','-'
                    ,'-','-','@'
                    ,'@','-','@'};
    
    result = solve_transform(3, m1, m2);
    ASSERT_EQ(result, 3);
    
    delete [] m1;
    delete [] m2;
    m1 = new char[9]{'@','-','@'
                    ,'-','-','-'
                    ,'@','@','-'};
    m2 = new char[9]{'@','-','@'
                    ,'-','-','-'
                    ,'-','@','@'};
    
    result = solve_transform(3, m1, m2);
    ASSERT_EQ(result, 4);
    
    delete [] m1;
    delete [] m2;
    m1 = new char[25]{'-','@','@','@','-'
                     ,'-','@','@','-','-'
                     ,'-','@','-','-','-'
                     ,'-','-','-','-','-'
                     ,'-','-','-','-','-'};
    m2 = new char[25]{'-','-','-','-','-'
                     ,'-','-','-','-','@'
                     ,'-','-','-','@','@'
                     ,'-','-','@','@','@'
                     ,'-','-','-','-','-'};
    
    result = solve_transform(5, m1, m2);
    ASSERT_EQ(result, 5);
}

TEST_F(UsacoProblemsTestClass, TestProblem_barn1)  // NOLINT
{
    std::vector<int> input = {3, 4, 6, 8, 14, 15, 16, 17, 21, 25, 26, 27, 30, 31, 40, 41, 42, 43};
    int result = solve_barn1(4, input);
    ASSERT_EQ(result, 25);
    std::vector<int> input2 = {18, 69, 195, 38, 73, 28, 6, 172, 53, 99};
    result = solve_barn1(50, input2);
    ASSERT_EQ(result, 10);
}

TEST_F(UsacoProblemsTestClass, TestProblem_crypt1)  // NOLINT
{
    std::set<int> vs = {2, 3, 4, 6, 8};
    int result = solve_cript1(vs);
    ASSERT_EQ(result, 1);
    std::set<int> vs1 = {4, 1, 2, 5, 6, 7, 3};
    result = solve_cript1(vs1);
    ASSERT_EQ(result, 384);
}