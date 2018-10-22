#include <cstdio>
#include <vector>
#include <algorithm>
#include <iterator>

typedef std::vector<int>::iterator itr;
int count_contiguous_subarray_with_some_ge_k(itr begin, itr end, int k)
{
	std::vector<int> prefix_sum(begin, end);
	for (itr it = prefix_sum.begin() + 1; it != prefix_sum.end(); *it += *(it - 1), it++);
	for (itr it = prefix_sum.begin(); it != prefix_sum.end(); it++)
	{
		printf("%d ", *it);
	}
	printf("\n");
	int count = 0;
	for (itr it = prefix_sum.begin(); it != prefix_sum.end(); it++)
	{
		for (itr jt = it + 1; jt != prefix_sum.end(); jt++)
		{
			if (*jt - *it >= k) count++;
		}
	}
	return count;
}

namespace my_algorithms
{
typedef std::vector<int>::iterator itr;

/*
 * Given two sorted arrays merge them in the final array
 */
static uint32_t merge(itr left_begin
                , itr left_end
				, itr right_begin
				, itr right_end
				, int k)
{
	uint32_t count = 0;
	itr left = left_begin;
	itr right = right_begin;
	while (left != left_end && right != right_end)
	{
		if (*right - *left >= k)
		{
			count += left - left_begin + 1;
			left++;
		} else {
			right++;
		}
	}
	while (left != left_end)
	{
		if (*(right_end - 1) - *left >= k) count++;
		left++;
	}
	while (right != right_end)
	{
		if (*right - *(left_end - 1) >= k) count++;
		right++;
	}
	return count;
}

static uint32_t recursive_merge_sort(itr arr_begin, itr arr_end, int k)
{
	size_t dist = std::distance(arr_begin, arr_end);
	if (dist == 1)
	{
		return (*arr_begin >= k ? 1 : 0);
	}
	size_t dist2 = dist / 2;
	itr lbegin = arr_begin;
	itr lend = arr_begin + dist2;
	itr rbegin = arr_begin + dist2;
	itr rend = arr_end;
	uint32_t lc = recursive_merge_sort(lbegin, lend, k);
	uint32_t rc = recursive_merge_sort(rbegin, rend, k);
	uint32_t mc = merge(lbegin, lend, rbegin, rend, k);
	return lc + rc + mc;
}

static uint32_t merge_sort(itr arr_begin, itr arr_end, int k)
{
	std::vector<int> aux_arr(arr_begin, arr_end);
	for (itr it = aux_arr.begin() + 1; it != aux_arr.end(); *it += *(it - 1), it++);
	return recursive_merge_sort(aux_arr.begin(), aux_arr.end(), k);
}

}

int main(int argc, char** argv)
{
	std::vector<int> arr{1, 2, 3, -2, 10, 11, -10, 3, 2, 1};
	int k = 10;
	printf("%d %d\n"
	, count_contiguous_subarray_with_some_ge_k(arr.begin(), arr.end(), k)
	, my_algorithms::merge_sort(arr.begin(), arr.end(), k));
	return 0;
}
