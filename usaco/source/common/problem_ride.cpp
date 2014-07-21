/*
ID: cristia26
PROG: ride
LANG: C++11
*/
#include <cstdio>
#include <string.h>
#include <stdint.h>
#define FILENAME "ride"

const char* go = "GO";
const char* stay = "STAY";

uint32_t compute_score(const char* str)
{
    size_t sz = strlen(str);
    uint32_t result = 1;
    for (size_t i = 0; i < sz; i++)
    {
        result *= (str[i] - 64);
    }
    return result % 47;
}

const char* solve_ride(const char* comet, const char* group)
{
    return (compute_score(comet) == compute_score(group) ? go : stay);
}

#ifndef TESTS
int main()
{
    FILE *fin = fopen(FILENAME ".in", "r");
    FILE *fout = fopen(FILENAME ".out", "w");
    char comet[10];
    char group[10];
    fscanf(fin, "%s", &comet);
    fscanf(fin, "%s", &group);
    fprintf(fout, "%s\n", solve_ride(comet, group));
    return 0;
}
#endif
