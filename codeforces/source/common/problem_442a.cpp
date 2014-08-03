#include <cstdio>
#include <stdint.h>
#include <vector>

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

uint16_t solve_442a(std::vector<uint16_t>& cards)
{
    uint16_t accepted_symbols = 0;
    for (auto it = cards.begin(); it != cards.end(); it++)
    {
        accepted_symbols = setMask(accepted_symbols, *it);
    }
    uint16_t solution = 0;
    while (solution < 1024)
    {
        // check if valid
        if ((solution | accepted_symbols) != accepted_symbols)
        {
            solution++;
            continue;
        }
        printf("solution: %d\n", solution);
        solution++;
    }
    return 2;
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
        fscanf("%s", &group);
        uint16_t card = 0;
        card = setMask(card, getMask(group[0]));
        card = setMask(card, getMask(group[1]));
        cards.push_back(card);
    }
    return 0;
}
#endif