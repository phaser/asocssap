/*
 ID: cristia26
 PROG: transform
 LANG: C++11
 */
#include <cstdio>
#define FILENAME "transform"

struct matrix
{
    char* m;
    size_t n;
    matrix()
    {
    }
    
    matrix(size_t n)
    {
        m = new char[n*n];
        this->n =n;
    }
    char* at(size_t i, size_t j)
    {
        return &m[i * n + j];
    }
    size_t idx(size_t i, size_t j) { return i * n + j; }
};

int solve_transform(char* mat1, char* mat2)
{
    struct matrix m1;
    struct matrix m2;
    m1.m = mat1;
    m2.m = mat2;
    return 1;
}

#ifndef TESTS
int main()
{
    FILE *fin = fopen(FILENAME ".in", "r");
    FILE *fout = fopen(FILENAME ".out", "w");
    return 0;
}
#endif