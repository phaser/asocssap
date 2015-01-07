#ifdef TESTS
#include <timus_include.h>
#else
#include <stdio.h>
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
#endif

double computeDistances (const Pt& cg, const Pt& p1, const Pt& p2, const Pt& p3, double w1, double w2, double w3)
{
    double dist1 = p1.dist(cg);
    double dist2 = p2.dist(cg);
    double dist3 = p3.dist(cg);
    dist1 *= w1;
    dist2 *= w2;
    dist3 *= w3;
    double result = dist1 + dist2 + dist3;
    return result;
}

double solve_1815(const Pt& p1, const Pt& p2, const Pt& p3, double w1, double w2, double w3)
{
    Pt y0 = (p1 + p2 + p3) / 3.f;
    Pt y = y0;
    double result = computeDistances(y0, p1, p2, p3, w1, w2, w3);
    double result2 = result;
    do
    {
        y0 = y;
        result = result2;
        double t1 = (p1 - y).length();
        double t2 = (p2 - y).length();
        double t3 = (p3 - y).length();
        Pt sum1 = p1 * w1 / t1
                + p2 * w2 / t2
                + p3 * w3 / t3;
        double sum2 = w1 / t1
                    + w2 / t2
                    + w3 / t3;
        y = sum1 / sum2;
        result2 = computeDistances(y, p1, p2, p3, w1, w2, w3);
    } while (result2 < result && result - result2 > 0.00000000001);

    return result;
}

#ifndef TESTS
int main()
{
    int n;
    scanf("%d", &n);
    for (int i = 0; i < n; i++)
    {
        Pt p1, p2, p3;
        int i1x, i1y, i2x, i2y, i3x, i3y;
        scanf("%d %d %d %d %d %d", &i1x, &i1y, &i2x, &i2y, &i3x, &i3y);
        p1.x = i1x; p1.y = i1y;
        p2.x = i2x; p2.y = i2y;
        p3.x = i3x; p3.y = i3y;
        int w1, w2, w3;
        scanf("%d %d %d", &w1, &w2, &w3);
        printf("%.10f\n", solve_1815(p1, p2, p3, w1, w2, w3));
    }
    return 0;
}
#endif