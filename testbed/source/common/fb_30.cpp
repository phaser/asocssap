#include <stdio.h>
#include <vector>
#include <Python/Python.h>

struct Food
{
    Food()
    {
        p = c = f = 0;
    }
    int p, c, f;
    Food& operator+=(const Food& rhs)
    {
        this->p += rhs.p;
        this->c += rhs.c;
        this->f += rhs.f;
        return *this;
    }
};

void printCase (int no, bool yes)
{
    printf("Case #%d: %s\n", no+1, yes ? "yes":"no");
}
#ifdef TESTS
int main()
{
    int t;
    Food target;
    int nf;
    scanf("%d", &t);
    for (int i = 0; i < t; i++)
    {
        scanf("%d %d %d", &target.p, &target.c, &target.f);
        scanf("%d", &nf);
        std::vector<struct Food> foods;
        foods.reserve(nf);
        Food food;
        for (int j = 0; j < nf; j++)
        {
            scanf("%d %d %d", &food.p, &food.c, &food.f);
            if (food.p > target.p || food.c > target.c || food.f > target.f) continue;
            foods.push_back(food);
        }
        if (foods.size() <= 0)
        {
            printCase(i, false);
            continue;
        }
        size_t sz = foods.size();
        uint32_t ftc = 0;
        uint32_t limit = (1 << (sz + 1));
        bool foundSolution = false;
        while (++ftc < limit)
        {
            Food sum;
            for (int k = 0; k < sz; k++)
            {
                if ((ftc & (1 << k)) != 0)
                {
                    sum += foods[k];
                }
            }
            if (sum.p == target.p && sum.c == target.c && sum.f == target.f)
            {
                printCase(i, true);
                foundSolution = true;
                break;
            }
        }

        if (!foundSolution)
        {
            printCase(i, false);
        }
    }
    return 0;
}
#endif