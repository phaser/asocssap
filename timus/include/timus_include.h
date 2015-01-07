#pragma once
#include <vector>
#include <stdint.h>
#include <math.h>

class Pt
{
public:
    double x, y;
    Pt() : x(0.f), y(0.f) {}
    Pt(double x, double y) : x(x), y(y) {}
    Pt(const Pt& p) : x(p.x), y(p.y) {}
    double dist(const Pt& p) const
    {
        double result = sqrt(pow(p.x - this->x, 2.f) + pow(p.y - this->y, 2.f));
        return result;
    }

    double length()
    {
        return sqrt(pow(x, 2) + pow(y, 2));
    }

    friend Pt operator+(Pt lhs, const Pt& rhs)
    {
        lhs.x += rhs.x;
        lhs.y += rhs.y;
        return lhs;
    }
    friend Pt operator-(Pt lhs, const Pt& rhs)
    {
        lhs.x -= rhs.x;
        lhs.y -= rhs.y;
        return lhs;
    }

    friend Pt operator*(Pt lhs, double s)
    {
        lhs.x *= s;
        lhs.y *= s;
        return lhs;
    }

    friend Pt operator/(Pt lhs, double s)
    {
        lhs.x /= s;
        lhs.y /= s;
        return lhs;
    }

    friend Pt operator/(Pt lhs, const Pt& rhs)
    {
        lhs.x /= rhs.x;
        lhs.y /= rhs.y;
        return lhs;
    }

    friend Pt operator/(double s, const Pt& rhs)
    {
        Pt lhs;
        lhs.x = s / rhs.x;
        lhs.y = s / rhs.y;
        return lhs;
    }
};

void solve_1796(std::vector<int>& input, int ticketprice, std::vector<int>& output);
int solve_1005(std::vector<int>& input);
void solve_1263(int nCandidates, std::vector<int>& input, std::vector<float>& output);
struct Point;
int solve_1875(std::vector<struct Point>& p);
double solve_1185(std::vector<struct Point>& p, int r);
double solve_1815(const Pt& p1, const Pt& p2, const Pt& p3, double w1, double w2, double w3);
int solve_1009(int n, int k);