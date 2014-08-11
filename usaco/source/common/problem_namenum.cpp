/*
 ID: cristia26
 PROG: namenum
 LANG: C++11
 */
#include <cstdio>
#include <string.h>
#include <vector>
#include <string>
#include <algorithm>
#include <assert.h>

#define FILENAME "namenum"
#define DICT "dict.txt"

char letters[27] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y'};
void filter_by_size(std::vector<std::string>& dict, std::vector<char>& dictu, size_t sz)
{
    size_t ms = dict.size();
    for (size_t i = 0; i < ms; i++)
    {
        if ((size_t)dictu[i] != sz)
        {
            dictu[i] = 0;
        }
    }
}

void filter_dict(std::vector<std::string>& dict, std::vector<char>& dictu, char letter, int idx)
{
    size_t sz = dict.size();
    for (size_t i = 0; i < sz; i++)
    {
        if ((size_t)dictu[i] != 0)
        {
            char l = dict[i].c_str()[idx];
            assert (letter != '0');
            assert (letter != '1');
            int let = ((letter - '0') - 2)*3;
            if (l != letters[let] && l != letters[let + 1] && l != letters[let + 2])
            {
                dictu[i] = 0;
            }
        }
    }
}

int main()
{
    // Load dictionary
    FILE *fin = fopen(DICT, "r");
    std::vector<std::string> dict;
    std::vector<char> dictu;
    char nume[13];
    while (!feof(fin))
    {
        fscanf(fin, "%s", &nume);
        dict.push_back(nume);
        dictu.push_back(strlen(nume));
    }
    fclose(fin);

    // Solve the problem
    fin = fopen(FILENAME ".in", "r");
    FILE *fout = fopen(FILENAME ".out", "w");
    char input[13];
    fscanf(fin, "%s", &input);
    fclose(fin);
    size_t sz = strlen(input);
    filter_by_size(dict, dictu, sz);
    for (size_t i = 0; i < sz; i++)
    {
        filter_dict(dict, dictu, input[i], i);
    }
    sz = dict.size();
    bool something_printed = false;
    for (size_t i = 0; i < sz; i++)
    {
        if (dictu[i] != 0)
        {
            fprintf(fout, "%s\n", dict[i].c_str());
            something_printed = true;
        }
    }
    if (!something_printed)
    {
        fprintf(fout, "NONE\n");
    }
    fclose(fout);
    return 0;
}