/*
 ID: cristia26
 PROG: transform
 LANG: C++11
 */
#include <cstdio>
#define FILENAME "transform"

#define ROTATION_90         1
#define ROTATION_180        2
#define ROTATION_270        3
#define REFLECTION          4
#define COMBO               5
#define NO_CHAGE            6
#define INVALID_TRANSFORM   7

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

int checkNoChange(struct matrix& m1, struct matrix& m2)
{
    for (size_t i = 0; i < m1.n; i++)
    for (size_t j = 0; j < m2.n; j++)
    {
        if (*(m1.at(i, j)) != *(m2.at(i, j)))
            return INVALID_TRANSFORM;
    }
    return NO_CHAGE;
}

int checkRotation90(struct matrix& m1, struct matrix& m2)
{
    for (size_t i = 0; i < m1.n; i++)
    for (size_t j = 0; j < m2.n; j++)
    {
        if (*(m1.at(i, j)) != *(m2.at(j, m2.n - i - 1)))
            return INVALID_TRANSFORM;
    }
    return ROTATION_90;
}

int checkRotation180(struct matrix& m1, struct matrix& m2)
{
    for (size_t i = 0; i < m1.n; i++)
    for (size_t j = 0; j < m2.n; j++)
    {
        if (*(m1.at(i, j)) != *(m2.at(m2.n - i - 1, m2.n - j - 1)))
            return INVALID_TRANSFORM;
    }
    return ROTATION_180;
}

int checkRotation270(struct matrix& m1, struct matrix& m2)
{
    for (size_t i = 0; i < m1.n; i++)
    for (size_t j = 0; j < m2.n; j++)
    {
        if (*(m1.at(i, j)) != *(m2.at(m2.n - j - 1, i)))
            return INVALID_TRANSFORM;
    }
    return ROTATION_270;
}

int checkReflection(struct matrix& m1, struct matrix& m2)
{
    for (size_t i = 0; i < m1.n; i++)
    for (size_t j = 0; j < m2.n; j++)
    {
        if (*(m1.at(i, j)) != *(m2.at(i, m2.n - j -1)))
            return INVALID_TRANSFORM;
    }
    return REFLECTION;
}

int solve_transform(size_t sz, char* mat1, char* mat2)
{
    struct matrix m1;
    struct matrix m2;
    m1.m = mat1;
    m2.m = mat2;
    m1.n = m2.n = sz;
    int t = checkRotation90(m1, m2);
    if (t == INVALID_TRANSFORM)
    {
        t = checkRotation180(m1, m2);
    }
    if (t == INVALID_TRANSFORM)
    {
        t = checkRotation270(m1, m2);
    }
    if (t == INVALID_TRANSFORM)
    {
        t = checkNoChange(m1, m2);
    }
    if (t == INVALID_TRANSFORM)
    {
        t = checkReflection(m1, m2);
    }
    return t;
}

#ifndef TESTS
int main()
{
    FILE *fin = fopen(FILENAME ".in", "r");
    FILE *fout = fopen(FILENAME ".out", "w");
    int n;
    fscanf(fin, "%d", &n);
    
    return 0;
}
#endif