#ifdef TESTS
#include <problems_ia.h>
#else
#include <cstdio>
#endif
#include <vector>

#define FILE_NAME "cautbin"

namespace problema_cautbin
{
int binary_find(std::vector<int>& vec, int begin, int end, int value, int result)
{
    if (end <= begin)
    {
        return result;
    }
    int middle = begin + (end - begin) / 2; 
    if (vec[middle] == value)
    {
        result = middle;
    }
    
    if (value < vec[middle])
    {
        return binary_find(vec, begin, middle - 1, value, result);
    } else if (value >= vec[middle])
    {
        return binary_find(vec, middle + 1, end, value, result);
    }
}
}  // namespace problema_cautbin

#ifndef TESTS
int main()
{
    FILE* f = fopen(FILE_NAME ".in", "rt"); 
    FILE* fout = fopen(FILE_NAME ".out", "wt");

    fclose(f);
    fclose(fout);
    return 0;
}
#endif  // TESTS
