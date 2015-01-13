#include <stdio.h>
#include <string.h>
#include <vector>

struct Position
{
    Position() : x(0), y(0) {}
    int x, y;
    int dist(Position& v)
    {
        Position result;
        result.x = v.x - x;
        result.y = v.y - y;
        if (result.x < 0) result.x *= -1;
        if (result.y < 0) result.y *= -1;
        return result.x + result.y;
    }
};

typedef struct Position Player;
typedef struct Position Turret;
typedef struct Position Goal;

struct Maze
{
    Maze(int m, int n) : m(m), n(n)
    {
        mz_ = new char*[m];
        for (int i = 0; i < m; i++)
        {
            char *line = new char[n+1];
            line[n] = '\0';
            mz_[i] = line;
        }
    }

    void printMaze()
    {
        for (int i = 0; i < m; i++)
        {
            printf("%s\n", mz_[i]);
        }
    }

    void solveMaze();
    bool getNextViableDirection(Position& dir);
    bool simulate();
    void rotate(Turret& t, bool ccw)
    {
        switch (mz_[t.x][t.y])
        {
            case '<': mz_[t.x][t.y] = (ccw ? 'v':'^'); break;
            case '^': mz_[t.x][t.y] = (ccw ? '<':'>'); break;
            case '>': mz_[t.x][t.y] = (ccw ? '^':'v'); break;
            case 'v': mz_[t.x][t.y] = (ccw ? '>':'<'); break;
        }
    }
    bool hitsPlayer(Turret& t);
    void initMaze();
    char **mz_;
    int m, n;
    Player player;
    Goal goal;
    std::vector<Turret> turrets;
    int nom;
};

void Maze::initMaze()
{
    for (int k = 0; k < m; k++)
    {
        for (int i = 0; i < n; i++)
        {
            switch (mz_[k][i])
            {
                case 'S':
                {
                    player.x = k;
                    player.y = i;
                    mz_[k][i] = '.';
                    break;
                }
                case 'G':
                {
                    goal.x = k;
                    goal.y = i;
                    mz_[k][i] = '.';
                    break;
                }
                case '<':
                case '^':
                case '>':
                case 'v':
                {
                    Turret turret;
                    turret.x = k;
                    turret.y = i;
                    turrets.push_back(turret);
                }
            }
        }
    }
}

void Maze::solveMaze()
{
    nom = 0;
    Position dir;
    bool directionAvailable = getNextViableDirection(dir);
    while (directionAvailable)
    {
        mz_[dir.x][dir.y] = 'P';
        bool result = simulate();
        if (result)
        {
            ++nom;
            if (dir.x == goal.x && dir.y == goal.y)
            {
                return;
            } else
            {
                player = dir;
            }
        } else
        {
            nom--;
        }
        printMaze();
        directionAvailable = getNextViableDirection(dir);
    }
    nom = 0;
}

bool Maze::getNextViableDirection(Position& dir)
{
    bool hasViableDirection = false;
    std::vector<Position> possible_moves;
    Position mp;
    for (int i = -1; i < 2; i++)
    for (int j = -1; j < 2; j++)
    {
        if (i == j || (i == -j)) continue;
        mp = player;
        mp.x += i; mp.y += j;
        if (mp.x >= 0 && mp.x < m && mp.y >= 0 && mp.y < n
                && mz_[mp.x][mp.y] == '.')
        {
            possible_moves.push_back(mp);
        }
    }
    if (possible_moves.size() <= 0)
    {
        return false;
    }
    Position min = possible_moves[0];
    size_t sz = possible_moves.size();
    for (int i = 1; i < sz; i++)
    {
        int dstmin = min.dist(goal);
        int cdst = possible_moves[i].dist(goal);
        if (cdst < dstmin)
        {
            min = possible_moves[i];
        }
    }
    dir = min;
    return true;
}

bool Maze::simulate()
{
    size_t sz = turrets.size();
    for (int i = 0; i < sz; i++)
    {
        rotate(turrets[i], false);
    }
    for (int i = 0; i < sz; i++)
    {
        if (hitsPlayer(turrets[i])) {
            for (int k = 0; k < sz; k++)
            {
                rotate(turrets[k], true);
            }
            return false;
        }
    }
    return true;
}

bool Maze::hitsPlayer(Turret& t)
{
    Position dir = t;

    switch (mz_[t.x][t.y])
    {
        case '<': dir.x -= 1; break;
        case '^': dir.y -= 1; break;
        case '>': dir.x += 1; break;
        case 'v': dir.y += 1; break;
    }

    while (dir.x >= 0 && dir.x < m && dir.y >= 0 && dir.y < n)
    {
        if (mz_[dir.x][dir.y] == 'P')
        {
            return true;
        } else
        if (mz_[dir.x][dir.y] == '#'
                || mz_[dir.x][dir.y] == '<'
                || mz_[dir.x][dir.y] == '^'
                || mz_[dir.x][dir.y] == '>'
                || mz_[dir.x][dir.y] == 'v')
        {
            return false;
        }

        switch (mz_[t.x][t.y])
        {
            case '<': dir.x -= 1; break;
            case '^': dir.y -= 1; break;
            case '>': dir.x += 1; break;
            case 'v': dir.y += 1; break;
        }
    }
    return false;
}

#ifdef TESTS
int main()
{
    int t;
    int m, n;
    scanf("%d", &t);
    for (int i = 0; i < t; i++)
    {
        scanf("%d %d", &m, &n);
        Maze maze(m, n);
        char line[n+1];
        for (int k = 0; k < m; k++)
        {
            scanf("%s", line);
            strcpy(maze.mz_[k], line);
        }
        maze.initMaze();
        maze.solveMaze();
        if (maze.nom == 0)
        {
            printf("Case #%d: impossible\n", i+1);
        } else
        {
            printf("Case #%d: %d\n", i+1, maze.nom - 1);
        }
        maze.printMaze();
    }
    return 0;
}
#endif

