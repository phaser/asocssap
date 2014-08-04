#include <cstdio>
#include <stdint.h>
#include <vector>
#include <algorithm>

#define RM 0x0001
#define GM 0x0002
#define BM 0x0004
#define YM 0x0008
#define WM 0x0010
#define M1 0x0020
#define M2 0x0040
#define M3 0x0080
#define M4 0x0100
#define M5 0x0200

uint16_t setMask(uint16_t val, uint16_t mask)
{
    return val | mask;
}

uint16_t getMask(char c)
{
    switch (c)
    {
        case 'R': return RM;
        case 'G': return GM;
        case 'B': return BM;
        case 'Y': return YM;
        case 'W': return WM;
        case '1': return M1;
        case '2': return M2;
        case '3': return M3;
        case '4': return M4;
        case '5': return M5;
        default: return 0;
    }
    return 0;
}

uint16_t countBits(uint16_t v)
{
    uint16_t c;
    for (c = 0; v; c++) v &= v - 1;
    return c;
}

uint16_t solve_442a(std::vector<uint16_t>& cards)
{
    uint16_t accepted_symbols = 0;
    std::vector<uint16_t> unique_cards;
    for (std::vector<uint16_t>::iterator it = cards.begin(); it != cards.end(); it++)
    {
        accepted_symbols = setMask(accepted_symbols, *it);
        std::vector<uint16_t>::iterator val = std::find(unique_cards.begin(), unique_cards.end(), *it);
        if (val == unique_cards.end())
        {
            unique_cards.push_back(*it);
        }
    }
    uint16_t solution = 0;
    uint16_t min = 11;
    if (unique_cards.size() == 1)
    {
        return 0;
    }

    while (++solution < 1024)
    {
        // check if valid
        if ((solution | accepted_symbols) != accepted_symbols)
        {
            continue;
        }
        std::vector<uint16_t> icards = cards;
        std::vector<uint16_t> lucards = unique_cards;
        for (std::vector<uint16_t>::iterator it = icards.begin(); it != icards.end(); it++)
        {
            *it = *it & solution;
        }
        
        // Remove the cards matched directly
        size_t sz = icards.size();
        for (size_t i = 0; i < sz; i++)
        {
            if (icards[i] == cards[i])
            {
                std::vector<uint16_t>::iterator it = find(lucards.begin(), lucards.end(), icards[i]);
                if (it != lucards.end()) lucards.erase(it);
                icards[i] = 0;
            }
        }
        
        // Remove the cards that were matched partially but there is only one type left in the
        // list that contain the same partial part matched
        for (size_t i = 0; i < sz; i++)
        {
            if (icards[i] != 0)
            {
                uint16_t count = 0;
                for (std::vector<uint16_t>::iterator it = lucards.begin(); it != lucards.end(); it++)
                {
                    if ((*it & icards[i]) == icards[i]) count++;
                }
                if (count == 1)
                {
                    std::vector<uint16_t>::iterator it = find(lucards.begin(), lucards.end(), cards[i]);
                    if (it != lucards.end()) lucards.erase(it);
                    icards[i] = 0;
                }
            }
        }
        if (lucards.size() <= 1)
        {
            uint16_t bits = countBits(solution);
            if (bits < min) min = bits;
        }
    }
    return min;
}

#ifndef TESTS
int main()
{
    int n;
    char group[3];
    std::vector<uint16_t> cards;
    scanf("%d", &n);
    for (int i = 0; i < n; i++)
    {
        scanf("%s", &group);
        uint16_t card = 0;
        card = setMask(card, getMask(group[0]));
        card = setMask(card, getMask(group[1]));
        cards.push_back(card);
    }
    printf("%d\n", solve_442a(cards));
    return 0;
}
#endif