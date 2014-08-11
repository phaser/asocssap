/*
ID: cristia26
PROG: dualpal
LANG: C++11
*/
#include <cstdio>
#define FILENAME "dualpal"
void convert_to_base(int num, int base, char cn[64], int& nd)
{
    int i = 0;
    while (num > 0)
    {
        int d = (num % base);
        if (d > 9)
            cn[i] = 'A' + (d - 10);
        else
            cn[i] = d + '0';
        num /= base;
        i++;
    }
    nd = i;
    for (i = 0; i < nd/2; i++)
    {
        char aux = cn[i];
        cn[i] = cn[nd - i - 1];
        cn[nd - i - 1] = aux;
    }
}

bool isPalindrome(char cn[12], int nd)
{
    for (int i = 0; i < nd/2; i++)
    {
        if (cn[i] != cn[nd - i - 1])
        {
            return false;
        }
    }
    return true;
}

#ifndef TESTS
int main()
{
    FILE *fin = fopen(FILENAME ".in", "r");
    FILE *fout = fopen(FILENAME ".out", "w");
    int n, s;
    fscanf(fin, "%d %d", &n, &s);
    int count = 0;
    while (count < n)
    {
        int num = ++s;
        int palb = 0;
        for (int base = 2; base <= 10; base++)
        {
            char cn[64];
            int nd;
            convert_to_base(num, base, cn, nd);
            if (isPalindrome(cn, nd)) palb++;
            if (palb > 1)
            {
                fprintf(fout, "%d\n", num);
                count++;
                break;
            }
        }
    }
    fclose(fin);
    fclose(fout);
    return 0;
}
#endif