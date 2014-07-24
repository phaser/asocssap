#include <cstdio>
#include <string>
#include <vector>
#include <sstream>

#define NOT_STARTED 0
#define NUMBER 1
#define SPACE 2
#define ELIPS 3
#define COMMA 4

bool isNumber (const char c)
{
    if (c >= '0' && c <= '9')
        return true;
    return false;
}

int detectType (const char c)
{
    if (isNumber(c))
    {
        return NUMBER;
    } else
    if (c == ' ')
    {
        return SPACE;
    } else
    if (c == '.')
    {
        return ELIPS;
    } else
    if (c == ',')
    {
        return COMMA;
    }
    return NOT_STARTED;
}

std::string solve_81b(const std::string str)
{
    size_t sz = str.size();
    std::ostringstream result;
    std::string elem;
    std::vector<std::string> parsed_elems;
    std::vector<int> parsed_elems_types;
    int type = NOT_STARTED;
    for (size_t i = 0; i < sz; i++)
    {
        if (type == NOT_STARTED)
        {
            type = detectType(str[i]);
        }
        
        if (type == NUMBER)
        {
            if (isNumber(str[i]))
            {
                elem.push_back(str[i]);
                continue;
            } else
            {
                parsed_elems.push_back(elem);
                parsed_elems_types.push_back(type);
                type = NOT_STARTED;
                elem.clear();
                i--;
                continue;
            }
        }
        
        if (type == SPACE)
        {
            if (str[i] == ' ')
            {
                elem.push_back(str[i]);
                continue;
            } else
            {
                parsed_elems.push_back(elem);
                parsed_elems_types.push_back(type);
                type = NOT_STARTED;
                elem.clear();
                i--;
                continue;
            }
        }
    
        if (type == ELIPS)
        {
            if (str[i] == '.')
            {
                if (elem.size() == 3)
                {
                    parsed_elems.push_back(elem);
                    parsed_elems_types.push_back(type);
                    elem.clear();
                }
                elem.push_back(str[i]);
                continue;
            } else
            {
                parsed_elems.push_back(elem);
                parsed_elems_types.push_back(type);
                type = NOT_STARTED;
                elem.clear();
                i--;
                continue;
            }
        }
        if (type == COMMA)
        {
            parsed_elems.push_back(",");
            parsed_elems_types.push_back(type);
            elem.clear();
            type = NOT_STARTED;
            continue;
        }
    }
    if (type != NOT_STARTED)
    {
        parsed_elems.push_back(elem);
        parsed_elems_types.push_back(type);
        elem.clear();
    }
    
    sz = parsed_elems.size();
    for (size_t i = 0; i < sz; i++)
    {
        if (parsed_elems_types[i] == SPACE)
        {
            parsed_elems_types.erase(parsed_elems_types.begin() + i);
            parsed_elems.erase(parsed_elems.begin() + i);
            i--; sz--;
        }
    }
    for (size_t i = 0; i < sz; i++)
    {
        if (parsed_elems_types[i] == COMMA)
        {
            result << parsed_elems[i];
            if (i < (sz - 1))
                result << " ";
        } else
        if (parsed_elems_types[i] == ELIPS)
        {
            if (i > 0 && parsed_elems_types[i-1] != COMMA)
                result << " ";
            result << parsed_elems[i];
        } else
        {
            result << parsed_elems[i];
            if (i < (sz - 1) && parsed_elems_types[i+1] == NUMBER)
                result << " ";
        }
    }
    return result.str();
}

#ifndef TESTS
int main()
{
    char input[256];
    scanf("%[^\n]", &input);
    printf("%s\n", solve_81b(input).c_str());
    return 0;
}
#endif
