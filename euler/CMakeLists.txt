cmake_minimum_required (VERSION 2.8)

SET (PROJ_NAME "euler")
PROJECT (${PROJ_NAME})

if (TESTS)
    add_module_dependency(${PROJ_NAME} "gtest-entry-point" "dev")
endif ()
make_library(${PROJ_NAME})

