#include "fsort.h"
#include <vector>
#include <iostream>

int main ()
{
    int myints[] = {32, 71, 12, 45, 32, 5, 6, 7, 80, 13, 19, 21};
    std::vector<int> vector(myints, myints+12);
    std::vector<int> vector1(myints, myints+12);
    std::sort(vector1.begin(), vector1.end());
    for (auto e : vector1)
    {
        std::cout << e << " ";
    }
    std::cout << std::endl;
    
    auto sorted = false;
    auto sz = vector.size();
    size_t begin = 0;
    while (!sorted)
    {
        if (!sorted)
        {
            begin = 0;
            while (vector[begin] < vector[begin+1])
            {
                begin++;
            }
        }
        sorted = true;
        size_t f1 = 1;
        size_t f2 = 1;
        size_t fe = begin;
        size_t se = begin + f2;
        while (se < sz)
        {
            if (vector[fe] > vector[se])
            {
                int aux = vector[fe];
                vector[fe] = vector[se];
                vector[se] = aux;
                sorted = false;
            }
            size_t aux = f1 + f2;
            f1 = f2;
            f2 = aux;
            fe += f1;
            se += f2;
        }
    }
    for (auto e : vector)
    {
        std::cout << e << " ";
    }
    std::cout << std::endl;
    return 0;
}