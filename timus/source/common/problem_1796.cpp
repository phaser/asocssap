#include <cstdio>
#include <vector>

int bills[6] = {10, 50, 100, 500, 1000, 5000};

void solve_1796(std::vector<int>& input, int ticketprice, std::vector<int>& output)
{
    int sum = 0;
    for (auto i = 0; i < 6; i++)
    {
        sum += input[i] * bills[i];
    }
    int max_num_tickets = sum / ticketprice;
    int min_num_tickets = max_num_tickets;
    bool haveMin = true;
    while (haveMin)
    {
        min_num_tickets--;
        int diff = (max_num_tickets - min_num_tickets) * ticketprice;
        for (int i = 0; i < 6; i++)
        {
            if (input[i] > 0 && (diff >= bills[i]))
            {
                min_num_tickets++;
                haveMin = false;
                break;
            }
        }
    }
    
    for (int i = min_num_tickets; i <= max_num_tickets; i++)
    {
        output.push_back(i);
    }
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
    scanf("%d", &ticketprice);
    std::vector<int> output;
    solve_1796(input, ticketprice, output);
    size_t sz = output.size();
    printf("%lu\n", sz);
    for (int i = 0; i < sz; i++)
    {
        printf("%d ", output[i]);
    }
    return 0;
}
#endif
