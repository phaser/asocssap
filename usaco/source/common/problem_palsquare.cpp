/*
 ID: cristia26
 PROG: palsquare
 LANG: C++11
 */
#include <cstdio>
#define FILENAME "palsquare"

void convert_to_base(int num, int base, char cn[12], int& nd)
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
    int base;
    fscanf(fin, "%d", &base);
    for (int i = 1; i <= 300; i++)
    {
        int si = i*i;
        // convert si to base
        char cn[12];
        int nd;
        convert_to_base(si, base, cn, nd);
        if (isPalindrome(cn, nd))
        {
            char an[12];
            int ad;
            convert_to_base(i, base, an, ad);
            cn[nd] = '\0';
            an[ad] = '\0';
            fprintf(fout, "%s %s\n", an, cn);
        }
    }
    fclose(fin);
    fclose(fout);
    return 0;
}
#endif