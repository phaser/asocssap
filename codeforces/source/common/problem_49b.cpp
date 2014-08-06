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

int solve_49b(const std::string a, const std::string b)
{
    char max = '0';
    struct determine_max dmax(max);
    for_each(a.begin(), a.end(), dmax);
    for_each(b.begin(), b.end(), dmax);
    int an = atoi(a.c_str());
    int bn = atoi(b.c_str());
    int base = max - '0' + 1;
    int digits = 0;
    int carry = 0;
    while (an > 0 || bn > 0)
    {
        int da = an % 10;
        int db = bn % 10;
        if (da + db + carry >= base)
        {
            carry = (da + db +carry) / base;
        } else carry = 0;
        an /= 10;
        bn /= 10;
        digits++;
    }
    if (carry) digits++;
    return digits;
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