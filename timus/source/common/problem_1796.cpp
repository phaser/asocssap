#include <cstdio>
#include <vector>

int bills[6] = {10, 50, 100, 500, 1000, 5000};

/* The solution is complicated unnecessarily but I was lazy to do a more compact version.
 * The idea is to compute the max number of tickets that we can buy with our sum and then
 * substract a ticket and add it with the offset (the surplus that doesn't cover a ticket) and
 * see if it exceeds the amount of any banknote. If this is the case then min++ is our minimum and
 * we can print the solution.
 */
void solve_1796(std::vector<int>& input, int ticketprice, std::vector<int>& output)
{
    int sum = 0;
    for (auto i = 0; i < 6; i++)
    {
        sum += input[i] * bills[i];
    }
    int max_num_tickets = sum / ticketprice;
    int offset = sum - max_num_tickets * ticketprice;
    int min_num_tickets = max_num_tickets;
    bool haveMin = true;
    while (haveMin)
    {
        if (min_num_tickets <= 0)
        {
            min_num_tickets = max_num_tickets;
            haveMin = false;
            break;
        }
        min_num_tickets--;
        int diff = (max_num_tickets - min_num_tickets) * ticketprice;
        for (int i = 0; i < 6; i++)
        {
            if (input[i] > 0 && (diff + offset >= bills[i]))
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
