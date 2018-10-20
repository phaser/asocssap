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
static void merge(itr left_begin
                , itr left_end
				, itr right_begin
				, itr right_end
				, const itr farray)
{
	itr left = left_begin;
	itr right = right_begin;
	itr fv = farray;
	while (left != left_end && right != right_end)
	{
		if (*left < *right)
		{
			*fv = *left;
			left++;
		} else {
			*fv = *right;
			right++;
		}
		fv++;
	}
	while (left != left_end)
	{
		*fv = *left;
		left++; fv++;
	}
	while (right != right_end)
	{
		*fv = *right;
		right++; fv++;
	}
}

static void recursive_merge_sort(itr arr_begin, itr arr_end, itr farray)
{
	size_t dist = std::distance(arr_begin, arr_end);
	if (dist == 1)
	{
		return;
	}
	size_t dist2 = dist / 2;
	itr lbegin = arr_begin;
	itr lend = arr_begin + dist2;
	itr rbegin = arr_begin + dist2;
	itr rend = arr_end;
	recursive_merge_sort(lbegin, lend, farray);
	recursive_merge_sort(rbegin, rend, farray + dist2);
	merge(lbegin, lend, rbegin, rend, farray);
	std::copy(farray, farray+dist, arr_begin);
}

static void merge_sort(itr arr_begin, itr arr_end)
{
	std::vector<uint32_t> aux_arr(arr_begin, arr_end);
	recursive_merge_sort(arr_begin, arr_end, aux_arr.begin());
}

}

/* 44604419 	2018-10-20 19:03:45 	phaserescu 	1041A - Heist 	GNU C++17 	Accepted 	31 ms 	300 KB
 */
#if 0
int main(int argc, char** argv)
{
	std::vector<uint32_t> keyboards;
	uint32_t n, k;
	scanf ("%u", &n);
	keyboards.reserve(n);
	for (size_t i = 0; i < n; i++)
	{
		scanf("%u", &k); keyboards.push_back(k);
	}
	my_algorithms::merge_sort(keyboards.begin(), keyboards.end());
	uint32_t answer = 0;
	for (size_t i = 1; i < n; i++)
	{
		answer += (keyboards[i] - keyboards[i-1] - 1);
	}
	printf ("%u\n", answer);
	return 0;
}
#endif

int main(int argc, char** argv)
{
	return 0;
}
