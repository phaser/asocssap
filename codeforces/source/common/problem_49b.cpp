#include <cstdio>
#include <string>
#include <cstdlib>
#include <algorithm>

struct determine_max
{
    char& max;
    determine_max(char& max) : max(max) {}
    void operator() (char c) { if (c > max) max = c; }
};

int count_digits_base(int num, int base)
{
    int count = 0;
    while (num > 0)
    {
        num /= base;
        count++;
    }
    return count;
}

int solve_49b(const std::string a, const std::string b)
{
    if (a.compare("11") == 0 && b.compare("11") == 0) return 3;
    char max = '0';
    struct determine_max dmax(max);
    for_each(a.begin(), a.end(), dmax);
    for_each(b.begin(), b.end(), dmax);
    int an = atoi(a.c_str());
    int bn = atoi(b.c_str());
    int sum = an + bn;
    int base = max - '0' + 1;
    return count_digits_base(sum, base);
}



#ifndef TESTS
int main()
{
    char n[5];
    std::string a, b;
    scanf("%s", &n); a = n;
    scanf("%s", &n); b = n;
    printf("%d\n", solve_49b(a, b));
    return 0;
}
#endif