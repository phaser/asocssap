#include <cstdio>
#include <vector>
#include <algorithm>
#include <iterator>

namespace my_algorithms
{
typedef std::vector<int>::iterator itr;

/*
 * Given two sorted arrays merge them in the final array
 */
static void merge(itr left_begin
                , itr left_end
				, itr right_begin
				, itr right_end
				, itr farray)
{

}
}

int main(void)
{
	std::vector<int> arr1{5, 1, 3, 4, 5};
	std::vector<int> arr2{7, 0, -1, 13};
	int final_length = arr1.size() + arr2.size();
	std::vector<int> arr3(final_length, 0);
	std::sort(arr1.begin(), arr1.end());
	std::sort(arr2.begin(), arr2.end());
	merge(arr1.begin(), arr1.end(), arr2.begin(), arr2.end(), arr3.begin());
	return 0;
}
