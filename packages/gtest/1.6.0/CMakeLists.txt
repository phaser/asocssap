cmake_minimum_required (VERSION 2.8)

SET (PROJ_NAME "gtest")
PROJECT (${PROJ_NAME})
mark_lib_for_reuse(${PROJ_NAME})

make_library(${PROJ_NAME})

if (MSVC)
    add_definitions(/D _VARIADIC_MAX=10)
endif ()
