#!/bin/bash

PRG=/Users/cristi/Library/Caches/clion10/cmake/generated/98e9277f/98e9277f/Debug/testbed/testbed_tests

let TIME=0
for i in {1..100}; do
    T=`$PRG --gtest_filter=FSortTestClass.TestPerformance4 | grep "==========" | grep "ms total" | sed 's/.*(\([0-9]*\) .*/\1/g'`
    let "TIME = TIME + T"
done

let "TIME = TIME / 100"
echo "FSort Time: $TIME ms"

let TIME=0
for i in {1..100}; do
    T=`$PRG --gtest_filter=FSortTestClass.TestPerformance4_comp | grep "==========" | grep "ms total" | sed 's/.*(\([0-9]*\) .*/\1/g'`
    let "TIME = TIME + T"
done

let "TIME = TIME / 100"
echo "C++ Time: $TIME ms"
