#include <stdio.h>
#include <string>

class CNumber
{
public:
    CNumber(int n);
    void show();
    const char* str()
    {
        populate_internal_str();
        return str_;
    }
    friend bool operator>(const CNumber& lhs, const CNumber& rhs);
    friend bool operator<(const CNumber& lhs, const CNumber& rhs);
    friend void minmax(CNumber& num, CNumber& min, CNumber& max);
private:
    char n_[10];
    char str_[10];
    void populate_internal_str()
    {
        for (int i = n_[0]; i > 0; i--)
        {
            str_[n_[0] - i] = n_[i] + '0';
        }
        str_[n_[0]] = '\0';
    }
};

CNumber::CNumber(int n)
{
    n_[0] = 0;
    while (n > 0)
    {
        n_[++n_[0]] = n % 10;
        n /= 10;
    }
    if (n_[0] == 0)
    {
        n_[0] = 1;
        n_[1] = 0;
    }
}

void CNumber::show()
{
    populate_internal_str();
    printf("%s\n", str_);
}

bool operator>(const CNumber& lhs, const CNumber& rhs)
{
    if (lhs.n_[0] > rhs.n_[0]) return true;
    else if (lhs.n_[0] < rhs.n_[0]) return false;
    for (int i = lhs.n_[0]; i > 0; i--)
    {
        if (lhs.n_[i] > rhs.n_[i]) return true;
        else if (lhs.n_[i] < rhs.n_[i]) return false;
    }
    return false;
}

bool operator<(const CNumber& lhs, const CNumber& rhs)
{
    if (lhs.n_[0] < rhs.n_[0]) return true;
    else if (lhs.n_[0] > rhs.n_[0]) return false;
    for (int i = lhs.n_[0]; i > 0; i--)
    {
        if (lhs.n_[i] < rhs.n_[i]) return true;
        else if (lhs.n_[i] > rhs.n_[i]) return false;
    }
    return false;
}

void minmax(CNumber& num, CNumber& min, CNumber& max)
{
    min = num;
    max = num;
    if (num.n_[0] <= 1)
        return;

    for (int i = num.n_[0]; i > 0; i--)
    {
        for (int k = i-1; k > 0; k--)
        {
            if (i == num.n_[0] && num.n_[k] == 0) continue;
            char aux = num.n_[i];
            num.n_[i] = num.n_[k];
            num.n_[k] = aux;
            if (num < min)
            {
                min = num;
            }
            if (num > max)
            {
                max = num;
            }
            aux = num.n_[i];
            num.n_[i] = num.n_[k];
            num.n_[k] = aux;
        }
    }
}
#ifdef TESTS
int main()
{
    int t;
    int n;
    scanf("%d", &t);
    for (int i = 0; i < t; i++)
    {
        scanf("%d", &n);
        CNumber num(n);
        CNumber min(0), max(0);
        minmax(num, min, max);
        printf("Case #%d: %s %s\n", (i+1), min.str(), max.str());
    }
    return 0;
}
#endif