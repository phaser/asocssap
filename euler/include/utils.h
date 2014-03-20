#pragma once
#include <iterator>

class Iterator : public std::iterator<std::bidirectional_iterator_tag, uint64_t> 
{
    uint64_t val;
public:
    Iterator(uint64_t i = 0) : val(i) {}
    bool operator==(Iterator const& rhs) const
    {
        return (val == rhs.val);
    }
    bool operator!=(Iterator const& rhs) const
    {
        return (val != rhs.val);
    }
    Iterator& operator++()
    {
        ++val;
        return *this;
    }
    Iterator& operator++(int)
    {
        Iterator tmp(*this);
        ++val;
        return tmp;
    }
    Iterator& operator--()
    {
        --val;
        return *this;
    }
    Iterator& operator--(int)
    {
        Iterator tmp(*this);
        --val;
        return tmp;
    }
    uint64_t operator* () const
    {
        return val;
    }
};

