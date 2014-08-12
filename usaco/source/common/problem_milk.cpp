/*
 ID: cristia26
 PROG: milk
 LANG: C++11
 */
#include <cstdio>
#include <map>
#include <math.h>
#include <algorithm>
#define FILENAME "milk"

int main()
{
    FILE *fin = fopen(FILENAME ".in", "r");
    FILE *fout = fopen(FILENAME ".out", "w");
    int amountMilk, noFarmers;
    fscanf(fin, "%d %d", &amountMilk, &noFarmers);
    std::multimap<int, int> prices;
    for (int i = 0; i < noFarmers; i++)
    {
        int price, amount;
        fscanf(fin, "%d %d", &price, &amount);
        prices.insert(std::make_pair(price, amount));
    }
    int minPrice = 0;
    while (amountMilk > 0)
    {
        auto pr = prices.begin();
        int amount = std::min(pr->second, amountMilk);
        minPrice += amount * pr->first;
        amountMilk -= amount;
        if (amount >= pr->second)
        {
            prices.erase(pr);
        }
    }
    fprintf(fout, "%d\n", minPrice);
    fclose (fin);
    fclose(fout);
    return 0;
}