#include <stdint.h>
#include <vector>
#include <stack>
#include <math.h>
#include <algorithm>

struct Point
{
    int64_t x, y;
};

// ccw > 0 counter-clock
// ccw < 0 clock
// ccw = 0 collinear
int ccw (const struct Point& p1, const struct Point& p2, const struct Point& p3)
{
    return (p2.x - p1.x)*(p3.y - p1.y) - (p2.y - p1.y)*(p3.x - p1.x);
}

// A utility function to swap two points
void swap(std::vector<struct Point>& p, int i, int j)
{
    struct Point temp = p[i];
    p[i] = p[j];
    p[j] = temp;
}

// A utility function to return square of distance between p1 and p2
int dist(const struct Point p1, const struct Point p2)
{
    return (p1.x - p2.x)*(p1.x - p2.x) + (p1.y - p2.y)*(p1.y - p2.y);
}

struct comparator
{
    struct Point p;
    bool operator() (const struct Point& p1, const struct Point& p2)
    {
        int d = ccw(p, p1, p2);
        if (d == 0)
        {
            return (dist(p, p2) >= dist(p, p1));
        }
        return (d > 0 ? false: true);
    }
};

int find_first_point(std::vector<struct Point>& p)
{
    int r = 0;
    std::size_t sz = p.size();
    for (std::size_t i = 1; i < sz; i++)
    {
        if ( p[i].y < p[r].y
          || (p[i].y == p[r].y && p[i].x < p[r].x))
        {
            r = i;
        }
    }
    return r;
}

// A utility function to find next to top in a stack
struct Point nextToTop(std::stack<struct Point> &S)
{
    Point p = S.top();
    S.pop();
    Point res = S.top();
    S.push(p);
    return res;
}

double solve_1185(std::vector<struct Point>& p, int r)
{
    int idx = find_first_point(p);
    struct Point fp = p[idx];
    swap(p, 0, idx);
    struct comparator compare;
    compare.p = p[0];
    std::sort(p.begin() + 1, p.end(), compare);
    std::stack<struct Point> s;
    s.push(p[0]);
    s.push(p[1]);
    s.push(p[2]);
    std::size_t sz = p.size();
    for (std::size_t i = 3; i < sz; i++)
    {
        while (ccw(nextToTop(s), s.top(), p[i]) > 0)
            s.pop();
        s.push(p[i]);
    }
    double sum = 0;
    struct Point sfp = s.top();
    fp = s.top();
    s.pop();
    while (!s.empty())
    {
        sum += sqrt(dist(fp, s.top()));
        fp = s.top();
        s.pop();
    }
    sum += sqrt(dist(fp, sfp));
    sum += 2 * 3.1415926535 * r;

    return floor(sum);
}

#ifndef TESTS
int main()
{
    int n, r;
    std::vector<struct Point> input;
    scanf("%d %d", &n, &r);
    for (int i = 0; i < n; i++)
    {
        struct Point p;
        scanf("%d %d", &p.x, &p.y);
        input.push_back(p);
    }
    int64_t result = solve_1185(input, r);
    printf("%lld\n", result);
    return 0;
}
#endif