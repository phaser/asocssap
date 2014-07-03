#include <cstdio>
#include <vector>

void solve_1796(std::vector<int>& input, int ticketprice, std::vector<int>& output)
{
    
}

#ifndef TESTS
int main()
{
    std::vector<int> input;
    input.reserve(5);
    int v;
    for (int i = 0; i < 6; i++)
    {
        scanf("%d", &v);
        input.push_back(v);
    }
    int ticketprice;
    std::vector<int> output;
    solve_1796(input, ticketprice, output);
    printf("%d\n", output.size());
    for (auto it = output.begin(); it != output.end(); it++)
    {
        printf("%d ", *it);
    }
    return 0;
}
#endif
