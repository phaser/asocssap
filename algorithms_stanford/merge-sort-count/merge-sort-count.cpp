#include <cstdio>
#include <vector>
#include <algorithm>
#include <iterator>

namespace my_algorithms
{
typedef std::vector<uint32_t>::iterator itr;

/*
 * Given two sorted arrays merge them in the final array
 */
static uint64_t merge(itr left_begin
                , itr left_end
				, itr right_begin
				, itr right_end
				, const itr farray)
{
	uint64_t count = 0;
	itr left = left_begin;
	itr right = right_begin;
	itr fv = farray;
	auto ld = std::distance(left, left_end);
	auto rd = std::distance(right_begin, right);
	while (left != left_end && right != right_end)
	{
		if (*left < *right)
		{
			*fv = *left;
			left++;
			count += rd;
		} else {
			*fv = *right;
			right++;
		}
		fv++;
		ld = std::distance(left, left_end);
		rd = std::distance(right_begin, right);
	}
	while (left != left_end)
	{
		*fv = *left;
		left++; fv++;
		count += rd;
		ld = std::distance(left, left_end);
	}
	while (right != right_end)
	{
		*fv = *right;
		right++; fv++;
	}
	return count;
}

static uint64_t recursive_merge_sort(itr arr_begin, itr arr_end, itr farray)
{
	size_t dist = std::distance(arr_begin, arr_end);
	if (dist == 1)
	{
		return 0;
	}
	size_t dist2 = dist / 2;
	itr lbegin = arr_begin;
	itr lend = arr_begin + dist2;
	itr rbegin = arr_begin + dist2;
	itr rend = arr_end;
	uint64_t lc = recursive_merge_sort(lbegin, lend, farray);
	uint64_t rc = recursive_merge_sort(rbegin, rend, farray + dist2);
	uint64_t mc = merge(lbegin, lend, rbegin, rend, farray);
	std::copy(farray, farray+dist, arr_begin);
	return lc + rc + mc;
}

static uint64_t merge_sort(itr arr_begin, itr arr_end)
{
	std::vector<uint32_t> aux_arr(arr_begin, arr_end);
	return recursive_merge_sort(arr_begin, arr_end, aux_arr.begin());
}

}

/* 22547530 	2018-10-20 22:19:28 	phaserescu	Inversion Count	accepted edit    ideone it 	0.06 	16M 	CPP14
 * SPOJ
 */
int main(int argc, char** argv)
{
	uint32_t t, n, num;
	scanf("%u", &t);
	for (auto i = 0; i < t; i++)
	{
		scanf("%u", &n);
		std::vector<uint32_t> arr;
		arr.reserve(n);
		for (auto j = 0; j < n; j++)
		{
			scanf("%u", &num); arr.push_back(num);
		}
		auto count = my_algorithms::merge_sort(arr.begin(), arr.end());
		printf("%llu\n", count);
	}
	return 0;
}
