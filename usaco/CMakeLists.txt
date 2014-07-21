cmake_minimum_required (VERSION 2.8)

SET (PROJ_NAME "usaco")
PROJECT (${PROJ_NAME})

if (TESTS)
    add_module_dependency(${PROJ_NAME} "gtest-entrypoint" "dev")
endif ()
add_definitions("-DTESTS")
make_library(${PROJ_NAME})
link_module_dependencies(${PROJ_NAME})
