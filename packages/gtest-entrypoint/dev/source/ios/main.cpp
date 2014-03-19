// Copyright (C) 2013 Cristian Bidea
#include <gtest/gtest.h>
#include <main.h>

void runtests()
{
    int argc = 1;
    char* argv = "Testing";
    ::testing::InitGoogleTest(&argc, &argv);
    exit(RUN_ALL_TESTS());
}
